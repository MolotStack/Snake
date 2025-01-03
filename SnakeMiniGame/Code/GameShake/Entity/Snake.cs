﻿using SnakeMiniGame.Code.GameShake.Input;
using SnakeMiniGame.Code.GameShake.Levels;
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Snakes
{
    public class Snake : BaseComponent, IEntity
    {
        public event Action<bool> OnChangedStateDie;

        public string name => "Snake";

        public Tail Tail => _tail;
        public Vector2Int CurrentPosition => _currentPosition;
        public Vector2Int LastPosition => _lastPosition;

        public ConsoleColor Color => _color;
        public ConsoleColor BackgroundColor => _backgroundColor;
        public char[,] Sprite => _sprite;


        private Tail _tail;
        private InputHandler _input;
        private BaseLevel _currentLevel;

        private Vector2Int _currentPosition;
        private Vector2Int _lastPosition;

        public ConsoleColor _color;
        public ConsoleColor _backgroundColor;

        public char[,] _sprite;

        private float _modifierSpeed;

        private float _currentSpeedTime;

        private float _timeMove = 0.0f;

        public Snake(BaseLevel currentLevel,InputHandler input, Vector2Int currentPosition, char[,] sprite, ConsoleColor color, ConsoleColor backgroundColor)
        {
            _input = input;

            _currentLevel = currentLevel;
            _currentPosition = currentPosition;
            _lastPosition = currentPosition;

            _sprite = sprite;
            _color = color;
            _backgroundColor = backgroundColor;
            _currentSpeedTime = 0.25f;
            _modifierSpeed = 1.0f;
        }

        public override void Update(float deltaTime)
        {
            Movement(deltaTime);
        }

        private void Movement(float deltaTime)
        {
            _timeMove += deltaTime;
            if (_timeMove >= _currentSpeedTime * _modifierSpeed)
            {
                if (!_currentLevel.Map[_currentPosition.y + _input.Direction.y, _currentPosition.x + _input.Direction.x].isOccupied)
                {
                    Step();
                }
                else
                {
                    if (_currentLevel.Map[_currentPosition.y + _input.Direction.y, _currentPosition.x + _input.Direction.x].currentEntity != null)
                    {
                        switch (_currentLevel.Map[_currentPosition.y + _input.Direction.y, _currentPosition.x + _input.Direction.x].currentEntity.name)
                        {
                            case "Snake":
                                Die();
                                break;
                            case "Apple":
                                Step();
                                LevelUp();
                                break;
                            default:
                                Die();
                                break;
                        }
                    }
                    else 
                    {
                        Die();
                    }
                }
                    _timeMove = 0f;
            }
        }

        private void Step()
        {
            _lastPosition = _currentPosition;
            _currentLevel.Map[_lastPosition.y, _lastPosition.x].ClearEntity();

            _currentPosition += _input.Direction;
            _currentLevel.Map[_currentPosition.y, _currentPosition.x].AddEntity(this);

            if (_tail != null)
            {
                _tail.SetPosition(_lastPosition, _currentLevel);
            }
        }

        private void LevelUp()
        {
            _currentLevel.EatApple();

            if (_modifierSpeed > 0.1f)
            {
                _modifierSpeed -= 0.05f;
            }

            Growing(ref _tail);
        }

        private void Die()
        {
            _currentSpeedTime = 100f;
            OnChangedStateDie?.Invoke(true);
        }

        private void Growing(ref Tail tail)
        {
            if (tail == null)
            {
                tail = new Tail(_lastPosition, new char[,] { { '■' } }, ConsoleColor.DarkGray, ConsoleColor.Black);
                _currentLevel.Map[_lastPosition.y, _lastPosition.x].AddEntity(tail);
            }
            else 
            {
                Growing(ref tail.tail);
            }
        }

        //private void MoveTail(Tail tail)
        //{
        //    if (tail.tail == null)
        //    {
        //        return;
        //    }

        //    tail.SetPosition(_lastPosition);


        //    MoveTail(tail.tail);
        //}
    }
}
