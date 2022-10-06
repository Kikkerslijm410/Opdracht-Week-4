namespace database{
    public class Gebruiker{
        public string Email {get; set;} 
        public Gebruiker(string NewEmail){
            Email = NewEmail; 
        }   
    }
}