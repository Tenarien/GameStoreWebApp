using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

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
app.MapGet("games/{Id}", (int Id) => games.Find(game => game.Id == Id)).WithName(GetGameEndpointName);

//POST /games
app.MapPost("games", (CreateGameDto newGame) => 
{
    GameDto game = new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new {Id = game.Id}, game);
});

//PUT /games
app.MapPut("games/{Id}", (int Id, UpdateGameDto updateGame) =>
{
    var index = games.FindIndex(game => game.Id == Id);

    games[index] = new GameDto(Id, updateGame.Name, updateGame.Genre, updateGame.Price, updateGame.ReleaseDate);
    
    return Results.NoContent();
});

//DELETE /games/1
app.MapDelete("games/{Id}", (int Id) => 
{
    games.RemoveAll(game => game.Id == Id );

    return Results.NoContent();
});

app.Run();
