using Microsoft.EntityFrameworkCore;
using Lost_And_Found_Portal.Components.Models;
using Lost_And_Found_Portal.Components.Data;
using Microsoft.Data.SqlClient;

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
			// Direct Raw SQL ensures it saves regardless of minor model namespace or structural mismatches
			string sql = @"
                INSERT INTO Items (Title, Description, Category, Location, ImageUrl, IsLost, UserEmail, ContactInfo, ClaimStatus)
                VALUES (@Title, @Description, @Category, @Location, @ImageUrl, @IsLost, @UserEmail, @ContactInfo, @ClaimStatus)";

			var parameters = new[]
			{
				new SqlParameter("@Title", (object)item.Title ?? "Untitled"),
				new SqlParameter("@Description", (object)item.Description ?? "No Description"),
				new SqlParameter("@Category", (object)item.Category ?? "General"),
				new SqlParameter("@Location", (object)item.Location ?? "Campus"),
				new SqlParameter("@ImageUrl", (object)item.ImageUrl ?? "/images/placeholder.png"),
				new SqlParameter("@IsLost", item.IsLost),
				new SqlParameter("@UserEmail", (object)item.UserEmail ?? "anonymous@au.edu.pk"),
				new SqlParameter("@ContactInfo", (object)item.ContactInfo ?? "None Provided"),
				new SqlParameter("@ClaimStatus", (object)item.ClaimStatus ?? "Available")
			};

			await _context.Database.ExecuteSqlRawAsync(sql, parameters);
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