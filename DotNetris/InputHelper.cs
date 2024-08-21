using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetris
{
    public class InputHelper
    {
        private static Inputs[] PressedOrder =
        [
            Inputs.Up,
            Inputs.Down, 
            Inputs.Left,
            Inputs.Right,
            Inputs.RotateLeft,
            Inputs.RotateRight
        ];

        uint[] Pressed = [ 
            0, // up
            0, // down
            0, // left
            0, // right
            0, // rotateleft
            0, // rotateright
        ];


        public void Tick(Inputs inputs)
        {
            for (int i = 0; i < Pressed.Length; i++)
            {
                if ((inputs & PressedOrder[i]) != 0)
                {
                    // we are pressing this input
                    Pressed[i]++;
                }
                else
                {
                    Pressed[i] = 0;
                }
            }
            
        }

        private int GetIndex(Inputs inputs)
        {
            // find our input in the PressedOrder
            // why doesn't c# have some sort of index method for ienumerables
            int index = PressedOrder
                .Select((item, index) => new { item, index })
                .FirstOrDefault(x => x.item == inputs)?.index ?? -1;
            if (index == -1)
            {
                throw new ArgumentException("Invalid Input");
            }
            return index;
        }

        public bool IsDown(Inputs inputs)
        {
            int index = GetIndex(inputs);
            return Pressed[index] > 0;
        }

        public bool IsDownThisTick(Inputs inputs)
        {
            int index = GetIndex(inputs);
            return Pressed[index] == 1;
        }

        public bool IsUp(Inputs inputs)
        {
            int index = GetIndex(inputs);
            return Pressed[index] == 0;
        }
       
    }
}
