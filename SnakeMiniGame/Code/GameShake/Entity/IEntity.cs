using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Snakes
{
    public interface IEntity
    {
        public String name { get; }
        public Vector2Int CurrentPosition { get; }
        public Vector2Int LastPosition { get; }

        public char[,] Sprite { get; }
        public ConsoleColor Color { get; }
        public ConsoleColor BackgroundColor { get; }
    }
}
