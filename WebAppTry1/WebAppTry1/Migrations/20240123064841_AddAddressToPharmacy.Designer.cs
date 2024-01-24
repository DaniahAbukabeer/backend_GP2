﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppTry1.Models;

#nullable disable

namespace WebAppTry1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240123064841_AddAddressToPharmacy")]
    partial class AddAddressToPharmacy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAppTry1.Models.FeedBack", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("PharmacyId")
                        .HasColumnType("int");

                    b.Property<double>("Ratting")
                        .HasMaxLength(5)
                        .HasColumnType("float");

                    b.Property<bool>("Statues")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "PharmacyId");

                    b.HasIndex("PharmacyId");

                    b.ToTable("FeedBacks");
                });

            modelBuilder.Entity("WebAppTry1.Models.Pharmacy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ClosingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Open24Hours")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("OpeningTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<float>("Ratting")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("WebAppTry1.Models.PharmaysProducts", b =>
                {
                    b.Property<int>("PharmacyId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<double?>("PrivatePrice")
                        .HasColumnType("float");

                    b.Property<double?>("PublicPrice")
                        .HasColumnType("float");

                    b.Property<double?>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("PharmacyId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("pharmaysProducts");
                });

            modelBuilder.Entity("WebAppTry1.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ATCCODE")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Dosage")
                        .HasColumnType("float");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("TName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebAppTry1.Models.ReceiptInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PharmacistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ReceiptInfo");
                });

            modelBuilder.Entity("WebAppTry1.Models.ReceiptsProducts", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ReceiptId")
                        .HasColumnType("int");

                    b.HasKey("Id", "ProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ReceiptId");

                    b.ToTable("ReceiptsProducts");
                });

            modelBuilder.Entity("WebAppTry1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "password12345678",
                            PhoneNumber = "0791234567",
                            UserName = "Test1"
                        });
                });

            modelBuilder.Entity("WebAppTry1.Models.UserProduct", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ViewedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("UserProduct");
                });

            modelBuilder.Entity("WebAppTry1.Models.FeedBack", b =>
                {
                    b.HasOne("WebAppTry1.Models.Pharmacy", "Pharmacy")
                        .WithMany("FeedBack")
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppTry1.Models.User", "Users")
                        .WithMany("FeedBacks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pharmacy");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebAppTry1.Models.PharmaysProducts", b =>
                {
                    b.HasOne("WebAppTry1.Models.Pharmacy", "Pharmacy")
                        .WithMany("PharmaysProducts")
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppTry1.Models.Product", "Product")
                        .WithMany("PharmaysProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pharmacy");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebAppTry1.Models.ReceiptsProducts", b =>
                {
                    b.HasOne("WebAppTry1.Models.Product", "ProductInfo")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppTry1.Models.ReceiptInfo", "Receipt")
                        .WithMany("ReceiptsProducts")
                        .HasForeignKey("ReceiptId");

                    b.Navigation("ProductInfo");

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("WebAppTry1.Models.UserProduct", b =>
                {
                    b.HasOne("WebAppTry1.Models.Product", "Product")
                        .WithMany("UserProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppTry1.Models.User", "user")
                        .WithMany("UserProducts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("user");
                });

            modelBuilder.Entity("WebAppTry1.Models.Pharmacy", b =>
                {
                    b.Navigation("FeedBack");

                    b.Navigation("PharmaysProducts");
                });

            modelBuilder.Entity("WebAppTry1.Models.Product", b =>
                {
                    b.Navigation("PharmaysProducts");

                    b.Navigation("UserProducts");
                });

            modelBuilder.Entity("WebAppTry1.Models.ReceiptInfo", b =>
                {
                    b.Navigation("ReceiptsProducts");
                });

            modelBuilder.Entity("WebAppTry1.Models.User", b =>
                {
                    b.Navigation("FeedBacks");

                    b.Navigation("UserProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
