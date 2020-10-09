using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer()
            {
                Id = 1,
                //FirstName = "Marli",
                LastName = "Çarli",
                Age = 26

            };

            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            Console.ReadLine();
        }
    }

    [ToTable("Customers")]
    class Customer
    {
        [PrimaryKey]
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        [RequiredProperty]

        public string LastName { get; set; }
        [RequiredProperty]

        public int Age { get; set; }
    }

    class CustomerDal
    {
        [Obsolete("Don't use Add, instead use NewAdd Method")]
        public void Add(Customer customer)
        {
            Console.WriteLine("{0} {1} {2} {3}  Customer added!",customer.Id,customer.FirstName,customer.LastName,customer.Age);
        }

        public void NewAdd(Customer customer)
        {
            Console.WriteLine("{0} {1} {2} {3}  Customer added!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }


    }
    [AttributeUsage(AttributeTargets.All)]              // Bu Attribute herkese kullanabilirsin. All değilde class yazsaydım sadece classların üzerine eklenebilir
    class RequiredPropertyAttribute : Attribute
    {

    }

    class ToTableAttribute : Attribute
    {
        private string _tableName;

        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }
}
