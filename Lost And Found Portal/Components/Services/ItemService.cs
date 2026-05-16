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
			item.Title ??= "Untitled Item";
			item.Description ??= "No description provided.";
			item.Category ??= "General";
			item.Location ??= "Campus Grounds";
			item.ImageUrl ??= "/images/placeholder.png";
			item.UserEmail ??= "anonymous@au.edu.pk";

			// FIX: Guard statement for database constraint execution
			item.ContactInfo ??= "Contact Admin Office / Email Provided";

			item.ClaimStatus ??= "Available";

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