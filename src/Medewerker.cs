namespace database{
    public class Medewerker : Gebruiker{
        public int Id {get; set;}
        public Medewerker(string Email) : base(Email){}
    }
}