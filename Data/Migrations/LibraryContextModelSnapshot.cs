﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("Data.Entities.MediaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("media");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Emily Brontë",
                            Category = 0,
                            Status = 2,
                            Title = "Wuthering Heights"
                        });
                });

            modelBuilder.Entity("Data.Entities.ReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MediaID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("review");
                });

            modelBuilder.Entity("Data.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "zozol"
                        });
                });

            modelBuilder.Entity("Data.Entities.MediaEntity", b =>
                {
                    b.HasOne("Data.Entities.UserEntity", null)
                        .WithMany("Media")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("Data.Entities.ReviewEntity", b =>
                {
                    b.HasOne("Data.Entities.UserEntity", null)
                        .WithMany("Reviews")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("Data.Entities.UserEntity", b =>
                {
                    b.Navigation("Media");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
