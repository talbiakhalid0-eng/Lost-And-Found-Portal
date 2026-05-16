using Lost_And_Found_Portal.Components.Models;

namespace Lost_And_Found_Portal.Components.Services
{
	public interface IUserService
	{
		Task<User?> LoginAsync(string email, string password);
		Task<bool> RegisterUserAsync(User user); // Ensure this definition is here!
	}
}