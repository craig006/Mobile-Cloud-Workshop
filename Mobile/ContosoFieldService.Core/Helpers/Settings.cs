using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ContosoFieldService.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string SettingsKey = "settings_key";
		private static readonly string SettingsDefault = string.Empty;

        private const string UserIsLoggedInKey = "user_is_logged_in_key";
        private static readonly bool UserIsLoggedInDefault = false;

        private const string FullNameKey = "fullname_key";
        private static readonly string FullNameDefault = string.Empty;

        private const string EmailKey = "email_key";
        private static readonly string EmailDefault = string.Empty;

		#endregion


		public static bool UserIsLoggedIn
		{
			get
			{
                return AppSettings.GetValueOrDefault(UserIsLoggedInKey, UserIsLoggedInDefault);
			}
			set
			{
                AppSettings.AddOrUpdateValue(UserIsLoggedInKey, value);
			}
		}

        public static string FullName
        {
            get
            {
                return AppSettings.GetValueOrDefault(FullNameKey, FullNameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(FullNameKey, value);
            }
        }

        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault(EmailKey, EmailDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(EmailKey, value);
            }
        }
	}
}