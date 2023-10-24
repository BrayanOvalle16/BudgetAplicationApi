﻿// <auto-generated />
using System;
using BudgetAplicationApi.Data.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BudgetAplicationApi.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BudgetAplicationApi.Api.Models.Compania", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IngresoTotal")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Companias");
                });

            modelBuilder.Entity("BudgetAplicationApi.Api.Models.Contabilidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Naturaleza")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Contabilidades");
                });

            modelBuilder.Entity("BudgetAplicationApi.Api.Models.Jwt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreadoEn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiraEn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Jwt");
                });

            modelBuilder.Entity("BudgetAplicationApi.Api.Models.Movimiento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CompañiaID")
                        .HasColumnType("int");

                    b.Property<int>("ContabilidadId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.Property<int>("TransaccionID")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CompañiaID");

                    b.HasIndex("ContabilidadId");

                    b.HasIndex("TransaccionID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Movimientos");
                });

            modelBuilder.Entity("BudgetAplicationApi.Api.Models.Rol", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Descripcion")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BudgetAplicationApi.Api.Models.Transaccion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("BudgetAplicationApi.Api.Models.Usuarios", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroIdentificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("RolUsuarios", b =>
                {
                    b.Property<int>("RolesID")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosID")
                        .HasColumnType("int");

                    b.HasKey("RolesID", "UsuariosID");

                    b.HasIndex("UsuariosID");

                    b.ToTable("RolUsuarios");
                });

            modelBuilder.Entity("BudgetAplicationApi.Api.Models.Jwt", b =>
                {
                    b.HasOne("BudgetAplicationApi.Api.Models.Usuarios", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("BudgetAplicationApi.Api.Models.Movimiento", b =>
                {
                    b.HasOne("BudgetAplicationApi.Api.Models.Compania", "Compañia")
                        .WithMany("Movimientos")
                        .HasForeignKey("CompañiaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BudgetAplicationApi.Api.Models.Contabilidad", "Contabilidad")
                        .WithMany("Movimientos")
                        .HasForeignKey("ContabilidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BudgetAplicationApi.Api.Models.Transaccion", "Transaccion")
                        .WithMany("Movimientos")
                        .HasForeignKey("TransaccionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BudgetAplicationApi.Api.Models.Usuarios", "Usuario")
                        .WithMany("Movimientos")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compañia");

                    b.Navigation("Contabilidad");

                    b.Navigation("Transaccion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("RolUsuarios", b =>
                {
                    b.HasOne("BudgetAplicationApi.Api.Models.Rol", null)
                        .WithMany()
                        .HasForeignKey("RolesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BudgetAplicationApi.Api.Models.Usuarios", null)
                        .WithMany()
                        .HasForeignKey("UsuariosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BudgetAplicationApi.Api.Models.Compania", b =>
                {
                    b.Navigation("Movimientos");
                });

            modelBuilder.Entity("BudgetAplicationApi.Api.Models.Contabilidad", b =>
                {
                    b.Navigation("Movimientos");
                });

            modelBuilder.Entity("BudgetAplicationApi.Api.Models.Transaccion", b =>
                {
                    b.Navigation("Movimientos");
                });

            modelBuilder.Entity("BudgetAplicationApi.Api.Models.Usuarios", b =>
                {
                    b.Navigation("Movimientos");
                });
#pragma warning restore 612, 618
        }
    }
}
