namespace tests;
using Xunit;
using database;
using Microsoft.EntityFrameworkCore.InMemory;

public class BoekTest{

    [Fact]
    //Test of de gast genoeg credits heeft (wel genoeg)
    public async void BoekWelCredits(){
        // Given
        Gast g = new Gast("LucasClavel@gmail");
        Attractie a = new Attractie("Draaimolen");
        DateTimeBereik d = new DateTimeBereik {Eind = DateTime.Today, Begin = DateTime.Today};
        DatabaseContext c = new DatabaseContext();
        // When
        bool test = await c.Boek(g, a, d);
        // Then
        Assert.True(test);
    }

    [Fact]
    //Test of de gast genoeg credits heeft (niet genoeg)
    public async void BoekGeenCredits(){
        // Given
        Gast g = new Gast("LucasClavel@gmail");
        Attractie a = new Attractie("Draaimolen");
        DateTimeBereik d = new DateTimeBereik {Eind = DateTime.Today, Begin = DateTime.Today};
        DatabaseContext c = new DatabaseContext();
        g.Credits = 0;
        // When
        bool test = await c.Boek(g, a, d);
        // Then
        Assert.False(test);

    }

    [Fact]
    //Test of de attractie goed wordt meegegeven (niet null)
    public async void BoekWelAttractie(){
        // Given
        Gast g = new Gast("LucasClavel@gmail");
        Attractie a = new Attractie("Draaimolen");
        DateTimeBereik d = new DateTimeBereik {Eind = DateTime.Today, Begin = DateTime.Today};
        DatabaseContext c = new DatabaseContext();
        // When
        bool test = await c.Boek(g, a, d);
        // Then
        Assert.True(test);
    }

    [Fact]
    //Test of de attractie goed wordt meegegeven (wel null)
    public async void BoekGeenAttractie(){
        // Given
        Gast g = new Gast("LucasClavel@gmail");
        Attractie a = new Attractie("Draaimolen");
        a.Naam = null;
        DateTimeBereik d = new DateTimeBereik {Eind = DateTime.Today, Begin = DateTime.Today};
        DatabaseContext c = new DatabaseContext();    
        // When
        bool test = await c.Boek(g, a, d);
        // Then
        Assert.False(test);
    }

    [Fact]
    //Test of de datum goed wordt meegegeven
    public async void BoekWelDatum(){
        // Given
        Gast g = new Gast("LucasClavel@gmail");
        Attractie a = new Attractie("Draaimolen");
        DateTimeBereik d = new DateTimeBereik {Eind = DateTime.Today, Begin = DateTime.Today};
        DatabaseContext c = new DatabaseContext();    
        // When
        bool test = await c.Boek(g, a, d);
        // Then
        Assert.True(test);
    }

    [Fact]
    //Test of Gast goed wordt meegegeven
    public async void BoekWelGast(){
        // Given
        Gast g = new Gast("LucasClavel@gmail");
        Attractie a = new Attractie("Draaimolen");
        DateTimeBereik d = new DateTimeBereik {Eind = DateTime.Today, Begin = DateTime.Today};
        DatabaseContext c = new DatabaseContext();    
        // When
        bool test = await c.Boek(g, a, d);
        // Then
        Assert.True(test);
    }
}