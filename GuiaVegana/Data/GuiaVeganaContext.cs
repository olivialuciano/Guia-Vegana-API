using Microsoft.EntityFrameworkCore;
using GuiaVegana.Entities;

namespace GuiaVegana.Data
{
    public class GuiaVeganaContext : DbContext
    {
        public GuiaVeganaContext(DbContextOptions<GuiaVeganaContext> options)
            : base(options)
        {
        }

        // DbSet properties for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<OpeningHour> OpeningHours { get; set; }
        public DbSet<VeganOption> VeganOptions { get; set; }
        public DbSet<HealthProfessional> HealthProfessionals { get; set; }
        public DbSet<InformativeResource> InformativeResources { get; set; }
        public DbSet<Activism> Activisms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User
            modelBuilder.Entity<User>()
                .HasMany(u => u.Businesses)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.HealthProfessionals)
                .WithOne(hp => hp.User)
                .HasForeignKey(hp => hp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.InformativeResources)
                .WithOne(ir => ir.User)
                .HasForeignKey(ir => ir.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Activisms)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Business
            modelBuilder.Entity<Business>()
                .HasMany(b => b.OpeningHours)
                .WithOne(oh => oh.Business)
                .HasForeignKey(oh => oh.BusinessId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Business>()
                .HasMany(b => b.VeganOptions)
                .WithOne(vo => vo.Business)
                .HasForeignKey(vo => vo.BusinessId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure OpeningHour
            modelBuilder.Entity<OpeningHour>()
                .Property(oh => oh.OpenTime1)
                .HasColumnType("time");

            modelBuilder.Entity<OpeningHour>()
                .Property(oh => oh.CloseTime1)
                .HasColumnType("time");

            modelBuilder.Entity<OpeningHour>()
                .Property(oh => oh.OpenTime2)
                .HasColumnType("time");

            modelBuilder.Entity<OpeningHour>()
                .Property(oh => oh.CloseTime2)
                .HasColumnType("time");
        }
    }
}
