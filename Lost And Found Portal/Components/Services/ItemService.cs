using Lost_And_Found_Portal.Components.Data;
using Lost_And_Found_Portal.Components.Models;
using Lost_And_Found_Portal.Components.Services;
using Microsoft.EntityFrameworkCore;

namespace Lost_And_Found_Portal.Services
{
	public class ItemService : IItemService
	{
		private readonly ApplicationDbContext _context;

		public ItemService(ApplicationDbContext context)
		{
			_context = context;
		}

		// Feature: Create/Post a New Item
		public async Task<bool> CreateItemAsync(Item item)
		{
			try
			{
				_context.Items.Add(item);
				var result = await _context.SaveChangesAsync();
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		// Feature: Get All Items for the Dashboard
		public async Task<List<Item>> GetAllItemsAsync()
		{
			return await _context.Items.OrderByDescending(x => x.Id).ToListAsync();
		}

		public async Task<bool> DeleteItemAsync(int id)
		{
			var item = await _context.Items.FindAsync(id);
			if (item == null) return false;

			_context.Items.Remove(item);
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
