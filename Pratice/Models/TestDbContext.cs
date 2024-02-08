using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pratice.Models;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Emptb> Emptbs { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<SchoolView> SchoolViews { get; set; }

    public virtual DbSet<User> Users { get; set; }



    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=200411LTP2848\\SQLEXPRESS;Database=TestDb;integrated security=true;Encrypt=False");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__CLASS__CB1927C05DF94492");

            entity.ToTable("CLASS");

            entity.HasIndex(e => e.ClassName, "UQ__CLASS__F8BF561BB4B96694").IsUnique();

            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.School).WithMany(p => p.Classes)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CLASS__SchoolId__72C60C4A");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Capital)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Economy).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__COURSE__C92D71A743E6973B");

            entity.ToTable("COURSE");

            entity.HasIndex(e => e.CourseName, "UQ__COURSE__9526E277EA51BAD3").IsUnique();

            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.Courses)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__COURSE__ClassId__787EE5A0");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__CUSTOMER__A4AE64D885DA53AB");

            entity.ToTable("CUSTOMER", tb => tb.HasTrigger("CheckPhoneNumber"));

            entity.HasIndex(e => e.CustomerNumber, "UQ__CUSTOMER__48D47E1E3556CA73").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Emptb>(entity =>
        {
            entity.HasKey(e => e.Eno).HasName("PK_emptbl");

            entity.ToTable("emptb");

            entity.Property(e => e.Eno)
                .ValueGeneratedNever()
                .HasColumnName("eno");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .HasColumnName("city");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Salary)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("salary");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Grade1).HasColumnName("Grade");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movies__3214EC076C846198");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Collection).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Director)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Hero)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MusicDirector)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReleaseDate).HasColumnType("date");
            entity.Property(e => e.Review).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.SchoolId).HasName("PK__SCHOOL__3DA4675BC51AAE2D");

            entity.ToTable("SCHOOL");

            entity.HasIndex(e => e.SchoolName, "UQ__SCHOOL__E3D5B6A553F8023D").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PostAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PostCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SchoolName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SchoolView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SchoolView");

            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SchoolName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CDF37B0F891");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        //modelBuilder.Entity<BackupCountry>(entity =>
        //{
        //    entity.ToTable("BackupCountry");

        //    entity.HasKey(e => e.Id);

        //    entity.Property(e => e.Name)
        //        .IsRequired()
        //        .HasMaxLength(255); // Adjust the length as needed

        //    entity.Property(e => e.Capital)
        //        .HasMaxLength(255); // Adjust the length as needed

        //    entity.Property(e => e.Population);

        //    entity.Property(e => e.Economy)
        //        .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as needed

        //    entity.Property(e => e.Currency)
        //        .HasMaxLength(255); // Adjust the length as needed

        //    entity.Property(e => e.IsDeleted)
        //        .IsRequired();

        //    entity.Property(e => e.BackupDateTime)
        //        .IsRequired();

        //    // Add other configurations as needed
        //});


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
