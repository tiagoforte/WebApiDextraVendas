﻿// <auto-generated />
using Dextra.Vendas.InfraV2.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Dextra.Vendas.InfraV2.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dextra.Vendas.Domain.Entities.IngredienteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("Dextra.Vendas.Domain.Entities.LancheEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Lanche");
                });

            modelBuilder.Entity("Dextra.Vendas.Domain.Entities.LancheIngredientesEntity", b =>
                {
                    b.Property<int>("IdLanche");

                    b.Property<int>("IdIngrediente");

                    b.HasKey("IdLanche", "IdIngrediente");

                    b.HasIndex("IdIngrediente");

                    b.ToTable("LancheIngredientes");
                });

            modelBuilder.Entity("Dextra.Vendas.Domain.Entities.LancheIngredientesEntity", b =>
                {
                    b.HasOne("Dextra.Vendas.Domain.Entities.IngredienteEntity", "Ingrediente")
                        .WithMany("Lanches")
                        .HasForeignKey("IdIngrediente")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dextra.Vendas.Domain.Entities.LancheEntity", "Lanche")
                        .WithMany("Ingredientes")
                        .HasForeignKey("IdLanche")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
