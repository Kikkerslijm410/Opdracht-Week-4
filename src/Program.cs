global using Microsoft.EntityFrameworkCore; 
namespace database{
public class MainClass
{
    private static async Task<T> Willekeurig<T>(DbContext c) where T : class => await c.Set<T>().OrderBy(r => EF.Functions.Random()).FirstAsync();
    public static async Task Main(string[] args)
    {
        Random random = new Random(1);
        using (DatabaseContext c = new DatabaseContext())
        {
            c.DbAttractie.RemoveRange(c.DbAttractie);
            c.DbGebruiker.RemoveRange(c.DbGebruiker);
            c.DbGast.RemoveRange(c.DbGast);
            c.DbMedewerker.RemoveRange(c.DbMedewerker);
            c.DbReservering.RemoveRange(c.DbReservering);
            c.DbOnderhoud.RemoveRange(c.DbOnderhoud);

            c.SaveChanges();

            foreach (string attractie in new string[] { "Reuzenrad", "Spookhuis", "Achtbaan 1", "Achtbaan 2", "Draaimolen 1", "Draaimolen 2" })
                c.DbAttractie.Add(new Attractie(attractie));

            c.SaveChanges();

            for (int i=0;i<40;i++)
                c.DbMedewerker.Add(new Medewerker($"medewerker{i}@mail.com"));

            c.SaveChanges();

            for (int i = 0; i < 10000; i++){
                var geboren = DateTime.Now.AddDays(-random.Next(36500));
                var nieuweGast = new Gast($"gast{i}@mail.com") { Geboortedatum = geboren, EersteBezoek = geboren + (DateTime.Now - geboren) * random.NextDouble(), Credits = random.Next(5) };
                if (random.NextDouble() > .6)
                    nieuweGast.FavorieteAttractie = await Willekeurig<Attractie>(c);
                c.DbGast.Add(nieuweGast);
            }
            c.SaveChanges();

            for (int i = 0; i < 10; i++)
                (await Willekeurig<Gast>(c)).Begeleider = await Willekeurig<Gast>(c);
                
            c.SaveChanges();

            Console.WriteLine("Finished initialization");

            Console.Write(await new DemografischRapport(c).Genereer());
            Console.ReadLine();
        }
    }
}
}