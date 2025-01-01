﻿using SnakeMiniGame.Code.GameShake.Cells;
using SnakeMiniGame.Code.GameShake.Entity;
using SnakeMiniGame.Code.GameShake.Input;
using SnakeMiniGame.Code.GameShake.Snakes;
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Levels
{
    public class Level : ILevel
    {
        public int Score => _score;
        public ICell[,] Map => _map;
        public Snake Snake => _snake;
        public Apple Apple => _apple;

        private int _score;
        private ICell[,] _map;
        private Snake _snake;
        private Apple _apple;

        private ICell _baseWall;
        private ICell _baseGround;

        private InputHandler _inputHandler;

        public Level(int heightCells, int widthCells, ICell baseWall, ICell baseGround, InputHandler input)
        {
            _map = new ICell[heightCells, widthCells];

            _baseWall = baseWall;
            _baseGround = baseGround;

            _inputHandler = input;

            _score = 0;
        }


        public void Update(float deltaTime)
        {
            _snake.Update(deltaTime);

            if (_apple.GetState())
            {
                _map[_apple.CurrentPosition.y, _apple.CurrentPosition.x].ClearEntity();
                GenerationApple();
            }
        }

        public void Generation()
        {
            GenerationLevel();
            GenerationApple();
        }

        public ICell[,] GetMap()
        {
            return _map;
        }

        public void EatApple()
        {
            _score += 10;
            _apple.SetState(true);
        }


        private void GenerationLevel()
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                if (i == 0 || i == _map.GetLength(0) - 1)
                {
                    for (int j = 0; j < _map.GetLength(1); j++)
                    {
                        SpawnEntity(i, j, _baseWall);
                    }
                }
                else
                {
                    for (int j = 0; j < _map.GetLength(1); j++)
                    {
                        if (j == 0 || j == _map.GetLength(1) - 1)
                        {
                            SpawnEntity(i, j, _baseWall);
                        }
                        else
                        {
                            SpawnEntity(i, j, _baseGround);
                        }
                    }
                }
            }

            SpawnSnake(new Vector2Int(_map.GetLength(1) / 2, _map.GetLength(0) / 2));
        }

        private void GenerationApple()
        {
            Random random = new Random();
            Vector2Int position = new Vector2Int(1, 1);

            do
            {
                position = new Vector2Int(random.Next(1, _map.GetLength(1) - 2), random.Next(1, _map.GetLength(0) - 2));
            }
            while (_map[position.y, position.x].isOccupied);

            SpawnApple(position);
        }

        private void SpawnEntity(int i, int j, ICell cells)
        {
            _map[i, j] = new Cell(new Vector2Int(j, i), cells.sprite, cells.isOccupied, cells.color, cells.colorBackground);
        }

        private void SpawnSnake(Vector2Int position)
        {
            _snake = new Snake(this, _inputHandler, position, new char[,] { { '■' } }, ConsoleColor.Green, ConsoleColor.Black);
            _map[position.y, position.x].AddEntity(_snake);
        }

        private void SpawnApple(Vector2Int position)
        {
            if (_apple == null)
            {
                _apple = new Apple(position, new char[,] { { '0' } }, ConsoleColor.Red, ConsoleColor.Black);
            }
            else
            {
                _apple.SetPosition(position);
                _apple.SetState(false);
            }

            _map[position.y, position.x].AddEntity(_apple);
        }

    }
}