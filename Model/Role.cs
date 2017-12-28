using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Role
	{
		public Role()
		{

		}

		private string roleid;
		private string roleName;
		private string description;
		private string givenBy;

		public string RoleID
		{
			get { return roleid; }
			set { roleid = value; }
		}

		public string RoleName
		{
			get { return roleName; }
			set { roleName = value; }
		}

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		public string GivenBy
		{
			get { return givenBy; }
			set { givenBy = value; }
		}
	}
}
