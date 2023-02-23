﻿// <auto-generated />
using System;
using CarShowroom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarShowroom.Migrations
{
    [DbContext(typeof(CarsDbContext))]
    [Migration("20230223193910_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarShowroom.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EngineCapacity")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<int?>("ModelYear")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasMaxLength(16)
                        .HasColumnType("int");

                    b.Property<int>("ShowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ShowId" }, "IX_Cars_ShowId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarShowroom.Models.Showroom", b =>
                {
                    b.Property<int>("ShowroomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShowroomId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("ShowroomAddress");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("ShowroomName");

                    b.Property<int?>("Phone")
                        .HasMaxLength(16)
                        .HasColumnType("int")
                        .HasColumnName("ShowroomPhone");

                    b.HasKey("ShowroomId");

                    b.ToTable("Showrooms");
                });

            modelBuilder.Entity("CarShowroom.Models.Car", b =>
                {
                    b.HasOne("CarShowroom.Models.Showroom", "ShowroomInfo")
                        .WithMany("Cars")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShowroomInfo");
                });

            modelBuilder.Entity("CarShowroom.Models.Showroom", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}