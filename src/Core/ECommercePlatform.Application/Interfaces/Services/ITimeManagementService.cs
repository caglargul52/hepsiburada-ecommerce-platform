using System;

namespace ECommercePlatform.Application.Interfaces.Services
{
    public interface ITimeManagementService
    {
        DateTime IncreaseTime(int hour);
        int DiscountedHours(DateTime startDate);
        DateTime GetDate();
    }
}
