using Microsoft.EntityFrameworkCore;
using Lost_And_Found_Portal.Components.Models;
using Lost_And_Found_Portal.Components.Data; // Ensure this matches where your ApplicationDbContext lives

namespace Lost_And_Found_Portal.Components.Services
{
	public class ItemService : IItemService
	{
		// 1. Declare the private field variable at the class level
		private readonly ApplicationDbContext _context;

		// 2. Pass the context into the constructor and assign it to the field variable
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