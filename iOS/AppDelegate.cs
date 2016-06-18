using System;
using System.Linq;
using System.Collections.Generic;

using UIKit;
using Foundation;

using Facebook.CoreKit;
using Facebook.LoginKit;

using Google.Core;
using Google.SignIn;

namespace iVoting.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		string appId = "1633974333590125";
		string appName = "iVoting";

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			Profile.EnableUpdatesOnAccessTokenChange (true);
			Settings.AppID = appId;
			Settings.DisplayName = appName;

			NSError configureError;
			Context.SharedInstance.Configure (out configureError);
			if (configureError != null) {
				Console.WriteLine ("Error configuring the Google context: {0}", configureError);
				SignIn.SharedInstance.ClientID = "183007078052-i99sq4ci8v6mh23bavl049olhrub3143.apps.googleusercontent.com";
			}

			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			if (url.AbsoluteUrl.AbsoluteString.StartsWith ("com.googleusercontent.apps", StringComparison.CurrentCulture)) {
				return SignIn.SharedInstance.HandleUrl (url, sourceApplication, annotation);
			} 
			else {
				return ApplicationDelegate.SharedInstance.OpenUrl (application, url, sourceApplication, annotation);
			}
		}
	}
}


