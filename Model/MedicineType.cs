using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class MedicineType
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="medicineTypeID">种类编号</param>
		/// <param name="medicineTypeName">种类名称</param>
		public MedicineType(string medicineTypeID, string medicineTypeName)
		{
			this.medicineTypeID = medicineTypeID;
			this.medicineTypeName = medicineTypeName;
		}

		private string medicineTypeID;
		private string medicineTypeName;

		/// <summary>
		/// 种类编号
		/// </summary>
		public string MedicineTypeID
		{
			get { return medicineTypeID; }
			set { medicineTypeID = value; }
		}

		/// <summary>
		/// 种类名称
		/// </summary>
		public string MedicineTypeName
		{
			get { return medicineTypeName; }
			set { medicineTypeName = value; }
		}
	}
}
