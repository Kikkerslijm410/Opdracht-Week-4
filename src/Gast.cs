namespace database{
    public class Gast : Gebruiker{
        public int Id {get; set;}
        public int Credits {get; set;}
        public int GastinfoId {get;set;}
        public DateTime Geboortedatum {get; set;}
        public DateTime EersteBezoek {get; set;}
        public Gast? Begeleider {get;set;}
        public Gast? Begeleid {get;set;}
        public Attractie? FavorieteAttractie {get;set;}
        public GastInfo GastInformatie;
        public List<Reservering> reservering {get;set;} = null!;

        public Gast(string Email) : base(Email){
            this.GastInformatie = new GastInfo(this);
            Credits = 1;
        }
    }
}