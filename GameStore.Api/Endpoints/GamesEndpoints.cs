using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";
    private static readonly List<GameDto> games = [
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

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games")
                        .WithParameterValidation();

        // GET /games
        group.MapGet("/", () => games);

        // GET /games/1
        group.MapGet("/{Id}", (int Id) => 
        {
            GameDto? game = games.Find(game => game.Id == Id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        //POST /games
        group.MapPost("/", (CreateGameDto newGame) => 
        {
            GameDto game = new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new {Id = game.Id}, game);
        });

        //PUT /games
        group.MapPut("/{Id}", (int Id, UpdateGameDto updateGame) =>
        {
            var index = games.FindIndex(game => game.Id == Id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(Id, updateGame.Name, updateGame.Genre, updateGame.Price, updateGame.ReleaseDate);
            
            return Results.NoContent();
        });

        //DELETE /games/1 
        app.MapDelete("/{Id}", (int Id) => 
        {
            games.RemoveAll(game => game.Id == Id );

            return Results.NoContent();
        });

        return group;
    }
}
