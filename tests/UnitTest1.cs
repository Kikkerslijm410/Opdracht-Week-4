namespace tests;
using Xunit;
using database;

public class UnitTest1{

    //probably needs mocks, since you need every class
       public Gast g = new Gast("LucasClavel@gmail");
       public Attractie a = new Attractie("Draaimolen");
       public DateTimeBereik d = new DateTimeBereik{Eind = DateTime.Today, Begin = DateTime.Today};
       public DatabaseContext c = new DatabaseContext();
       public Reservering r = new Reservering();

    [Fact]
    public async void BoekWelCredits(){
        // Given
        g.Credits = 10;
        // When
        bool test = await c.Boek(g, a, d);

        // Then
        Assert.True(test);
    }
}