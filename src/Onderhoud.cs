namespace database{
    public class Onderhoud{
        public int Id_Onderhoud {get; set;}
        public string? probleem {get; set;}
        public DateTimeBereik? DTB_Onderhoud {get; set;}
        public Attractie? attractie;
        public List<Medewerker> medewerkers = new List<Medewerker>();
        public Onderhoud (string probleem, Attractie attractie){
            this.attractie = attractie;
            this.probleem = probleem;
        }

        protected Onderhoud(){}
    }
}