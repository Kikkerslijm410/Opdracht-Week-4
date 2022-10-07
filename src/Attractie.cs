namespace database{
    public class Attractie{
        public int Id_Attractie {get; set;}
        public string? Naam {get; set;}
        public DateTimeBereik? DTB_Attractie {get; set;}

        public Task<bool> OnderhoudBezig (DatabaseContext c){
            return
        }

        public Task<bool> Vrij (DatabaseContext c, DateTimeBereik d){
            return
        }    
    }
}