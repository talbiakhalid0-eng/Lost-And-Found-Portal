using Lost_And_Found_Portal.Components.Data;
using Lost_And_Found_Portal.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace Lost_And_Found_Portal.Components.Services
{
	public class UserService : IUserService
	{
		private readonly ApplicationDbContext _context;

		// Inject the exact DbContext registered in your Program.cs
		public UserService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<User?> LoginAsync(string email, string password)
		{
			return await _context.Users
				.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.Password == password);
		}

		public async Task<bool> RegisterUserAsync(User user)
		{
			// Safeguard against duplicate registrations
			var emailExists = await _context.Users
				.AnyAsync(u => u.Email.ToLower() == user.Email.ToLower());

			if (emailExists) return false;

			_context.Users.Add(user);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}