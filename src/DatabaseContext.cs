namespace database{
    public class DatabaseContext : DbContext{
        public DbSet<Attractie>? DbAttractie {get; set;}
        public DbSet<Gast>? DbGast {get; set;}
        public DbSet<GastInfo>? DbGastInfo {get; set;}
        public DbSet<Gebruiker>? DbGebruiker {get; set;}
        public DbSet<Medewerker>? DbMedewerker {get; set;}
        public DbSet<Onderhoud>? DbOnderhoud {get; set;}
        public DbSet<Reservering>? DbReservering {get; set;}

        public async Task<bool> boek (Gast g, Attractie a, DateTimeBereik d){
            await a.Semaphore.WaitAsync();
            try { 
                if (a.reservering == null){
                    var reservering = new Reservering {gast = g, DTB_Reservering = d};
                    if (g.Credits >= 1){
                    g.Credits--;
                    reservering.GereserverdeAttracties.Add(a);
                    this.SaveChanges();
                    return true;
                    }
                }
                return false;
            }
            finally { a.Semaphore.Release(); }
        }
        protected override void OnModelCreating(ModelBuilder builder){

            //Attractie
            var Attractie = builder.Entity<Attractie>();
                Attractie.ToTable("Attractie");
                Attractie.HasKey(u => u.Id_Attractie);

            //Gast
            var Gast = builder.Entity<Gast>();
                Gast.ToTable("Gast");
                Gast.HasOne(g => g.Begeleider)
                    .WithOne(g => g.Begeleid);
            
            //GastInfo
            var GastInfo = builder.Entity<GastInfo>();
                // GastInfo.ToTable("Gastinfo");
                GastInfo.HasKey(u => u.Id_GastInfo);
                GastInfo.OwnsOne(o => o.coordinaat);
                GastInfo.HasOne(g => g.gast)
                    .WithOne(g => g.GastInformatie)
                    .HasForeignKey<Gast>(g => g.GastinfoId);

            //Gebruiker
            var Gebruiker = builder.Entity<Gebruiker>();
                Gebruiker.ToTable("Gebruiker");
                Gebruiker.HasKey(u => u.Email); 

            //Medewerker
            var Medewerker = builder.Entity<Medewerker>();
                Medewerker.ToTable("Medewerker");

            //Onderhoud
            var Onderhoud = builder.Entity<Onderhoud>(); 
                Onderhoud.ToTable("Onderhoud");
                Onderhoud.HasKey(u => u.Id_Onderhoud);
                //Onderhoud.OwnsOne(o => o.DTB_Onderhoud);
                Onderhoud.HasOne(g => g.attractie)
                    .WithMany(g => g.onderhoud)
                    .HasForeignKey(g => g.Id_Onderhoud)
                    .IsRequired();

            //Reservering
            var Reservering = builder.Entity<Reservering>();
                // Reservering.ToTable("Reservering");
                // Reservering.HasKey(u => u.Id_Reservering);
                Reservering.OwnsOne(o => o.DTB_Reservering);
                Reservering.HasMany(f => f.GereserverdeAttracties).WithOne(f => f.reservering);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder){
            var computer = Environment.MachineName;
            //DESKTOP-6PE5SC4\SQLEXPRESS01
            builder.UseSqlServer("Server=" + computer + "\\SQLEXPRESS01;Initial Catalog=YourDatabase;Integrated Security=true");
        }
    }
}