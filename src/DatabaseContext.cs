namespace database{
    public class DatabaseContext : DbContext{
        //all tables:
        public DbSet<Attractie>? DbAttractie {get; set;}
        public DbSet<Gast>? DbGast {get; set;}
        public DbSet<GastInfo>? DbGastInfo {get; set;}
        public DbSet<Gebruiker>? DbGebruiker {get; set;}
        public DbSet<Medewerker>? DbMedewerker {get; set;}
        public DbSet<Onderhoud>? DbOnderhoud {get; set;}
        public DbSet<Reservering>? DbReservering {get; set;}


        //Makes the keys
        protected override void OnModelCreating(ModelBuilder builder){
            //builder.Entity<Gebruiker>().ToTable("Mafklapper"); //other way of phrasing it

            //Attractie
            var Attractie = builder.Entity<Attractie>();
                Attractie.ToTable("Attractie");
                Attractie.HasKey(u => u.Id_Attractie);
                Attractie.OwnsOne(o => o.DTB_Attractie);

            //Gast
            var Gast = builder.Entity<Gast>();
                Gast.ToTable("Gast");
                Gast.HasOne(g => g.Begeleider)
                    .WithOne(g => g.Begeleid);
            
            //GastInfo
            var GastInfo = builder.Entity<GastInfo>();
                GastInfo.HasKey(u => u.Id_GastInfo);
                GastInfo.OwnsOne(o => o.coordinaat);

            //Gebruiker
            var Gebruiker = builder.Entity<Gebruiker>();
                Gebruiker.ToTable("Gebruiker");
                Gebruiker.HasKey(u => u.Email); 

            //Medewerker
            var Medewerker = builder.Entity<Medewerker>();
                Medewerker.HasKey(u => u.Id_Medewerker);

            //Onderhoud
            var Onderhoud = builder.Entity<Onderhoud>(); 
                Onderhoud.HasKey(u => u.Id_Onderhoud);

            //Reservering
            var Reservering = builder.Entity<Reservering>();
                Reservering.HasKey(u => u.Id_Reservering);
                Reservering.OwnsOne(o => o.DTB_Reservering);
                Reservering.HasMany(f => f.GereserverdeAttracties).WithOne(f => f.reservering);

            builder.Entity<Gast>().HasOne(f => f.Id_GebruikerGast);
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
//gast id is een foreign key naar gebruiker id (hetzelfde geld voor medewerker id)
