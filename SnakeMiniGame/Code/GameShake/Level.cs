
using SnakeMiniGame.Code.GameShake.Interfaces;

namespace SnakeMiniGame.Code.Game
{
    public class Level
    {
        public IEntity[,] map;

        private IEntity _baseWall;
        private IEntity _baseGround;

        public Level(int heightCells, int widthCells, IEntity baseWall, IEntity baseGround)
        {
            map = new IEntity[heightCells, widthCells];

            _baseWall = baseWall;
            _baseGround = baseGround;
        }



        public void Generation()
        {
            GenerationLevel(_baseWall, _baseGround);
        }

        public IEntity[,] GetMap()
        {
            return map;
        }

        private void GenerationLevel(IEntity wall, IEntity floor)
        {
            for (int i = 0; i < map.GetLength(0); i++) 
            {
                if (i == 0 || i == map.GetLength(0) - 1)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        map[i, j] = wall;
                    }
                }
                else 
                {
                    for(int j = 0;j < map.GetLength(1); j++)
                    {
                        if(j == 0 || j == map.GetLength(1) - 1)
                        {
                            map[i, j] = wall;
                        }else
                        {
                            map[i, j] = floor;
                        }
                    }
                }

            }
        }

    }
}
