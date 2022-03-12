using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RPGInfo.Web.Models;

namespace RPGInfo.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WorldEvent> WorldEvents { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Area> AreasOfInterest { get; set; }
        public DbSet<RelatedNpc> RelatedNpcs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
