using System;

namespace PhotonSpaceMiner.Model
{
    [Serializable]
    public struct Position
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format($"[X:{this.X} Y:{this.Y}]");
        }
    }
}
