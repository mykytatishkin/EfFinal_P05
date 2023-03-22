using EfFinal_P05;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

/* CONFIGURATION */
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var options = new DbContextOptionsBuilder<BookDbContext>()
    .UseLazyLoadingProxies()
    .UseSqlServer(config.GetConnectionString("MainConnectionString"))
    .Options;

DataBaseClass dbBaseClass = new DataBaseClass(options);



//using (var db = new BookDbContext(options))
//{
//    db.Books.AddRange(new Book
//    {
//        Name = "Book1",
//        Author = "Author1",
//        Publisher = "Publisher1",
//        PageCount = 100,
//        Style = "Style1",
//        Created = new DateTime(2000, 01, 01),
//        SelfPrice = 100,
//        SellPrice = 150,
//        Continuos = 1
//    },
//    new Book
//    {
//        Name = "Book2",
//        Author = "Author2",
//        Publisher = "Publisher2",
//        PageCount = 200,
//        Style = "Style2",
//        Created = new DateTime(1000, 02, 01),
//        SelfPrice = 2000,
//        SellPrice = 25000,
//        Continuos = 2
//    },
//    new Book
//    {
//        Name = "Book3",
//        Author = "Author3",
//        Publisher = "Publisher3",

//        PageCount = 300,
//        Style = "Style3",
//        Created = new DateTime(3000, 03, 03),

//        SelfPrice = 3000,
//        SellPrice = 35000,
//        Continuos = 3
//    });
//    db.SaveChanges();
//}

dbBaseClass.addBook("Book4", "Author4", "Publisher4", 400, "Style4", new DateTime(400, 4, 4), 4, 400, 4);
dbBaseClass.removeBook("Book4", "Author4", "Publisher4", 400, "Style4", new DateTime(400, 4, 4), 4, 400, 4);

Console.WriteLine("DbChanged\n");

using (var db = new BookDbContext(options)) // Lazy loading
{
    var books = db.Books.ToList();
    foreach (var book in books)
    {
        Console.WriteLine($"Name:{book.Id} {book.Name}, Author: {book.Author}, Publisher: {book.Publisher}\n" +
                          $"Page Count: {book.PageCount}, Style: {book.Style}, Created: {book.Created}\n" +
                          $"Self Price: {book.SelfPrice}, Sell Price: {book.SellPrice}, Continus: {book.Continuos}\n");
    }

}

Console.WriteLine("Output 1 ended");