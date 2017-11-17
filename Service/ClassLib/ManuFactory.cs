using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.ClassLib
{
	public class ManuFactory
	{
		public ManuFactory()
		{

		}

		private string animalID;
		public string AnimalID
		{
			get { return animalID; }
		}

		private string manuworkID;
		public string ManuworkID
		{
			get { return manuworkID; }
		}

		private DateTime manuDate;
		public DateTime ManuDate
		{
			get { return manuDate; }
		}

		private string manuID;
		public string ManuID
		{
			get { return manuID; }
		}

		private string manuPerson;
		public string ManuPerson
		{
			get { return manuPerson; }
		}

		private string manuPosition;
		public string ManuPosition
		{
			get { return manuPosition; }
		}

		private string manuTel;
		public string ManuTel
		{
			get { return manuTel; }
		}
	}
}