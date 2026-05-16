using Microsoft.EntityFrameworkCore;
using Lost_And_Found_Portal.Components.Models;
using Lost_And_Found_Portal.Components.Data;

namespace Lost_And_Found_Portal.Components.Services
{
	public class ItemService : IItemService
	{
		private readonly ApplicationDbContext _context;

		public ItemService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Item>> GetAllItemsAsync()
		{
			return await _context.Items.ToListAsync();
		}

		public async Task AddItemAsync(Item item)
		{
			_context.Items.Add(item);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateItemAsync(Item item)
		{
			_context.Items.Update(item);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteItemAsync(int id)
		{
			var item = await _context.Items.FindAsync(id);
			if (item != null)
			{
				_context.Items.Remove(item);
				await _context.SaveChangesAsync();
			}
		}
	}
}