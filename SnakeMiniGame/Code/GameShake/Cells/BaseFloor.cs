
using SnakeMiniGame.Code.GameShake.Interfaces;
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Cells
{
    public class BaseFloor : IEntity
    {
        public BaseFloor(Vector2Int position, char[,] sprite, bool isInteraction, bool isPassable, ConsoleColor color) :
            base(position, sprite, isInteraction, isPassable, color)
        {
        }

    }
}
