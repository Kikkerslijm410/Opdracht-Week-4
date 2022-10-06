using Microsoft.EntityFrameworkCore;

namespace database{
    public class DatabaseContext : DbContext{
        public DbSet<Gebruiker> DbGebruiker {get; set;}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Gebruiker>().HasKey(u => u.Id);
            builder.Entity<Gebruiker>().ToTable("Mafklapper");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder){
            var computer = Environment.MachineName;
            //DESKTOP-6PE5SC4\SQLEXPRESS01
            builder.UseSqlServer("Server=" + computer + "\\SQLEXPRESS01;Initial Catalog=YourDatabase;Integrated Security=true");
        }
    }
}