
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Interfaces
{
    public abstract class ICells
    {
        public Vector2Int position;
        public char[,] sprite;

        public bool isWall;

        public ConsoleColor colorBackground;
        public ConsoleColor color;

        public ICells(Vector2Int position, char[,] sprite, bool isWall, ConsoleColor color, ConsoleColor colorBackground)
        {
            this.position = position;
            this.sprite = sprite;
            this.isWall = isWall;
            this.color = color;
            this.colorBackground = colorBackground;
        }
    }
}
