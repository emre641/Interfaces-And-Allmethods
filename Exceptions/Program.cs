using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExceptionIntro();

            try
            {
                Find();
            }
            catch (MyRecordNotFoundException exception)
            {
                Console.WriteLine(exception.Message); 
            }

            HandleException(() => 
            {
                Find();                         // Action denilen şey aslında burası
            });

            Console.ReadLine();

        }

        private static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
        
            }
        }

        private static void Find()
        {
            List<string> student = new List<string> { "Engin", "Derin", "Salih" };


            if (!student.Contains("Ahmet"))
            {
                throw new MyRecordNotFoundException("Record Not Found");
                
            }
            else
            {
                Console.WriteLine("record found!");
            }
        }

        private static void ExceptionIntro()
        {
            try
            {
                string[] students = new string[3] { "Emre", "Mehmet", "Ali" };

                students[3] = "Ahmet";
            }

            catch (IndexOutOfRangeException exception)        // bu hataya denk gelen bir hata değilse alttaki catch Exception olmasının sebebi hepsinin inheritance olması Exceptiondan
            {
                Console.WriteLine(exception.Message);

            }

            catch (Exception exception)                 //Exception hatası üstteki çalışmazsa çalışır
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
