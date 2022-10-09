namespace database{
    public class GastInfo{
        public int Id_GastInfo {get; set;}
        public string LaatstBezochteURL = null!;
        public Coordinate coordinaat = new Coordinate();
        public Gast gast = null!;
        
        public GastInfo(Gast gast){
            this.gast = gast;
        }

        protected GastInfo(){}
        
    }
}