using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	class Power
	{
		public Power()
		{

		}

		private string id;
		public string powerName;

		public string ID
		{
			get { return id; }
			set { id = value; }
		}

		public string PowerName
		{
			get { return powerName; }
			set { powerName = value; }
		}
	}
}
