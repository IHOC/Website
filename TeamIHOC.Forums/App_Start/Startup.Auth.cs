using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using Owin.Security.Providers.GooglePlus;
using TeamIHOC.Forums.Library;
using TeamIHOC.Forums.Models;

namespace TeamIHOC.Forums
{
	public partial class Startup
	{
		// For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
		public void ConfigureAuth(IAppBuilder app)
		{
			// Configure the db context and user manager to use a single instance per request
			app.CreatePerOwinContext(ApplicationDbContext.Create);
			app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

			// Enable the application to use a cookie to store information for the signed in user
			// and to use a cookie to temporarily store information about a user logging in with a third party login provider
			// Configure the sign in cookie
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Account/Login"),
				Provider = new CookieAuthenticationProvider
				{
					OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
							validateInterval: TimeSpan.FromMinutes(30),
							regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
				}
			});

			app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

			// Uncomment the following lines to enable logging in with third party login providers
			//app.UseMicrosoftAccountAuthentication(
			//    clientId: "",
			//    clientSecret: "");

	 //	 app.UseTwitterAuthentication(
	 //consumerKey: "UCy1ahFf7ieFlj9lZyiYlif86",
	 //consumerSecret: "G55d523CEwF9DjMIckUfHIWcBZ3qhJvPbp49bVU4d9VqvYWHnH");

	 //	 if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[SettingsRef.FacebookAPIKey]))
	 //	 {
	 //		 app.UseFacebookAuthentication(
	 //			 appId: ConfigurationManager.AppSettings[SettingsRef.FacebookAPIKey],
	 //			 appSecret: ConfigurationManager.AppSettings[SettingsRef.FacebookAPISecret]);
	 //	 }

			//app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
			//{
			//    ClientId = "",
			//    ClientSecret = ""
			//});

			//if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[SettingsRef.GooglePlusAPIKey]))
			//{
			//	app.UseGooglePlusAuthentication(new GooglePlusAuthenticationOptions()
			//	{
			//		ClientId = ConfigurationManager.AppSettings[SettingsRef.GooglePlusAPIKey],
			//		ClientSecret = ConfigurationManager.AppSettings[SettingsRef.GooglePlusAPISecret]
			//	});
			//}
		}
	}
}