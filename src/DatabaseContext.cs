namespace database{
    public class DatabaseContext : DbContext{
        public DbSet<Attractie> DbAttractie {get; set;} = null!;
        public DbSet<Gast> DbGast {get; set;} = null!;
        public DbSet<GastInfo> DbGastInfo {get; set;} = null!;
        public DbSet<Gebruiker> DbGebruiker {get; set;} = null!;
        public DbSet<Medewerker> DbMedewerker {get; set;} = null!;
        public DbSet<Onderhoud> DbOnderhoud {get; set;} = null!;
        public DbSet<Reservering> DbReservering {get; set;} = null!;

        public async Task<bool> Boek (Gast g, Attractie a, DateTimeBereik d){
            await a.Satan.WaitAsync();
            try { 
                if (a.reservering == null && a != null && g != null && d != null){
                    var reserveringX = new Reservering {gast = g, DTB_Reservering = d};
                    if (g.Credits >= 1){
                        g.Credits--;
                        g.reservering.Add(reserveringX);
                        this.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            finally {a.Satan.Release();}
        }
        protected override void OnModelCreating(ModelBuilder builder){

            //Attractie
            var Attractie = builder.Entity<Attractie>();
                Attractie.ToTable("Attractie");
                Attractie.HasKey(u => u.Id);

            //Gast
            var Gast = builder.Entity<Gast>();
                Gast.ToTable("Gast");
                Gast.HasOne(g => g.Begeleider)
                    .WithOne(g => g.Begeleid);
            
            //GastInfo
            var GastInfo = builder.Entity<GastInfo>();
                GastInfo.HasKey(u => u.Id);
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
                Onderhoud.HasKey(u => u.Id);
                Onderhoud.HasOne(g => g.attractie)
                    .WithMany(g => g.onderhoud)
                    .HasForeignKey(g => g.Id)
                    .IsRequired();

            //Reservering
            var Reservering = builder.Entity<Reservering>();
                Reservering.OwnsOne(o => o.DTB_Reservering);
                Reservering.HasOne(f => f.GereserverdeAttracties)
                    .WithMany(f => f.reservering);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder){
            var computer = Environment.MachineName;
            Console.WriteLine(computer);
            //DESKTOP-6PE5SC4\\SQLEXPRESS           niet "01" sukkel
            builder.UseSqlServer("Server=" + computer + "\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=true");
        }
    }
}