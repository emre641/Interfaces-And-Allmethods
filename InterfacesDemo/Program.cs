using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorker[] workers = new IWorker[3]
            {
                new Managers(),
                new Robot(),
                new Worker()
            };

            foreach (var worker in workers)
            {
                worker.Work();                      /// workerları gez hepsine çalış de
            }

            IEat[] eats = new IEat[2]
            {
                new Managers(),
                new Worker(),
            };

            foreach (var eat in eats)
            {
                eat.Eat();
            }
 
        }

        interface IWorker
        {
            void Work();
          
        }

        interface IEat
        {
            void Eat();
        }

        interface ISalary
        {
            void Salary();
        }

        class Managers : IWorker, IEat, ISalary
        {
            public void Eat()
            {
                  
            }

            public void Salary()
            {
                throw new NotImplementedException();
            }

            public void Work()
            {
                throw new NotImplementedException();
            }
        }

        class Worker : IWorker, IEat, ISalary
        {
            public void Eat()
            {
                throw new NotImplementedException();
            }

            public void Salary()
            {
                throw new NotImplementedException();
            }

            public void Work()
            {
                throw new NotImplementedException();
            }
        }

        class Robot : IWorker
        {
            public void Work()
            {
                throw new NotImplementedException();
            }
        }

    }
}
