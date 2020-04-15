using System;
using System.Text;

namespace BerlinClock.Classes
{
    internal class HourConverter : IHourConverter
    {
        const int TotalHourLights = 4;

        private readonly StringBuilder timeInMatrix;
        public HourConverter()
        {
            timeInMatrix = new StringBuilder();
        }

        public string ConvertHourToMatrix(int time)
        {
            var numberOfFiveHourLights = Utility.GetTimeDivision(time);
            var numberOfOneHourLights = Utility.GetTimeRemainder(time);
            SetFiveHourLights(numberOfFiveHourLights);

            timeInMatrix.Append(Environment.NewLine);
            SetOneHourLights(numberOfOneHourLights);

            return timeInMatrix.ToString();
        }

        private void SetFiveHourLights(int numberOfFiveHourLights)
        {
            for (int lightFiveHour = 1; lightFiveHour <= TotalHourLights; lightFiveHour++)
            {
                timeInMatrix.Append(lightFiveHour > numberOfFiveHourLights ?
                                    Utility.SwitchOff :
                                    Utility.SwitchOnRed);
            }
        }

        private void SetOneHourLights(int numberOfOneHourLights)
        {
            for (int lightOneHour = 1; lightOneHour <= TotalHourLights; lightOneHour++)
            {
                timeInMatrix.Append(lightOneHour > numberOfOneHourLights ?
                                    Utility.SwitchOff :
                                    Utility.SwitchOnRed);
            }
        }
    }
}