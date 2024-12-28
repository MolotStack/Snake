
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code
{
    public class InputHandler : IInput
    {
        public Vector2Int Direction => _currentDirection;
        public Action CloseGame; 

        private Vector2Int _currentDirection = Vector2Int.left;

        public void GetDirection()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: _currentDirection = Vector2Int.down; break;
                    case ConsoleKey.W: _currentDirection = Vector2Int.down; break;

                    case ConsoleKey.DownArrow: _currentDirection = Vector2Int.up; break;
                    case ConsoleKey.S: _currentDirection = Vector2Int.up; break;

                    case ConsoleKey.LeftArrow: _currentDirection = Vector2Int.left; break;
                    case ConsoleKey.A: _currentDirection = Vector2Int.left; break;

                    case ConsoleKey.RightArrow: _currentDirection = Vector2Int.right; break;
                    case ConsoleKey.D: _currentDirection = Vector2Int.right; break;

                    case ConsoleKey.Escape:
                        CloseGame?.Invoke();
                    break;

                    default:

                    break;
                }
            }

        }

    }

    public enum Direction 
    { 
        Def = -1,
        Up = 0, 
        Down = 1, 
        Left = 2, 
        Right = 3
    }
}
