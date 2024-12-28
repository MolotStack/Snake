
using SnakeMiniGame.Code.GameShake.Interfaces;
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Cells
{
    public class Cell : ICells
    {
        public Cell(Vector2Int position, char[,] sprite, bool isWall,ConsoleColor color,  ConsoleColor colorBackground) :
            base(position, sprite, isWall,color, colorBackground)
        {
        }
    }
}
