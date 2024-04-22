using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = 
    [
        new() {
            Id = 1,
            Name = "Starfield",
            Genre = "RPG",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2024, 2, 10)
        },
        new() {
            Id = 2,
            Name = "Witcher 3",
            Genre = "RPG",
            Price = 29.99M,
            ReleaseDate = new DateOnly(2012, 3, 15)
        },
        new() {
            Id = 3,
            Name = "Forza Horizon 5",
            Genre = "Racing",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2023, 1, 24)
        },
        new() {
            Id = 4,
            Name = "Call Of Duty: Modern Warfare",
            Genre = "Shooter",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2022, 6, 11)
        },
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {   
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }

    public GameDetails GetGame(int Id)
    {
        var game = games.Find(game => game.Id == Id);
        ArgumentNullException.ThrowIfNull(game);

        var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };
    }
}
