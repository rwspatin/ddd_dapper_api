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

        //To place an order
        public void Place() 
        {
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0,8).ToUpper();
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
            deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));

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