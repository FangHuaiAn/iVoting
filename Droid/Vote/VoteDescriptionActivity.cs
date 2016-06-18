
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.OS;
using Android.App;
using Android.Views;
using Android.Media;
using Android.Widget;
using Android.Content;
using Android.Runtime;


namespace iVoting.Droid
{
	[Activity (Label = "說明", Theme = "@style/MyTheme")]
	public class VoteDescriptionActivity : Activity
	{
		MediaPlayer player;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			var voteString = Intent.GetStringExtra ("vote");
			var vote = Newtonsoft.Json.JsonConvert.DeserializeObject<Vote> (voteString);
			// Create your application here
			SetContentView (Resource.Layout.votedescriptionview);

			var btnConfirm = FindViewById<Button> (Resource.Id.votedescview_btnConfirm);
			btnConfirm.Click += (sender, e) => { 
			
				Intent voteNowView = new Intent (this, typeof (VoteNowActivity));
				voteNowView.PutExtra ("vote", voteString);
				StartActivity (voteNowView);
			
			};



			LoadVideoFragment (vote);

		}

		private void LoadImageFragment (Vote vote) {

			var fragment = VoteImageTypeFragment.NewInstance (vote);

			var fragmentManager = this.FragmentManager;
			var ft = fragmentManager.BeginTransaction ();
			ft.Replace (Resource.Id.votedescview_fragmentcontent, fragment);
			ft.Commit ();
		}


		private void LoadVideoFragment (Vote vote)
		{

			var fragment = VoteVideoTypeFragment.NewInstance (vote);

			var fragmentManager = this.FragmentManager;
			var ft = fragmentManager.BeginTransaction ();
			ft.Replace (Resource.Id.votedescview_fragmentcontent, fragment);
			ft.Commit ();
		}



		internal class VoteImageTypeFragment : Fragment
		{
			
			public const string VoteImageTypeFragment_KEY = "voteString";

			public static Fragment NewInstance (Vote vote)
			{
				Fragment fragment = new VoteImageTypeFragment ();

				Bundle args = new Bundle ();
				args.PutString (VoteImageTypeFragment_KEY, Newtonsoft.Json.JsonConvert.SerializeObject(vote));
				fragment.Arguments = args;

				return fragment;
			}

			public override View OnCreateView (LayoutInflater inflater, ViewGroup container,
											   Bundle savedInstanceState)
			{
				View rootView = inflater.Inflate (Resource.Layout.votedescview_type01, container, false);

				//var iv = rootView.FindViewById<ImageView> (Resource.Id.votedescview_type01_descimage);
				var textView = rootView.FindViewById<TextView> (Resource.Id.votedescview_type01_lbDesc);


				var jsonString = this.Arguments.GetString (VoteImageTypeFragment_KEY);
				var vote = Newtonsoft.Json.JsonConvert.DeserializeObject<Vote> (jsonString);
				textView.Text = vote.Description;

				return rootView;
			}
		}


		internal class VoteVideoTypeFragment : Fragment
		{

			public const string VoteVidoeTypeFragment_KEY = "voteString";

			public static Fragment NewInstance (Vote vote)
			{
				Fragment fragment = new VoteVideoTypeFragment ();

				Bundle args = new Bundle ();
				args.PutString (VoteVidoeTypeFragment_KEY, Newtonsoft.Json.JsonConvert.SerializeObject (vote));
				fragment.Arguments = args;

				return fragment;
			}

			private VideoView _videoView;

			public override View OnCreateView (LayoutInflater inflater, ViewGroup container,
											   Bundle savedInstanceState)
			{
				var jsonString = this.Arguments.GetString (VoteVidoeTypeFragment_KEY);
				var vote = Newtonsoft.Json.JsonConvert.DeserializeObject<Vote> (jsonString);

				View rootView = inflater.Inflate (Resource.Layout.votedescview_type02, container, false);

				MediaController mc = new MediaController (Activity);

				_videoView = rootView.FindViewById<VideoView> (Resource.Id.votedescview_type02_player);

				_videoView.Prepared += (sender, e) => { 
					_videoView.Start ();
				};


				var uri = Android.Net.Uri.Parse (vote.VideoUrl);
				_videoView.SetVideoURI (uri);
				_videoView.SetMediaController (mc);


				var textView = rootView.FindViewById<TextView> (Resource.Id.votedescview_type02_lbDesc);


				textView.Text = vote.Description;

				return rootView;
			}

			public void Play () { 
				_videoView.Start ();
				
			}

		}
	}
}

