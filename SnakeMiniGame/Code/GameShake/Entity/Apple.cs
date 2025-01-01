using SnakeMiniGame.Code.GameShake.Snakes;
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Entity
{
    public class Apple : IEntity
    {
        public string name => "Apple";
        public Vector2Int CurrentPosition => _currentPosition;
        public Vector2Int LastPosition => _lastPosition;

        public ConsoleColor Color => _color;
        public ConsoleColor BackgroundColor => _backgroundColor;
        public char[,] Sprite => _sprite;


        private Vector2Int _currentPosition;
        private Vector2Int _lastPosition;

        private ConsoleColor _color;
        private ConsoleColor _backgroundColor;
        private char[,] _sprite;
        private bool _isEaten;

        public Apple( Vector2Int currentPosition, char[,] sprite, ConsoleColor color, ConsoleColor backgroundColor)
        {
            _currentPosition = currentPosition;
            _lastPosition = currentPosition;

            _sprite = sprite;
            _color = color;
            _backgroundColor = backgroundColor;
            _isEaten = false;
        }

        public bool GetState()
        {
            return _isEaten;
        }

        public void SetState(bool isEaten)
        {
            _isEaten = isEaten;
        }

        public void SetPosition(Vector2Int position)
        {
            _currentPosition = position;
        }
    }
}
