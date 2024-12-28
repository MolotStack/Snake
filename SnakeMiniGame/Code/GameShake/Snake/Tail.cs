using SnakeMiniGame.Code.GameShake.Interfaces;
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Snake
{
    public class Tail : IEntity
    {
        public Vector2Int CurrentPosition => _currentPosition;
        public Vector2Int LastPosition => _currentPosition;

        public ConsoleColor Color => _color;
        public ConsoleColor BackgroundColor => _backgroundColor;

        public char[,] Sprite => _sprite;

        private Vector2Int _currentPosition;
        private Vector2Int _lastPosition;

        private ConsoleColor _color;
        private ConsoleColor _backgroundColor;

        private char[,] _sprite;

        public Tail tail;
        public Tail() 
        {
        
        }
    }
}
