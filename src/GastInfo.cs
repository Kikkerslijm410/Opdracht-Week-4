namespace database{
    public class GastInfo{
        public int Id_GastInfo {get; set;}
        public string LaatstBezochteURL = null!;
        public Coordinate? coordinaat = new Coordinate();
        public Gast gast = null!;
        
        public GastInfo(Gast gast2){
            this.gast = gast2;
        }
    }
}