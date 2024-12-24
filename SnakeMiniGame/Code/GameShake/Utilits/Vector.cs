

namespace SnakeMiniGame.Code.GameShake.Utilits
{
    public struct Vector2Int
    {
        public static Vector2Int up = new Vector2Int(0, -1);
        public static Vector2Int down = new Vector2Int(0, -1);
        public static Vector2Int left = new Vector2Int(0, -1);
        public static Vector2Int right = new Vector2Int(0, -1);
        public static Vector2Int zero = new Vector2Int(0, 0);


        public int x;
        public int y;

        public Vector2Int(int x = 0, int y = 0)
        {
            this.x = x; 
            this.y = y;
        }

        public bool Equals(Vector2Int other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return other.x.Equals(x) && other.y.Equals(y);
        }
    }
}
