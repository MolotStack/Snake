
using SnakeMiniGame.Code.GameShake.Cells;
using SnakeMiniGame.Code.GameShake.Interfaces;
using SnakeMiniGame.Code.GameShake.Snake;
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.Game
{
    public class Level : ILevel
    {
        public ICells[,] Map => _map;
        public IEntity Snake => _snake;

        private ICells[,] _map;
        public Snake _snake;

        private ICells _baseWall;
        private ICells _baseGround;

        private InputHandler _inputHandler;

        public Level(int heightCells, int widthCells, ICells baseWall, ICells baseGround, InputHandler input)
        {
            _map = new ICells[heightCells, widthCells];

            _baseWall = baseWall;
            _baseGround = baseGround;

            _inputHandler = input;
        }


        public void Update(float deltaTime)
        {
            _snake.Update(deltaTime);
        }

        public void Generation()
        {
            GenerationLevel();
        }

        public ICells[,] GetMap()
        {
            return _map;
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
                    for(int j = 0;j < _map.GetLength(1); j++)
                    {
                        if(j == 0 || j == _map.GetLength(1) - 1)
                        {
                            SpawnEntity(i,j, _baseWall);
                        }else
                        {
                            SpawnEntity(i, j, _baseGround);
                        }
                    }
                }
            }

            SpawnSnake(new Vector2Int(_map.GetLength(1) / 2, _map.GetLength(0) / 2));
        }
        
        private void SpawnEntity(int i, int j, ICells cells)
        {
            _map[i, j] = new Cell(new Vector2Int(j,i), cells.sprite, cells.isWall, cells.color, cells.colorBackground );
        }

        private void SpawnSnake(Vector2Int position)
        {
            _snake = new Snake(this, _inputHandler, position, new char[,] { { '*' } }, ConsoleColor.Green, ConsoleColor.DarkGray);
        }
    }
}
