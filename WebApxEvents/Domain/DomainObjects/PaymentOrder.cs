using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Enums;
using shortid;
using shortid.Configuration;

namespace Domain.DomainObjects
{
    public class PaymentOrder
    {
        public Guid Key { get; }
        public string Identifier { get; set; }
        public FormOfPayment FormOfPayment { get; set; }
        public PaymentOrderStatus Status { get; set; } = PaymentOrderStatus.Available;
        public List<OrderItem> OrderItems { get; }

        public PaymentOrder(ShoppingCart shoppingCart)
        {
            Key = Guid.NewGuid();
            Identifier = ShortId.Generate(new GenerationOptions(useSpecialCharacters: false, length: 6, useNumbers: true));
            shoppingCart.CalculateTotal();
            OrderItems = shoppingCart.ShoppingCardItems
                .Select(items => new OrderItem(Key, items.EventKey, items.DiscountAmount, items.Price)).ToList();
        }
    }
}