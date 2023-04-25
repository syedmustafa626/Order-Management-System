﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagement1.Models;

namespace OrderManagement1.Migrations.OrderManagement81363
{
    [DbContext(typeof(OrderManagement81363Context))]
    partial class OrderManagement81363ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderManagement1.Models.AspNetRoleClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("OrderManagement1.Models.AspNetRoles", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("OrderManagement1.Models.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("OrderManagement1.Models.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("OrderManagement1.Models.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("OrderManagement1.Models.AspNetUsers", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("OrderManagement1.Models.AspNetUserTokens", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OrderManagement1.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductId");

                    b.Property<double>("Totalcost")
                        .HasColumnName("TOTALCOST");

                    b.Property<int?>("UserId");

                    b.HasKey("CartId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("OrderManagement1.Models.CartItems", b =>
                {
                    b.Property<int>("CartItemsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CartId");

                    b.Property<int?>("ProductId");

                    b.Property<double>("ProductPrice");

                    b.Property<int?>("ProductQty");

                    b.HasKey("CartItemsId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("OrderManagement1.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("OrderManagement1.Models.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("LoginId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ__Login__A9D105346291E6DB");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("OrderManagement1.Models.OrderItems", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId");

                    b.Property<int?>("ProductId");

                    b.Property<double>("ProductPrice");

                    b.Property<int?>("ProductQty");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("OrderManagement1.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Discount");

                    b.Property<double>("FinalAmount");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("UserId");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderManagement1.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("PaymentId");

                    b.HasIndex("OrderId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("OrderManagement1.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<double>("ProductPrice");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OrderManagement1.Models.Shipping", b =>
                {
                    b.Property<int>("ShippingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId");

                    b.Property<string>("ShippingCity")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("ShippingCompany")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("ShippingDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ShippingStatus")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("ShippingId");

                    b.HasIndex("OrderId");

                    b.ToTable("Shipping");
                });

            modelBuilder.Entity("OrderManagement1.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PinCode");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("UserCity")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UserContact")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("UserFname")
                        .IsRequired()
                        .HasColumnName("UserFName")
                        .HasMaxLength(50);

                    b.Property<string>("UserLname")
                        .IsRequired()
                        .HasColumnName("UserLName")
                        .HasMaxLength(50);

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("UserId");

                    b.HasIndex("UserEmail")
                        .IsUnique()
                        .HasName("UQ__Users__08638DF8FE6AD3C4");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrderManagement1.Models.AspNetRoleClaims", b =>
                {
                    b.HasOne("OrderManagement1.Models.AspNetRoles", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrderManagement1.Models.AspNetUserClaims", b =>
                {
                    b.HasOne("OrderManagement1.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrderManagement1.Models.AspNetUserLogins", b =>
                {
                    b.HasOne("OrderManagement1.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrderManagement1.Models.AspNetUserRoles", b =>
                {
                    b.HasOne("OrderManagement1.Models.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OrderManagement1.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrderManagement1.Models.AspNetUserTokens", b =>
                {
                    b.HasOne("OrderManagement1.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrderManagement1.Models.Cart", b =>
                {
                    b.HasOne("OrderManagement1.Models.Products", "Product")
                        .WithMany("Cart")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__Cart__ProductId__2739D489");

                    b.HasOne("OrderManagement1.Models.Users", "User")
                        .WithMany("Cart")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Cart__UserId__2645B050");
                });

            modelBuilder.Entity("OrderManagement1.Models.CartItems", b =>
                {
                    b.HasOne("OrderManagement1.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .HasConstraintName("FK__CartItems__CartI__367C1819");

                    b.HasOne("OrderManagement1.Models.Products", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__CartItems__Produ__37703C52");
                });

            modelBuilder.Entity("OrderManagement1.Models.OrderItems", b =>
                {
                    b.HasOne("OrderManagement1.Models.Orders", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__OrderItem__Order__3B40CD36");

                    b.HasOne("OrderManagement1.Models.Products", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__OrderItem__Produ__3A4CA8FD");
                });

            modelBuilder.Entity("OrderManagement1.Models.Orders", b =>
                {
                    b.HasOne("OrderManagement1.Models.Users", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Orders__UserId__2A164134");
                });

            modelBuilder.Entity("OrderManagement1.Models.Payment", b =>
                {
                    b.HasOne("OrderManagement1.Models.Orders", "Order")
                        .WithMany("Payment")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__Payment__OrderId__30C33EC3");
                });

            modelBuilder.Entity("OrderManagement1.Models.Products", b =>
                {
                    b.HasOne("OrderManagement1.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__Products__Catego__151B244E");
                });

            modelBuilder.Entity("OrderManagement1.Models.Shipping", b =>
                {
                    b.HasOne("OrderManagement1.Models.Orders", "Order")
                        .WithMany("Shipping")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__Shipping__OrderI__339FAB6E");
                });
#pragma warning restore 612, 618
        }
    }
}
