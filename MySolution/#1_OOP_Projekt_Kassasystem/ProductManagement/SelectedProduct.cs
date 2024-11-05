using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_OOP_Projekt_Kassasystem.ProductManagement
{
    public class SelectedProduct
    {
        public Product Product { get; set; }
        public ushort Amount {  get; set; }
        public SelectedProduct(Product product, ushort amount)
        {
            Product = product;
            Amount = amount;
        }
    }
}
