using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class SaleInfo
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="saleID">订单号</param>
		/// <param name="marketID">零售点编号</param>
		/// <param name="animalUniqueCode">牲畜唯一标识码</param>
		/// <param name="saleDate">销售日期</param>
		/// <param name="salePosition">销售地点</param>
		/// <param name="saleType">商品类型</param>
		public SaleInfo(string saleID, string marketID, DateTime saleDate, string salePosition, string animalUniqueCode, string saleType,string hasSaled)
		{
			this.saleID = saleID;
			this.marketID = marketID;
			this.animalUniqueCode = animalUniqueCode;
			this.saleDate = saleDate;
			this.salePosition = salePosition;
			this.saleType = saleType;
			this.hasSaled = hasSaled;
		}

		private string hasSaled;
		public string HasSaled
		{
			get { return hasSaled; }
			set { hasSaled = value; }
		}

		private string saleType;
		public string SaleType
		{
			get { return saleType; }
			set { saleType = value; }
		}

		private string saleID;
		/// <summary>
		/// 订单号
		/// </summary>
		public string SaleID
		{
			get { return saleID; }
			set { saleID = value; }
		}

		private string marketID;
		/// <summary>
		/// 零售点编号
		/// </summary>
		public string MarketID
		{
			get { return marketID; }
			set { marketID = value; }
		}

		private string animalUniqueCode;
		/// <summary>
		/// 牲畜唯一标识码
		/// </summary>
		public string AnimalUniqueCode
		{
			get { return animalUniqueCode; }
			set { animalUniqueCode = value; }
		}

		private DateTime saleDate;
		/// <summary>
		/// 销售日期
		/// </summary>
		public DateTime SaleDate
		{
			get { return saleDate; }
			set { saleDate = value; }
		}

		private string salePosition;
		/// <summary>
		/// 销售地点
		/// </summary>
		public string SalePosition
		{
			get { return salePosition; }
			set { salePosition = value; }
		}
	}
}
