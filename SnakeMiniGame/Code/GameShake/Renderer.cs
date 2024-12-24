
using SnakeMiniGame.Code.Game;
using SnakeMiniGame.Code.GameShake.Interfaces;
using System;
using System.Diagnostics;

namespace SnakeMiniGame.Code.GameShake
{
    public class Renderer
    {
        private const int _heightCells = 50;
        private const int _widthCells = 50;

        private int[,] screen = new int[_heightCells, _widthCells];

        private Direction current;

        public void Render(IEntity[,] map)
        {
            Console.Clear();
            Console.CursorVisible = false;

            IEntity[,] currentMap = map;

            InfoRender();

            int indexY = 0;
            int offestY = 3;

            for (int i = 0; i < currentMap.GetLength(0); i++)
            {
                indexY = offestY + (i * 3);
                int indexX = 0;
                for (int j = 0; j < currentMap.GetLength(1); j++)
                {
                    indexX = j * 3;
                    Console.SetCursorPosition(indexX, indexY);
                    EntityRender(currentMap[i,j], indexX, indexY);
;
                }
            }

            DebugRender(indexY);
        }

        private void EntityRender(IEntity entity, int pointX , int pointY)
        {
            for (int i = 0; i < entity.sprite.GetLength(0); i++)
            {
                for (int j = 0; j < entity.sprite.GetLength(1); j++)
                {
                    Console.BackgroundColor = entity.color;
                    Console.Write(entity.sprite[i, j]);
                }
                Console.SetCursorPosition(pointX,  ++pointY);
            }
        }

        private void InfoRender()
        {
            Console.WriteLine("Очки");
            Console.Write("________________________________________________________");
        }
        private void DebugRender(int pointY)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, pointY + 3);
            Console.WriteLine("Направление движения: " + current);
        }

        public void Debug(IInput input)
        {
            current = input.Direction;
        }
    }
}
