﻿// <auto-generated />
using Framework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Framework.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220926091211_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Framework.Models.Penempatan", b =>
                {
                    b.Property<int>("idPenempatan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idPerusahaan")
                        .HasColumnType("int");

                    b.Property<int>("idProvinsi")
                        .HasColumnType("int");

                    b.Property<string>("namaPerusahaan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idPenempatan");

                    b.HasIndex("idPerusahaan");

                    b.HasIndex("idProvinsi");

                    b.ToTable("Penempatans");
                });

            modelBuilder.Entity("Framework.Models.Perusahaan", b =>
                {
                    b.Property<int>("idPerusahan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("tipePerusahaan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idPerusahan");

                    b.ToTable("Perusahaans");
                });

            modelBuilder.Entity("Framework.Models.Provinsi", b =>
                {
                    b.Property<int>("idProvinsi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("namaProvinsi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idProvinsi");

                    b.ToTable("Provinsis");
                });

            modelBuilder.Entity("Framework.Models.Penempatan", b =>
                {
                    b.HasOne("Framework.Models.Perusahaan", "Perusahaan")
                        .WithMany()
                        .HasForeignKey("idPerusahaan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Framework.Models.Provinsi", "Provinsi")
                        .WithMany()
                        .HasForeignKey("idProvinsi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
