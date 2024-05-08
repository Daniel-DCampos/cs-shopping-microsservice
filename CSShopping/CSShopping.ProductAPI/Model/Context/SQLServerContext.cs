using Microsoft.EntityFrameworkCore;

namespace CSShopping.ProductAPI.Model.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext() {}
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Name",
                Price = 99.99M,
                Description = "Description",
                CategoryName = "Category",
                ImageUrl = ""
            },
            new Product
            {
                Id = 3,
                Name = "Name 2",
                Price = 199.99M,
                Description = "Description 2",
                CategoryName = "Category 2",
                ImageUrl = ""
            });
        }
    }
}
