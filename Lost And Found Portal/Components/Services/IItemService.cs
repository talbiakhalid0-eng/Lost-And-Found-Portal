namespace Lost_And_Found_Portal.Components.Services
{
	public interface IItemService
	{
		Task<IEnumerable<Lost_And_Found_Portal.Components.Models.Item>> GetAllItemsAsync();
		Task AddItemAsync(Lost_And_Found_Portal.Components.Models.Item item);
		Task UpdateItemAsync(Lost_And_Found_Portal.Components.Models.Item item);
		Task DeleteItemAsync(int id);
	}
}