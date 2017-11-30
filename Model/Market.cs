using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	class Market : Company
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="marketID">零售点编号</param>
		/// <param name="marketName">零售点名称</param>
		/// <param name="marketPerson">负责人</param>
		/// <param name="marketPosition">零售点地点</param>
		/// <param name="marketTel">零售点电话</param>
		public Market(string marketID, string marketName, string marketPerson, string marketPosition, string marketTel)
		{
			this.marketID = marketID;
			this.marketName = marketName;
			this.marketPerson = marketPerson;
			this.marketPosition = marketPosition;
			this.marketTel = marketTel;
		}

		private string marketID;
		private string marketName;
		private string marketPerson;
		private string marketPosition;
		private string marketTel;

		/// <summary>
		/// 零售点编号
		/// </summary>
		public string MarketID
		{
			get { return marketID; }
			set { marketID = value; }
		}

		/// <summary>
		/// 零售点名称
		/// </summary>
		public string MarketName
		{
			get { return marketName; }
			set { marketName = value; }
		}

		/// <summary>
		/// 负责人
		/// </summary>
		public string MarketPerson
		{
			get { return marketPerson; }
			set { marketPerson = value; }
		}

		/// <summary>
		/// 零售点地点
		/// </summary>
		public string MarketPosition
		{
			get { return marketPosition; }
			set { marketPosition = value; }
		}

		/// <summary>
		/// 零售点电话
		/// </summary>
		public string MarketTel
		{
			get { return marketTel; }
			set { marketID = value; }
		}

	}
}
