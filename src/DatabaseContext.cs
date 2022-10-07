namespace database{
    public class DatabaseContext : DbContext{
        //all tables:
        public DbSet<Gebruiker>? DbGebruiker {get; set;}
        public DbSet<Gast>? DbGast {get; set;}
        public DbSet<GastInfo>? DbGastInfo {get; set;}
        public DbSet<Medewerker>? DbMedewerker {get; set;}
        public DbSet<Reservering>? DbReservering {get; set;}
        public DbSet<Attractie>? DbAttractie {get; set;}

        //Makes the keys
        protected override void OnModelCreating(ModelBuilder builder){
            //builder.Entity<Gebruiker>().ToTable("Mafklapper"); //other way of phrasing it

            var Attractie = builder.Entity<Attractie>();
                Attractie.HasKey(u => u.Id_Attractie);

            var Gast = builder.Entity<Gast>();
                Gast.HasKey(u => u.Id_GebruikerGast);

            var GastInfo = builder.Entity<GastInfo>();
                .HasKey(u => u.Id_GastInfo);

            builder.Entity<Gebruiker>()
                .HasKey(u => u.Id_Gebruiker); 

            builder.Entity<Medewerker>()
                .HasKey(u => u.Id_Medewerker);

            builder.Entity<Onderhoud>() 
                .HasKey(u => u.Id_Onderhoud);

            builder.Entity<Reservering>()
                .HasKey(u => u.Id_Reservering);



            //cant be added to the rest of the keys so they can stand here like losers
            builder.Entity<GastInfo>().OwnsOne(o => o.coordinaat);
            builder.Entity<Attractie>().OwnsOne(o => o.DTB_Attractie);
            builder.Entity<Reservering>().OwnsOne(o => o.DTB_Reservering);

            builder.Entity<Gast>().HasOne(f => f.Id_GebruikerGast).WithOne();
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
}//gast id is een foreign key naar gebruiker id (hetzelfde geld voor medewerker id)
