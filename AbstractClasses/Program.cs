﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Oracle();
            database.Add();
            database.Delete();

            Database database2 = new Oracle();
            database2.Add();
            database2.Delete();

            Console.ReadLine();

        }

        abstract class Database
        {
            public void Add()
            {
                Console.WriteLine("Veri ekleme metodu çalışır.");
            }

            public abstract void Delete();
            
        }

        class SqlServer : Database
        {
            public override void Delete()
            {
                Console.WriteLine("Delete by Sql");
            }
        }

        class Oracle : Database
        {
            public override void Delete()
            {
                Console.WriteLine("Delete by Oracle");
            }
        }

    }
}
