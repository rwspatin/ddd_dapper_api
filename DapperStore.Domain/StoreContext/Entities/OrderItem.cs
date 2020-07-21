using System;
using System.Collections.Generic;

namespace DapperStore.Domain.StoreContext.Entities
{
    public class OrderItem
    {

        public OrderItem(
            Product product, 
            decimal quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Price = product.Price;
        }
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}