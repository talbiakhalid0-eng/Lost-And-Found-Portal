using Lost_And_Found_Portal.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace Lost_And_Found_Portal.Components.Services
{
	public class UserService : IUserService
	{
		private readonly IDbContextFactory<LostAndFoundDbContext> _contextFactory;

		public UserService(IDbContextFactory<LostAndFoundDbContext> contextFactory)
		{
			_contextFactory = contextFactory;
		}

		public async Task<User?> LoginAsync(string email, string password)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			return await context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
		}

		public async Task<bool> RegisterUserAsync(User user)
		{
			using var context = await _contextFactory.CreateDbContextAsync();

			// Security check: Check if email already occupies a row entry in SQL Server
			var emailExists = await context.Users.AnyAsync(u => u.Email.ToLower() == user.Email.ToLower());
			if (emailExists) return false;

			context.Users.Add(user);
			await context.SaveChangesAsync();
			return true;
		}
	}
}
