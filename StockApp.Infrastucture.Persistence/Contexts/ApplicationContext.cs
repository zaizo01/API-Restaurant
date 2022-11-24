using Microsoft.EntityFrameworkCore;
using StockApp.Core.Domain.Common;
using StockApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockApp.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }   
        public DbSet<Order> Orders { get; set; }   
        public DbSet<Table> Tables { get; set; }   
        public DbSet<Dish> Dishs { get; set; }   
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<OrderTableDish> OrderTableDishs { get; set; }

        //public DbSet<DishIngredient> DishIngredients { get; set; }
      

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            modelBuilder.Entity<Table>()
                .Property(prop => prop.TableStatus)
                .HasDefaultValue(Core.Domain.Enums.TableStatus.Aviable);

            modelBuilder.Entity<DishIngredient>()
                 .HasKey(di => new { di.DishId, di.IngredientId });

            modelBuilder.Entity<OrderTableDish>()
                 .HasKey(o => new { o.OrderId, o.TableId, o.DishId });

            modelBuilder.Entity<OrderTableDish>()
                  .HasOne(t => t.Order)
                  .WithMany(t => t.OrderTableDishs)
                  .HasForeignKey(t => t.OrderId)
                  .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderTableDish>()
                 .HasOne(t => t.Table)
                 .WithMany(t => t.OrderTableDishs)
                 .HasForeignKey(t => t.TableId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderTableDish>()
                   .HasOne(t => t.Dish)
                   .WithMany(t => t.OrderTableDishs)
                   .HasForeignKey(t => t.DishId)
                   .OnDelete(DeleteBehavior.NoAction);

            #region tables

            modelBuilder.Entity<Product>()
                .ToTable("Products");

            modelBuilder.Entity<Category>()
                .ToTable("Categories");

       

            #endregion

            #region "primary keys"
            modelBuilder.Entity<Product>()
                .HasKey(product => product.Id);

            modelBuilder.Entity<Category>()
                .HasKey(category => category.Id);

            #endregion

            #region "Relationships"
            modelBuilder.Entity<Category>()
                .HasMany<Product>(category => category.Products)
                .WithOne(product => product.Category)
                .HasForeignKey(product => product.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            #endregion

           // modelBuilder.Entity<Order>()
           //.HasOne(p => p.Dishes)
           //.WithMany().OnDelete(DeleteBehavior.NoAction);

           // modelBuilder.Entity<Order>()
           //.HasOne(p => p.Table)
           //.WithMany().OnDelete(DeleteBehavior.NoAction);


            #region "Property configurations"

            #region products

            modelBuilder.Entity<Product>().
                Property(product => product.Name)
                .IsRequired();

            modelBuilder.Entity<Product>().
               Property(product => product.Price)
               .IsRequired();

            #endregion

            #region categories
            modelBuilder.Entity<Category>().
              Property(category => category.Name)
              .IsRequired()
              .HasMaxLength(100);
            #endregion       

            #endregion

        }

    }
}
