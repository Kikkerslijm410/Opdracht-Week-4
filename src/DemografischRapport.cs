namespace database{
        class DemografischRapport : Rapport{
        private DatabaseContext context = new DatabaseContext();
        public DemografischRapport(DatabaseContext context) => this.context = context;
        public override string Naam() => "Demografie";
        public override async Task<string> Genereer()
        {
            string ret = "Dit is een demografisch rapport: \n";
            ret += $"Er zijn in totaal { await AantalGebruikers() } gebruikers van dit platform (dat zijn gasten en medewerkers)\n";

            var dateTime = new DateTime(2000, 1, 1);
            ret += $"Er zijn { await AantalSinds(dateTime) } bezoekers sinds { dateTime }\n";

            if (await AlleGastenHebbenReservering())
                ret += "Alle gasten hebben een reservering\n";
            else
                ret += "Niet alle gasten hebben een reservering\n";

            ret += $"Het percentage bejaarden is { await PercentageBejaarden() }\n";
            ret += $"De oudste gast heeft een leeftijd van { await HoogsteLeeftijd() } \n";
            ret += $"{ await FavorietCorrect() } gasten hebben de favoriete attractie inderdaad het vaakst bezocht. \n";

            return ret;
        }
        private async Task<int> AantalGebruikers() => await Task<int>.Run(() => {return context.DbGebruiker.Count();}); 
        private async Task<bool> AlleGastenHebbenReservering() => await Task<bool>.Run(() =>{return context.DbGast.Where<Gast>(gast => gast.reservering.Count() > 0).Count() == context.DbGast.Count();});
        private async Task<int> AantalSinds(DateTime sinds) => await Task<int>.Run(() => {return context.DbGast.Where<Gast>(gast => gast.EersteBezoek > sinds).Count();});
        private async Task<Gast> GastBijEmail(string email) => await Task<Gast>.Run(() =>{return context.DbGast.First<Gast>(gast => gast.Email == email);}); 
        private async Task<Gast?> GastBijGeboorteDatum(DateTime d) => await Task<Gast>.Run(() =>{return context.DbGast.First<Gast>(gast => gast.Geboortedatum == d);});
        private async Task<double> PercentageBejaarden() => await Task<double>.Run(() => {return (double)context.DbGast.Where<Gast>(gast => (EF.Functions.DateDiffDay(gast.Geboortedatum, DateTime.Now) / 365) > 79).Count()/(double)(context.DbGebruiker.Count())*100;});
        private async Task<int> HoogsteLeeftijd() => await Task<int>.Run(() => {return context.DbGast.Select(gast => (int)(EF.Functions.DateDiffDay(gast.Geboortedatum, DateTime.Now) / 365)).Max();});
        private IEnumerable<Gast> Blut (IEnumerable<Gast> b) => b.Where(b => b.Credits < 1);
        private async Task<int> FavorietCorrect() => await Task<int>.Run(() => {return context.DbGast.Where(gast => gast.reservering.Where(k => gast.FavorieteAttractie !=null && k.GereserverdeAttracties.Id == gast.FavorieteAttractie.Id ).Count() > (gast.reservering.Count()/2)).Count();}); 
    }
}