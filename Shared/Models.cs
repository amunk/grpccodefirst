using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Shared
{
    [DataContract]
    public class CalculateResponse
    {
        [DataMember(Order = 1)]
        public decimal Result { get; set; }
    }

    [DataContract]
    public class CalculateRequest
    {
        [DataMember(Order = 1)]
        public decimal A { get; set; }

        [DataMember(Order = 2)]
        public decimal B { get; set; }

        [DataMember(Order = 3)]
        public Operator Operator { get; set; }
    }

    [DataContract]
    public enum Operator
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }

    [DataContract]
    public class TimeRequest
    {
    }

    [DataContract]
    public class TimeResponse
    {
        [DataMember(Order = 1)]
        public DateTime NowUtc { get; set; }

        [DataMember(Order = 2)]
        public DateTime Now { get; set; }
    }

    [DataContract]
    public class HelloRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
    }

    [DataContract]
    public class HelloResponse
    {
        [DataMember(Order = 1)]
        public string Result { get; set; }
    }

    [DataContract]
    public class CalendarResponse
    {
        [DataMember(Order = 1)]
        public IEnumerable<Day> List { get; set; }
    }

    [DataContract]
    public class Day
    {
        [DataMember(Order = 1)]
        public int DayNumber { get; set; }

        [DataMember(Order = 2)]
        public string Weekday { get; set; }

        [DataMember(Order = 3)]
        public int Year { get; set; }

        [DataMember(Order = 4)]
        public string Month { get; set; }

        public override string ToString()
        {
            return $"{Weekday} {DayNumber} {Month} {Year}";
        }
    }

    [DataContract]
    public class CalendarRequest
    {
        [DataMember(Order = 1)]
        public int Year { get; set; }

        [DataMember(Order = 2)]
        public int Month { get; set; }
    }
}
