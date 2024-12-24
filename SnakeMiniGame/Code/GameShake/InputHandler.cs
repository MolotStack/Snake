
namespace SnakeMiniGame.Code
{
    public class InputHandler : IInput
    {
        public Direction Direction => _currentDirection;
        public Action CloseGame; 

        private Direction _currentDirection = Direction.Left;

        public void GetDirection()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: _currentDirection = Direction.Up; break;
                    case ConsoleKey.W: _currentDirection = Direction.Up; break;

                    case ConsoleKey.DownArrow: _currentDirection = Direction.Down; break;
                    case ConsoleKey.S: _currentDirection = Direction.Down; break;

                    case ConsoleKey.LeftArrow: _currentDirection = Direction.Left; break;
                    case ConsoleKey.A: _currentDirection = Direction.Left; break;

                    case ConsoleKey.RightArrow: _currentDirection = Direction.Right; break;
                    case ConsoleKey.D: _currentDirection = Direction.Right; break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
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
