namespace Lost_And_Found_Portal.Services
{
	public class UserSessionState
	{
		// Ensure both properties have public getters and setters
		public bool IsLoggedIn { get; set; } = false;
		public string CurrentUserEmail { get; set; } = string.Empty;

		// Optional helper method to cleanly reset everything on logout
		public void ClearSession()
		{
			IsLoggedIn = false;
			CurrentUserEmail = string.Empty;
		}
	}
}