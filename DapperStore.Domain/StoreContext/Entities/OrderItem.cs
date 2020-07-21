using System;
using System.Collections.Generic;
using FluentValidator;

namespace DapperStore.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {

        public OrderItem(
            Product product, 
            int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Price = product.Price;

            if(product.QuantityOnHand < quantity)
                AddNotification("Quantidade", "Produto fora de estoque");
            
            product.DecreseQuantity(quantity);
        }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}