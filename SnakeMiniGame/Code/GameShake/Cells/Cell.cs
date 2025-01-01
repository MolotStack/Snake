
using SnakeMiniGame.Code.GameShake.Snakes;
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Cells
{
    public class Cell : ICell
    {
        public Cell(Vector2Int position, char[,] sprite, bool isOccupied, ConsoleColor color,  ConsoleColor colorBackground) :
            base(position, sprite, isOccupied, color, colorBackground)
        {
        }

        public override void AddEntity(IEntity entity)
        {
            isOccupied = true;
            currentEntity = entity; 
        }

        public override void ClearEntity()
        {
            isOccupied = false;
            currentEntity = null;
        }
    }
}
