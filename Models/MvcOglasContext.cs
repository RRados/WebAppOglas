using Microsoft.EntityFrameworkCore;

namespace WebAppOglas.Models
{
    public partial class MvcOglasContext : DbContext
    {
        public MvcOglasContext()
        {
        }

        public virtual DbSet<Automobil> Automobil { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP\\SQLSERVER;Database=AutoOglas;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Automobil>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Fotografija)
                    .HasColumnName("fotografija")
                    .HasMaxLength(50);

                entity.Property(e => e.Godiste).HasColumnName("godiste");

                entity.Property(e => e.Gorivo)
                    .HasColumnName("gorivo")
                    .HasMaxLength(50);

                entity.Property(e => e.Karoserija)
                    .HasColumnName("karoserija")
                    .HasMaxLength(50);

                entity.Property(e => e.Kontakt).HasColumnName("kontakt");

                entity.Property(e => e.Marka)
                    .HasColumnName("marka")
                    .HasMaxLength(50);

                entity.Property(e => e.Opis)
                    .HasColumnName("opis")
                    .HasMaxLength(50);

                entity.Property(e => e.Snaga).HasColumnName("snaga");

                entity.Property(e => e.ZapreminaMotora).HasColumnName("zapremina_motora");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
