using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class FeedUse
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="feedID">饲料ID</param>
		/// <param name="feedUseID">喂养记录ID</param>
		/// <param name="animalUniqueCode">牲畜唯一标识码</param>
		/// <param name="feedDate">喂养时间</param>
		/// <param name="feedPerson">喂养人员</param>
		/// <param name="feedAmount">喂养剂量</param>
		public FeedUse(string feedUseID, string feedID, string animalID, DateTime feedDate, string feedPerson, int feedAmount)
		{
			this.feedID = feedID;
			this.feedUseID = feedUseID;
			this.animalID = animalID;
			this.feedDate = feedDate;
			this.feedPerson = feedPerson;
			this.feedAmount = feedAmount;
		}

		private string feedID;
		private string feedUseID;
		private string animalID;
		private DateTime feedDate;
		private string feedPerson;
		private int feedAmount;

		/// <summary>
		/// 饲料ID
		/// </summary>
		public string FeedID
		{
			get { return feedID; }
			set { feedID = value; }
		}

		/// <summary>
		/// 喂养记录ID
		/// </summary>
		public string FeedUseID
		{
			get { return feedUseID; }
			set { feedUseID = value; }
		}

		/// <summary>
		/// 牲畜唯一标识码
		/// </summary>
		public string AnimalID
		{
			get { return animalID; }
			set { animalID = value; }
		}

		/// <summary>
		/// 喂养时间
		/// </summary>
		public DateTime FeedDate
		{
			get { return feedDate; }
			set { feedDate = value; }
		}

		/// <summary>
		/// 喂养人员
		/// </summary>
		public string FeedPerson
		{
			get { return feedPerson; }
			set { feedPerson = value; }
		}

		/// <summary>
		/// 喂养剂量
		/// </summary>
		public int FeedAmount
		{
			get { return feedAmount; }
			set { feedAmount = value; }
		}
	}
}
