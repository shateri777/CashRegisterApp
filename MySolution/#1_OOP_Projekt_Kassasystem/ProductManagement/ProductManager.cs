

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
        public void DisplayChosenProducts(string productId, List<SelectedProduct> selectedProducts, ref float totalPrice, ushort amount)
        {
            foreach (var product in _listOfProducts.Products)
            {
                if (productId == product.Id.ToString())
                {
                    SelectedProduct? selectedProduct = null;
                    foreach (var sp in selectedProducts)
                    {
                        if (sp.Product.Id == product.Id)
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
                        selectedProducts.Add(new SelectedProduct(product, amount));
                    }
                    float itemTotalPrice = product.Price * amount;
                    totalPrice += itemTotalPrice;
                    Console.WriteLine($"Du valde: {product.Name}");
                    Console.WriteLine($"Enhet: {product.Unit}");
                    Console.WriteLine($"Antal: {amount}");
                    Console.WriteLine($"Slutpriset är: {totalPrice} kr");
                }
            }
            Console.WriteLine("\nDina totala produkter:");
            foreach (var selectedProduct in selectedProducts)
            {
                Console.WriteLine($"{selectedProduct.Product.Name}, {selectedProduct.Product.Price} * {selectedProduct.Amount} = {selectedProduct.Product.Price * selectedProduct.Amount} kr");
            }
            Console.WriteLine($"Totalt belopp för alla produkter: {totalPrice} kr");
        }
    }
}
