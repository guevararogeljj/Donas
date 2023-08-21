﻿using Donouts.Domain.Entities;
using Donouts.Domain.Entities.Donouts;
using Donouts.Persistance.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Donouts.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TypeDonouts> TypeDonouts { get; set; }
        public DbSet<SalesDonouts> SalesDonouts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new TypeDonoutsConfiguration());
            builder.ApplyConfiguration(new SalesDonoutsConfiguration());
        }
    }
}
