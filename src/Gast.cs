namespace database{
    public class Gast{
        public Gebruiker Id_GebruikerGast {get; set;}
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