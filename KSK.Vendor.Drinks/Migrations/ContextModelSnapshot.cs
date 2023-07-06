﻿// <auto-generated />
using System;
using KSK.Vendor.Drinks.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KSK.Vendor.Drinks.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Drink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Drink", b =>
                {
                    b.OwnsOne("KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink.Values.Cup", "Cup", b1 =>
                        {
                            b1.Property<Guid>("DrinkId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Material")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<double>("Size")
                                .HasColumnType("double precision");

                            b1.HasKey("DrinkId");

                            b1.ToTable("Drinks");

                            b1.WithOwner()
                                .HasForeignKey("DrinkId");
                        });

                    b.Navigation("Cup")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}