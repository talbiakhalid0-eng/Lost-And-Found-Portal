namespace Lost_And_Found_Portal.Components.Services
{
    public class UserSessionState
    {
		public string? CurrentUserEmail { get; private set; }
		public bool IsLoggedIn => !string.IsNullOrEmpty(CurrentUserEmail);

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
