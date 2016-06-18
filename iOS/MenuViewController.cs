using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using UIKit;
using Foundation;

using Debug = System.Diagnostics.Debug;

namespace iVoting.iOS
{
	public partial class MenuViewController : UIViewController
	{
		private Vote SelectedVote { get; set; }

		public MenuViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			var votes = new VoteManager ().ReadVotesFromRemote ();

			var source = new TableSource (votes);

			voteTable.Source = source;

			source.VoteSelected += (object sender, VoteSelectedEventArgs e) => {

				SelectedVote = e.SelectedVote;

				if (DateTime.Now > e.SelectedVote.EndTime) {
					InvokeOnMainThread (() => {
						PerformSegue ("moveToVoteResultViewSegue", this);
					});
				}
				else { 
				
					InvokeOnMainThread (() => {
						PerformSegue ("moveToVoteFlowSegue", this);
					});
				}
			};
		}


		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			switch (segue.Identifier) {
				case "moveToVoteResultViewSegue": {

					if (segue.DestinationViewController is VoteResultViewController) {
						var destViewController = segue.DestinationViewController as VoteResultViewController;
						destViewController.SelectedVote = SelectedVote;
					}

				}
				break;

				case "moveToVoteFlowSegue": { 
				
					if (segue.DestinationViewController is VoteTitleViewController) {
						var destViewController = segue.DestinationViewController as VoteTitleViewController;
						destViewController.SelectedVote = SelectedVote;
					}
				}
				break;
			}

		}


		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}


		public class TableSource : UITableViewSource
		{

			string CellIdentifier = "VoteTableViewCell";

			List<Vote> Items;

			public TableSource (List<Vote> items)
			{

				this.Items = new List<Vote> ();

				this.Items.AddRange (items);

			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return this.Items.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				VoteTableViewCell cell = tableView.DequeueReusableCell (CellIdentifier) as VoteTableViewCell;

				// Data
				var item = Items [indexPath.Row];

				cell.UpdateUIWith (item);

				cell.btnNext.TouchUpInside += (sender, e) => { 

					var args = new VoteSelectedEventArgs { SelectedVote = item };

					OnVoteSelected (args);
				};

				return cell;

			}

			public event EventHandler<VoteSelectedEventArgs> VoteSelected;

			public virtual void OnVoteSelected (VoteSelectedEventArgs e)
			{
				EventHandler<VoteSelectedEventArgs> handler = VoteSelected;

				if (null != handler) {
					handler (this, e);
				}

			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				tableView.DeselectRow (indexPath, true);

				var item = Items [indexPath.Row];
				var args = new VoteSelectedEventArgs { SelectedVote = item };

				OnVoteSelected (args);
			}

		}

		public class VoteSelectedEventArgs : EventArgs
		{
			public Vote SelectedVote { get; set; }
		}



	}
}


