﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignEvent> CampaignEvent { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<AreaOfInterest> AreasOfInterest { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Character>()
                .HasMany(x => x.OthersWhoCharacterKnows).WithMany(y => y.OthersWhoKnowCharacter);

            base.OnModelCreating(builder);
        }
    }
}
