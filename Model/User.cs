using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class User
	{
		public User(string username,string password,string tel)
		{
			this.username = username;
			this.password = password;
			this.tel = tel;
		}

		public User()
		{
		}

		private string companyID;
		/// <summary>
		/// 所属公司ID
		/// </summary>
		public string CompanyID
		{
			get { return companyID; }
			set { companyID = value; }
		}

		private string username;
		public string Username
		{
			get { return username; }
			set { username = value; }
		}

		private string password;
		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		private string tel;
		public string Tel
		{
			get { return tel; }
			set { tel = value; }
		}
	}
}
