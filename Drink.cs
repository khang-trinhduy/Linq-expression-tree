using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Drinks
{
    public class Drink
    {
        public string Name { get; set; }
        public DateTime ManufacturedOn { get; set; }
        public List<string> With { get; set; }

        internal static Drink ColdVodka()
        {
            return new Drink {
                Name = "Vodka",
                ManufacturedOn = DateTime.Now.Date,
                With = new List<string> {"Ice", "Lemon"}
            };
        }

        internal static Drink WarmTea()
        {
            return new Drink {
                Name = "Black Tea",
                ManufacturedOn = DateTime.Now.Date,
                With = new List<string> {"Cookies"}
            };
        
        }

        internal static Drink OrangeJuice()
        {
            return new Drink {
                Name = "Orange juice",
                ManufacturedOn = DateTime.Now.Date,
                With = new List<string> {}
            };
        }
    }
}