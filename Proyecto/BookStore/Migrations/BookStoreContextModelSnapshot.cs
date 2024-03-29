﻿// <auto-generated />
using System;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    partial class BookStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookStore.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("authorId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Surname")
                        .HasColumnName("surname")
                        .HasMaxLength(70)
                        .IsUnicode(false);

                    b.HasKey("AuthorId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BookStore.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bookId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId")
                        .HasColumnName("authorId");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(90)
                        .IsUnicode(false);

                    b.Property<int?>("Pagecount")
                        .HasColumnName("pagecount");

                    b.Property<int?>("Point")
                        .HasColumnName("point");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BookStore.Models.Borrow", b =>
                {
                    b.Property<int>("BorrowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("borrowId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId")
                        .HasColumnName("bookId");

                    b.Property<DateTime?>("BroughtDate")
                        .HasColumnName("broughtDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("StudentId")
                        .HasColumnName("studentId");

                    b.Property<DateTime?>("TakenDate")
                        .HasColumnName("takenDate")
                        .HasColumnType("datetime");

                    b.HasKey("BorrowId");

                    b.HasIndex("BookId");

                    b.HasIndex("StudentId");

                    b.ToTable("borrow");
                });

            modelBuilder.Entity("BookStore.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("BookStore.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId")
                        .HasColumnName("bookId");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Person")
                        .HasMaxLength(150);

                    b.Property<string>("ReviewText")
                        .HasMaxLength(500);

                    b.HasKey("ReviewId");

                    b.HasIndex("BookId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("BookStore.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("studentId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnName("birthdate")
                        .HasColumnType("date");

                    b.Property<string>("Class")
                        .HasColumnName("class")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("Gender")
                        .HasColumnName("gender")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int?>("Point")
                        .HasColumnName("point");

                    b.Property<string>("Surname")
                        .HasColumnName("surname")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("StudentId");

                    b.ToTable("student");
                });

            modelBuilder.Entity("BookStore.Models.Book", b =>
                {
                    b.HasOne("BookStore.Models.Author", "Author")
                        .WithMany("Book")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK_books_authors");

                    b.HasOne("BookStore.Models.Category", "Category")
                        .WithMany("Book")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_books_types");
                });

            modelBuilder.Entity("BookStore.Models.Borrow", b =>
                {
                    b.HasOne("BookStore.Models.Book", "Book")
                        .WithMany("Borrow")
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_borrows_books");

                    b.HasOne("BookStore.Models.Student", "Student")
                        .WithMany("Borrow")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_borrows_students");
                });

            modelBuilder.Entity("BookStore.Models.Review", b =>
                {
                    b.HasOne("BookStore.Models.Book", "Book")
                        .WithMany("Review")
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_Review_book");
                });
#pragma warning restore 612, 618
        }
    }
}
