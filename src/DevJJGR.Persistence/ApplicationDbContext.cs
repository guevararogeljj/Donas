using Donouts.Domain.Entities;
using Donouts.Domain.Entities.Activities;
using Donouts.Domain.Entities.Calendario;
using Donouts.Domain.Entities.Donouts;
using Donouts.Domain.Entities.Messages;
using Donouts.Persistance.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Donouts.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TypeDonouts> TypeDonouts { get; set; }
        public DbSet<SalesDonouts> SalesDonouts { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<MessagesChat> MessagesChats { get; set; }
        public DbSet<CalendarioActividades> CalendarioActividades { get; set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new TypeDonoutsConfiguration());
            builder.ApplyConfiguration(new SalesDonoutsConfiguration());
            builder.ApplyConfiguration(new ActivitiesConfiguration());
            builder.ApplyConfiguration(new CalendarConfiguration());
            builder.ApplyConfiguration(new MessagesChatConfiguration());
        }
    }
}
