namespace DapperStore.Domain.StoreContext.Entities
{
    public class Product
    {

        public Product(string title, string description, string image, string price)
        {
            this.Title = title;
            this.Description = description;
            this.Image = image;
            this.Price = price;

        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public string Price { get; private set; }
    }
}