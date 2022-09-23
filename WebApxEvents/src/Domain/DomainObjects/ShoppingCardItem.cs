using System;

namespace Domain.DomainObjects
{
    public class ShoppingCardItem
    {
        public Guid Key { get; }
        public Guid EventKey { get; }
        public Guid DiscountKey { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public decimal Price { get; }
        public decimal PriceToPay { get; private set; }

        public ShoppingCardItem(Guid eventKey, decimal price)
        {
            Key = Guid.NewGuid();
            EventKey = eventKey;
            Price = price;
            PriceToPay = price;
        }

        public void ApplyDiscount(Guid discountKey, int discountPercentage)
        {
            DiscountKey = discountKey;
            DiscountAmount = Price * discountPercentage / 100;
            PriceToPay = Price - DiscountAmount;
        }
    }
}