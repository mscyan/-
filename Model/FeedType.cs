using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	class FeedType
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="feedTypeID">种类编号</param>
		/// <param name="feedTypeName">种类名称</param>
		public FeedType(string feedTypeID,string feedTypeName)
		{
			this.feedTypeID = feedTypeID;
			this.feedTypeName = feedTypeName;
		}

		private string feedTypeID;
		private string feedTypeName;

		/// <summary>
		/// 种类编号
		/// </summary>
		public string FeedTypeID
		{
			get { return feedTypeID; }
			set { feedTypeID = value; }
		}

		/// <summary>
		/// 种类名称
		/// </summary>
		public string FeedTypeName
		{
			get { return feedTypeName; }
			set { feedTypeName = value; }
		}
	}
}
