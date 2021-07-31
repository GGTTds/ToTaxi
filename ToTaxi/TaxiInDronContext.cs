using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ToTaxi
{
    public partial class TaxiInDronContext : DbContext
    {
        public TaxiInDronContext()
        {
        }

        public TaxiInDronContext(DbContextOptions<TaxiInDronContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FuncPp> FuncPps { get; set; }
        public virtual DbSet<PolPol> PolPols { get; set; }
        public virtual DbSet<RoulPp> RoulPps { get; set; }
        public virtual DbSet<ToSatu> ToSatus { get; set; }
        public virtual DbSet<TransTt> TransTts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Zakaz> Zakazs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=WIN-TUD2DUAF5IN\\SQLEXPRESS;Database=TaxiInDron;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<FuncPp>(entity =>
            {
                entity.ToTable("FuncPP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.WhoIsItFuncNavigation)
                    .WithMany(p => p.FuncPps)
                    .HasForeignKey(d => d.WhoIsItFunc)
                    .HasConstraintName("FK_User_FuncPP");
            });

            modelBuilder.Entity<PolPol>(entity =>
            {
                entity.ToTable("PolPol");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RoulPp>(entity =>
            {
                entity.ToTable("RoulPP");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.WhoIsroul).HasColumnName("WhoISRoul");

                entity.HasOne(d => d.WhoIsroulNavigation)
                    .WithMany(p => p.RoulPps)
                    .HasForeignKey(d => d.WhoIsroul)
                    .HasConstraintName("FK_RoulPP_User");
            });

            modelBuilder.Entity<ToSatu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TransTt>(entity =>
            {
                entity.ToTable("TransTT");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DateReg).HasColumnType("date");

                entity.Property(e => e.DateSpis).HasColumnType("date");

                entity.Property(e => e.Mark).HasMaxLength(150);

                entity.Property(e => e.YearPr).HasColumnType("date");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateBird0).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fam).HasMaxLength(150);

                entity.Property(e => e.FuncPp).HasColumnName("FuncPP");

                entity.Property(e => e.LogininVx)
                    .HasMaxLength(50)
                    .HasColumnName("logininVx");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Otc).HasMaxLength(150);

                entity.Property(e => e.PasswordInVx).HasMaxLength(50);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.Tel).HasMaxLength(50);

                entity.HasOne(d => d.PolNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Pol)
                    .HasConstraintName("FK_User_PolPol");
            });

            modelBuilder.Entity<Zakaz>(entity =>
            {
                entity.HasKey(e => e.NomerZakaza);

                entity.ToTable("Zakaz");

                entity.Property(e => e.AddresDost).HasMaxLength(150);

                entity.Property(e => e.AddresOtp).HasMaxLength(150);

                entity.Property(e => e.DateZak).HasColumnType("date");

                entity.Property(e => e.WhoIszak).HasColumnName("WhoISZak");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Zakazs)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Zakaz_ToSatus");

                entity.HasOne(d => d.TransprtNavigation)
                    .WithMany(p => p.Zakazs)
                    .HasForeignKey(d => d.Transprt)
                    .HasConstraintName("FK_Zakaz_TransTT");

                entity.HasOne(d => d.WhoIszakNavigation)
                    .WithMany(p => p.Zakazs)
                    .HasForeignKey(d => d.WhoIszak)
                    .HasConstraintName("FK_Zakaz_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
