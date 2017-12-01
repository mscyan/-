using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class ManuWorkInfo
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="manuWorkInfoID">加工工作批次编号</param>
		/// <param name="manuFactoryID">加工厂编号</param>
		/// <param name="manuDate">加工日期</param>
		/// <param name="animalUniqueCode">牲畜唯一标识码</param>
		public ManuWorkInfo(string manuWorkInfoID, string manuFactoryID, DateTime manuDate, string animalUniqueCode)
		{
			this.manuWorkInfoID = manuWorkInfoID;
			this.manuFactoryID = manuFactoryID;
			this.manuDate = manuDate;
			this.animalUniqueCode = animalUniqueCode;
		}

		private string manuWorkInfoID;
		/// <summary>
		/// 加工工作批次编号
		/// </summary>
		public string ManuWorkInfoID
		{
			get { return manuWorkInfoID; }
			set { manuWorkInfoID = value; }
		}

		private string manuFactoryID;
		/// <summary>
		/// 加工厂编号
		/// </summary>
		public string ManuFactoryID
		{
			get { return manuFactoryID; }
			set { manuFactoryID = value; }
		}

		private DateTime manuDate;
		/// <summary>
		/// 加工日期
		/// </summary>
		public DateTime ManuDate
		{
			get { return ManuDate; }
			set { manuDate = value; }
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
	}
}
