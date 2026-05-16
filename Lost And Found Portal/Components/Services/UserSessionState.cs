using System;

namespace Lost_And_Found_Portal.Services
{
	public class UserSessionState
	{
		// Holds the logged-in student's email address context globally
		public string? CurrentUserEmail { get; private set; }

		// Helper flag to verify if a user circuit session is active
		public bool IsLoggedIn => !string.IsNullOrEmpty(CurrentUserEmail);

		// Event that alerts components (like the Navbar buttons) to update when someone logs in/out
		public event Action? OnStateChange;

		public void Login(string email)
		{
			CurrentUserEmail = email;
			NotifyStateChanged();
		}

		public void Logout()
		{
			CurrentUserEmail = null;
			NotifyStateChanged();
		}

		private void NotifyStateChanged() => OnStateChange?.Invoke();

	}
}