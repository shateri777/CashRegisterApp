namespace _1_OOP_Projekt_Kassasystem.ProductManagement
{
    class ProductManager
    {
        private ListOfProducts _listOfProducts;
        public ProductManager()
        {
            _listOfProducts = new ListOfProducts();
            InitializeProducts();
        }
        private void InitializeProducts()
        {
            Product product1 = new Product(1, "Banan", 9.99f, Units.Styck);
            _listOfProducts.AddProduct(product1);
            Product product2 = new Product(2, "Apelsin", 39.95f, Units.Kg);
            _listOfProducts.AddProduct(product2);
            Product product3 = new Product(3, "Karins Lasagne", 19.95f, Units.Styck);
            _listOfProducts.AddProduct(product3);
            Product product4 = new Product(4, "Äpple", 35.95f, Units.Kg);
            _listOfProducts.AddProduct(product4);
            Product product5 = new Product(5, "Snus", 42.95f, Units.Styck);
            _listOfProducts.AddProduct(product5);
        }
        public void DisplayProducts()
        {
            foreach (Product product in _listOfProducts.Products)
            {
                Console.WriteLine($"{product.Name}, Price: {product.Price}");
            }
        }
        public void DisplayChosenProducts(byte productId, List<Product> chosenProducts, float totalPrice, byte amount)
        {
            foreach (Product item in _listOfProducts.Products)
            {
                if (productId == item.Id)
                {
                    chosenProducts.Add(item);
                    totalPrice = item.Price * amount;
                    Console.WriteLine($"Du valde: {item.Name}");
                    Console.WriteLine($"Enhet: {item.Unit}");
                    Console.WriteLine($"Antal: {amount}");
                    Console.WriteLine($"Slutpriset är: {totalPrice}kr");
                }
            }
        }
    }
}
