using Microsoft.EntityFrameworkCore;
using Lost_And_Found_Portal.Components.Models; // Ensure this matches your Item.cs folder
using Lost_And_Found_Portal.Components.Data;   // Ensure this matches your ApplicationDbContext folder

namespace Lost_And_Found_Portal.Components.Services
{
	public class ItemService : IItemService
	{
		private readonly ApplicationDbContext _context;

		public ItemService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Lost_And_Found_Portal.Components.Models.Item>> GetAllItemsAsync()
		{
			return await _context.Items.ToListAsync();
		}

		public async Task AddItemAsync(Lost_And_Found_Portal.Components.Models.Item item)
		{
			_context.Items.Add(item);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateItemAsync(Lost_And_Found_Portal.Components.Models.Item item)
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