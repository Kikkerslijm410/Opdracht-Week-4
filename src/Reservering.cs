namespace database{
    public class Reservering{
        public int  Id_Reservering {get; set;}
        public int Id_Gast {get; set;}
        public Gast? gast {get; set;}
        public List<Attractie>? GereserverdeAttracties {get;set;}
        public DateTimeBereik? DTB_Reservering {get; set;}
    }
}