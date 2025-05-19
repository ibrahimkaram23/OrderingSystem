using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Data.Entities.Identity;
using System.Reflection;
using OrderingSystem.Data.Entities.Stock;
using OrderingSystem.Data.Entities.Orders;

namespace OrderingSystem.infrastructure.Data
{
    public class APPDBContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private readonly IEncryptionProvider _encryptionProvider;
#pragma warning disable CS8618
        public APPDBContext()
#pragma warning restore CS8618
        {

        }

        public APPDBContext(DbContextOptions<APPDBContext> options) : base(options)
        {
            _encryptionProvider = new GenerateEncryptionProvider("3e482d3d1bbe47af818ad6e445ef4e92");
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<StatusLookup> StatusLookups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.UseEncryption(_encryptionProvider);
            modelBuilder.Entity<Category>()
            .OwnsOne(c => c.Name, c => { c.ToJson(); });

            modelBuilder.Entity<Product>()
                .OwnsOne(c => c.Name, c => { c.ToJson(); });

            modelBuilder.Entity<Color>()
                .OwnsOne(c => c.Name, c => { c.ToJson(); });
            modelBuilder.Entity<Size>()
                .OwnsOne(c => c.Name, c => { c.ToJson(); });

        }


    }
}
