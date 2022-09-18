using DesignPatternDecorator.Abstraction;
using DesignPatternDecorator.Model;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternDecorator.Controllers;

[ApiController]
[Route("[controller]")]
//[ResponseCache(Duration = 10)]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IPlayersService _playersService;

    public WeatherForecastController
    (
        ILogger<WeatherForecastController> logger,
        IPlayersService playersService
    )
    {
        _logger = logger;
        _playersService = playersService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Player> Get()
    {
        return _playersService.GetPlayersList();
    }
}

