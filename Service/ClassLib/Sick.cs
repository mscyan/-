using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.ClassLib
{
	public class Sick
	{
		public Sick()
		{

		}

		private string sickID;
		public string SickID
		{
			get { return sickID; }
		}

		private string sickInfo;
		public string SickInfo
		{
			get { return sickInfo; }
		}

		private string animalID;
		public string AnimalID
		{
			get { return animalID; }
		}

		private DateTime sickDate;
		public DateTime SickDate
		{
			get { return sickDate; }
		}

		private string sickAddress;
		public string SickAddress
		{
			get { return sickAddress; }
		}

		private string sickPerson;
		public string SickPerson
		{
			get { return sickPerson; }
		}
	}
}