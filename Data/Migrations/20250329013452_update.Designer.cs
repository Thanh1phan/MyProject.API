﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyProject.API.Data;

#nullable disable

namespace MyProject.API.Migrations.Data
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250329013452_update")]
    partial class update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyProject.API.Data.Entities.B03T", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("B03T");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            CreateDate = new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Canon",
                            UpdateDate = new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                            CreateDate = new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sony",
                            UpdateDate = new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MyProject.API.Data.Entities.K01T", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("K01T");
                });

            modelBuilder.Entity("MyProject.API.Data.Entities.K02T", b =>
                {
                    b.Property<int>("Seq")
                        .HasColumnType("int");

                    b.Property<Guid>("M01CId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Seq", "M01CId");

                    b.HasIndex("M01CId");

                    b.ToTable("K02T");

                    b.HasData(
                        new
                        {
                            Seq = 1,
                            M01CId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            Url = "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/44d7d59b-297e-43fb-1ed7-c402c3fce500/storedata"
                        },
                        new
                        {
                            Seq = 2,
                            M01CId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            Url = "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/b9749b99-0ce3-42e3-c1ac-25cfb033b100/storedata"
                        },
                        new
                        {
                            Seq = 3,
                            M01CId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            Url = "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/ab09dca0-c22d-46df-a563-99fb11d08f00/storedata"
                        },
                        new
                        {
                            Seq = 1,
                            M01CId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                            Url = "https://kyma.vn/StoreData/images/Product/may-anh-sony-alpha-ilce6700-a6700-body.jpg"
                        },
                        new
                        {
                            Seq = 2,
                            M01CId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                            Url = "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/1fb59980-67f3-49cb-4060-1eb1dc10f400/storedata"
                        },
                        new
                        {
                            Seq = 3,
                            M01CId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                            Url = "https://imagedelivery.net/ZeGtsGSjuQe1P3UP_zk3fQ/4e622b29-115b-4ab3-cf7c-9816f1d2fb00/storedata"
                        });
                });

            modelBuilder.Entity("MyProject.API.Data.Entities.K11T", b =>
                {
                    b.Property<Guid>("M01CId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ZIBAIKA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ZOBAIKA")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("M01CId");

                    b.ToTable("K11T");

                    b.HasData(
                        new
                        {
                            M01CId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            ZIBAIKA = 18700000m,
                            ZOBAIKA = 17000000m
                        },
                        new
                        {
                            M01CId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                            ZIBAIKA = 36300000m,
                            ZOBAIKA = 33000000m
                        });
                });

            modelBuilder.Entity("MyProject.API.Data.Entities.M01C", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("B3Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("B3Id");

                    b.ToTable("M01C");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            B3Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            CreateDate = new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Canon EOS R6 Mark II Kit RF24-105mm F4 L IS USM",
                            UpdateDate = new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                            B3Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                            CreateDate = new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sony Alpha ILCE-6700 / A6700 Body",
                            UpdateDate = new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MyProject.API.Data.Entities.M02T", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<Guid>("M01CID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SEQ")
                        .HasColumnType("int");

                    b.Property<decimal>("ZIBAIKA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ZOBAIKA")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("M01CID")
                        .IsUnique();

                    b.ToTable("M02T");
                });

            modelBuilder.Entity("MyProject.API.Data.Entities.K02T", b =>
                {
                    b.HasOne("MyProject.API.Data.Entities.M01C", "M01C")
                        .WithMany("K02T")
                        .HasForeignKey("M01CId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("M01C");
                });

            modelBuilder.Entity("MyProject.API.Data.Entities.K11T", b =>
                {
                    b.HasOne("MyProject.API.Data.Entities.M01C", "M01C")
                        .WithOne("K11T")
                        .HasForeignKey("MyProject.API.Data.Entities.K11T", "M01CId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("M01C");
                });

            modelBuilder.Entity("MyProject.API.Data.Entities.M01C", b =>
                {
                    b.HasOne("MyProject.API.Data.Entities.B03T", "B03T")
                        .WithMany("M01C")
                        .HasForeignKey("B3Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("B03T");
                });

            modelBuilder.Entity("MyProject.API.Data.Entities.M02T", b =>
                {
                    b.HasOne("MyProject.API.Data.Entities.M01C", "M01C")
                        .WithOne("M02T")
                        .HasForeignKey("MyProject.API.Data.Entities.M02T", "M01CID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("M01C");
                });

            modelBuilder.Entity("MyProject.API.Data.Entities.B03T", b =>
                {
                    b.Navigation("M01C");
                });

            modelBuilder.Entity("MyProject.API.Data.Entities.M01C", b =>
                {
                    b.Navigation("K02T");

                    b.Navigation("K11T")
                        .IsRequired();

                    b.Navigation("M02T")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
