
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Interfaces
{
    public abstract class IEntity
    {
        public Vector2Int position;
        public char[,] sprite;
        public bool isInteraction;
        public bool isPassable;

        public ConsoleColor color;

        public IEntity(Vector2Int position, char[,] sprite, bool isInteraction, bool isPassable, ConsoleColor color)
        {
            this.position = position;
            this.sprite = sprite;
            this.isInteraction = isInteraction;
            this.isPassable = isPassable;
            this.color = color;
        }
    }
}
