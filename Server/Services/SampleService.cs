using System;
using System.Collections.Generic;
using Shared;
using Shared.Services;
using Server.Helpers;

namespace Server.Services
{
    public class SampleService : ISampleService
    {
        public CalculateResponse Calculate(CalculateRequest request)
        {
            decimal result = 0;
            switch (request.Operator)
            {
                case Operator.Add:
                    result = request.A + request.B;
                    break;
                case Operator.Subtract:
                    result = request.A - request.B;
                    break;
                case Operator.Multiply:
                    result = request.A * request.B;
                    break;
                case Operator.Divide:
                    result = request.A / request.B;
                    break;
            }
            return new CalculateResponse { Result = result };
        }

        public CalendarResponse GetDaysInMonth(CalendarRequest request)
        {
            var result = new CalendarResponse();

            var list = new List<Day>();
            var date = new DateTime(request.Year, request.Month, 1);

            while (date.Month == request.Month)
            {
                list.Add(
                    new Day
                    {
                        Year = date.Year,
                        Month = date.ToMonthName(),
                        Weekday = date.DayOfWeek.ToString(),
                        DayNumber = date.Day
                    });
                date = date.AddDays(1);
            }

            result.List = list;
            return result;
        }

        public TimeResponse GetTime(TimeRequest request)
        {
            return new TimeResponse
            {
                Now = DateTime.Now,
                NowUtc = DateTime.UtcNow
            };
        }

        public HelloResponse Hello(HelloRequest request)
        {
            return new HelloResponse
            {
                Result = $"Hello {request.Name}"
            };
        }
    }
}
