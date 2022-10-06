namespace database{
    public class Gebruiker{
        public int Id {get;set;}
        public string Email {get; set;} 
        public Gebruiker(string NewEmail){
            Email = NewEmail; 
        }   

        protected Gebruiker(){}
    }
}