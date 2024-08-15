using day_01.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace day_01.Data
{
    public class ApplicationDbConteXt: DbContext

    {
      public ApplicationDbConteXt(DbContextOptions<ApplicationDbConteXt> options): base(options)
        {

        } 
      public DbSet<Category> Categories{ get; set; }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrders = 1 },  // Creating an entries in the database
                 new Category { Id = 2, Name = "History", DisplayOrders = 2 },
                  new Category { Id = 3, Name = "ASCHI", DisplayOrders = 3 }
                );
        }
    }
}
