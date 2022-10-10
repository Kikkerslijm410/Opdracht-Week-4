namespace database {
    [Owned]
    public class DateTimeBereik{
        public DateTime Begin {get; set;}
        public DateTime? Eind {get; set;}

        public bool Eindigt(){
            if (Eind < DateTime.Today){
                return true;
            }
            return false;
        }

        public bool Overlapt (DateTime that){
            if (that < Eind && that > Begin){
                return true;
            }
            return false;
        }

        public bool OverlaptV2 (DateTimeBereik that){
            if (that.Eind < Begin && that.Begin > Eind){
                return true;
            }
            return false;
        }
    }
}