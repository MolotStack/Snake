using SnakeMiniGame.Code.GameShake.Levels;
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Snakes
{
    public class Tail : IEntity
    {
        public string name => "Tail";
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

        public Tail tail;
        public Tail(Vector2Int currentPosition, char[,] sprite, ConsoleColor color, ConsoleColor backgroundColor) 
        {
            _currentPosition = currentPosition;

            _sprite = sprite;
            _color = color;
            _backgroundColor = backgroundColor;
        }

        public void SetPosition(Vector2Int position, Level currentLevel)
        {   
            _lastPosition = _currentPosition;
            _currentPosition = position;

            currentLevel.Map[_lastPosition.y, _lastPosition.x].ClearEntity();
            currentLevel.Map[_currentPosition.y, _currentPosition.x].AddEntity(this);

            if (tail == null)
            {
               return;
            }
            tail.SetPosition(_lastPosition, currentLevel);


        }
    }
}
