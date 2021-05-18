using System;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Shared;
using Shared.Services;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // This switch must be set before creating the GrpcChannel/HttpClient.
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client = channel.CreateGrpcService<ISampleService>();

            var helloResponse = client.Hello(new HelloRequest { Name = "World!" });
            Console.WriteLine($"Greeting: {helloResponse.Result}");

            var calculateAddResponse = client.Calculate(new CalculateRequest { A = 2.4M, B = 1.3M, Operator = Operator.Add });
            Console.WriteLine($"Add result: {calculateAddResponse.Result}");

            var calculateSubtractResponse = client.Calculate(new CalculateRequest { A = 2.4M, B = 1.3M, Operator = Operator.Subtract });
            Console.WriteLine($"Subtract result: {calculateSubtractResponse.Result}");

            var calculateMultiplyResponse = client.Calculate(new CalculateRequest { A = 2.4M, B = 1.3M, Operator = Operator.Multiply });
            Console.WriteLine($"Multiply result: {calculateMultiplyResponse.Result}");

            var calculateDivideResponse = client.Calculate(new CalculateRequest { A = 2.4M, B = 1.3M, Operator = Operator.Divide });
            Console.WriteLine($"Divide result: {calculateDivideResponse.Result}");

            var timeResponse = client.GetTime(new TimeRequest());
            Console.WriteLine($"Now: {timeResponse.Now}");
            Console.WriteLine($"UtcNow: {timeResponse.NowUtc}");

            var calendarResponse = client.GetDaysInMonth(new CalendarRequest { Year = 2021, Month = 5 });
            Console.WriteLine($"Days in month:");
            foreach (Day day in calendarResponse.List)
            {
                Console.WriteLine(day.ToString());
            }
        }
    }
}
