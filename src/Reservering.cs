namespace database{
    public class Reservering{
        public int Id {get; set;}
        public int Id_Gast {get; set;}
        public Gast? gast {get; set;}
        public Attractie GereserverdeAttracties {get;set;} = null!;
        public DateTimeBereik DTB_Reservering {get; set;} = null!;
    }
}