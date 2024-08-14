using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetris
{
    public class Piece(bool[] data, Color color): ICloneable
    {
        public bool[] Data = data;
        public Color Color { get; set; } = color;

        public object Clone()
        {
            return new Piece((bool[])Data.Clone(), Color);
        }

        public void Rotate()
        {
            // 0 1 2
            // 3 4 5
            // 6 7 8
            // becomes
            // 6 3 0
            // 7 4 1
            // 8 5 2

            Data = new[]
            {
                Data[6], Data[3], Data[0],
                Data[7], Data[4], Data[1],
                Data[8], Data[5], Data[2]
            };

        }

    }
}
