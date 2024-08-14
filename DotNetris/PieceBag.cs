using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetris
{
    public class PieceBag
    {


        private Piece[] bag = new[] { 
            new Piece([
                false, true, false,
                true, true, true,
                false, false, false
            ], Color.Red),
            new Piece([
                false, false, true,
                true, true, true,
                false, false, false
            ], Color.Yellow),
            new Piece([
                true, false, false,
                true, true, true,
                false, false, false
                ], Color.Blue)
        };

        public PieceBag(Random rand)
        {
            Rand = rand;
            Rand.Shuffle(bag);
        }

        private int bagPtr = 0;

        public Random Rand;

        public Piece Next()
        {
            var outv = bag[bagPtr];
            bagPtr++;
            if (bagPtr >= bag.Length)
            {
                Rand.Shuffle(bag);
                bagPtr = 0;
            }
            
            return (Piece)outv.Clone();
        }
    }
}
