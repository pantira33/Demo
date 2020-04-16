using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiDemo.Entitys
{
    public partial class WebApiDemoContext : DbContext
    {
        public WebApiDemoContext()
        {
        }

        public WebApiDemoContext(DbContextOptions<WebApiDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentInUnivercity> StudentInUnivercity { get; set; }
        public virtual DbSet<Univercity> Univercity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=WebApiDemo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentInUnivercity>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.UnivercityId).HasColumnName("UnivercityID");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentInUnivercity_Student");

                entity.HasOne(d => d.Univercity)
                    .WithMany()
                    .HasForeignKey(d => d.UnivercityId)
                    .HasConstraintName("FK_StudentInUnivercity_Univercity");
            });

            modelBuilder.Entity<Univercity>(entity =>
            {
                entity.Property(e => e.UnivercityId)
                    .HasColumnName("UnivercityID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UnivercityName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
