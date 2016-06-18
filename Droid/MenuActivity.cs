using System;
using System.Collections.Generic;

using Android.OS;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Graphics;

namespace iVoting.Droid
{
	[Activity (Label = "iVoting", Theme = "@style/MyTheme")]
	public class MenuActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.menuview);
			var listView = FindViewById<ListView> (Resource.Id.menu_listview);

			var votes = new VoteManager().ReadVotesFromRemote() ;

			var listAdapter = new VoteListAdapter (this, votes);

			listView.Adapter = listAdapter;
			listAdapter.VoteSelected += (object sender, VoteSelectedEventArgs e) => { 

				var vote = e.SelectedVote;
				var voteString = Newtonsoft.Json.JsonConvert.SerializeObject (vote);


				if (DateTime.Now > e.SelectedVote.EndTime) {

					Intent voteResultView = new Intent (this, typeof (VoteResultActivity));
					voteResultView.PutExtra ("vote", voteString );
					StartActivity (voteResultView);
				} 
				else { 

					Intent voteTitleView = new Intent (this, typeof (VoteTitleActivity));
					voteTitleView.PutExtra ("vote", voteString);
					StartActivity (voteTitleView);
				}
			};

		}

		public override void OnBackPressed ()
		{
			
		}


		#region Vote ListAdapter

		class VoteListAdapter : BaseAdapter<Vote>
		{

			List<Vote> Items { get; set; }

			Activity context;

			public VoteListAdapter (Activity context, List<Vote> items)
				: base ()
			{
				this.context = context;
				Items = new List<Vote>( items );
			}
			public override long GetItemId (int position)
			{
				return position;
			}
			public override Vote this [int position] {
				get { return Items [position]; }
			}
			public override int Count {
				get { return Items.Count; }
			}

			public override View GetView (int position, View convertView, ViewGroup parent)
			{
				var item = Items [position];
				var view = convertView;

				if (view == null) {
					//使用自訂的 Layout
					view = context.LayoutInflater.Inflate (Resource.Layout.menuview_voteitemview, parent, false);
				}

				Button btnVote = view.FindViewById<Button> (Resource.Id.menuview_voteitemview_btnVote);

				btnVote.Click += (sender, e) => {

					EventHandler<VoteSelectedEventArgs> handler = VoteSelected;

					if (null != handler) {
						handler (this, new VoteSelectedEventArgs { SelectedVote = item });
					}
				
				};


				if (DateTime.Now < item.StartTime) {
					// 尚未開始
					view.FindViewById (Resource.Id.menuview_voteitemview_layoutBackground).SetBackgroundColor (Color.LightYellow );

					btnVote.Visibility = ViewStates.Gone;
				}
				else {
					

					// 已開始，未結束
					if (DateTime.Now < item.EndTime) {

						btnVote.Text = @"投票去";
					}
					// 已開始，已結束
					else {
						view.FindViewById (Resource.Id.menuview_voteitemview_layoutBackground).SetBackgroundColor (Color.LightGray);

						btnVote.Text = @"看結果";
					}

				}

				view.FindViewById<TextView> (Resource.Id.menuview_voteitemview_lbTitle).Text = item.Title;
				view.FindViewById<TextView> (Resource.Id.menuview_voteitemview_lbDescription).Text = item.Description;

				return view;
			}

			public event EventHandler<VoteSelectedEventArgs> VoteSelected; 

		}

		public class VoteSelectedEventArgs : EventArgs { 
			public Vote SelectedVote { get; set; }
		}

		#endregion
	}
}

