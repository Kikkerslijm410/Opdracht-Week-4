using Microsoft.EntityFrameworkCore;

namespace database{
    public class DatabaseContext : DbContext{
        protected override void OnModelCreating(ModelBuilder builder){

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder){
            //UseSQLServer(Data Source=DESKTOP-6PE5SC4\SQLEXPRESS01 Catalog=YourDatabase;Integrated Security=true);
        }

        public DbSet<Gebruiker> DBGebruiker(){
            return 
        }
    }
}

//DESKTOP-6PE5SC4\SQLEXPRESS01