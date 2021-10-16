using System;
using ECommercePlatform.Application.Interfaces.Services;

namespace ECommercePlatform.Infrastructure.Services
{
    public class TimeManagementService : ITimeManagementService
    {
        private DateTime _date;

        public TimeManagementService()
        {
            _date = DateTime.Today;
        }
        public DateTime IncreaseTime(int hour)
        {
            _date = _date.AddHours(hour);
            return _date;
        }

        public int DiscountedHours(DateTime startDate)
        {
            return (int)(_date - startDate).TotalHours;
        }

        public DateTime GetDate()
        {
            return _date;
        }
    }
}
