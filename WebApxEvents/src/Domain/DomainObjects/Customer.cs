using System;
using System.Collections.Generic;
using Domain.ValueObjects;

namespace Domain.DomainObjects
{
    public class Customer : User
    {
        public Document Document { get; }
        public DateTime BirthDay { get; set; }
        public ShoppingCart ShoppingCart { get; }
        public List<PaymentOrder> PaymentOrders { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Customer(string name, string emailAddress, string documentNumber) : base(name, emailAddress)
        {
            Document = new Document(documentNumber);
            ShoppingCart = new ShoppingCart();
        }
    }
}