﻿// <auto-generated />
using CommonModule.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CommonModule.Migrations
{
    [DbContext(typeof(DatabaseRepository))]
    [Migration("20240505161156_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28");

            modelBuilder.Entity("CommonModule.Model.Competition", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ageCategory")
                        .HasColumnType("TEXT");

                    b.Property<int>("count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("sample")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("CommonModule.Model.Man", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int>("sample_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Men");
                });

            modelBuilder.Entity("CommonModule.Model.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
