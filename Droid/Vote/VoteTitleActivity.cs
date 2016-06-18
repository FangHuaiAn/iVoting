using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Android.OS;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Runtime;
using Android.Graphics;

using Debug = System.Diagnostics.Debug;

namespace iVoting.Droid
{
	[Activity (Label = "確認投票", Theme = "@style/MyTheme")]
	public class VoteTitleActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			var voteString = Intent.GetStringExtra ("vote");
			var vote = Newtonsoft.Json.JsonConvert.DeserializeObject<Vote> (voteString);

			SetContentView (Resource.Layout.votetitleview);

			var lbTitle = FindViewById <TextView>(Resource.Id.votetitleview_txtVoteTitle);
			lbTitle.Text = vote.Description;


			var btnCancel = FindViewById<Button> (Resource.Id.votetitleview_btnCancel);
			btnCancel.Click += (sender, e) => {
				base.OnBackPressed ();
			};

			var btnConfirm = FindViewById<Button> (Resource.Id.votetitleview_btnConfirm);
			btnConfirm.Click += (sender, e) => { 
				Intent voteDescriptionView = new Intent (this, typeof (VoteDescriptionActivity));
				voteDescriptionView.PutExtra ("vote", voteString);
				StartActivity (voteDescriptionView);
			};

		}
	}
}

