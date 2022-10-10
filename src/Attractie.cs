namespace database{
    public class Attractie{
        public int Id_Attractie {get; set;}
        public string? Naam {get; set;}
        public Reservering? reservering {get; set;}
        public List<Onderhoud> onderhoud = new List<Onderhoud>();
        
        public Attractie(string naam){
            Naam = naam;
        }

        // public async Task<bool> OnderhoudBezig (DatabaseContext c){
        //     return await
        // }

        // public async Task<bool> Vrij (DatabaseContext c, DateTimeBereik d){
        //     return await
        // }    
    }
}