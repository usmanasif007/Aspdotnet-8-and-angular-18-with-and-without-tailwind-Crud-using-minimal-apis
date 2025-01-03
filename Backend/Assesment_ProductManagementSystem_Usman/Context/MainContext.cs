using Assesment_ProductManagementSystem_Usman.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Assesment_ProductManagementSystem_Usman.Context
{
    public class MainContext : DbContext
    {
        public MainContext() { }
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        public virtual DbSet<Product> Products { get; set; }
    }
}
