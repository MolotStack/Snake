using SnakeMiniGame.Code.GameShake.Interfaces;
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.Game
{
    public class Snake : IEntity
    {
        public Snake(Vector2Int position, char[,] spritem, bool isInteraction, bool isPassable, ConsoleColor color) : base(position, spritem, isInteraction, isPassable, color)
        {

        }
    }


}
