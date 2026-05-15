using Lost_And_Found_Portal.Components.Models;

namespace Lost_And_Found_Portal.Services
{
	public interface IItemService
	{
		Task<bool> CreateItemAsync(Item item);
		Task<List<Item>> GetAllItemsAsync();
		Task<bool> DeleteItemAsync(int id);
	}
}