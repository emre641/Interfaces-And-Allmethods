using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferanceAndValueType
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 10;
            int number2 = 20;
            number2 = number1;
            number1 = 30;

            Console.WriteLine(number2);

            Console.WriteLine(number1);

            string[] cities1 = new string[] { "Ankra", "Adana", "Afyon"}; /// 101
            string[] cities2 = new string[] { "Bursa", "Bolu", "Balıkesir" };  /// 102
            cities2 = cities1;
            cities1[0] = "İstanbul";   /// Ankara İstanbul olarak değişecektir. ve bu ikisinde de güncellenecek...
            Console.WriteLine(cities2[0]); /// ekrana İstanbul yazacaktır.


            DataTable dataTable; /*= new DataTable();*/
            DataTable dataTable2 = new DataTable();
            dataTable = dataTable2;

            Console.ReadLine();
        }
    }
}
