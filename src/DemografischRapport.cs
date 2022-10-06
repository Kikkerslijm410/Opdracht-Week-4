namespace database{
    //     class DemografischRapport : Rapport{
    //     private DatabaseContext context;
    //     public DemografischRapport(DatabaseContext context) => this.context = context;
    //     public override string Naam() => "Demografie";
    //     public override async Task<string> Genereer()
    //     {
    //         string ret = "Dit is een demografisch rapport: \n";
    //         ret += $"Er zijn in totaal { await AantalGebruikers() } gebruikers van dit platform (dat zijn gasten en medewerkers)\n";
    //         var dateTime = new DateTime(2000, 1, 1);
    //         ret += $"Er zijn { await AantalSinds(dateTime) } bezoekers sinds { dateTime }\n";
    //         if (await AlleGastenHebbenReservering())
    //             ret += "Alle gasten hebben een reservering\n";
    //         else
    //             ret += "Niet alle gasten hebben een reservering\n";
    //         ret += $"Het percentage bejaarden is { await PercentageBejaarden() }\n";

    //         ret += $"De oudste gast heeft een leeftijd van { await HoogsteLeeftijd() } \n";

    //         ret += "De verdeling van de gasten per dag is als volgt: \n";
    //         var dagAantallen = await VerdelingPerDag();
    //         var totaal = dagAantallen.Select(t => t.aantal).Max();
    //         foreach (var dagAantal in dagAantallen)
    //             ret += $"{ dagAantal.dag }: { new string('#', (int)(dagAantal.aantal / (double)totaal * 20)) }\n";

    //         ret += $"{ await FavorietCorrect() } gasten hebben de favoriete attractie inderdaad het vaakst bezocht. \n";

    //         return ret;
    //     }
    //     private async Task<int> AantalGebruikers() => /* ... */;
    //     private async Task<bool> AlleGastenHebbenReservering() => /* ... */;
    //     private async Task<int> AantalSinds(DateTime sinds) => /* ... */;
    //     private async Task<Gast> GastBijEmail(string email) => /* ... */;
    //     private async Task<Gast?> GastBijGeboorteDatum(DateTime d) => /* ... */;
    //     private async Task<double> PercentageBejaarden() => /* ... */;
    //     private async Task<int> HoogsteLeeftijd() => /* ... */;
    //     private async Task<(string dag, int aantal)[]> VerdelingPerDag() => /* ... */;
    //     private async Task<int> FavorietCorrect() => /* ... */; 
    // }
}