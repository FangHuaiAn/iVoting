using System;
using System.Linq;
using System.Collections.Generic;

namespace iVoting
{
	public enum AnswerType { 
		Single,
		Multi,

	}

	public class Vote
	{
		public Vote ()
		{
			Answers = new List<Answer> ();
		}

		public string Title { get; set; }
		public string Description { get; set; }

		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public List<Answer> Answers { get; set; }

		public AnswerType SelectType { get; set; }

		public string ImageUrl { get; set; }
		public string VideoUrl { get; set; }
	}

	public class Answer { 
		public string Title { get; set; }
		public string Description { get; set; }
		public int Id { get; set; }
		public int GroupId { get; set; }
		public int Count { get; set; }
	}

	public enum EditStatus{ 
		Edit,
		Approve,
		Reject,
		Release,
		Close,
	}

	public class EditingVote { 

		public Employee Editor { get; set; }
		public Employee Manager { get; set; }

		public EditStatus Status { get; set; }

		public Vote EditVote { get; set; }

	}

	public class VoteManager {

		public Vote CreateVote (string title, string description) {

			var vote = new Vote ();



			return vote;
		}

		public List<Vote> ReadVotesFromRemote () {
			var votes = new List<Vote> ();



			votes.Add (new Vote {
				Title = @"增加特休天數",
				Description = @"實在太累",

				StartTime = new DateTime (2016, 1, 1, 8, 0, 0),
				EndTime = new DateTime(2016, 1, 31, 23, 59, 59),

				ImageUrl = "",
				VideoUrl = "http://techslides.com/demos/sample-videos/small.mp4",

				Answers = new List<Answer> { 
					new Answer{
						Title = @"新增一天",
						Description = @"一天就好",
						GroupId = 0,
						Count =125,
					},
					new Answer{
						Title = @"新增五天",
						Description = @"五福臨門",
						GroupId = 0,
						Count =150,
					},
					new Answer{
						Title = @"新增十天",
						Description = @"十全十美",
						GroupId = 0,
						Count =120,
					}
				}

			});

			votes.Add (new Vote {
				Title = @"員工旅遊地點",
				Description = @"就出去走走吧",

				StartTime = new DateTime (2016, 6, 1, 8, 0, 0),
				EndTime = new DateTime (2016, 6, 30, 23, 59, 59),

				ImageUrl = "",
				VideoUrl = "http://techslides.com/demos/sample-videos/small.mp4",

				SelectType = AnswerType.Single ,
				Answers = new List<Answer> {
					new Answer{
						Title = @"阿拉斯加",
						Description = @"體驗北國風情",
						GroupId = 0,
						Count =100,
						Id = 1001,
					},
					new Answer{
						Title = @"紐約。紐約",
						Description = @"百老匯歌舞秀",
						GroupId = 0,
						Count =150,
						Id = 1002,
					},
					new Answer{
						Title = @"峇里島 Villa",
						Description = @"完全放鬆",
						GroupId = 0,
						Count =400,
						Id = 1003,
					}
				}
			});


			votes.Add (new Vote {
				Title = @"加薪10%",
				Description = @"這才是拼經濟",

				StartTime = new DateTime (2017, 6, 1, 8, 0, 0),
				EndTime = new DateTime (2017, 6, 30, 23, 59, 59),

			});


			return votes;
		}


		public List<EditingVote> ReadEditVotesFromRemote () {
			var results = new List<EditingVote> ();

			results.Add (
				new EditingVote { 
				
				
				
				}
			);


			return results;
		}

	}

}

