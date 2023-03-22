using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFinal_P05
{
    public class DataBaseClass
    {
        DbContextOptions<BookDbContext> options1;

        public DataBaseClass(DbContextOptions<BookDbContext> options)
        {
            options1 = options;
        }
        public void addBook(string name, string author, string publisher, int pageCount, string style, DateTime created, decimal selfPrice, decimal sellPrice, int continuos)
        {
            using (var db = new BookDbContext(options1))
            {
                db.Books.AddRange(new Book
                {
                    Name = name,
                    Author = author,
                    Publisher = publisher,
                    PageCount = pageCount,
                    Style = style,
                    Created = created,
                    SelfPrice = selfPrice,
                    SellPrice = sellPrice,
                    Continuos = continuos
                });
                db.SaveChanges();
            }
        }
        public void removeBook(int id)
        {
            using (var db = new BookDbContext(options1))
            {
                var temp = db.Books.FirstOrDefault(x => x.Id == id);
                db.Remove(temp);
                db.SaveChanges();
            }
        }
        public void editBook(int id,string name, string author, string publisher, int pageCount, string style, DateTime created, decimal selfPrice, decimal sellPrice, int continuos)
        {
            using (var db = new BookDbContext(options1)) // Lazy loading
            {

                var temp = db.Books.FirstOrDefault(x => x.Id == id);
                temp.Name = name;
                temp.Author = author;
                temp.Publisher = publisher;
                temp.PageCount = pageCount;
                temp.Style = style;
                temp.Created = created;
                temp.SelfPrice = selfPrice;
                temp.SellPrice = sellPrice;
                temp.Continuos = continuos;
                db.SaveChanges();

            }
        }
    }
}
