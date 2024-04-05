﻿// <auto-generated />
using System;
using CleanArchCqrs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArchCqrs.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240404134719_AlterTablePaymentAddStatus")]
    partial class AlterTablePaymentAddStatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CleanArchCqrs.Domain.Entities.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Agents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(7228),
                            Name = "Fernando José"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(7244),
                            Name = "Priscila Antunes"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(7245),
                            Name = "Gabriel Antunes"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(7245),
                            Name = "Beatriz Antunes"
                        });
                });

            modelBuilder.Entity("CleanArchCqrs.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(9027),
                            Name = "Material Escolar"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(9032),
                            Name = "Eletrônicos"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(9033),
                            Name = "Acessórios"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 4, 4, 10, 47, 18, 653, DateTimeKind.Local).AddTicks(9034),
                            Name = "Livros"
                        });
                });

            modelBuilder.Entity("CleanArchCqrs.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Goal")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("ProductId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("CleanArchCqrs.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CleanArchCqrs.Domain.Entities.Payment", b =>
                {
                    b.HasOne("CleanArchCqrs.Domain.Entities.Agent", "Agent")
                        .WithMany("Payments")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArchCqrs.Domain.Entities.Product", "Product")
                        .WithMany("Payments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CleanArchCqrs.Domain.Entities.Product", b =>
                {
                    b.HasOne("CleanArchCqrs.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CleanArchCqrs.Domain.Entities.Agent", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("CleanArchCqrs.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CleanArchCqrs.Domain.Entities.Product", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}