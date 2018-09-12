namespace eu.cdab.GraphQL_Gokhan.Data
{
    using Microsoft.EntityFrameworkCore;

    using eu.cdab.GraphQL_Gokhan.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}