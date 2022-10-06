using Microsoft.EntityFrameworkCore;

namespace database{
    public class DatabaseContext : DbContext{
        public DbSet<Gebruiker> DbGebruiker {get; set;}

        protected override void OnModelCreating(ModelBuilder builder){

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder){
            var computer = Environment.MachineName;
            builder.UseSQLServer("server" + computer + "\\SQLEXPRESS01 Catalog=YourDatabase;Integrated Security=true");
        }
    }
}

//DESKTOP-6PE5SC4\SQLEXPRESS01