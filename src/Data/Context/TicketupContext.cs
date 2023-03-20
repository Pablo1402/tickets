using Business.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class TicketupContext : DbContext
    {
        public TicketupContext( DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StorePlan> StorePlans { get; set; }
        public DbSet<Campain> Campains { get; set; }
        
        public DbSet<CampainConfigurationType> CampainsConfigurationType { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientCampain> ClientCampains { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketupContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
