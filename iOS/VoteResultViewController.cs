using System;
using System.Linq;
using System.Collections.Generic;

using UIKit;

using BarChart;

namespace iVoting.iOS
{
	public partial class VoteResultViewController : UIViewController
	{

		public Vote SelectedVote { get; set; }

		public VoteResultViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
			var data = new List<BarModel> ();

			SelectedVote.Answers.ForEach (a => data.Add (new BarModel { ValueCaption = $"{a.Title}:{a.Count}", Value = a.Count }));

			var max = (int)( SelectedVote.Answers.Max (x => x.Count) * 1.2) ;
			var min = (int)(SelectedVote.Answers.Min (x => x.Count) * 0.8);

			var chart = new BarChartView{
				
				Frame = View.Frame,
				ItemsSource = data,
				BarCaptionInnerColor = UIColor.Black,
				BarCaptionOuterColor = UIColor.DarkGray,
				BarWidth = 60,
				BarOffset = 20,
				BarColor = UIColor.FromRGB(62, 181, 227),
				           
				MaximumValue = max,
				MinimumValue = min,

			};

			View.AddSubview (chart);

			btnBack.Clicked += (sender, e) => {
				NavigationController.PopToRootViewController (true);
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


