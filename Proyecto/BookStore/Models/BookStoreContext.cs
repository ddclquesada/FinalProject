using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStore.Models
{
    public partial class BookStoreContext : DbContext
    {
        public BookStoreContext()
        {
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Borrow> Borrow { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=BookStore;Data Source=localhost;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorId).HasColumnName("authorId");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.AuthorId).HasColumnName("authorId");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Pagecount).HasColumnName("pagecount");

                entity.Property(e => e.Point).HasColumnName("point");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_books_authors");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_books_types");
            });

            modelBuilder.Entity<Borrow>(entity =>
            {
                entity.ToTable("borrow");

                entity.Property(e => e.BorrowId).HasColumnName("borrowId");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.BroughtDate)
                    .HasColumnName("broughtDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.TakenDate)
                    .HasColumnName("takenDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Borrow)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_borrows_books");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Borrow)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_borrows_students");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Person).HasMaxLength(150);

                entity.Property(e => e.ReviewText).HasMaxLength(500);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_Review_book");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Point).HasColumnName("point");

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
