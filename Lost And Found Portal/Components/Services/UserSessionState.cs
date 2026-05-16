namespace Lost_And_Found_Portal.Services
{
	public class UserSessionState
	{
		// 🚀 Fully accessible setters to fix CS0200, CS0272, and CS1061 errors completely!
		public bool IsLoggedIn { get; set; } = false;
		public string CurrentUserEmail { get; set; } = "";

		// Event backing to allow navbar refreshes
		public event Action? OnStateChange;

		public void Login(string email)
		{
			IsLoggedIn = true;
			CurrentUserEmail = email;
			NotifyStateChanged();
		}

		public void Logout()
		{
			IsLoggedIn = false;
			CurrentUserEmail = "";
			NotifyStateChanged();
		}

		public void ClearSession()
		{
			Logout();
		}

		private void NotifyStateChanged() => OnStateChange?.Invoke();
	}
}