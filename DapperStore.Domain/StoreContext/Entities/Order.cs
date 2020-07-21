using System;
using System.Collections.Generic;
using DapperStore.Domain.StoreContext.Enums;
using System.Linq;
namespace DapperStore.Domain.StoreContext.Entities
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliverys;
        public Order(
            Customer customer
            )
        {
            this.Customer = customer;
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0,8).ToUpper();
            this.CreatedDate = DateTime.Now;
            this.Status = EOrderStatus.Created;
            this._items = new List<OrderItem>();
            this._deliverys = new List<Delivery>();
        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliverys => _deliverys.ToArray();

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }

        public void AddItem(Delivery delivery)
        {
            _deliverys.Add(delivery);
        }

        //To place an order
        public void Place() { }
    }
}