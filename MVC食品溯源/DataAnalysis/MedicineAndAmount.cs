using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC食品溯源.DataAnalysis
{
	public class MedicineAndAmount
	{
		public string Name;
		public double ys;
		public MedicineAndAmount(string medicineName,double medicineAmount)
		{
			this.Name = medicineName;
			this.ys = medicineAmount;
		}
	}
}