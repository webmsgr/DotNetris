using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetris
{
    public class TickTimer(int interval)
    {
        public int Left = interval;
        public int Interval = interval;

        public bool Tick()
        {
            Left--;
            if (Left > 0)
            {
                return false;
            }
            Left = Interval;
            return true;
        }
    }
}
