using System;
using System.Collections.Generic;

namespace DapperStore.Domain.StoreContext.Entities
{
    public class Order
    {
        public Order(Customer customer, string number, DateTime createdDate, string status)
        {
            this.Customer = customer;
            this.Number = number;
            this.CreatedDate = createdDate;
            this.Status = status;

        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Status { get; private set; }
        public IList<OrderItem> Items { get; private set; }
        public IList<Delivery> Deliverys { get; private set; }

        //To place an order
        public void Place() { }
    }
}