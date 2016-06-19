using System;

using Foundation;
using UIKit;

namespace iVoting.Editor.iOS
{
	public partial class StatusCellView : UITableViewCell
	{

		protected StatusCellView (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UpdateUIWith (EditingVote editingVote) {
			lbTitle.Text = editingVote.EditVote.Title;
			lbStatus.Text = VoteManager.StatusTitles [(int)editingVote.Status];

			switch (editingVote.Status) {
				case EditStatus.Approve: {
					btnStatus.SetTitle ("已通過", UIControlState.Normal);
				}
				break;
				case EditStatus.Close: { 
					btnStatus.SetTitle ("看結果", UIControlState.Normal);
				}
				break;
				case EditStatus.Edit:{ 
					btnStatus.SetTitle ("編輯", UIControlState.Normal);
				}
				break;
				case EditStatus.Reject:{
					btnStatus.Hidden = true;
				}
				break;
				case EditStatus.Release:{ 
					btnStatus.SetTitle ("目前狀況", UIControlState.Normal);
				}
				break;

			
			}

		}
	}
}
