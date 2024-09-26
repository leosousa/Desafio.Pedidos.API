﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pedidos.Infraestrutura.Database;

#nullable disable

namespace Pedidos.Infraestrutura.Migrations
{
    [DbContext(typeof(PedidoDbContext))]
    [Migration("20240926015602_MigrationInicial")]
    partial class MigrationInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pedidos.Dominio.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Pedidos.Dominio.Entidades.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPedido");

                    b.HasIndex("IdProduto")
                        .IsUnique();

                    b.ToTable("ItemPedido", (string)null);
                });

            modelBuilder.Entity("Pedidos.Dominio.Entidades.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<bool>("Pago")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("Pedidos.Dominio.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Valor")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("Pedidos.Dominio.Entidades.ItemPedido", b =>
                {
                    b.HasOne("Pedidos.Dominio.Entidades.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pedidos.Dominio.Entidades.Produto", "Produto")
                        .WithOne("ItemPedido")
                        .HasForeignKey("Pedidos.Dominio.Entidades.ItemPedido", "IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Pedidos.Dominio.Entidades.Pedido", b =>
                {
                    b.HasOne("Pedidos.Dominio.Entidades.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Pedidos.Dominio.Entidades.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Pedidos.Dominio.Entidades.Pedido", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("Pedidos.Dominio.Entidades.Produto", b =>
                {
                    b.Navigation("ItemPedido")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
