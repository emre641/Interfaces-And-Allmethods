using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
     class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(42);
            customerManager.List();

            Product product = new Product { Id = 1, Name = "Emre" };
            Product product1 = new Product(2, "Computer");




            Console.ReadLine();
        }

        class CustomerManager
        {
            private int _count = 15;
            public CustomerManager(int count)
            {
                _count = count;
            }

            public CustomerManager()
            {

            }
            public void List()
            {
                Console.WriteLine("Listed {0} items", _count);
            }

            public void Add()
            {
                Console.WriteLine("Added");
            }

            class Product
            {
                public Product()
                {

                }
                private int _id;
                private string _name;
                public Product(int id, string name)
                {
                    _id = id;
                    _name = name;

                }
                public int Id { get; set; }
                public string Name { get; set; }
            }

        }
    }
}
