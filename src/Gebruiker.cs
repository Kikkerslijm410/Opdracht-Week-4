namespace database{
    public class Gebruiker{
        public string Email {get; set;} = null!;
        public Gebruiker(string NewEmail){
            this.Email = NewEmail; 
        }   
        protected Gebruiker(){}
    }
}