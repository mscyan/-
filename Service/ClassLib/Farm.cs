using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.ClassLib
{
	public class Farm
	{
		public Farm()
		{ }

		private string farmID;
		public string FarmID
		{
			get { return farmID; }
		}

		private string farmPerson;
		public string FarmPerson
		{
			get { return farmPerson; }
		}

		private string farmPosition;
		public string FarmPosition
		{
			get { return farmPosition; }
		}

		private string farmTel;
		public string FarmTel
		{
			get { return farmTel; }
		}
	}
}