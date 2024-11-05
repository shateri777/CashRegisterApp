

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
                Console.WriteLine($"ID: {product.Id}, {product.Name}, Price: {product.Price}");
            }
        }
        public void DisplayChosenProducts(string productId, List<SelectedProduct> chosenProducts, ref float totalPrice, ushort amount)
        {
            foreach (Product item in _listOfProducts.Products)
            {
                if (productId == item.Id.ToString())
                {
                    SelectedProduct selectedProduct = null;
                    foreach (var sp in chosenProducts)
                    {
                        if (sp.Product.Id == item.Id)
                        {
                            selectedProduct = sp;
                            break;
                        }
                    }
                    if (selectedProduct != null)
                    {
                        selectedProduct.Amount += amount;
                    }
                    else
                    {
                        chosenProducts.Add(new SelectedProduct(item, amount));
                    }
                    float itemTotalPrice = item.Price * amount;
                    totalPrice += itemTotalPrice;
                    Console.WriteLine($"Du valde: {item.Name}");
                    Console.WriteLine($"Enhet: {item.Unit}");
                    Console.WriteLine($"Antal: {amount}");
                    Console.WriteLine($"Slutpriset är: {totalPrice} kr");
                }
            }
            Console.WriteLine("\nDina totala produkter:");
            foreach (var selectedProduct in chosenProducts)
            {
                Console.WriteLine($"{selectedProduct.Product.Name}, {selectedProduct.Product.Price} * {selectedProduct.Amount} = {selectedProduct.Product.Price * selectedProduct.Amount} kr");
            }
            Console.WriteLine($"Totalt belopp för alla produkter: {totalPrice} kr");
        }
    }
}
