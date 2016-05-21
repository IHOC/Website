using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin.Security.Providers.GooglePlus;
using Owin;
using System;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Twitter;
using TeamIHOC.Library.Global;
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
            //app.UseMicrosoftAccountAuthentication(
            //	clientId: "000000004813E325",
            //	clientSecret: "fgffIe58y0MJ3NP3Ead6J7HxOSRKcfT1");

            app.UseTwitterAuthentication(new TwitterAuthenticationOptions()
            {
                ConsumerKey = "UCy1ahFf7ieFlj9lZyiYlif86",
                ConsumerSecret = "G55d523CEwF9DjMIckUfHIWcBZ3qhJvPbp49bVU4d9VqvYWHnH",
                BackchannelCertificateValidator = new CertificateSubjectKeyIdentifierValidator(new[]
                {
                    "A5EF0B11CEC04103A34A659048B21CE0572D7D47", // VeriSign Class 3 Secure Server CA - G2
                    "0D445C165344C1827E1D20AB25F40163D8BE79A5", // VeriSign Class 3 Secure Server CA - G3
                    "7FD365A7C2DDECBBF03009F34339FA02AF333133", // VeriSign Class 3 Public Primary Certification Authority - G5
                    "39A55D933676616E73A761DFA16A7E59CDE66FAD", // Symantec Class 3 Secure Server CA - G4
                    "5168FF90AF0207753CCCD9656462A212B859723B", //DigiCert SHA2 High Assurance Server C‎A 
                    "B13EC36903F8BF4701D498261A0802EF63642BC3" //DigiCert High Assurance EV Root CA
                })
            });

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[SettingsRef.FacebookAPIKey]))
            {
                app.UseFacebookAuthentication(
                    appId: ConfigurationManager.AppSettings[SettingsRef.FacebookAPIKey],
                    appSecret: ConfigurationManager.AppSettings[SettingsRef.FacebookAPISecret]);
            }

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //	ClientId = "393562117312-37quoibauo0ldb9m4i06ihokp9mdh19v.apps.googleusercontent.com",
            //	ClientSecret = "qBJArS9r1Sjj8n82fZt5BYch"
            //});

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[SettingsRef.GooglePlusAPIKey]))
            {
                app.UseGooglePlusAuthentication(new GooglePlusAuthenticationOptions()
                {
                    ClientId = ConfigurationManager.AppSettings[SettingsRef.GooglePlusAPIKey],
                    ClientSecret = ConfigurationManager.AppSettings[SettingsRef.GooglePlusAPISecret]
                });
            }
        }
    }
}