using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Input
{
    public class InputHandler : IInput
    {
        public Vector2Int Direction => _currentDirection;
        public Action CloseGame;

        private Vector2Int _currentDirection = Vector2Int.left;

        private bool _isHorizontalMove = true;
        private bool _isVerticalMove = false;

        public void GetDirection()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: DirectionVertical(Vector2Int.down); break;
                    case ConsoleKey.W: DirectionVertical(Vector2Int.down); break;

                    case ConsoleKey.DownArrow: DirectionVertical(Vector2Int.up); break;
                    case ConsoleKey.S: DirectionVertical(Vector2Int.up); break;

                    case ConsoleKey.LeftArrow: DirectionHorizontal(Vector2Int.left); break;
                    case ConsoleKey.A: DirectionHorizontal(Vector2Int.left); break;

                    case ConsoleKey.RightArrow: DirectionHorizontal(Vector2Int.right); break;
                    case ConsoleKey.D: DirectionHorizontal(Vector2Int.right); break;

                    case ConsoleKey.Escape:
                        CloseGame?.Invoke();
                        break;

                    default:

                        break;
                }
            }

        }

        public void SetDefaulDirection()
        {
            _currentDirection = Vector2Int.left;
            _isHorizontalMove = true;
            _isVerticalMove = false;
        }

        private void DirectionHorizontal(Vector2Int direction)
        {
            if (_isVerticalMove)
            {
                _isVerticalMove = false;

                _currentDirection = direction;

                _isHorizontalMove = true;
            }
        }

        private void DirectionVertical(Vector2Int direction)
        {
            if (_isHorizontalMove)
            {
                _isHorizontalMove = false;

                _currentDirection = direction;

                _isVerticalMove = true;
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
