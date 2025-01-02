using SnakeMiniGame.Code.GameShake.Cells;
using SnakeMiniGame.Code.GameShake.Input;

namespace SnakeMiniGame.Code.GameShake.Levels
{
    public class Level : BaseLevel
    {
        public Level(string name, int heightCells, int widthCells, ICell baseWall, ICell baseGround, InputHandler input, int winScore) : base(name, heightCells, widthCells, baseWall, baseGround, input, winScore)
        {
        }

    }
}
