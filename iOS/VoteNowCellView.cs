using System;

using Foundation;
using UIKit;

namespace iVoting.iOS
{
	public partial class VoteNowCellView : UITableViewCell
	{
		public bool IsChecked { get; set; }

		protected VoteNowCellView (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UpdateUIWith (Answer answer) {
			lbTitle.Text = $"{answer.Title}:{answer.Description}";
		}
	}
}
