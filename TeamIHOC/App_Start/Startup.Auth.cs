﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin.Security.Providers.GooglePlus;
using Owin;
using System;
using TeamIHOC.Models;

namespace TeamIHOC
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
			app.UseMicrosoftAccountAuthentication(
				clientId: "000000004813E325",
				clientSecret: "fgffIe58y0MJ3NP3Ead6J7HxOSRKcfT1");

			//app.UseTwitterAuthentication(
			//   consumerKey: "",
			//   consumerSecret: "");

			//app.UseFacebookAuthentication(
			//   appId: "",
			//   appSecret: "");

			//app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
			//{
			//	ClientId = "393562117312-37quoibauo0ldb9m4i06ihokp9mdh19v.apps.googleusercontent.com",
			//	ClientSecret = "qBJArS9r1Sjj8n82fZt5BYch"
			//});

			app.UseGooglePlusAuthentication(new GooglePlusAuthenticationOptions()
			{
				ClientId = "393562117312-37quoibauo0ldb9m4i06ihokp9mdh19v.apps.googleusercontent.com",
				ClientSecret = "qBJArS9r1Sjj8n82fZt5BYch"
			});
		}
	}
}