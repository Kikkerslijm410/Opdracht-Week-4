namespace database{
    public class Medewerker : Gebruiker{
        public int Id_Medewerker {get; set;}
        public Medewerker(string Email) : base(Email){}
    }
}