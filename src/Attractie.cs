namespace database{
    public class Attractie{
        public int Id_Attractie {get; set;}
        public string? Naam {get; set;}
        public DateTimeBereik? DTB_Attractie {get; set;}
        public Reservering? reservering {get; set;}

        public async Task<bool> OnderhoudBezig (DatabaseContext c){
            return await
        }

        public async Task<bool> Vrij (DatabaseContext c, DateTimeBereik d){
            return await
        }    
    }
}