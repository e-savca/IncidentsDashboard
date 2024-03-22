using System;

namespace Common.Dates
{
    public class DateService : IDateService
    {
        private readonly string _timeZoneId = "CET";
        private readonly TimeZoneInfo _timeZone;
        public DateService()
        {
            _timeZone = TimeZoneInfo.FindSystemTimeZoneById(_timeZoneId);
        }
        public DateTime GetDate()
        {
            return TimeZoneInfo.ConvertTime(DateTime.UtcNow, _timeZone);
        }
    }
}
