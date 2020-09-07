using Microsoft.EntityFrameworkCore;

namespace LIBRARYmanagement.Models
{
    public partial class LibManContext : DbContext
    {
        public LibManContext()
        {
        }

        public LibManContext(DbContextOptions<LibManContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookDetail> BookDetail { get; set; }
        public virtual DbSet<StudentDetail> StudentDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SAHIL-RAJPUT09\\SQLEXPRESS;Database=LibMan;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDetail>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__BookDeta__3DE0C207B4ADB22E");

                entity.Property(e => e.BookId).ValueGeneratedNever();

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.BookDetail)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__BookDetai__Stude__286302EC");
            });

            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__StudentD__32C52B99E3FB2E27");

                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
