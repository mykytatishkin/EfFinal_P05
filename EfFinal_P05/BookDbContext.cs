using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFinal_P05
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
