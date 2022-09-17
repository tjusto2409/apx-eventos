using System;

namespace Domain.DomainObjects
{
    public class DiscountCoupon
    {
        public Guid Key { get; }
        
        public Guid EventKey { get; }
        public int Percentage { get; }

        private DateTime _expirationDate;
        public DateTime ExpirationDate
        {
            get => _expirationDate;
            private set
            {
                IsExpired = DateTime.UtcNow > value;
                _expirationDate = value;
            }
        }
        
        public bool IsExpired { get; private set; }

        public DiscountCoupon(int percentage, DateTime expirationDate, Guid eventKey)
        {
            Percentage = percentage;
            ExpirationDate = expirationDate;
            EventKey = eventKey;
            Key = Guid.NewGuid();
        }
        
        public DiscountCoupon(Guid key, int percentage, DateTime expirationDate, Guid eventKey)
        {
            Percentage = percentage;
            ExpirationDate = expirationDate;
            EventKey = eventKey;
            Key = key;
        }
    }
}