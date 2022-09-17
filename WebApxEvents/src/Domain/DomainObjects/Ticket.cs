using System;
using Domain.Enums;
using shortid;
using shortid.Configuration;

namespace Domain.DomainObjects
{
    public class Ticket
    {
        public Guid Key { get; }
        public Guid OrderKey { get; }
        public Guid EventKey { get; }
        public string CodePass { get; }
        public TicketStatus Status { get; private set; } = TicketStatus.Active;
        public decimal PricePaid { get; }
        
        Ticket(Guid eventKey, Guid orderKey, decimal pricePaid)
        {
            Key = Guid.NewGuid();
            OrderKey = orderKey;
            EventKey = eventKey;
            PricePaid = pricePaid;
            CodePass = ShortId.Generate(new GenerationOptions(useSpecialCharacters: false, length: 8));
        }
        
        Ticket(Guid key, Guid orderKey, Guid eventKey, decimal pricePaid, string codePass)
        {
            Key = key;
            OrderKey = orderKey;
            EventKey = eventKey;
            PricePaid = pricePaid;
            CodePass = codePass;
        }

        public void Attended() => Status = TicketStatus.Used;

        public void Canceled() => Status = TicketStatus.Canceled;

        public void Expired() => Status = TicketStatus.Expired;
    }
}