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

using Debug = System.Diagnostics.Debug;


using BarChart;

namespace iVoting.Droid
{
	[Activity (Label = "VoteResultActivity", Theme = "@style/MyTheme")]
	public class VoteResultActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			//

			var voteString = Intent.GetStringExtra ("vote");
			var vote = Newtonsoft.Json.JsonConvert.DeserializeObject<Vote> (voteString);

			var data = new List<BarModel> ();

			vote.Answers.ForEach (a => data.Add (new BarModel { ValueCaption = $"{a.Title}:{a.Count}" , Value = a.Count }));
			var max = (int)(vote.Answers.Max (x => x.Count) * 1.2);
			var min = (int)(vote.Answers.Min (x => x.Count) * 0.8);

			var chart = new BarChartView (this) {
				ItemsSource = data,
				BarWidth = 120,
				BarOffset = 80,
				BarCaptionInnerColor = Android.Graphics.Color.Black,
				BarCaptionOuterColor = Android.Graphics.Color.DarkGray,
				MaximumValue = max,
				MinimumValue = min
				                              
			};

			AddContentView (chart, new ViewGroup.LayoutParams (
			  ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
		}

		public override void OnBackPressed ()
		{
			base.OnBackPressed ();

			Intent menuView = new Intent (this, typeof(MenuActivity));
			menuView.AddFlags (ActivityFlags.ClearTop);
			StartActivity (menuView);

		}
	}
}

