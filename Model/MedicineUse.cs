using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	class MedicineUse
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="medicineID">药品ID</param>
		/// <param name="medicineUseID">用药记录ID</param>
		/// <param name="animalUniqueCode">牲畜唯一标识码</param>
		/// <param name="medicineDate">用药时间</param>
		/// <param name="medicinePerson">用药人员</param>
		/// <param name="medicineAmount">用药剂量</param>
		/// <param name="reason">用药原因</param>
		public MedicineUse(string medicineID, string medicineUseID, string animalUniqueCode, DateTime medicineDate, string medicinePerson, int medicineAmount, string reason)
		{
			this.medicineID = medicineID;
			this.medicineUseID = medicineUseID;
			this.animalUniqueCode = animalUniqueCode;
			this.medicineDate = medicineDate;
			this.medicinePerson = medicinePerson;
			this.medicineAmount = medicineAmount;
			this.reason = reason;
		}

		private string medicineID;
		private string medicineUseID;
		private string animalUniqueCode;
		private DateTime medicineDate;
		private string medicinePerson;
		private int medicineAmount;
		private string reason;

		/// <summary>
		/// 药品ID
		/// </summary>
		public string MedicineID
		{
			get { return medicineID; }
			set { medicineID = value; }
		}

		/// <summary>
		/// 用药记录ID
		/// </summary>
		public string MedicineUseID
		{
			get { return medicineUseID; }
			set { medicineUseID = value; }
		}

		/// <summary>
		/// 牲畜唯一标识码
		/// </summary>
		public string AnimalUniqueCode
		{
			get { return animalUniqueCode; }
			set { animalUniqueCode = value; }
		}

		/// <summary>
		/// 用药时间
		/// </summary>
		public DateTime MedicineDate
		{
			get { return medicineDate; }
			set { medicineDate = value; }
		}

		/// <summary>
		/// 用药人员
		/// </summary>
		public string MedicinePerson
		{
			get { return medicinePerson; }
			set { medicinePerson = value; }
		}

		/// <summary>
		/// 用药剂量
		/// </summary>
		public int MedicineAmount
		{
			get { return medicineAmount; }
			set { medicineAmount = value; }
		}

		/// <summary>
		/// 用药原因
		/// </summary>
		public string Reason
		{
			get { return reason; }
			set { reason = value; }
		}
	}
}
