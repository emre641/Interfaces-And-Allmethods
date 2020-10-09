using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities(); // Convert işlemleri yapan metotlar olabilir içinde
            List<string> result = utilities.BuildList<string>("Ankara", "İzmir", "İstanbul");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            List<Customer> result2 = utilities.BuildList<Customer>(new Customer {FirstName = "Emre" }, new Customer { FirstName = "Ziya" });

            foreach (var customer in result2)
            {
                Console.WriteLine(customer.FirstName);
            }
            Console.ReadLine();
        }
    }

    class Utilities
    {
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }

    class Product : IEntity
    {

    }
    interface IProductDal : IRepository<Product>
    {
        
        
    }

    interface ICustomerDal : IRepository<Customer>
    {

    }

    interface IStudentDal : IRepository<Student>
    {

    }

    class Student : IEntity
    {

    }

    interface IEntity
    {

    }



    class Customer : IEntity
    {
        public string FirstName { get; set; }
    }


    // T aslında type yani tip, entity ise varlık anlamına geliyor. Yani hepsini ortak bir repositoryde yazıyorum tipi de aynı oluyor 
    // Her yapıya aynı yetenekler oluşacak zaten o yüzden hepsini tek tip yaparsam tek bir ana yetenek kısmı oluşturmam yetiyor.
    // burada where diyerek kısıtlama getiriyoruz. 1- class olması gerekiyor2- newlenebilir olması gerekn bir şey yazılabilir anlamına geliyor.
    // sadece veri tabanı nesneleri yazılabilir olsun
    // new daima sona gelir ve IEntityden referans almayanda yazılamaz duruma geldi.

    interface IRepository<T> where T: class,IEntity,new()
    {                               

        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    interface IRepository2<T> where T : struct // sadece değer tipleri koymak istersek kısıtlamaya böyle yazılır.
    {

        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    class ProductDal : IProductDal      // bu şekilde yazıp implement ederseniz her şey tipe göre gelir mesela burada product tipi olduğu için Product gelir.
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }

    class CostumerDal : ICustomerDal        // Burada da implement sonucunda CustomerDal a Customer tipi gelmmiş oldu. Yani daha pratik
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
