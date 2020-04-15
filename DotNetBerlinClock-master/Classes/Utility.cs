using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public static class Utility
    {
        private const int TimeDivider = 5;
        public const char SwitchOnRed = 'R';
        public const char SwitchOnYellow = 'Y';
        public const char SwitchOff = 'O';

        public static int GetTimeDivision(int time)
        {
            return time / TimeDivider;
        }

        public static int GetTimeRemainder(int time)
        {
            return time % TimeDivider;
        }
    }
}
