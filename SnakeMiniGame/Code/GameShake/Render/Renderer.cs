using SnakeMiniGame.Code.GameShake.Entity;
using SnakeMiniGame.Code.GameShake.Levels;
using SnakeMiniGame.Code.GameShake.Snakes;
using System.Drawing;
using System.Xml.Linq;

namespace SnakeMiniGame.Code.GameShake.Render
{
    public class Renderer
    {
        private string _direction;
        private int _score;

        private int _sizeMapY;
        private int _sizeMapX;
        private int _sizeCells;

        private bool _isRenderingMap = false;

        private ILevel _level;

        public void Render(ILevel level, int sizyCells)
        {
            _level = level;

            _sizeCells = sizyCells;

            _sizeMapY = _level.Map.GetLength(0) * _sizeCells;
            _sizeMapX = _level.Map.GetLength(1) * _sizeCells;

            Console.CursorVisible = false;



            if (!_isRenderingMap)
            {
                RenderAllStaticMap(level);

                _isRenderingMap = true;
            }

            RenderApple(_level.Apple);

            RenderSnake(_level.Snake);
            DebugRender(_sizeMapY);
            InfoRender(_sizeMapY);
        }

        private void RenderAllStaticMap(ILevel level)
        {
            for (int i = 0; i < _level.Map.GetLength(0); i++)
            {
                for (int j = 0; j < _level.Map.GetLength(1); j++)
                {
                    Console.SetCursorPosition(_level.Map[i, j].position.x, _level.Map[i, j].position.y);
                    Console.BackgroundColor = _level.Map[i, j].colorBackground;
                    Console.ForegroundColor = _level.Map[i, j].color;

                    for (int x = 0; x < _level.Map[i, j].sprite.GetLength(0); x++)
                    {
                        for (int y = 0; y < _level.Map[i, j].sprite.GetLength(1); y++)
                        {
                            Console.Write(_level.Map[i, j].sprite[x, y]);
                        }
                    }

                }
            }
        }

        private void RenderSnake(Snake snake)
        {
            Console.SetCursorPosition(snake.LastPosition.x, snake.LastPosition.y);
            Console.BackgroundColor = snake.BackgroundColor;
            Console.ForegroundColor = snake.Color;
            Console.Write(" ");

            Console.SetCursorPosition(snake.CurrentPosition.x, snake.CurrentPosition.y);

            Console.Write(snake.Sprite[0, 0]);
            if (snake.Tail == null) 
            {
                return;
            }
            RenderTail(snake.Tail);
        }
        private void RenderTail(Tail tail) 
        {
            Console.SetCursorPosition(tail.LastPosition.x, tail.LastPosition.y);
            Console.BackgroundColor = tail.BackgroundColor;
            Console.ForegroundColor = tail.Color;
            Console.Write(" ");
            Console.SetCursorPosition(tail.CurrentPosition.x, tail.CurrentPosition.y);
            Console.Write(tail.Sprite[0, 0]);
            if (tail.tail == null)
            {
                return;
            }
            RenderTail(tail.tail);
        }

        private void RenderApple(Apple apple)
        {
            Console.SetCursorPosition(apple.CurrentPosition.x, apple.CurrentPosition.y);
            Console.BackgroundColor = apple.BackgroundColor;
            Console.ForegroundColor = apple.Color;
            Console.Write(apple.Sprite[0, 0]);

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void InfoRender(int pointY)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, pointY);
            Console.WriteLine("Очки  " + _score);
            Console.Write("________________________________________________________");
        }
        private void DebugRender(int pointY)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, pointY + 2);
            Console.WriteLine("________________________________________________________");
            Console.WriteLine("                                                        ");
            Console.SetCursorPosition(0, pointY + 3);
            Console.WriteLine("Направление движения: " + _direction);
        }

        public void Debug(IInput input)
        {
            _direction = input.Direction.ToString();
        }

        public void Score(int score)
        {
            _score = score;
        }
    }
}
