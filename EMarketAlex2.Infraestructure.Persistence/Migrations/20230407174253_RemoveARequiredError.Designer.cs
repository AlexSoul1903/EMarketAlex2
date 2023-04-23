﻿// <auto-generated />
using System;
using EMarketAlex2.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EMarketAlex2.Infraestructure.Persistence.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230407174253_RemoveARequiredError")]
    partial class RemoveARequiredError
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EMarketAlex2.Core.Domain.Entities.Anuncios", b =>
                {
                    b.Property<int>("IdAnuncio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imagen1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("miCategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("miUserId")
                        .HasColumnType("int");

                    b.Property<string>("nombre_anuncio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("precio")
                        .HasColumnType("int");

                    b.HasKey("IdAnuncio");

                    b.HasIndex("miCategoriaId");

                    b.HasIndex("miUserId");

                    b.ToTable("Anuncios");
                });

            modelBuilder.Entity("EMarketAlex2.Core.Domain.Entities.Categorias", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("EMarketAlex2.Core.Domain.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgRoute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idEstatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EMarketAlex2.Core.Domain.Entities.Anuncios", b =>
                {
                    b.HasOne("EMarketAlex2.Core.Domain.Entities.Categorias", "categorias")
                        .WithMany("Anuncios")
                        .HasForeignKey("miCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMarketAlex2.Core.Domain.Entities.Users", "user")
                        .WithMany("anuncios")
                        .HasForeignKey("miUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categorias");

                    b.Navigation("user");
                });

            modelBuilder.Entity("EMarketAlex2.Core.Domain.Entities.Categorias", b =>
                {
                    b.Navigation("Anuncios");
                });

            modelBuilder.Entity("EMarketAlex2.Core.Domain.Entities.Users", b =>
                {
                    b.Navigation("anuncios");
                });
#pragma warning restore 612, 618
        }
    }
}
