using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonManager personManager = new PersonManager("Product");
            personManager.Add();

            Teacher.Number = 12;
            Utilities.Validate();
            Manager.DoSomething();

            Manager manager = new Manager();
            manager.DoSomething2();
            

            Console.ReadLine();
        }
    }

    class BaseClass
    {
        private string _entity;
        public BaseClass(string entity)
        {
            _entity = entity;
        }
        public void Message()
        {
            Console.WriteLine("{0} message", _entity);
        }

    }
    class PersonManager : BaseClass
    {
        public PersonManager(string entity):base(entity)
        {
                
        }

        public void Add()
        {
            Console.WriteLine("Veri tabanına eklendi");
            Message();
        }

    }


    static class Teacher
    {
        public static int Number { get; set; }
    }

    static class Utilities
    {
        static Utilities()
        {
            /// mutlaka çalışması gereken bir şey varsa buraya yazabilirsiniz.
        }
        public static void Validate()
        {
            Console.WriteLine("Validate is done");
        }
    }

    class Manager
    {
        public static void DoSomething()
        {
            Console.WriteLine("Done");
        }

        public void DoSomething2()
        {
            Console.WriteLine("Done 2");
        }

    }


}
