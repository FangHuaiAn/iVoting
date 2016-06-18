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

namespace iVoting.Droid
{
	[Activity (Label = "投票", Theme = "@style/MyTheme")]
	public class VoteNowActivity : Activity
	{

		private Vote SelectedVote { get; set; }
		private Dictionary<int, bool> SelectedIndexes { get; set; }


		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			var voteString = Intent.GetStringExtra ("vote");
			SelectedVote = Newtonsoft.Json.JsonConvert.DeserializeObject<Vote> (voteString);

			SelectedIndexes = new Dictionary<int, bool> ();

			SetContentView (Resource.Layout.votenowview);


			LinearLayout currentLayout = FindViewById <LinearLayout>(Resource.Id.votenow_content);

			if (SelectedVote.SelectType == AnswerType.Single) {


				RadioGroup radioG = new RadioGroup (this);

				LinearLayout.LayoutParams radioGP = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
				LinearLayout.LayoutParams rlp = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);

				foreach (var answer in SelectedVote.Answers) {

					var button = new RadioButton (this);
					button.Id = answer.Id;
					button.Text = $"{answer.Title}:{answer.Description}";

					radioG.AddView (button, rlp);
				}

				radioG.CheckedChange += (object sender, RadioGroup.CheckedChangeEventArgs e) => {

					if (!SelectedIndexes.Keys.Contains (e.CheckedId)) {
						SelectedIndexes.Add (e.CheckedId, true);
					}

				};

				currentLayout.AddView (radioG, radioGP);

			} 
			else {

				LinearLayout.LayoutParams rlp = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);

				foreach (var answer in SelectedVote.Answers) { 
				
					var button = new CheckBox (this);
					button.Id = answer.Id;
					button.Text = $"{answer.Title}:{answer.Description}";

					currentLayout.AddView (button, rlp);

					button.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {

						var btn = sender as CheckBox;

						if (!SelectedIndexes.Keys.Contains ( btn.Id )) {
							SelectedIndexes.Add ( btn.Id, true);
						}
					};
				}
				
			}

			var btnConfirm = FindViewById<Button> (Resource.Id.votenowview_btnConfirm);
			btnConfirm.Click += (sender, e) => {


				SelectedVote.Answers.ForEach (answer => { if (SelectedIndexes.Keys.Contains (answer.Id)) { answer.Count++; } } );

				var nowVoteString = Newtonsoft.Json.JsonConvert.SerializeObject (SelectedVote);

				Intent voteResultView = new Intent (this, typeof (VoteResultActivity));
				voteResultView.PutExtra ("vote", nowVoteString);
				StartActivity (voteResultView);

			};


		}




	}
}

