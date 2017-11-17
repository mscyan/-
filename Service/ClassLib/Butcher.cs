using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.ClassLib
{
	public class Butcher
	{
		public Butcher()
		{

		}

		private string animalID;
		public string AnimalID
		{
			get { return animalID; }
		}

		private DateTime butchDate;
		public DateTime ButchDate
		{
			get { return butchDate; }
		}

		private string butchworkID;
		public string ButchworkID
		{
			get { return butchworkID; }
		}

		private string butchID;
		public string ButchID
		{
			get { return butchID; }
		}

		private string butchPerson;
		public string ButchPerson
		{
			get { return butchPerson; }
		}

		private string butchPosition;
		public string ButchPosition
		{
			get { return butchPosition; }
		}

		private string butchTel;
		public string ButchTel
		{
			get { return butchTel; }
		}
	}
}