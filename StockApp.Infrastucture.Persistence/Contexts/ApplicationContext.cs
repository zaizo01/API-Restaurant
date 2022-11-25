using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Domain.Common;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

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


        }

    }
}
