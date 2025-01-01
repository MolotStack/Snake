using SnakeMiniGame.Code.GameShake.Input;
using SnakeMiniGame.Code.GameShake.Levels;
using SnakeMiniGame.Code.GameShake.Utilits;
using SnakeMiniGame.Code.GameShake.Cells;
using SnakeMiniGame.Code.GameShake.Render;

namespace SnakeMiniGame.Code.GameShake
{
    public class Game
    {
        private InputHandler _inputHandler;
        private Renderer _render;
        private Level _level1;

        private Cell _wall = new Cell(Vector2Int.zero, new char[,] { { '#' } }, true,ConsoleColor.Blue, ConsoleColor.Black);

        private Cell _floor = new Cell(Vector2Int.zero, new char[,] { { ' ' } }, false, ConsoleColor.White, ConsoleColor.Black);

        public Game()
        {
            _inputHandler = new InputHandler();
            _render = new Renderer();
            _level1 = new Level(25,100,_wall, _floor, _inputHandler);
        }

        public void Start()
        {
            _inputHandler.CloseGame += CloseGame;

            _level1.Generation();


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

                //var nextTime = startTime + TimeSpan.FromSeconds(deltaTime);
                //var endTime = DateTime.Now;
                //if (nextTime > endTime) 
                //{
                    Thread.Sleep(33);
                //}

            }
        }

        private void UpdateLogic(float deltaTime)
        {
            _level1.Update(deltaTime);
        }

        private void Render()
        {
            _render.Debug(_inputHandler);
            _render.Score(_level1.Score);
            _render.Render(_level1, 1);

        }

        private void Input() 
        {
            _inputHandler.GetDirection();
        }

        private void CloseGame()
        {
            _inputHandler.CloseGame -= CloseGame;
            Environment.Exit(0);
        }
    }
}
