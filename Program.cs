using System;
using Drinks;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Drink vodka = Drink.ColdVodka();
            Drink blackTea = Drink.WarmTea();
            Drink orangeJuice = Drink.OrangeJuice();
            List<Drink> drinks = new List<Drink> {vodka, blackTea, orangeJuice};
            ParameterExpression obj = Expression.Parameter(typeof(Drink), "Drink");
            MemberExpression prop = Expression.Property(obj, "Name");
            ConstantExpression cons = Expression.Constant("Vodka", typeof(string));
            BinaryExpression expression = Expression.Equal(prop, cons);
            var isVodka = Expression.Lambda<Func<Drink, bool>>(expression, new [] {obj});
            System.Console.WriteLine(isVodka.Parameters.Count);
        }
    }
}
