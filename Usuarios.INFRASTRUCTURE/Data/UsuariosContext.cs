using Microsoft.EntityFrameworkCore;
using Usuarios.CORE.Entities;

namespace Usuarios.INFRASTRUCTURE.Data
{
    public partial class UsuariosContext : DbContext
    {
        public UsuariosContext()
        {
        }

        public UsuariosContext(DbContextOptions<UsuariosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cards> Cards { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Usuarios;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cards>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CARDS");

                entity.Property(e => e.Cardid)
                    .HasColumnName("CARDID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("USER");

                entity.Property(e => e.Cardid).HasColumnName("CARDID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasMaxLength(11);

                entity.Property(e => e.Iduser)
                    .HasColumnName("IDUSER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(16);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
