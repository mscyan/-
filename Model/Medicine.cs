using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Medicine
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="medicineID">药品ID</param>
		/// <param name="medicineTypeID">药品种类ID</param>
		/// <param name="medicineName">药品名称</param>
		/// <param name="medicineTypeName">药品种类名称</param>
		/// <param name="duration">保质期(月)</param>
		/// <param name="provider">生产商</param>
		public Medicine(string medicineID, string medicineName, string medicineTypeID, 
			string medicineTypeName, int duration, string provider,int amount,DateTime addTime)
		{
			this.medicineID = medicineID;
			this.medicineTypeID = medicineTypeID;
			this.medicineName = medicineName;
			this.medicineTypeName = medicineTypeName;
			this.duration = duration;
			this.provider = provider;
			this.addTime = addTime;
			this.amount = amount;
		}

		private string medicineID;
		private string medicineTypeID;
		private string medicineName;
		private string medicineTypeName;
		private int duration;
		private string provider;

		/// <summary>
		/// 药品ID
		/// </summary>
		public string MedicineID
		{
			get { return medicineID; }
			set { medicineID = value; }
		}

		/// <summary>
		/// 药品种类ID
		/// </summary>
		public string MedicineTypeID
		{
			get { return medicineTypeID; }
			set { medicineTypeID = value; }
		}

		/// <summary>
		/// 药品名称
		/// </summary>
		public string MedicineName
		{
			get { return medicineName; }
			set { medicineName = value; }
		}

		/// <summary>
		/// 药品种类名称
		/// </summary>
		public string MedicineTypeName
		{
			get { return medicineTypeName; }
			set { medicineTypeName = value; }
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

		private int amount;
		public int Amount
		{
			set { amount = value; }
			get { return amount; }
		}

		private DateTime addTime;
		public DateTime AddTime
		{
			set { addTime = value; }
			get { return addTime; }
		}
	}
}
