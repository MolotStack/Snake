using SnakeMiniGame.Code.GameShake.Snakes;
using SnakeMiniGame.Code.GameShake.Utilits;

namespace SnakeMiniGame.Code.GameShake.Cells
{
    public abstract class ICell
    {
        public Vector2Int position;
        public char[,] sprite;

        public bool isOccupied;
        public IEntity currentEntity;

        public ConsoleColor colorBackground;
        public ConsoleColor color;

        public ICell(Vector2Int position, char[,] sprite, bool isOccupied, ConsoleColor color, ConsoleColor colorBackground, IEntity entity = null)
        {
            this.position = position;
            this.sprite = sprite;
            this.isOccupied = isOccupied;
            this.color = color;
            this.colorBackground = colorBackground;
            this.currentEntity = entity;
        }

        public virtual void AddEntity(IEntity entity)
        {

        }

        public virtual void ClearEntity()
        {

        }

    }
}
