using DapperStore.Shared.Entities;
using FluentValidator;

namespace DapperStore.Domain.StoreContext.Entities
{
    public class Product : Entity
    {

        public Product(
            string title, 
            string description, 
            string image, 
            decimal price,
            int quantityOnHand)
        {
            this.Title = title;
            this.Description = description;
            this.Image = image;
            this.Price = price;
            this.QuantityOnHand = quantityOnHand;
        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityOnHand { get; set; }

        public override string ToString()
        {
            return this.Title;
        }

        public void DecreseQuantity(int qtd)
        {
            QuantityOnHand = qtd;
        }
    }
}