using System.Diagnostics;
using DesignPatternDecorator.Abstraction;
using DesignPatternDecorator.Model;

namespace DesignPatternDecorator.Implementation
{
	public class PlayersServiceLoggingDecorator : IPlayersService
	{
        private readonly IPlayersService _playersService;
        private readonly ILogger<PlayersServiceLoggingDecorator> _logger;

        public PlayersServiceLoggingDecorator
        (
            IPlayersService playersService,
            ILogger<PlayersServiceLoggingDecorator> logger
        )
        {
            _playersService = playersService;
            _logger = logger;
        }

        public IEnumerable<Player> GetPlayersList()
        {
            _logger.LogInformation("Starting to fetch data..");
            var stopWatch = Stopwatch.StartNew();

            var players = _playersService.GetPlayersList();

            foreach (var player in players)
            {
                _logger.LogInformation("Player: " + player.Id + ", Name: " + player.Name);
            }

            stopWatch.Stop();
            var elapsedTime = stopWatch.ElapsedMilliseconds;

            _logger.LogInformation($"Finished fetching data in {elapsedTime} milliseconds");

            return players;
        }
    }
}

