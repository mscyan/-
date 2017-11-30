using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Company
	{
		public Company()
		{

		}

		private string companyID;
		private string companyName;
		private string companyPerson;
		private string companyPosition;
		private string companyTel;

		public string CompanyID
		{
			set { companyID = value; }
			get { return companyID; }
		}

		public string CompanyPerson
		{
			set { companyPerson = value; }
			get { return companyPerson; }
		}

		public string CompanyPostion
		{
			set { companyPosition = value; }
			get { return companyPosition; }
		}

		public string CompanyTel
		{
			set { companyTel = value; }
			get { return companyTel; }
		}

		public string CompanyName
		{
			set { CompanyName = value; }
			get { return companyTel; }
		}
	}
}
