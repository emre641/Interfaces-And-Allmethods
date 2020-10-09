using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Custumer custumer = new Custumer();
            //Person[] persons = new Person[3]
            //{
            //    new Custumer(),
            //    new Person(),
            //    new Student()
            //};

            Person[] persons = new Person[3]
           {
                new Custumer{ Name = "Emre"},
                new Person{ Name = "Yasir"},
                new Student{Name = "Mert" }
           };

            foreach (var person in persons)
            {
                Console.WriteLine(person.Name);
            }

            Console.ReadLine();

        }

        class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
        }

        class MyClass
        {

        }
                

        class Custumer : Person
        {
            public string City { get; set; }
        }

        class Student : Person
        {
            public string Departmen { get; set; }
        }
    }
}
