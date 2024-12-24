
using SnakeMiniGame.Code.Game;
using SnakeMiniGame.Code.GameShake.Cells;
using SnakeMiniGame.Code.GameShake.Utilits;
using System.ComponentModel.DataAnnotations;


namespace SnakeMiniGame.Code.GameShake
{
    public class Game
    {
        private InputHandler _inputHandler;
        private Renderer _render;
        private Level _level1;

        private BaseWall _wall = new BaseWall(Vector2Int.zero, new char[,] { { '#', '#', '#' }, { '#', '#', '#' }, { '#', '#', '#' } }, false, false, ConsoleColor.Red);

        private BaseFloor _floor = new(Vector2Int.zero, new char[,] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } }, false, true, ConsoleColor.DarkGray);

        public Game()
        {
            _inputHandler = new InputHandler();
            _render = new Renderer();
            _level1 = new Level(8,25,_wall, _floor);
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
                UpdateLogic();
                Render();

                var nextTime = startTime + TimeSpan.FromSeconds(deltaTime);
                var endTime = DateTime.Now;
                if (nextTime > endTime) 
                {
                    Thread.Sleep((int)(nextTime - endTime).TotalMilliseconds);
                }

            }

            Console.ReadKey();
        }

        private void UpdateLogic()
        {

        }

        private void Render()
        {
            _render.Debug(_inputHandler);
            _render.Render(_level1.GetMap());

        }

        private void Input() 
        {
            _inputHandler.GetDirection();
        }

        private void CloseGame()
        {
            _inputHandler.CloseGame -= CloseGame;
        }
    }
}
