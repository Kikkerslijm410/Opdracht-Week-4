using Microsoft.EntityFrameworkCore;

namespace database{
    public class DatabaseContext : DbContext{
        //all tables:
        public DbSet<Gebruiker> DbGebruiker {get; set;}
        public DbSet<Gast> DbGast {get; set;}
        public DbSet<GastInfo> DbGastInfo {get; set;}
        public DbSet<Medewerker> DbMedewerker {get; set;}
        public DbSet<Reservering> DbReservering {get; set;}
        public DbSet<Attractie> DbAttractie {get; set;}

        //Makes the keys
        protected override void OnModelCreating(ModelBuilder builder){
            //builder.Entity<Gebruiker>().ToTable("Mafklapper"); //other way of phrasing it
            builder.Entity<Gebruiker>().HasKey(u => u.Id_Gebruiker); 
            builder.Entity<Gast>().HasKey(u => u.Id_Gast);
            builder.Entity<GastInfo>().HasKey(u => u.Id_GastInfo);
            builder.Entity<Medewerker>().HasKey(u => u.Id_Medewerker);
            builder.Entity<Onderhoud>().HasKey(u => u.Id_Onderhoud);
            builder.Entity<Reservering>().HasKey(u => u.Id_Reservering);
            builder.Entity<Attractie>().HasKey(u => u.Id_Attractie);

            // Die builder.entity en dan .hasOne of .hasMany 
            // gooi daar een lambda in naar het id van het object in kwestie. 
            // En daarachter kan je nog een .withOne of withMany doen om hem compleet te maken
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder){
            var computer = Environment.MachineName;
            //DESKTOP-6PE5SC4\SQLEXPRESS01
            builder.UseSqlServer("Server=" + computer + "\\SQLEXPRESS01;Initial Catalog=YourDatabase;Integrated Security=true");
        }
    }
}