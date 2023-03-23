using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FootballClubAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public DbSet<Klub> Kluby { get; set; }
        public DbSet<Pilkarz> Pilkarze { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Statystyka> Statystyki { get; set; }
        public DbSet<Zarzad> Zarzady { get; set; }

        public ApplicationDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetConnectionString("Database");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one to one
            modelBuilder.Entity<Klub>()
                .HasOne(k => k.Zarzad)
                .WithOne(k => k.Klub)
                .HasForeignKey<Zarzad>(k => k.IdKlubu)
                .OnDelete(DeleteBehavior.Cascade);


            // one to many
            modelBuilder.Entity<Pracownik>()
                .HasOne(p => p.Zarzad)
                .WithMany(p => p.Pracownicy)
                .HasForeignKey(p => p.IdZarzadu)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Statystyka>()
                .HasOne(s => s.Pilkarz)
                .WithMany(s => s.Statystyki)
                .HasForeignKey(s => s.IdPilkarz)
                .OnDelete(DeleteBehavior.Cascade);


            // football players have one current club
            modelBuilder.Entity<Pilkarz>()
                .HasOne(p => p.Klub)
                .WithMany(p => p.ObecniPilkarze)
                .HasForeignKey(p => p.IdKlubu)
                .OnDelete(DeleteBehavior.Cascade);


            // Entity Framework does not support collections of primitive types. Converting ICollection to string table
            modelBuilder.Entity<Klub>()
                .Property(e => e.Trofea)
                .HasConversion(v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Zarzad>()
                .Property(e => e.Cele)
                .HasConversion(v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

        }
    }
}
