﻿// <auto-generated />
using System;
using Financial_management_system_in_educational_institutions_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Financial_management_system_in_educational_institutions_API.Models.Account", b =>
                {
                    b.Property<int>("accId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("accId"));

                    b.Property<string>("organisationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("twoFAcode")
                        .HasColumnType("int");

                    b.Property<DateTime>("twoFAtime")
                        .HasColumnType("datetime2");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("accId");

                    b.ToTable("tblAccounts");

                    b.HasData(
                        new
                        {
                            accId = 1,
                            organisationName = "Rilindja",
                            passwordHash = "324refds32q",
                            role = "kompani",
                            salt = "fdszx",
                            twoFAcode = 491593,
                            twoFAtime = new DateTime(2025, 4, 5, 21, 39, 37, 727, DateTimeKind.Local).AddTicks(7212),
                            username = "kompania1"
                        },
                        new
                        {
                            accId = 2,
                            organisationName = "Hasan Prishtina",
                            passwordHash = "vdsv2wqc2ws2",
                            role = "universitet",
                            salt = "adsyx",
                            twoFAcode = 154923,
                            twoFAtime = new DateTime(2025, 4, 5, 21, 39, 37, 727, DateTimeKind.Local).AddTicks(7272),
                            username = "kompania1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
