using Lost_And_Found_Portal.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace Lost_And_Found_Portal.Components.Services
{
	public class UserService : IUserService
	{
		// CHANGED: Using the correct name or adding missing namespace imports
		private readonly IDbContextFactory<LostAndFoundPortalDbContext> _contextFactory;

		public UserService(IDbContextFactory<LostAndFoundPortalDbContext> contextFactory)
		{
			_contextFactory = contextFactory;
		}

		public async Task<User?> LoginAsync(string email, string password)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			return await context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.Password == password);
		}

		public async Task<bool> RegisterUserAsync(User user)
		{
			using var context = await _contextFactory.CreateDbContextAsync();

			// Cross-check database for existing users
			var emailExists = await context.Users.AnyAsync(u => u.Email.ToLower() == user.Email.ToLower());
			if (emailExists) return false;

			context.Users.Add(user);
			await context.SaveChangesAsync();
			return true;
		}
	}
}