using Biosite.Core;
using Biosite.Domain.Entities;
using Biosite.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Biosite.Infrastructure.Contexts
{
    public class BiositeDataContext : DbContext
    {
        public BiositeDataContext() { }

        public BiositeDataContext(DbContextOptions<BiositeDataContext> options) : base(options) { }

        public DbSet<Biomarker> Biomarkers { get; set; }
        public DbSet<Organ> Organs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Area> Areas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Runtime.ConnectionString);
            options.UseLazyLoadingProxies(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BiomarkerMap());
            modelBuilder.ApplyConfiguration(new BiomarkerOrganMap());
            modelBuilder.ApplyConfiguration(new OrganMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PlanMap());
            modelBuilder.ApplyConfiguration(new PlanAreaMap());
            modelBuilder.ApplyConfiguration(new AreaMap());
        }
    }
}
