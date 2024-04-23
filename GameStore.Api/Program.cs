using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new( 
        1,
        "Starfield",
        "RPG",
        59.99M,
        new DateOnly(2024, 2, 10)),

    new( 
        2,
        "Witcher 3",
        "RPG",
        29.99M,
        new DateOnly(2012, 3, 15)),
        
    new( 
        3,
        "Forza Horizon 5",
        "Racing",
        59.99M,
        new DateOnly(2023, 1, 24)),
    
    new( 
        4,
        "Call Of Duty: Modern Warfare",
        "Shooter",
        59.99M,
        new DateOnly(2022, 6, 11)),
        
];

// GET /games
app.MapGet("games", () => games);

// GET /games/1
app.MapGet("games/{Id}", (int Id) => games.Find(game => game.Id == Id));

app.Run();
