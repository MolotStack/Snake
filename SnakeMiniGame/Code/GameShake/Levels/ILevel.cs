using SnakeMiniGame.Code.GameShake.Cells;
using SnakeMiniGame.Code.GameShake.Entity;
using SnakeMiniGame.Code.GameShake.Snakes;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace SnakeMiniGame.Code.GameShake.Levels
{
    public interface ILevel
    {
        public string Name { get; }
        public int CurrentScore { get; }
        public int WinScore { get; }
        public ICell[,] Map {get;}
        public Snake Snake {get;}
        public Apple Apple { get; }
    }
}