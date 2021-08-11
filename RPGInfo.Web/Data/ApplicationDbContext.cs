using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGInfo.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // TODO: Need to run migrations, may need to inherit from DbContext as well as IdentityDbContext?
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignEvent> CampaignEvent { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<AreaOfInterest> AreasOfInterest { get; set; }
        public DbSet<Party> Parties { get; set; }
    }
}
