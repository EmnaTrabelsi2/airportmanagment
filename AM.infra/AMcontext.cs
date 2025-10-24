using AM.applicationcore.domaine;
using AM.infra.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.infra
{
    public class AMcontext: DbContext  //classe generer de la base du donne ,classe de configuration du base du donne, classe generique du orm
        //package externe de visual studio :nuget 
        //chaque calsse herite de dbcontext est un fichier de configuration 
    {
        // les classes 
        public DbSet <Flight> Flghts{ get; set; }//crud
        public DbSet <Passenger> Passengers{ get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers{ get; set; }
        //chaine de connexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer

  (@"Data Source=(localdb)\mssqllocaldb;

    Initial Catalog=BdBi6;

    Integrated Security=true;

    MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
            //lazyLoading
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//configuration fkuent api 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //tph 
            //modelBuilder.Entity<Passenger>().HasDiscriminator<int>("PassengerType").HasValue<Passenger>(0).HasValue<Staff>(1).HasValue<Traveller>(2);
            //tpt
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");
            modelBuilder.Entity<Ticket>().HasKey(t => new { t.passenger_fk, t.flight_fk });



        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }




    }
}
