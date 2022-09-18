using DesignPatternDecorator.Abstraction;
using DesignPatternDecorator.Model;

namespace DesignPatternDecorator.Implementation
{
    public class PlayersService : IPlayersService
    {
        public IEnumerable<Player> GetPlayersList()
        {
            Thread.Sleep(4000);
            return new List<Player>()
            {
                new Player(){ Id=1,  Name="Juan Mata"},
                new Player(){ Id=2,  Name="Paul Pogba"},
                new Player(){ Id=3,  Name="Phil Jones"},
                new Player(){ Id=4,  Name="David de Gea"},
                new Player(){ Id=5,  Name="Marcus Rashford"}
            };
        }
    }
}
