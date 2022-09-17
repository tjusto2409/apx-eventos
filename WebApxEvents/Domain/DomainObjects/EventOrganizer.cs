using System.Collections.Generic;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.DomainObjects
{
    public class EventOrganizer : User
    {
        public Document Document { get; }
        public Address Address { get; } = new();
        public string WebSite { get; set; }
        public EventOrganizerType Type { get; }
        public List<string> Phones { get; } = new();

        public EventOrganizer(string name, string emailAddress, string documentNumber, string eventOrganizerType) : base(name, emailAddress)
        {
            Document = new Document(documentNumber);
        }
    }
}