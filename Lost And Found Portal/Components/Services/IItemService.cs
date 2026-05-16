using Lost_And_Found_Portal.Components.Models;

namespace Lost_And_Found_Portal.Components.Services
{
	public interface IItemService
	{
		Task<IEnumerable<Item>> GetAllItemsAsync();
		Task AddItemAsync(Item item);
		Task UpdateItemAsync(Item item);
		Task DeleteItemAsync(int id);
	}
}