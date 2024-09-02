using Web.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Web.dataAccess.Data
{

    public class ApplicationDbConteXt : DbContext

    {
        public ApplicationDbConteXt(DbContextOptions<ApplicationDbConteXt> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrders = 1 },
                 new Category { Id = 2, Name = "History", DisplayOrders = 2 },
                  new Category { Id = 3, Name = "ASCHI", DisplayOrders = 3 }

                );
            modelBuilder.Entity<Product>().HasData(
     new Product
     {
         Id = 1,
         Title = "Fortune of Time",
         Author = "Billy Spark",
         Description = "A thrilling adventure through time and space.",
         ISBN = "123DASLFJ",
         ListPrice = 99,
         Price = 90,
         Price50 = 80,
         Price100 = 85,
         CategoryId= 1,
         ImageUrl = ""
     },
     new Product
     {
         Id = 2,
         Title = "C# in Depth",
         Author = "Jon Skeet",
         Description = "A deep dive into the features of C# and how to use them effectively.",
         ISBN = "987JSDKL45",
         ListPrice = 60,
         Price = 55,
         Price50 = 50,
         Price100 = 48,
         CategoryId = 1,
         ImageUrl = ""
     },
     new Product
     {
         Id = 3,
         Title = "JavaScript: The Good Parts",
         Author = "Douglas Crockford",
         Description = "An insightful guide to the best parts of JavaScript.",
         ISBN = "456JKLDF89",
         ListPrice = 45,
         Price = 40,
         Price50 = 35,
         Price100 = 30,
         CategoryId = 1,
         ImageUrl = ""
     },
     new Product
     {
         Id = 4,
         Title = "Clean Code",
         Author = "Robert C. Martin",
         Description = "A handbook of agile software craftsmanship.",
         ISBN = "789KLJSD65",
         ListPrice = 70,
         Price = 65,
         Price50 = 60,
         Price100 = 55,
         CategoryId = 2,
         ImageUrl = ""
     },
     new Product
     {
         Id = 5,
         Title = "The Pragmatic Programmer",
         Author = "Andrew Hunt, David Thomas",
         Description = "Your journey to mastery in software development.",
         ISBN = "159DFHJK33",
         ListPrice = 80,
         Price = 75,
         Price50 = 70,
         Price100 = 65,
         CategoryId = 2,
         ImageUrl = ""
     },
     new Product
     {
         Id = 6,
         Title = "Design Patterns: Elements of Reusable Object-Oriented Software",
         Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
         Description = "A comprehensive guide to design patterns in software engineering.",
         ISBN = "423JDSKLF23",
         ListPrice = 95,
         Price = 90,
         Price50 = 85,
         Price100 = 80,
         CategoryId = 3,
         ImageUrl = ""
     }
 );

        }
    }
}
