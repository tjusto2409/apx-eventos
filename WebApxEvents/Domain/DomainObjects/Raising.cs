using System;

namespace Domain.DomainObjects
{
    public class Raising
    {
        public Guid Key { get; set; }
        public decimal Percentage { get; set; }
        public Guid EventKey { get; set; }
        public decimal TotalBilledEvent { get; set; }
        public decimal TotalBilledPercentage { get; set; }
    }
}