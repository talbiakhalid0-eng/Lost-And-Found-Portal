using Lost_And_Found_Portal.Components.Data;
using Lost_And_Found_Portal.Components.Models;
using Lost_And_Found_Portal.Components.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Lost_And_Found_Portal.Services
{
	public class ItemService : IItemService
	{
		private readonly ApplicationDbContext _context;

		public ItemService(ApplicationDbContext context)
		{
			_context = context;
		}
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
			try
			{
				return await _context.Items.ToListAsync();
			}
			catch (Exception)
			{
				return new List<Item>();
			}
		}
		public async Task<bool> DeleteItemAsync(int id)
		{
			var item = await _context.Items.FindAsync(id);
			if (item == null) return false;

			_context.Items.Remove(item);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			_context.Items.Update(item);
			return await _context.SaveChangesAsync() > 0;
		}


		public async Task<bool> RegisterUserAsync(RegisterModel model)
		{
			try
			{
				// 1. Check if the email already exists in the DB
				var alreadyExists = await _context.Users.AnyAsync(u => u.Email == model.Email);
				if (alreadyExists) return false;

				// 2. Create the User object from the registration data
				var newUser = new User
				{
					Email = model.Email,
					PasswordHash = model.Password, // Ideally, use hashing here for security
					Role = "Student"
				};

				// 3. Save to database
				_context.Users.Add(newUser);
				await _context.SaveChangesAsync();

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<bool> LoginUserAsync(string email, string password)
		{
			// Look for a user in the DB that matches both email AND password
			var user = await _context.Users
				.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);

			return user != null; // Returns true if found, false if not
		}

	}
}
