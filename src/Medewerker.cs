namespace database{
    public class Medewerker{
        public int Id_Medewerker {get; set;}
        public Medewerker(string email){
            new Gebruiker(email);
        }
    }
}