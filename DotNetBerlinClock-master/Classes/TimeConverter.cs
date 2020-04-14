using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private StringBuilder timeInMatrix;
        private const int TimeDivider = 5;
        private const char SwitchOnRed = 'R';
        private const char SwitchOnYellow = 'Y';
        private const char SwitchOff = 'O';

        public TimeConverter()
        {
            timeInMatrix = new StringBuilder();
        }

        public string convertTime(string aTime)
        {
            timeInMatrix.Clear();
            try
            {
                GetBlinkStatus(aTime);
                timeInMatrix.Append(Environment.NewLine);
                ConvertHourToMatrix(!aTime.Contains("24") ? DateTime.Parse(aTime).Hour : 24);
                timeInMatrix.Append(Environment.NewLine);
                ConvertMinutesToMatrix(!aTime.Contains("24") ? DateTime.Parse(aTime).Minute : 0);
            }
            catch (Exception ex)
            {
                timeInMatrix.Append($"Enter a valid time and time format- HH:MM:SS {Environment.NewLine} close and try again..!!");
            }

            return timeInMatrix.ToString();
        }

        private void GetBlinkStatus(string time)
        {
            var wrappedTime = Regex.Replace(time, @"24:(\d\d:\d\d)$", "00:$1");
            var blinkStatus = DateTime.Parse(wrappedTime).Second % 2 == 0 ? SwitchOnYellow : SwitchOff;

            timeInMatrix.Append((char)blinkStatus);
        }

        private void ConvertHourToMatrix(int time)
        {
            const int TotalHourLights = 4;
            var numberOfFiveHourLights = GetTimeDivision(time);
            var numberOfOneHourLights = GetTimeRemainder(time);

            for (int lightFiveHour = 1; lightFiveHour <= TotalHourLights; lightFiveHour++)
            {
                    timeInMatrix.Append(lightFiveHour > numberOfFiveHourLights ? 
                                        SwitchOff :
                                        SwitchOnRed);
            }
            timeInMatrix.Append(Environment.NewLine);

            for (int lightOneHour = 1; lightOneHour <= TotalHourLights; lightOneHour++)
            {
                    timeInMatrix.Append(lightOneHour > numberOfOneHourLights ?
                                        SwitchOff : 
                                        SwitchOnRed);
            }
        }

        private void ConvertMinutesToMatrix(int time)
        {
            const int TotalQuarterlyMinutesLights = 11;
            const int TotalOneMinuteLights = 4;
            int[] QuarterlyIntervals = new int[3] { 3, 6, 9 };
            var numberOfQuarterlyLights = GetTimeDivision(time);
            var numberOfOneMinuteLights = GetTimeRemainder(time);

            for (int lightQuarterly = 1; lightQuarterly <= TotalQuarterlyMinutesLights; lightQuarterly++)
            {
                if (lightQuarterly > numberOfQuarterlyLights)
                    timeInMatrix.Append(SwitchOff);
                else
                    timeInMatrix.Append(QuarterlyIntervals.Any(x => x == lightQuarterly) ?
                                                        SwitchOnRed :
                                                        SwitchOnYellow);
            }
            timeInMatrix.Append(Environment.NewLine);

            for (int lightOneMinute = 1; lightOneMinute <= TotalOneMinuteLights; lightOneMinute++)
            {
                timeInMatrix.Append(lightOneMinute > numberOfOneMinuteLights ?
                                    SwitchOff : 
                                    SwitchOnYellow);
            }
        }

        private int GetTimeDivision(int time)
        {
            return time / TimeDivider;
        }

        private int GetTimeRemainder(int time)
        {
            return time % TimeDivider;
        }
    }
}