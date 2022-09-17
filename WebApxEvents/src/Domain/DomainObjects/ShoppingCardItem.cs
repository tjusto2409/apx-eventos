using System;

namespace Domain.DomainObjects
{
    public class ShoppingCardItem
    {
        public Guid Key { get; }
        public Guid EventKey { get; }

        private decimal _discountAmount;
        public decimal DiscountAmount
        {
            get => _discountAmount;
            set
            {
                _discountAmount = (Price * value / 100);
                PriceToPay = Price - _discountAmount;
            }
        }
        public decimal Price { get; }
        public decimal PriceToPay { get; private set; }

        public ShoppingCardItem(Guid eventKey, decimal price)
        {
            Key = Guid.NewGuid();
            EventKey = eventKey;
            Price = price;
            PriceToPay = price;
        }
    }
}