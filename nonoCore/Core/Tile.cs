using System;

namespace nonoCore
{
    [Serializable]
    public class Tile
    {
        public int Value { get; set;}

        public Tile(int value)
        {
            this.Value = value;
        }
    }
}
