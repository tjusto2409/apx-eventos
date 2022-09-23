using System;
using Domain.Enums;

namespace Domain.DomainObjects
{
    public class OrderItem
    {
        public Guid Key { get; }
        public Guid EventKey { get; }
        public Guid OrderKey { get;  }
        public Guid DiscountKey { get; }
        public decimal DiscountAmount { get; }
        public decimal Price { get; }
        public decimal PriceToPay { get; }
        
        public PaymentOrderStatus Status { get; set; } = PaymentOrderStatus.Available;

        public OrderItem(Guid orderKey, Guid eventKey, Guid discountKey, decimal discountAmount, decimal price)
        {
            Key = Guid.NewGuid();
            OrderKey = orderKey;
            EventKey = eventKey;
            DiscountKey = discountKey;
            DiscountAmount = discountAmount;
            Price = price;
            PriceToPay = price - discountAmount;
        }

        public void PendingRefund() => Status = PaymentOrderStatus.PendingRefund;
    }
}