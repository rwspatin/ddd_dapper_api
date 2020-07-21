using System;
using System.Collections.Generic;
using DapperStore.Domain.StoreContext.Enums;
using System.Linq;
using FluentValidator;

namespace DapperStore.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliverys;
        public Order(
            Customer customer
            )
        {
            this.Customer = customer;
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

        public void AddItem(Product product, int quantity)
        {
            if(quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} em estoque");

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }

        //To place an order
        public void Place() 
        {
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0,8).ToUpper();
            if(_items.Count == 0)
                AddNotification("Order", "Este pedido não possui itens");
        }

        //Pay order
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }
        //send order
        public void Ship()
        {
            //For each 5 products this will be send
            var deliveries = new List<Delivery>();

            int count = 1;
            foreach(var item in _items)
            {
                if(count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }

                count++;
            }

            deliveries.ForEach(x => x.Ship());
            
            deliveries.ForEach(x => _deliverys.Add(x));
        }

        //cancel order
        public void Cancel(){
            Status = EOrderStatus.Canceled;
            _deliverys.ToList().ForEach(x => x.Cancel());
        }
    }
}