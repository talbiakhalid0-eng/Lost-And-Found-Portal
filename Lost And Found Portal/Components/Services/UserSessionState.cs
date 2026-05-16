using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Lost_And_Found_Portal.Services
{
	public class UserSessionState
	{
		private readonly IJSRuntime _jsRuntime;
		private bool _isLoggedIn = false;
		private string _currentUserEmail = "";

		// Combined into a single consistent event for all components to subscribe to
		public event Action? OnChange;

		// 🚀 THE FIX: Inject IJSRuntime so the state container can talk to the browser storage
		public UserSessionState(IJSRuntime jsRuntime)
		{
			_jsRuntime = jsRuntime;
		}

		public bool IsLoggedIn
		{
			get => _isLoggedIn;
			set
			{
				if (_isLoggedIn != value)
				{
					_isLoggedIn = value;
					NotifyStateChanged();
				}
			}
		}

		public string CurrentUserEmail
		{
			get => _currentUserEmail;
			set
			{
				if (_currentUserEmail != value)
				{
					_currentUserEmail = value;
					NotifyStateChanged();
				}
			}
		}

		// 🚀 Modified to save to browser storage so it survives full page reloads
		public async Task Login(string email)
		{
			IsLoggedIn = true;
			CurrentUserEmail = email;

			try
			{
				await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "user_email", email);
			}
			catch { /* Catch silently during initial server prerendering */ }

			NotifyStateChanged();
		}

		public async Task Logout()
		{
			IsLoggedIn = false;
			CurrentUserEmail = "";

			try
			{
				await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", "user_email");
			}
			catch { /* Catch silently during initial server prerendering */ }

			NotifyStateChanged();
		}

		public async Task ClearSession()
		{
			await Logout();
		}

		// 🚀 NEW METHOD: Call this inside component lifecycle initializations to restore memory states
		public async Task LoadSessionFromBrowserAsync()
		{
			try
			{
				var cachedEmail = await _jsRuntime.InvokeAsync<string?>("sessionStorage.getItem", "user_email");
				if (!string.IsNullOrEmpty(cachedEmail))
				{
					_isLoggedIn = true;
					_currentUserEmail = cachedEmail;
					NotifyStateChanged();
				}
			}
			catch { /* Catch silently during initial server prerendering */ }
		}

		private void NotifyStateChanged() => OnChange?.Invoke();
	}
}