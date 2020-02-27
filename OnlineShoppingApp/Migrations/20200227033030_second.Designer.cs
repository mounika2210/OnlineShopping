﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShoppingApp;

namespace OnlineShoppingApp.Migrations
{
    [DbContext(typeof(ShoppingApp))]
    [Migration("20200227033030_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineShoppingApp.Account", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int?>("MyPaymentCardNo")
                        .HasColumnType("int");

                    b.HasKey("UserName")
                        .HasName("PK_Accounts");

                    b.HasIndex("MyPaymentCardNo");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("OnlineShoppingApp.CartEntry", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ItemId")
                        .HasName("PK_ItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserName");

                    b.ToTable("cart");
                });

            modelBuilder.Entity("OnlineShoppingApp.OrderDetails", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountUserName1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CartEntryItemId")
                        .HasColumnType("int");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId")
                        .HasName("PK_OrderId");

                    b.HasIndex("AccountUserName1");

                    b.HasIndex("CartEntryItemId");

                    b.HasIndex("UserName");

                    b.ToTable("orderdetails");
                });

            modelBuilder.Entity("OnlineShoppingApp.Payment", b =>
                {
                    b.Property<int>("CardNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<string>("CardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ValidDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardNo")
                        .HasName("PK_CardNo");

                    b.HasIndex("UserName");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("OnlineShoppingApp.Account", b =>
                {
                    b.HasOne("OnlineShoppingApp.Payment", "MyPayment")
                        .WithMany()
                        .HasForeignKey("MyPaymentCardNo");
                });

            modelBuilder.Entity("OnlineShoppingApp.CartEntry", b =>
                {
                    b.HasOne("OnlineShoppingApp.OrderDetails", "OrderDetails")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShoppingApp.Account", "Account")
                        .WithMany()
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("OnlineShoppingApp.OrderDetails", b =>
                {
                    b.HasOne("OnlineShoppingApp.Account", null)
                        .WithMany("OrderHistory")
                        .HasForeignKey("AccountUserName1");

                    b.HasOne("OnlineShoppingApp.CartEntry", "CartEntry")
                        .WithMany()
                        .HasForeignKey("CartEntryItemId");

                    b.HasOne("OnlineShoppingApp.Account", "Account")
                        .WithMany()
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("OnlineShoppingApp.Payment", b =>
                {
                    b.HasOne("OnlineShoppingApp.Account", "Account")
                        .WithMany()
                        .HasForeignKey("UserName");
                });
#pragma warning restore 612, 618
        }
    }
}
