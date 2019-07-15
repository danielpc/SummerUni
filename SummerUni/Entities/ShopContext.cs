using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SummerUni.Entities
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<Product>()
                .HasOne(x => x.Cart)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CartId)
                .OnDelete(DeleteBehavior.Cascade);
            
            base.OnModelCreating( builder );
        }
    }
}