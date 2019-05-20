using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;
using System.Linq.Dynamic.Core;
using Class;
using System.Linq;

namespace Linq
{
    // public class Adult : ISpecifications<User>
    // {
    //     public IsSatisfiedBy(User user)
    //     {
    //         return user.Age >= 19;
    //     }
    // }
    class Program
    {
        
        private static readonly IQueryable<User> userData = UserDataSeed().AsQueryable();

        static void Main(string[] args)
        {
            var user = userData.Where("FirstName == @1", 2, "Kevin").ToList();
            foreach (var u in user)
            {
                System.Console.WriteLine(u.LastName);
            }
        }
        private static List<User> UserDataSeed()
        {
            
            return new List<User>
            {
                new User{ ID = 1, FirstName = "Kevin", LastName = "Garnett", Age = 18},
                new User{ ID = 2, FirstName = "Stephen", LastName = "Curry", Age = 19},
                new User{ ID = 3, FirstName = "Kevin", LastName = "Durant", Age = 20}
            };
            

        }

        // private static Func<User, bool> GetDynamicQueryWithExpresionTrees(string propertyName, string val)
        // {
        //     //x =>
        //     var param = Expression.Parameter(typeof(User), "x");

        //     #region Convert to specific data type
        //     MemberExpression member = Expression.Property(param, propertyName);
        //     UnaryExpression valueExpression = GetValueExpression(propertyName, val, param);
        //     #endregion
        //     //val ("Curry")
        //     Expression body = Expression.Equal(member, valueExpression);
        //     //x => x.LastName == "Curry"
        //     var final = Expression.Lambda<Func<User, bool>>(body: body, parameters: param);
        //     return final.Compile();
        // }

        // private static UnaryExpression GetValueExpression(string propertyName, string val, ParameterExpression param)
        // {
        //     var member = Expression.Property(param, propertyName);
        //     var propertyType = ((PropertyInfo)member.Member).PropertyType;
        //     var converter = TypeDescriptor.GetConverter(propertyType);

        //     if (!converter.CanConvertFrom(typeof(string)))
        //         throw new NotSupportedException();

        //     var propertyValue = converter.ConvertFromInvariantString(val);
        //     var constant = Expression.Constant(propertyValue);
        //     return Expression.Convert(constant, propertyType);
        // }

        private static Func<User, bool> GetDynamicFunc(string property, string val)
        {
            Func<User, bool> exp = (t) => true;
            switch (property.ToLower())
            {

                case "id":
                    exp = d => d.ID == Convert.ToInt32(val);
                    break;
                case "firstname":
                    exp = d => d.FirstName == val;
                    break;
                case "lastname":
                    exp = d => d.LastName == val;
                    break;
                default:
                    throw new InvalidCastException(nameof(property));


            }
            return exp;
        }
    }

}

