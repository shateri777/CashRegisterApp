namespace _1_OOP_Projekt_Kassasystem.ProductManagement
{
    public class ListOfProducts
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
