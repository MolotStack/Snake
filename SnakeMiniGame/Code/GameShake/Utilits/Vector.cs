

using System.Diagnostics.Metrics;

namespace SnakeMiniGame.Code.GameShake.Utilits
{
    public struct Vector2Int
    {
        public static Vector2Int up = new Vector2Int(0, 1);
        public static Vector2Int down = new Vector2Int(0, -1);
        public static Vector2Int left = new Vector2Int(-1, 0);
        public static Vector2Int right = new Vector2Int(1, 0);
        public static Vector2Int zero = new Vector2Int(0, 0);


        public int x;
        public int y;

        public Vector2Int(int x = 0, int y = 0)
        {
            this.x = x; 
            this.y = y;
        }

        public static Vector2Int operator + (Vector2Int vector2Int_1, Vector2Int vector2Int_2)
        {
            return new Vector2Int(vector2Int_1.x + vector2Int_2.x, vector2Int_1.y + vector2Int_2.y);
        }

        public override string ToString()
        {
            return $"X = {x}, Y = {y}";
        }
    }
}
