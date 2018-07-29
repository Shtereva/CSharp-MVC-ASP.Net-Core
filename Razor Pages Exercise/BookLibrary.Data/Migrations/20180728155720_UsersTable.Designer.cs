﻿// <auto-generated />
using System;
using BookLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookLibrary.Data.Migrations
{
    [DbContext(typeof(BookLibraryDbContext))]
    [Migration("20180728155720_UsersTable")]
    partial class UsersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookLibray.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookLibray.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<string>("CoverImg");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookLibray.Models.BookHistory", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("HistoryId");

                    b.HasKey("BookId", "HistoryId");

                    b.HasIndex("HistoryId");

                    b.ToTable("BookHistory");
                });

            modelBuilder.Entity("BookLibray.Models.BooksBorrower", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("BorrowerId");

                    b.HasKey("BookId", "BorrowerId");

                    b.HasIndex("BorrowerId");

                    b.ToTable("BooksBorrower");
                });

            modelBuilder.Entity("BookLibray.Models.Borrower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Borrowers");
                });

            modelBuilder.Entity("BookLibray.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("BookLibray.Models.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("History");
                });

            modelBuilder.Entity("BookLibray.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverImg");

                    b.Property<int>("DirectorId");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("BookLibray.Models.MovieBorrower", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("BorrowerId");

                    b.HasKey("MovieId", "BorrowerId");

                    b.HasIndex("BorrowerId");

                    b.ToTable("MovieBorrower");
                });

            modelBuilder.Entity("BookLibray.Models.MovieHistory", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("HistoryId");

                    b.HasKey("MovieId", "HistoryId");

                    b.HasIndex("HistoryId");

                    b.ToTable("MovieHistory");
                });

            modelBuilder.Entity("BookLibray.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookLibray.Models.Book", b =>
                {
                    b.HasOne("BookLibray.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookLibray.Models.BookHistory", b =>
                {
                    b.HasOne("BookLibray.Models.Book", "Book")
                        .WithMany("History")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookLibray.Models.History", "History")
                        .WithMany("Books")
                        .HasForeignKey("HistoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookLibray.Models.BooksBorrower", b =>
                {
                    b.HasOne("BookLibray.Models.Book", "Book")
                        .WithMany("Borrowers")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookLibray.Models.Borrower", "Borrower")
                        .WithMany("Books")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookLibray.Models.Movie", b =>
                {
                    b.HasOne("BookLibray.Models.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookLibray.Models.MovieBorrower", b =>
                {
                    b.HasOne("BookLibray.Models.Borrower", "Borrower")
                        .WithMany("Movies")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookLibray.Models.Movie", "Movie")
                        .WithMany("Borrowers")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookLibray.Models.MovieHistory", b =>
                {
                    b.HasOne("BookLibray.Models.History", "History")
                        .WithMany("Movies")
                        .HasForeignKey("HistoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookLibray.Models.Movie", "Movie")
                        .WithMany("History")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}