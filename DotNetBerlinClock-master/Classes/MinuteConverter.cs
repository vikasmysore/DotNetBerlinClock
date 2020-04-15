using System;
using System.Linq;
using System.Text;

namespace BerlinClock.Classes
{
    public class MinuteConverter : IMinutesConverter
    {
        private readonly StringBuilder timeInMatrix;

        public MinuteConverter()
        {
            timeInMatrix = new StringBuilder();
        }

        public string ConvertMinutesToMatrix(int time)
        {
            var numberOfQuarterlyLights = Utility.GetTimeDivision(time);
            var numberOfOneMinuteLights = Utility.GetTimeRemainder(time);
            SetQuarterlyLights(numberOfQuarterlyLights);
            SetOneMinuteLights(numberOfOneMinuteLights);

            timeInMatrix.Append(Environment.NewLine);

            return timeInMatrix.ToString();
        }

        private void SetQuarterlyLights(int numberOfQuarterlyLights)
        {
            const int TotalQuarterlyMinutesLights = 11;
            int[] QuarterlyIntervals = new int[3] { 3, 6, 9 };

            for (int lightQuarterly = 1; lightQuarterly <= TotalQuarterlyMinutesLights; lightQuarterly++)
            {
                if (lightQuarterly > numberOfQuarterlyLights)
                    timeInMatrix.Append(Utility.SwitchOff);
                else
                    timeInMatrix.Append(QuarterlyIntervals.Any(x => x == lightQuarterly) ?
                                                        Utility.SwitchOnRed :
                                                        Utility.SwitchOnYellow);
            }
        }

        private void SetOneMinuteLights(int numberOfOneMinuteLights)
        {
            const int TotalOneMinuteLights = 4;

            for (int lightOneMinute = 1; lightOneMinute <= TotalOneMinuteLights; lightOneMinute++)
            {
                timeInMatrix.Append(lightOneMinute > numberOfOneMinuteLights ?
                                    Utility.SwitchOff :
                                    Utility.SwitchOnYellow);
            }
        }
    }
}