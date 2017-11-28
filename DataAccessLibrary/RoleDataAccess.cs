using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DataAccessLibrary
{
	public class RoleDataAccess
	{
		//添加角色
		public bool AddRole(string name,string givenBy, string description)
		{
			string sql = string.Format("insert into [Role] (RoleName,Description,GivenBy) values ('{0}','{1}','{2}')", name, description, givenBy);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//获取所有的角色
		public List<Role> GetAllRole()
		{
			List<Role> list = new List<Role>();
			string sql = "select * from [Role]";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					Role role = new Role();
					role.ID = dt.Rows[i][0].ToString();
					role.RoleName = dt.Rows[i][1].ToString();
					role.Description = dt.Rows[i][2].ToString();
					role.GivenBy = dt.Rows[i][3].ToString();
					list.Add(role);
				}
				return list;
			}
			else
				return null;
		}

		//根据ID删除指定角色
		public bool DeleteRoleById(string id)
		{
			string sql = string.Format("delete from [Role] where RoleID = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}
