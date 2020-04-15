using System;
using System.Text.RegularExpressions;

namespace BerlinClock.Classes
{
    internal class BlinkStatus : IBlinkStatus
    {
        public char GetBlinkStatus(string time)
        {
            var wrappedTime = Regex.Replace(time, @"24:(\d\d:\d\d)$", "00:$1");
            var blinkStatus = DateTime.Parse(wrappedTime).Second % 2 == 0 ? Utility.SwitchOnYellow : Utility.SwitchOff;

            return blinkStatus;
        }
    }
}