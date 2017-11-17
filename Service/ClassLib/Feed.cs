using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.ClassLib
{
	public class Feed
	{
		public Feed()
		{

		}

		private string feedID;
		public string FeedID
		{
			get { return feedID; }
		}

		private string farmID;
		public string FarmID
		{
			get { return farmID; }
		}

		private string feedName;
		public string FeedName
		{
			get { return feedName; }
		}

		private string provider;
		public string Provider
		{
			get { return provider; }
		}

		private DateTime birDate;
		public DateTime BriDate
		{
			get { return birDate; }
		}

		private int durationTime;
		public int DurationTime
		{
			get { return durationTime; }
		}

		private string suitAnimal;
		public string SuitAnimal
		{
			get { return suitAnimal; }
		}
	}
}