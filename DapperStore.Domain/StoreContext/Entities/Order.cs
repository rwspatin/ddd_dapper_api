using System;
using System.Collections.Generic;
using DapperStore.Domain.StoreContext.Enums;

namespace DapperStore.Domain.StoreContext.Entities
{
    public class Order
    {
        public Order(
            Customer customer
            )
        {
            this.Customer = customer;
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0,8).ToUpper();
            this.CreatedDate = DateTime.Now;
            this.Status = EOrderStatus.Created;
            this.Items = new List<OrderItem>();
            this.Deliverys = new List<Delivery>();
        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get; private set; }
        public IReadOnlyCollection<Delivery> Deliverys { get; private set; }

        public void AddItem(OrderItem item)
        {

        }

        //To place an order
        public void Place() { }
    }
}