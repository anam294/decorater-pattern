using DesignPatternDecorator.Abstraction;
using DesignPatternDecorator.Model;
using Microsoft.Extensions.Caching.Memory;

namespace DesignPatternDecorator.Implementation;

public class PlayersServiceCachingDecorator : IPlayersService
{
    private readonly IPlayersService _playersService;
    private readonly IMemoryCache _memoryCache;

    private const string GetPlayersListCacheKey = "players.list";

    public PlayersServiceCachingDecorator(IPlayersService playersService, IMemoryCache memoryCache)
    {
        _playersService = playersService;
        _memoryCache = memoryCache;
    }
    
    public IEnumerable<Player> GetPlayersList()
    {
        IEnumerable<Player>? players = null;

        if (_memoryCache.TryGetValue(GetPlayersListCacheKey, out players)) return players;
        players = _playersService.GetPlayersList();
        var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1));

        _memoryCache.Set(GetPlayersListCacheKey, players, cacheEntryOptions);

        return players;
    }
}