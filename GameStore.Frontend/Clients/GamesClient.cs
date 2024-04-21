using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = 
    [
        new() {
            ID = 1,
            Name = "Starfield",
            Genre = "RPG",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2024, 2, 10)
        },
        new() {
            ID = 2,
            Name = "Witcher 3",
            Genre = "RPG",
            Price = 29.99M,
            ReleaseDate = new DateOnly(2012, 3, 15)
        },
        new() {
            ID = 3,
            Name = "Forza Horizon 5",
            Genre = "Racing",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2023, 1, 24)
        },
        new() {
            ID = 4,
            Name = "Call Of Duty: Modern Warfare",
            Genre = "Shooter",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2022, 6, 11)
        },
    ];

    public GameSummary[] GetGames() => [.. games];
}
