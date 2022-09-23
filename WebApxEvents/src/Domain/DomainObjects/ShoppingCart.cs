using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.DomainObjects
{
    public class ShoppingCart
    {
        public Guid Key { get; }
        public List<ShoppingCardItem> ShoppingCardItems { get; }
        public int AmountItems { get; private set; }
        public decimal TotalAmount { get; private set; }
        public decimal TotalDiscount { get; private set; }
        public decimal TotalPayable { get; private set; }
        
        public ShoppingCart()
        {
            Key = Guid.NewGuid();
            ShoppingCardItems = new List<ShoppingCardItem>();
        }

        public ShoppingCart(Guid key, List<ShoppingCardItem> shoppingCardItems)
        {
            Key = key;
            ShoppingCardItems = shoppingCardItems;
        }

        public void CalculateTotal()
        {
            AmountItems = ShoppingCardItems.Count;
            TotalAmount = ShoppingCardItems.Sum(s => s.Price);
            TotalDiscount = ShoppingCardItems.Sum(s => s.DiscountAmount);
            TotalPayable = ShoppingCardItems.Sum(s => s.PriceToPay);
        }

        private void CalculateDiscount(DiscountCoupon discountCoupon)
        {
            var shoppingCardItems = ShoppingCardItems
                .Where(s => s.EventKey == discountCoupon.EventKey).ToList();

            foreach (var cardItem in shoppingCardItems)
            {
                cardItem.ApplyDiscount(discountCoupon.Key, discountCoupon.Percentage);
            }
        }

        public void Add(ShoppingCardItem purchaseItem) => ShoppingCardItems.Add(purchaseItem);
        
        public void Remove(ShoppingCardItem purchaseItem) => ShoppingCardItems.Remove(purchaseItem);
    }
}