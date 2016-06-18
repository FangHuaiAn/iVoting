using System;

using Android.OS;
using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Gms.Plus;
using Android.Gms.Common;
using Android.Gms.Common.Apis;

namespace iVoting.Droid
{
	[Activity (Label = "GoogleLoginActivity")]
	public class GoogleLoginActivity : Activity, View.IOnClickListener,
	GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
	{
		const string TAG = "MainActivity";

		const int RC_SIGN_IN = 9001;

		const string KEY_IS_RESOLVING = "is_resolving";
		const string KEY_SHOULD_RESOLVE = "should_resolve";

		GoogleApiClient mGoogleApiClient;

		TextView mStatus;

		bool mIsResolving = false;

		bool mShouldResolve = false;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.googleloginview);

			//
			if (savedInstanceState != null) {
				mIsResolving = savedInstanceState.GetBoolean (KEY_IS_RESOLVING);
				mShouldResolve = savedInstanceState.GetBoolean (KEY_SHOULD_RESOLVE);
			}

			FindViewById (Resource.Id.googleloginview_btnSignIn).SetOnClickListener (this);
			FindViewById (Resource.Id.googleloginview_btnSignOut).SetOnClickListener (this);
			FindViewById (Resource.Id.googleloginview_btnDisconnect).SetOnClickListener (this);

			FindViewById<SignInButton> (Resource.Id.googleloginview_btnSignIn).SetSize (SignInButton.SizeWide);
			FindViewById (Resource.Id.googleloginview_btnSignIn).Enabled = false;

			mStatus = FindViewById<TextView> (Resource.Id.googleloginview_status);

			mGoogleApiClient = new GoogleApiClient.Builder (this)
				.AddConnectionCallbacks (this)
				.AddOnConnectionFailedListener (this)
				.AddApi (PlusClass.API)
				.AddScope (new Scope (Scopes.Profile))
				.Build ();
		}

		protected override void OnStart ()
		{
			base.OnStart ();
			mGoogleApiClient.Connect ();
		}

		protected override void OnStop ()
		{
			base.OnStop ();
			mGoogleApiClient.Disconnect ();
		}

		protected override void OnSaveInstanceState (Bundle outState)
		{
			base.OnSaveInstanceState (outState);
			outState.PutBoolean (KEY_IS_RESOLVING, mIsResolving);
			outState.PutBoolean (KEY_SHOULD_RESOLVE, mIsResolving);
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);
			Log.Debug (TAG, "onActivityResult:" + requestCode + ":" + resultCode + ":" + data);

			if (requestCode == RC_SIGN_IN) {
				if (resultCode != Result.Ok) {
					mShouldResolve = false;
				}

				mIsResolving = false;
				mGoogleApiClient.Connect ();
			}
		}

		void UpdateUI (bool isSignedIn)
		{
			if (isSignedIn) {
				var person = PlusClass.PeopleApi.GetCurrentPerson (mGoogleApiClient);
				var name = string.Empty;
				if (person != null)
					name = person.DisplayName;

				mStatus.Text = string.Format ("{0}", name);

				FindViewById (Resource.Id.googleloginview_btnSignIn).Visibility = ViewStates.Gone;
				FindViewById (Resource.Id.sign_out_and_disconnect).Visibility = ViewStates.Visible;

				RunOnUiThread (() => {
					StartActivity (typeof(MenuActivity));
				});

			} else {
				mStatus.Text = "SignOut";

				FindViewById (Resource.Id.googleloginview_btnSignIn).Enabled = true;
				FindViewById (Resource.Id.googleloginview_btnSignIn).Visibility = ViewStates.Visible;
				FindViewById (Resource.Id.sign_out_and_disconnect).Visibility = ViewStates.Gone;
			}
		}

		public void OnConnected (Bundle connectionHint)
		{
			Log.Debug (TAG, "onConnected:" + connectionHint);

			UpdateUI (true);
		}

		public void OnConnectionSuspended (int cause)
		{
			Log.Warn (TAG, "onConnectionSuspended:" + cause);
		}

		public void OnConnectionFailed (ConnectionResult result)
		{
			Log.Debug (TAG, "onConnectionFailed:" + result);

			if (!mIsResolving && mShouldResolve) {
				if (result.HasResolution) {
					try {
						result.StartResolutionForResult (this, RC_SIGN_IN);
						mIsResolving = true;
					} catch (IntentSender.SendIntentException e) {
						Log.Error (TAG, "Could not resolve ConnectionResult.", e);
						mIsResolving = false;
						mGoogleApiClient.Connect ();
					}
				} else {
					ShowErrorDialog (result);
				}
			} else {
				UpdateUI (false);
			}
		}

		class DialogInterfaceOnCancelListener : Java.Lang.Object, IDialogInterfaceOnCancelListener
		{
			public Action<IDialogInterface> OnCancelImpl { get; set; }

			public void OnCancel (IDialogInterface dialog)
			{
				OnCancelImpl (dialog);
			}
		}

		void ShowErrorDialog (ConnectionResult connectionResult)
		{
			int errorCode = connectionResult.ErrorCode;

			if (GooglePlayServicesUtil.IsUserRecoverableError (errorCode)) {
				var listener = new DialogInterfaceOnCancelListener ();
				listener.OnCancelImpl = (dialog) => {
					mShouldResolve = false;
					UpdateUI (false);
				};
				GooglePlayServicesUtil.GetErrorDialog (errorCode, this, RC_SIGN_IN, listener).Show ();
			} else {
				var errorstring = string.Format ("{0}", errorCode);
				Toast.MakeText (this, errorstring, ToastLength.Short).Show ();

				mShouldResolve = false;
				UpdateUI (false);
			}
		}

		public async void OnClick (View v)
		{
			switch (v.Id) {
				case Resource.Id.googleloginview_btnSignIn:
				{
					//mStatus.Text = GetString (Resource.String.signing_in);
					mShouldResolve = true;
					mGoogleApiClient.Connect ();
				}
				break;
				case Resource.Id.googleloginview_btnSignOut: {
					if (mGoogleApiClient.IsConnected) {
						PlusClass.AccountApi.ClearDefaultAccount (mGoogleApiClient);
						mGoogleApiClient.Disconnect ();
					}

					UpdateUI (false);
				}
				break;
				case Resource.Id.googleloginview_btnDisconnect: {
					if (mGoogleApiClient.IsConnected) {

						PlusClass.AccountApi.ClearDefaultAccount (mGoogleApiClient);
						await PlusClass.AccountApi.RevokeAccessAndDisconnect (mGoogleApiClient);
						mGoogleApiClient.Disconnect ();
					}
					UpdateUI (false);
				}
				break;
			}
		}
	}
}

