using SnakeMiniGame.Code.GameShake.Input;
using SnakeMiniGame.Code.GameShake.Levels;
using SnakeMiniGame.Code.GameShake.Utilits;
using SnakeMiniGame.Code.GameShake.Cells;
using SnakeMiniGame.Code.GameShake.Render;
using System;

namespace SnakeMiniGame.Code.GameShake
{
    public class Game
    {
        private InputHandler _inputHandler;
        private Renderer _render;

        private BaseLevel _level1;
        private BaseLevel _level2;
        private BaseLevel _level3;
        private BaseLevel _level4;

        private BaseLevel _currentLevel;
        private int _currentIndexLevel;
        private List<BaseLevel> _levels;

        private Cell _wall = new Cell(Vector2Int.zero, new char[,] { { '#' } }, true,ConsoleColor.Blue, ConsoleColor.Black);

        private Cell _floor = new Cell(Vector2Int.zero, new char[,] { { ' ' } }, false, ConsoleColor.White, ConsoleColor.Black);

        public Game()
        {
            _inputHandler = new InputHandler();
            _render = new Renderer();

            _levels = new List<BaseLevel>();

            _levels.Add(_level1 = new Level("Level 1",25,100,_wall, _floor, _inputHandler, 30));
            _levels.Add(_level2 = new Level("Level 2", 25, 100, _wall, _floor, _inputHandler, 50));
            _levels.Add(_level3 = new Level("Level 3", 25,100,_wall, _floor, _inputHandler, 100));
            _levels.Add(_level3 = new Level("Sandbox Level", 25, 100, _wall, _floor, _inputHandler, 0));
        }

        public void Start(int indexLevel)
        {
            _render.ClearRender();

            _inputHandler.SetDefaulDirection();

            _currentLevel = _levels[indexLevel];
            _currentIndexLevel = indexLevel;

            _render.RenderLoadScene(_currentLevel.Name, ConsoleColor.White);

            _inputHandler.CloseGame += CloseGame;

            _currentLevel.Generation();
            _currentLevel.Snake.OnChangedStateDie += OnChangedStateDie;
            _currentLevel.LevelWin += LevelWin;

            Thread.Sleep(1000);


            _render.ClearRender();
            GameLoop();
        }

        private void GameLoop()
        {
            var lastTime = DateTime.Now;
            while (true)
            {
                var startTime = DateTime.Now;
                float deltaTime = (float)(startTime - lastTime).TotalSeconds;

                lastTime = startTime;

                Input();
                UpdateLogic(deltaTime);
                Render();

                Thread.Sleep(33);
            }
        }

        private void UpdateLogic(float deltaTime)
        {
            _currentLevel.Update(deltaTime);
        }

        private void Render()
        {
            _render.Debug(_inputHandler);
            _render.Score(_currentLevel.CurrentScore, _currentLevel.WinScore);
            _render.Render(_currentLevel);

        }

        private void Input() 
        {
            _inputHandler.GetDirection();
        }

        private void LevelWin()
        {
            NextLevel();
        }

        private void OnChangedStateDie(bool value)
        {
            GameOver();
        }

        private void NextLevel()
        {
            _inputHandler.CloseGame -= CloseGame;
            _currentLevel.Snake.OnChangedStateDie -= OnChangedStateDie;

            if (_currentIndexLevel < 2)
            {
                _currentIndexLevel += 1;
                Start(_currentIndexLevel);
            }
            else
            {
                GameVictory();
            }

        }
        private void GameOver()
        {
            _render.RenderLoadScene("You Dead!", ConsoleColor.Red);
            Thread.Sleep(1000);
            Start(0);
        }

        private void GameVictory()
        {
            _render.RenderLoadScene("You Won!", ConsoleColor.Yellow);
            Thread.Sleep(1000);
            Start(3);
        }

        private void CloseGame()
        {
            _inputHandler.CloseGame -= CloseGame;
            _currentLevel.Snake.OnChangedStateDie -= OnChangedStateDie;
            Environment.Exit(0);
        }
    }
}
