using System.Collections.Generic;
using System.Linq;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.DomainObjects
{
    public class Event
    {
        public EventDetails Info { get; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public bool IsActive { get; private set; }
        public int NumberOfVacancies { get; }
        public int PresentCustomers { get; private set; }
        public decimal TotalBilled { get; private set; }
        public EventStatus Status { get; set; }

        public Event(EventDetails info, int numberOfVacancies)
        {
            Info = info;
            NumberOfVacancies = numberOfVacancies;
        }

        public void ToggleActive() => IsActive = !IsActive;

        private void CalculateBilling() => TotalBilled = OrderItems.ToList().Sum(t => t.PriceToPay);

        private void CalculatePresentCustomers() => PresentCustomers = Tickets.Count(t => t.Status == TicketStatus.Used);

        public void Closed()
        {
            CalculateBilling();
            CalculatePresentCustomers();

            Status = EventStatus.Closed;
        }

        public void Cancel()
        {
            Status = EventStatus.Canceled;
            
            foreach (var ticket in Tickets)
            {
                ticket.Canceled();
            }

            foreach (var orderItem in OrderItems)
            {
                orderItem.PendingRefund();
            }
        }
    }
}