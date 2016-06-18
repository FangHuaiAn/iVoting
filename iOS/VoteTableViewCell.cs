using System;

using Foundation;
using UIKit;

namespace iVoting.iOS
{
	public partial class VoteTableViewCell : UITableViewCell
	{
		protected VoteTableViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UpdateUIWith (Vote vote) {

			lbTitle.Text = vote.Title;
			lbDescription.Text = vote.Description;

			if (DateTime.Now < vote.StartTime) {
				this.BackgroundColor = UIColor.FromRGB (255, 255, 224);
				btnNext.Hidden = true;
			}
			else {

				// 已開始，未結束
				if (DateTime.Now < vote.EndTime) {

					btnNext.SetTitle( @"投票去", UIControlState.Normal );
				}
				// 已開始，已結束
				else {
					this.BackgroundColor = UIColor.LightGray;

					btnNext.SetTitle (@"看結果", UIControlState.Normal);
				}
			}
		}
	}
}
