using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList();
            //List();

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("book","kitap");
            dictionary.Add("table","tablo");
            dictionary.Add("computer","bilgisayar");

             
            Console.WriteLine(dictionary["table"]);
            Console.WriteLine(dictionary["book"]);

            foreach (var dic in dictionary)
            {
                Console.WriteLine(dic);
            }

            foreach (var dic in dictionary)
            {
                Console.WriteLine(dic.Key); // burada keylerine ulaştık istersek Value yazarakta ulaşabiliriz...
            }

            Console.WriteLine(dictionary.ContainsKey("glass"));         // Varsa True yoksa false döner
            Console.WriteLine(dictionary.ContainsKey("book"));       // Varsa True yoksa false döner   


            
            Console.WriteLine();


            Console.ReadLine();
        }

        private static void List()
        {
            List<string> cities = new List<string>();  // ben Array temelli collection oluşturmak istiyorum ama stringlerden oluşsun..
            cities.Add("Kars");
            cities.Add("Milas");
            cities.Add("Antakya");

            // Console.WriteLine(cities.Contains("Milas"));     Aralarında Milas adında bir cities varsa true döner yoksa false olarak döner...

            foreach (var city in cities)
            {
                Console.WriteLine(city);         // Foreach ile tüm listeyi gezebiliriz.
            }

            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer { Id =1, FirtName = "Emre"});
            //customers.Add(new Customer { Id =2, FirtName = "Mehmet"});

            List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1, FirtName = "Emre" },
                new Customer { Id = 2, FirtName = "Mehmet" }

            };


            var customer2 = new Customer
            {
                Id = 3,
                FirtName = "Salih"
            };

            customers.Add(customer2);
            customers.AddRange(new Customer[2]
            {
                new Customer{Id=4, FirtName = "Bilal"},
                new Customer{Id=5, FirtName = "Mert"}
            });

            var customer3 = new Customer { Id = 6, FirtName = "Murat" };
            customers.Add(customer3);

            //customers.Clear(); //Listenin tüm elemanlarını siler...

            Console.WriteLine(customers.Contains(customer2));  // var olan bir şeyi arayabilirsin var mı diye kontrol edebilirsin varsa true döner yoksa false döner...

            var index = customers.IndexOf(customer2);       // burada IndexOf ile customer2 'nin kaçıncı sırada olduğunu öğrenmek için kullanırım....
            Console.WriteLine("Index : {0}", index);

            var index2 = customers.LastIndexOf(customer2);      // sondan kaçıncı sırada olduğunu belirtir...
            Console.WriteLine("index2 : {0}", index2);

            customers.Insert(0, customer2);          // Insert ile istediğimiz indexe int yazarak ona ekleyebiliriz. (0,1,2,3,.......n) 



            //customers.Remove(customer3);          Remove ile silebilirsin customerlardan istediğini...
            //customers.RemoveAll(c => c.FirtName=="Salih"); Buna predicate denir. tüm FirstName = "Salih olanları siler."

            foreach (var customer in customers)
            {

                Console.WriteLine(customer.FirtName);
            }

            var count = customers.Count;
            Console.WriteLine("Count : {0}", count);         /// Kaç adet eleman kaldıysa onun sayısını gösterir.
        }

        private static void ArrayList()
        {
            //string[] cities = new string[2] { "Ankara", "istanbul" };
            //cities = new string[3];
            //Console.WriteLine(cities[0]);   /// bu durum içerisinde yeni bir Array new 'lediğimiz için eski aldığımız ve ya atadığımız değerler uçar gider.
            //Console.ReadLine();             /// Veri tabanını Arraylerle oluşturmak yönetme bu konuda çok yorucu ve zordur. bu yüzden collectionsları kullanmalıyız.
            ///Günümüzde zaten Arrayler kullanılmıyor desek sırıtmaz... Collectionslar daha çok kullanılıyor.
            ///
            ArrayList cities = new ArrayList();  /// Bakın burada new'lerken sayı vermedik ve her an ekleme yapabiliyoruz. Bu işimize oldukça fazla yarıyor ve kolaylaştırıyor. 
            cities.Add("Ankara");
            cities.Add("Adana");

            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
            cities.Add("Tekirdağ");
            cities.Add(2);

            Console.WriteLine(cities[2]);

            // ArrayList 'leri biz bir veri tipi yoksa kullanabiliriz.Type safe denir bu duruma. Böylelikle tip seçmeden rahatlıkla çalışabilirsiniz. Ancak collections'ları kullanırız.
        }
    }
    class Customer
    {
        public int Id { get; set; }
        public string FirtName { get; set; }
    }


}
