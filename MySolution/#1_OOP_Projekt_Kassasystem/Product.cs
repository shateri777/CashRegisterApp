using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_OOP_Projekt_Kassasystem
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public Units Unit { get; set; }

        public Product(int  id, string name, float price, Units unit)
        {
            Id = id;
            Name = name;
            Price = price;
            Unit = unit;
        }
    }
}
