using System.ServiceModel;

namespace Shared.Services
{
    [ServiceContract]
    public interface ISampleService
    {
        HelloResponse Hello(HelloRequest request);
        TimeResponse GetTime(TimeRequest request);
        CalculateResponse Calculate(CalculateRequest request);
        CalendarResponse GetDaysInMonth(CalendarRequest request);
    }
}
