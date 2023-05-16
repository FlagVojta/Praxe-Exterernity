﻿// <auto-generated />
using System;
using EntityFrameWorkDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkLibrary.Migrations
{
    [DbContext(typeof(DemoDbContext))]
    [Migration("20230516141359_Applicationadd")]
    partial class Applicationadd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityFrameWorkDataAccess.Models.tbContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Based")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BreakEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BreakStart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ICO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastChanged")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrgName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PSC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Registred")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepresentedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepresentedFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepresentedLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetANumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkStart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("tbUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("tbUserId");

                    b.ToTable("tbContract");
                });

            modelBuilder.Entity("EntityFrameWorkDataAccess.Models.tbUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbUser");
                });

            modelBuilder.Entity("EntityFrameworkLibrary.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PSC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreeAndNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("tbUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("tbUserId");

                    b.ToTable("applications");
                });

            modelBuilder.Entity("EntityFrameWorkDataAccess.Models.tbContract", b =>
                {
                    b.HasOne("EntityFrameWorkDataAccess.Models.tbUser", "tbUser")
                        .WithMany()
                        .HasForeignKey("tbUserId");

                    b.Navigation("tbUser");
                });

            modelBuilder.Entity("EntityFrameworkLibrary.Models.Application", b =>
                {
                    b.HasOne("EntityFrameWorkDataAccess.Models.tbUser", "tbUser")
                        .WithMany()
                        .HasForeignKey("tbUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tbUser");
                });
#pragma warning restore 612, 618
        }
    }
}
