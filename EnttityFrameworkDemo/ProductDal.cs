using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnttityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList();         // Entityframeworkte tabloya erişme kodu 
            }
        }

        public List<Product> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p=> p.Name.Contains(key)).ToList();         //  veri tabanından sadece ihtiyacı olanı alır yani daha performanslı
            }
        }

        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //context.Products.Add(product);
                var entity = context.Entry(product);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);        //Benim gönderdiğimi product ile veri tabanındakini eşitliyor, yani ilişkilendiriyor (Id üzerinden eşitler )
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext()) 
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)       // bu sorguda iki fiyat aralığında olanaları getirir 
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice>=min && p.UnitPrice<=max).ToList();
            }
        }

        public Product GetById(int id)          /// burada list olmasına gerek yok çünkü tek bir şey arıyoruz.
        {
            using (ETradeContext context = new ETradeContext())
            {
                var result =  context.Products.FirstOrDefault(p => p.Id == id); // varsa bu Id' yi getir yoksa null olarak getir
                return result;

            }
        }

    }
}
