namespace database{
    public class Attractie{
        public int Id {get; set;}
        public string? Naam {get; set;}
        public Reservering? reservering {get; set;}
        public List<Onderhoud> onderhoud = new List<Onderhoud>();
        public readonly SemaphoreSlim Satan = new SemaphoreSlim(1, 1);
        //https://dotnetpattern.com/threading-semaphore
        
        public Attractie(string naam){
            Naam = naam;
        }

        public async Task<bool> OnderhoudBezig (DatabaseContext c){
            return await OnderhoudBezigDate (c, new DateTimeBereik{Begin = DateTime.Now, Eind = DateTime.Now});
        }

        public async Task<bool> Vrij(DatabaseContext c, DateTimeBereik d){
           if(await OnderhoudBezigDate(c,d) && await VrijDate(c,d)){
            return true;
           }
           return false;
        }

        public async Task<bool> OnderhoudBezigDate (DatabaseContext c, DateTimeBereik d){
            var bezig = Task<bool>.Run(() => {
                foreach (Onderhoud probleem in c.DbOnderhoud.AsEnumerable()){
                    if (probleem.attractie.Id == this.Id){
                        if (probleem.DTB_Onderhoud.OverlaptV2(d)){
                            return true;
                        }
                    }
                }
                return false;
            });
            return await bezig;
        }

        public async Task<bool> VrijDate (DatabaseContext c, DateTimeBereik d){
            var bezig = Task<bool>.Run(() => {
                foreach (Reservering probleem in c.DbReservering.AsEnumerable()){
                    if (probleem.GereserverdeAttracties.Equals(this.Id)){
                        if (probleem.DTB_Reservering.OverlaptV2(d)){
                            return true;
                        }
                    }
                }
                return false;
            });
            return await bezig;
        }
    }    
}