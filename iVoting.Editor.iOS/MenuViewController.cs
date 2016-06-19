using System;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;

using Debug = System.Diagnostics.Debug;

namespace iVoting.Editor.iOS
{
	public partial class MenuViewController : UIViewController
	{
		private EditingVote SelectedEditingVote { get; set; }
		private PopMenuViewController PopMenuView { get; set; }

		public MenuViewController (IntPtr handle) : base (handle)
		{
		}

		// moveToVerifyViewSegue
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			btnAdd.Enabled = false;

			PopMenuView = new PopMenuViewController ();
			PopMenuView.FeatureSelected += (sender, e) => {
				Debug.WriteLine (e.SelectedFeatureName);

				if ("Edit" == e.SelectedFeatureName) {
					btnAdd.Enabled = true;
				} 
				else if ("Edit" == e.SelectedFeatureName) {
					btnAdd.Enabled = true;
				} 
				else {
					btnAdd.Enabled = false;
				}

			};


			btnMenu.Clicked += (sender, e) => { 
				UIPopoverController pop = new UIPopoverController (PopMenuView);
				pop.SetPopoverContentSize (new CGSize (200, 150), true);
				pop.PresentFromBarButtonItem ( btnMenu, UIPopoverArrowDirection.Any, true);
			};

			btnAdd.Clicked += (sender, e) => {
				PerformSegue ("moveToFlow01ViewSegue", this);
			};

			var editingVotes = new VoteManager ().ReadEditVotesFromRemote ();

			var source = new TableSource (editingVotes);

			editingVoteTable.Source = source;

			source.EditingVoteSelected += ( sender, e) => {
				if (e.SelectedEditingVote.Status == EditStatus.Request) {
					PerformSegue ("moveToVerifyViewSegue", this);
				}
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public class TableSource : UITableViewSource
		{

			string CellIdentifier = "StatusCellView";

			List<EditingVote> Items;

			public TableSource (List<EditingVote> items)
			{
				Items = new List<EditingVote> ();
				Items.AddRange (items);
			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return Items.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				StatusCellView cell = tableView.DequeueReusableCell (CellIdentifier) as StatusCellView;

				// Data
				var item = Items [indexPath.Row];

				cell.UpdateUIWith (item);

				return cell;

			}

			public event EventHandler<EditingVoteSelectedEventArgs> EditingVoteSelected;

			public virtual void OnEditingVoteSelected (EditingVoteSelectedEventArgs e)
			{
				EventHandler<EditingVoteSelectedEventArgs> handler = EditingVoteSelected;

				if (null != handler) {
					handler (this, e);
				}

			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				tableView.DeselectRow (indexPath, true);

				var item = Items [indexPath.Row];
				var args = new EditingVoteSelectedEventArgs { SelectedEditingVote = item };

				OnEditingVoteSelected (args);
			}

		}

		public class EditingVoteSelectedEventArgs : EventArgs
		{
			public EditingVote SelectedEditingVote { get; set; }
		}
	}
}


