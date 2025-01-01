using SnakeMiniGame.Code.GameShake.Cells;
using SnakeMiniGame.Code.GameShake.Entity;
using SnakeMiniGame.Code.GameShake.Snakes;
using static System.Formats.Asn1.AsnWriter;

namespace SnakeMiniGame.Code.GameShake.Levels
{
    public interface ILevel
    {
        public int Score { get; }
        public ICell[,] Map {get;}
        public Snake Snake {get;}
        public Apple Apple { get; }
    }
}