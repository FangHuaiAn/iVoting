using System;

using Android.OS;
using Android.App;
using Android.Content;
using Android.Runtime;

using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Login.Widget;

namespace iVoting.Droid
{

	[Activity (Label = "Facebook 登入")]
	public class FacebookLoginActivity : Activity
	{
		ICallbackManager callbackManager;
		ProfilePictureView profilePictureView;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			//

			FacebookSdk.SdkInitialize (ApplicationContext);

			callbackManager = CallbackManagerFactory.Create ();

			var loginCallback = new FacebookCallback<LoginResult> {
				HandleSuccess = (loginResult) => {

					UpdateUI ();
					MoveToNextView ();

				},
				HandleError = (loginError) => {
					ShowAlert ("Exception", loginError.Message, "確認", (obj) => { });
					UpdateUI ();
				},
				HandleCancel = () => {
					ShowAlert ("Cancel", "取消", "確認", (obj) => { });
					UpdateUI ();
				}
			};

			LoginManager.Instance.RegisterCallback (callbackManager, loginCallback);


			SetContentView (Resource.Layout.facebookloginview);

			profilePictureView = FindViewById <ProfilePictureView> (Resource.Id.facebookloginview_profilePicture);


			var profile = Profile.CurrentProfile;

			if (profile != null) {
				profilePictureView.ProfileId = profile.Id;
				MoveToNextView ();
			}

		}

		/// <summary>
		/// 注意需要加上處理 ActivityResult 的部分
		/// Facebook 的 LoginActivity 執行後，會回呼這邊。 
		/// callbackManager (Xamarin.Facebook.ICallbackManager) 執行 OnActivityResult 後，就會執行 HandleSuccess, HandleError 或是 HandleCancel
		/// </summary>
		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);

			callbackManager.OnActivityResult (requestCode, (int)resultCode, data);
		}

		private void UpdateUI ()
		{

			var profile = Profile.CurrentProfile;

			if ( profile != null) {
				profilePictureView.ProfileId = profile.Id;
			} 
			else {
				profilePictureView.ProfileId = null;
			}
		}

		private void ShowAlert (string title, string message, string comfirmMessage, Action<string> action)
		{

			var alert = new AlertDialog.Builder (this);

			alert.SetTitle (title);
			alert.SetMessage (message);

			alert.SetPositiveButton (comfirmMessage, (sender, e) => { action (""); });

			RunOnUiThread (() => {
				alert.Show ();
			});

		}

		private void MoveToNextView () { 
			RunOnUiThread (() => {
				StartActivity (typeof(MenuActivity));
			});
		}

		class FacebookCallback<TResult> : Java.Lang.Object, IFacebookCallback where TResult : Java.Lang.Object
		{
			public Action HandleCancel { get; set; }
			public Action<FacebookException> HandleError { get; set; }
			public Action<TResult> HandleSuccess { get; set; }

			public void OnCancel ()
			{
				var c = HandleCancel;
				if (c != null)
					c ();
			}

			public void OnError (FacebookException error)
			{
				var c = HandleError;
				if (c != null)
					c (error);
			}

			public void OnSuccess (Java.Lang.Object result)
			{
				var c = HandleSuccess;
				if (c != null)
					c (result.JavaCast<TResult> ());
			}
		}
	}
}