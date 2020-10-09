using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; initial catalog=ETrade;integrated security=true");
        public List<Product> GetAll()
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("Select * from Products", _connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())       //Gelen kayıtları tek tek oku, okudukça da döngünün içini çalıştır
            {
                Product product = new Product           //her okuduğunu Products listesine ekle 
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
                products.Add(product);          //burada da listeye ekle
            }

            reader.Close();
            _connection.Close();

            return products;            // listeyi dönüyoruz

        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }


        //public DataTable GetAll2()
        //{
        //    SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; initial catalog=ETrade;integrated security=true");
        //    if (connection.State==ConnectionState.Closed)
        //    {
        //        connection.Open();
        //    }

        //    SqlCommand command = new SqlCommand("Select * from Products",connection);

        //    SqlDataReader reader =  command.ExecuteReader();

        //    DataTable dataTable = new DataTable();             //DataTable  Daha çok yer kaplar ve pek kullanılmaz daha küçük projelerde kullanılır.
        //    dataTable.Load(reader);

        //    reader.Close();
        //    connection.Close();

        //    return dataTable; 

        //} 

        public void Add(Product product)        
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Insert into Products values(@name, @unitPrice, @stockAmount)", _connection);   // parantez içine nereden alacaksam bilgiyi onları yazıyorum

            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();      // int döndürür etkilenen kayıt sayısını döndürür 
            

            _connection.Close();

        }

        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Product set Name=@name, UnitePrice=@unitPrice, StockAmount=@stockAmount where Id=@id", _connection);   // parantez içine nereden alacaksam bilgiyi onları yazıyorum

            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@id", product.Id);
            command.ExecuteNonQuery();      // int döndürür etkilenen kayıt sayısını döndürür 


            _connection.Close();

        }

    }
}
