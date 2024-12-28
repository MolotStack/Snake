namespace SnakeMiniGame.Code.GameShake.Interfaces
{
    public interface ILevel
    {
        public ICells[,] Map {get;}
        public IEntity Snake {get;}
    }
}