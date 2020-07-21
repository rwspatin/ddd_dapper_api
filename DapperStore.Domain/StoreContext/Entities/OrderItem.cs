using System;
using System.Collections.Generic;

namespace DapperStore.Domain.StoreContext.Entities
{
    public class OrderItem
    {

        public OrderItem(Product product, string quantity, string price)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Price = price;

        }
        public Product Product { get; private set; }
        public string Quantity { get; private set; }
        public string Price { get; private set; }
    }
}