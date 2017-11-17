using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.ClassLib
{
	public class Animal
	{
		public Animal(string animalType,DateTime animalBirth,string farmID)
		{
			this.animalType = animalType;
			this.animalBirth = animalBirth;
			this.farmID = farmID;
			this.animalID = CodeProvider.GetCode();
		}

		private string animalID;
		public string AnimalID
		{
			get { return animalID; }
		}

		private string animalType;
		public string AnimalType
		{
			get { return animalType; }
		}

		private DateTime animalBirth;
		public DateTime AnimalBirth
		{
			get { return animalBirth; }
		}

		private string farmID;
		public string FarmID
		{
			get { return FarmID; }
		}

		private string farmPerson;
		public string FarmPerson
		{
			get { return farmPerson; }
		}

		private DateTime sendDate;
		public DateTime SendDate
		{
			get { return sendDate; }
		}

		private double sendWeight;
		public double SendWeight
		{
			get { return sendWeight; }
		}

		private string sendPosition;
		public string SendPosition
		{
			get { return sendPosition; }
		}
	}
}