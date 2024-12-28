using SnakeMiniGame.Code.GameShake.Interfaces;
using SnakeMiniGame.Code.GameShake.Snake;
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake
{
    public class Renderer
    {
        private string _direction;

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

            //InfoRender();

            if (!_isRenderingMap)
            {
                RenderAllStaticMap(level);

                _isRenderingMap = true;
            }

            RanderSnake(_level.Snake);

            DebugRender(_sizeMapY);
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

        private void RanderSnake(IEntity entity)
        {
            Console.SetCursorPosition(entity.LastPosition.x, entity.LastPosition.y);
            Console.BackgroundColor = entity.BackgroundColor;
            Console.ForegroundColor = entity.Color;
            Console.Write(" ");

            Console.SetCursorPosition(entity.CurrentPosition.x, entity.CurrentPosition.y);

            Console.Write(entity.Sprite[0, 0]);
        }

        private void InfoRender()
        {
            Console.WriteLine("Очки");
            Console.Write("________________________________________________________");
        }
        private void DebugRender(int pointY)
        {
            Console.BackgroundColor = ConsoleColor.Black;
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
    }
}
