using BerlinClock.Classes;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private StringBuilder timeInMatrix;
        private readonly IBlinkStatus blinkStatus;
        private readonly IHourConverter hourConverter;
        private readonly IMinutesConverter minuteConverter;

        public TimeConverter(): this(new BlinkStatus(), new HourConverter(), new MinuteConverter())
        {
        }

        public TimeConverter(IBlinkStatus blinkStatus, IHourConverter hourConverter,IMinutesConverter minuteConverter)
        {
            timeInMatrix = new StringBuilder();
            this.blinkStatus = blinkStatus;
            this.hourConverter = hourConverter;
            this.minuteConverter = minuteConverter;
        }

        public string convertTime(string aTime)
        {
            timeInMatrix.Clear();
            try
            {
                timeInMatrix.Append(blinkStatus.GetBlinkStatus(aTime));
                timeInMatrix.Append(Environment.NewLine);
                timeInMatrix.Append(hourConverter.ConvertHourToMatrix(!aTime.Contains("24") ? DateTime.Parse(aTime).Hour : 24));
                timeInMatrix.Append(Environment.NewLine);
                timeInMatrix.Append(minuteConverter.ConvertMinutesToMatrix(!aTime.Contains("24") ? DateTime.Parse(aTime).Minute : 0));
            }
            catch (Exception ex)
            {
                timeInMatrix.Append($"Enter a valid time and time format- HH:MM:SS {Environment.NewLine} close and try again..!!");
            }

            return timeInMatrix.ToString();
        }
    }
}