using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingApp
{
    public class ShoppingApp: DbContext
    {
        public DbSet<Account> Accounts { get; set; }   
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CartEntry> Cart { get; set; }
        public DbSet<CartEntry> CartEntries { get; set; }
        public DbSet<OrderedItem> OrderedItems { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public ShoppingApp()
        {

        }

        public ShoppingApp(DbContextOptions<ShoppingApp> Options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= Online Shopping  Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts");

                entity.HasKey(e => e.UserName)
                      .HasName("PK_Accounts");

                entity.Property(e => e.UserName)
                      .IsRequired();

                entity.Property(e => e.MobileNo)
                      .HasMaxLength(10)
                      .IsRequired();

                entity.Property(e => e.Email);

                entity.Property(e => e.Address)
                .IsRequired();
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payments");

                entity.HasKey(e => e.ID)
                .HasName("PK_PaymentMethodId");

                entity.Property(e => e.ID)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.CardName)
                .IsRequired();

                entity.Property(e => e.CardNo)
                .IsRequired();

                entity.Property(e => e.CVV)
                .IsRequired();

                entity.Property(e => e.PaymentMethod)
                .IsRequired();

                entity.HasOne(e => e.Account)
                .WithMany()
                .HasForeignKey(e => e.UserName);

                entity.Property(e => e.ValidDate)
                .IsRequired();

            });
            

            modelBuilder.Entity<CartEntry>(entity =>
            {
                entity.ToTable("CartEntries");

                entity.HasKey(e => e.ItemId)
                 .HasName("PK_ItemId");

                entity.Property(e => e.ItemId)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Item)
                .IsRequired();

                entity.Property(e => e.Quantity)
                .IsRequired();

                entity.Property(e => e.Size)
                .IsRequired();

                entity.Property(e => e.Price)
               .IsRequired();

                entity.HasOne(e => e.Account)
                .WithMany()
                .HasForeignKey(e => e.UserName);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.ToTable("OrderDetails");

                entity.HasKey(e => e.OrderId)
                 .HasName("PK_OrderId");

                entity.Property(e => e.OrderId)
                .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Account)
                .WithMany()
                .HasForeignKey(e => e.UserName);

                entity.Property(e => e.DeliveryAddress)
                .IsRequired();

                entity.Property(e => e.DeliveryDate)
                .IsRequired();
            });

            modelBuilder.Entity<OrderedItem>(entity =>
            {
                entity.ToTable("OrderedItems");

                entity.HasKey(e => e.ItemId)
                 .HasName("PK_OrderedItemId");

                entity.Property(e => e.ItemId)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Item)
                .IsRequired();

                entity.Property(e => e.Quantity)
                .IsRequired();

                entity.Property(e => e.Size)
                .IsRequired();

                entity.Property(e => e.Price)
               .IsRequired();

                entity.HasOne(e => e.Account)
                .WithMany()
                .HasForeignKey(e => e.UserName);

                entity.HasOne(e => e.OrderDetails)
                .WithMany()
                .HasForeignKey(e => e.OrderId);
            });

        }
       
        
    }
}
