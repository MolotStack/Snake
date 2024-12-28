using SnakeMiniGame.Code.Game;
using SnakeMiniGame.Code.GameShake.Interfaces;
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Snake
{
    public class Snake : BaseComponent, IEntity
    {
        public Vector2Int CurrentPosition => _currentPosition;
        public Vector2Int LastPosition => _lastPosition;

        public ConsoleColor Color => _color;
        public ConsoleColor BackgroundColor => _backgroundColor;
        public char[,] Sprite => _sprite;


        private Tail tail;
        private InputHandler _input;
        private Level _currentLevel;

        private Vector2Int _currentPosition;
        private Vector2Int _lastPosition;

        public ConsoleColor _color;
        public ConsoleColor _backgroundColor;

        public char[,] _sprite;

        private int _levelTail;

        private float _currentSpeedTime;

        private float _timeMove = 0.0f;

        public Snake(Level currentLevel,InputHandler input, Vector2Int currentPosition, char[,] sprite, ConsoleColor color, ConsoleColor backgroundColor)
        {
            _input = input;

            _currentLevel = currentLevel;
            _currentPosition = currentPosition;
            _lastPosition = currentPosition;

            _sprite = sprite;
            _color = color;
            _backgroundColor = backgroundColor;
            _currentSpeedTime = 0.35f;
        }

        public override void Update(float deltaTime)
        {
            Movement(deltaTime);
        }

        private void Movement(float deltaTime)
        {
            _timeMove += deltaTime;
            if (_timeMove >= _currentSpeedTime)
            {
                Step();
                _timeMove = 0f;
            }
        }

        private void Step()
        {
            if (!_currentLevel.Map[_currentPosition.y + _input.Direction.y, _currentPosition.x + _input.Direction.x].isWall)
            {
                _lastPosition = _currentPosition;
                _currentPosition += _input.Direction;
            }
        }
    }
}
