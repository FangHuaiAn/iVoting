using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using UIKit;
using Foundation;

using Debug = System.Diagnostics.Debug;

namespace iVoting.iOS
{
	public partial class VoteNowViewController : UIViewController
	{
		public Vote SelectedVote { get; set; }

		public VoteNowViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			var source = new AnswerTableSource (SelectedVote.Answers, SelectedVote.SelectType == AnswerType.Single );

			voteTable.Source = source;
			voteTable.AllowsSelection = false;

			var builder = new StringBuilder ();

			source.AnswerSelected += (sender, e) => {

				builder.Clear ();

				var list = source.SelectedIndex.Keys.ToList ();
				list.ForEach (i => builder.AppendFormat (@"{0},", i));

			};

			btnConfirm.TouchUpInside += (sender, e) => { 
			
				var list = source.SelectedIndex.Keys.ToList ();

				foreach (var answer in SelectedVote.Answers) {

					foreach (int i in list) {

						if (i == answer.Id) {
							answer.Count++;
						}
					
					}
				}

				PerformSegue ("moveToResultSegue", this );
			};

		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			switch (segue.Identifier) {
			case "moveToResultSegue": {

					if (segue.DestinationViewController is VoteResultViewController) {
						var destViewController = segue.DestinationViewController as VoteResultViewController;
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

		public class AnswerTableSource : UITableViewSource
		{
			private UIImage CheckedImage { get; set; }
			private UIImage UnCheckedImage { get; set; }

			string CellIdentifier = "VoteNowCellView";

			List<Answer> Items { get; set; }

			public Dictionary<int, bool> SelectedIndex { get; set; }

			private bool SingleSelection { get; set; }

			public AnswerTableSource (List<Answer> items, bool singleSelection)
			{

				Items = new List<Answer> ();
				Items.AddRange (items);

				SelectedIndex = new Dictionary<int, bool> ();

				SingleSelection = singleSelection;

				if (SingleSelection) {
					CheckedImage = UIImage.FromFile ("Images/selected.png");
					UnCheckedImage = UIImage.FromFile ("Images/unselected.png");
				} 
				else {
					CheckedImage = UIImage.FromFile ("Images/check.png");
					UnCheckedImage = UIImage.FromFile ("Images/uncheck.png");
				}

			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return Items.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (CellIdentifier) as VoteNowCellView;

				// Data
				var item = Items [indexPath.Row];

				cell.Tag = item.Id;
				cell.UpdateUIWith (item);

				if (SingleSelection && 0 == indexPath.Row) {
					cell.IsChecked = true;
					cell.btnCheck.SetImage (CheckedImage, UIControlState.Normal);
					SelectedIndex.Add (item.Id, true);
				}
				else { 
					cell.IsChecked = false;
					cell.btnCheck.SetImage (UnCheckedImage, UIControlState.Normal);
				}


				cell.btnCheck.TouchUpInside += (sender, e) => {

					var index = (int)cell.Tag;
					if (cell.IsChecked) {


						if (SingleSelection) {


						}
						else { 
						
							if (SelectedIndex.Keys.Contains (index)) {
								SelectedIndex.Remove (index);
							}

							cell.IsChecked = false;
							cell.btnCheck.SetImage (UnCheckedImage, UIControlState.Normal);

						}


					} 
					else {

						for (int lt = 0; lt < Items.Count; lt ++) {

							var p = NSIndexPath.FromRowSection (lt, 0);

							var tempcell = tableView.CellAt (p) as VoteNowCellView;

							tempcell.IsChecked = false;

							tempcell.btnCheck.SetImage (UnCheckedImage, UIControlState.Normal);


						}

						cell.IsChecked = true;
						cell.btnCheck.SetImage (CheckedImage, UIControlState.Normal);

						if (SingleSelection) {

							SelectedIndex.Clear ();
							SelectedIndex.Add (index, true);

						} 
						else {
							
							if (!SelectedIndex.Keys.Contains (index)) {	
								SelectedIndex.Add (index, true);
							}
						}


					}

					var args = new AnswerSelectedEventArgs { SelectedAnswer = item };
					OnAnswerSelected (args);

				};

				return cell;

			}

			public event EventHandler<AnswerSelectedEventArgs> AnswerSelected;

			public virtual void OnAnswerSelected (AnswerSelectedEventArgs e)
			{
				EventHandler<AnswerSelectedEventArgs> handler = AnswerSelected;

				if (null != handler) {
					handler (this, e);
				}

			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				tableView.DeselectRow (indexPath, true);
			}

		}

		public class AnswerSelectedEventArgs : EventArgs
		{
			public Answer SelectedAnswer { get; set; }
		}
	}
}


