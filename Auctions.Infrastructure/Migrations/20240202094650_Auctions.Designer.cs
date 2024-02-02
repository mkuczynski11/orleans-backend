﻿// <auto-generated />
using System;
using Auctions.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Auctions.Infrastructure.Migrations
{
    [DbContext(typeof(AuctionsDbContext))]
    [Migration("20240202094650_Auctions")]
    partial class Auctions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Auctions.Infrastructure.Data.Models.Auction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("Auctions.Infrastructure.Data.Models.AuctionBid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuctionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.HasIndex("UserId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("Auctions.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a5ae013c-14a1-4c2d-a731-47fbbd0ba527"),
                            Name = "Sport"
                        },
                        new
                        {
                            Id = new Guid("5f923017-86da-4793-9332-7b74197acc51"),
                            Name = "AGD"
                        },
                        new
                        {
                            Id = new Guid("2f07481d-5f3f-4bbf-923f-60e62fcfe4e7"),
                            Name = "Home"
                        },
                        new
                        {
                            Id = new Guid("7322b307-1431-4203-bda8-9161b60c45d0"),
                            Name = "Electronic"
                        });
                });

            modelBuilder.Entity("Auctions.Infrastructure.Data.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Auctions.Infrastructure.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Auctions.Infrastructure.Data.Models.Auction", b =>
                {
                    b.HasOne("Auctions.Infrastructure.Data.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auctions.Infrastructure.Data.Models.User", "Owner")
                        .WithMany("OwnedAuctions")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Auctions.Infrastructure.Data.Models.AuctionBid", b =>
                {
                    b.HasOne("Auctions.Infrastructure.Data.Models.Auction", "Auction")
                        .WithMany("AuctionBids")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auctions.Infrastructure.Data.Models.User", "User")
                        .WithMany("AuctionBids")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Auctions.Infrastructure.Data.Models.Item", b =>
                {
                    b.HasOne("Auctions.Infrastructure.Data.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Auctions.Infrastructure.Data.Models.Auction", b =>
                {
                    b.Navigation("AuctionBids");
                });

            modelBuilder.Entity("Auctions.Infrastructure.Data.Models.User", b =>
                {
                    b.Navigation("AuctionBids");

                    b.Navigation("OwnedAuctions");
                });
#pragma warning restore 612, 618
        }
    }
}