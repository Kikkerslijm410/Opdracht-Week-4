using Microsoft.EntityFrameworkCore;

namespace database{
    public class DatabaseContext : DbContext{
        public DbSet<Gebruiker> DbGebruiker {get; set;}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Gebruiker>().HasKey(u => u.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder){
            var computer = Environment.MachineName;
            //DESKTOP-6PE5SC4\SQLEXPRESS01
            builder.UseSqlServer("server" + computer + "\\SQLEXPRESS01 Catalog=YourDatabase;Integrated Security=true");
        }
    }
}