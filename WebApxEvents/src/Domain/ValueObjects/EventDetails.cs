using System;
using Domain.Enums;

namespace Domain.ValueObjects
{
    public class EventDetails
    {
        public Guid Key { get; set; }
        public string Title { get; set; }
        public string WebSite { get; set; }
        public DateTime StartEvent { get; set; }
        public DateTime EndEvent { get; set; }
        public TimeSpan EventDuration { get; }
        public string Language { get; set; } = "português";
        public Address Local { get; set; }
        public string Description { get; set; }
        public EventType Type { get; set; }
        public EventCategory Category { get; set; }
        public string SubCategory { get; set; }
        public decimal TicketPrice { get; set; }

        EventDetails()
        {
            
        }
    }
}