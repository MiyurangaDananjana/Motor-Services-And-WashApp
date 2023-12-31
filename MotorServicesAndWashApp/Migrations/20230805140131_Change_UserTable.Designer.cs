﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotorServicesAndWashApp.Data;

#nullable disable

namespace MotorServicesAndWashApp.Migrations
{
    [DbContext(typeof(MotorServiceDbContext))]
    [Migration("20230805140131_Change_UserTable")]
    partial class Change_UserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MotorServicesAndWashApp.Models.Domain.Cities", b =>
                {
                    b.Property<int>("CitiesId")
                        .HasColumnType("int");

                    b.Property<string>("CitiesName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DistrictsId")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("PostCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CitiesId");

                    b.HasIndex("DistrictsId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("MotorServicesAndWashApp.Models.Domain.Districts", b =>
                {
                    b.Property<int>("DistrictsId")
                        .HasColumnType("int");

                    b.Property<string>("DistrictsName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Districts_Name");

                    b.Property<int>("ProvincesId")
                        .HasColumnType("int");

                    b.HasKey("DistrictsId");

                    b.HasIndex("ProvincesId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("MotorServicesAndWashApp.Models.Domain.Provinces", b =>
                {
                    b.Property<int>("ProvincesId")
                        .HasColumnType("int");

                    b.Property<string>("ProvincesName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Provinces_Name");

                    b.HasKey("ProvincesId");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("MotorServicesAndWashApp.Models.Domain.UserDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CitiesId")
                        .HasColumnType("int");

                    b.Property<short>("OptCode")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("OptCodeSendDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("firstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("lastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("password")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salt")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("MotorServicesAndWashApp.Models.Domain.UserSesstion", b =>
                {
                    b.Property<Guid>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sesston")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("SesstonCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SesstonEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SessionId");

                    b.ToTable("UserSesstions");
                });

            modelBuilder.Entity("MotorServicesAndWashApp.Models.Domain.Cities", b =>
                {
                    b.HasOne("MotorServicesAndWashApp.Models.Domain.Districts", "Districts")
                        .WithMany("Cities")
                        .HasForeignKey("DistrictsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Districts");
                });

            modelBuilder.Entity("MotorServicesAndWashApp.Models.Domain.Districts", b =>
                {
                    b.HasOne("MotorServicesAndWashApp.Models.Domain.Provinces", "Provinces")
                        .WithMany("Districts")
                        .HasForeignKey("ProvincesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("MotorServicesAndWashApp.Models.Domain.Districts", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("MotorServicesAndWashApp.Models.Domain.Provinces", b =>
                {
                    b.Navigation("Districts");
                });
#pragma warning restore 612, 618
        }
    }
}
