using DesignPatternDecorator.Model;

namespace DesignPatternDecorator.Abstraction
{
	public interface IPlayersService
	{
		IEnumerable<Player> GetPlayersList();
	}
}

