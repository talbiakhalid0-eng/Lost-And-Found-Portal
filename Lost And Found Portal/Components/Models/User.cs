namespace Lost_And_Found_Portal.Components.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Email { get; set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty; // Ensure this is exactly 'PasswordHash'
		public string Role { get; set; } = "Student";
	  }
}
