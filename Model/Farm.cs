using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Farm
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="farmID">养殖场ID</param>
		/// <param name="farmName">养殖场名称</param>
		/// <param name="farmPerson">养殖场负责人</param>
		/// <param name="farmPosition">养殖场地点</param>
		/// <param name="farmTel">养殖场电话</param>
		public Farm(string farmID, string farmPerson, string farmPosition, string farmTel, string farmName)
		{
			this.farmID = farmID;
			this.farmName = farmName;
			this.farmPerson = farmPerson;
			this.farmPosition = farmPosition;
			this.farmTel = farmTel;
		}

		private string farmID;
		/// <summary>
		/// 养殖场ID
		/// </summary>
		public string FarmID
		{
			get { return farmID; }
			set { farmID = value; }
		}

		private string farmName;
		/// <summary>
		/// 养殖场名称
		/// </summary>
		public string FarmName
		{
			get { return farmName; }
			set { farmName = value; }
		}

		private string farmPerson;
		/// <summary>
		/// 养殖场负责人
		/// </summary>
		public string FarmPerson
		{
			get { return farmPerson; }
			set { farmPerson = value; }
		}

		private string farmPosition;
		/// <summary>
		/// 养殖场地点
		/// </summary>
		public string FarmPosition
		{
			get { return farmPosition; }
			set { farmPosition = value; }
		}

		private string farmTel;
		/// <summary>
		/// 养殖场电话
		/// </summary>
		public string FarmTel
		{
			get { return farmTel; }
			set { farmTel = value; }
		}
	}
}
