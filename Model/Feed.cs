using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	class Feed
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="feedID">饲料ID</param>
		/// <param name="feedTypeID">饲料种类ID</param>
		/// <param name="feedName">饲料名称</param>
		/// <param name="feedTypeName">饲料种类名称</param>
		/// <param name="duration">保质期(月)</param>
		/// <param name="provider">生产商</param>
		public Feed(string feedID, string feedTypeID, string feedName, string feedTypeName, int duration, string provider)
		{
			this.feedID = feedID;
			this.feedTypeID = feedTypeID;
			this.feedName = feedName;
			this.feedTypeName = feedTypeName;
			this.duration = duration;
			this.provider = provider;
		}

		private string feedID;
		private string feedTypeID;
		private string feedName;
		private string feedTypeName;
		private int duration;
		private string provider;

		/// <summary>
		/// 饲料ID
		/// </summary>
		public string FeedID
		{
			get { return feedID; }
			set { feedID = value; }
		}

		/// <summary>
		/// 饲料种类ID
		/// </summary>
		public string FeedTypeID
		{
			get { return feedTypeID; }
			set { feedTypeID = value; }
		}

		/// <summary>
		/// 饲料名称
		/// </summary>
		public string FeedName
		{
			get { return feedName; }
			set { feedName = value; }
		}

		/// <summary>
		/// 饲料种类名称
		/// </summary>
		public string FeedTypeName
		{
			get { return feedTypeName; }
			set { feedTypeName = value; }
		}

		/// <summary>
		/// 保质期(月)
		/// </summary>
		public int Duration
		{
			get { return duration; }
			set { duration = value; }
		}

		/// <summary>
		/// 生产商
		/// </summary>
		public string Provider
		{
			get { return provider; }
			set { provider = value; }
		}
	}
}
