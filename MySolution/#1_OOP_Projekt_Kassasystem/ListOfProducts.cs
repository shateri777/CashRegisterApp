using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_OOP_Projekt_Kassasystem
{
    public class ListOfProducts
    {
        public List<Product> Products {  get; set; } = new List<Product>();


        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
