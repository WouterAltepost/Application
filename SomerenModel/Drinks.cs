using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drinks
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool IsAlcoholic { get; set; } // 0 = alcholic, 1 = non alcoholic
    }

    enum ListOfDrinks
    {
        Fanta, 
        Coke,
        Beer,
        Wine,
        Water
    }

    enum DrinkType
    {
        Alcoholic = 0,
        NonAlcoholic = 1
    }
}
