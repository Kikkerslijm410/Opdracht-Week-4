namespace database{
    public class Gast{
        public int Id_Gast {get; set;}
        public int Credits {get; set;}
        public DateTime Geboortedatum {get; set;}
        public DateTime EersteBezoek {get; set;}

        public Gast(string email){
            new Gebruiker(email);
            Geboortedatum = DateTime.Today;
            EersteBezoek = DateTime.Today;
        }
    }
}