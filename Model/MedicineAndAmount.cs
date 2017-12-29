using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class MedicineAndAmount
	{
		public string Name;
		public double Amount;
		public MedicineAndAmount(string medicineName, double medicineAmount)
		{
			this.Name = medicineName;
			this.Amount = medicineAmount;
		}
	}
}
