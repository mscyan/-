using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLibrary
{
	public class RoleDataAccess
	{
		//添加角色
		public bool AddRole(string name, string givenBy, string description)
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
					role.RoleID = dt.Rows[i][0].ToString();
					role.RoleName = dt.Rows[i][1].ToString().Trim();
					role.Description = dt.Rows[i][2].ToString();
					role.GivenBy = dt.Rows[i][3].ToString();
					list.Add(role);
				}
				return list;
			}
			else
				return null;
		}

		public DataTable GetUserPowerButtonByUsername(string username)
		{
			string sql = string.Format("select distinct PowerID from RolePower where RoleID in ( select RoleID from UserRole where Username = '{0}')", username);
			return SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
		}

		public bool RolePowerAuthorize(int roleId, string powerIds)
		{
			try
			{
				//先删除所有权限 再重新插入
				DelRolePowerByRoleId(roleId);

				string[] rolepowers = powerIds.Split(',');
				if (!string.IsNullOrEmpty(powerIds))
				{
					int objs = 1;
					for (int i = 0; i < rolepowers.Length - 1; i++)
					{
						string powerId = rolepowers[i];

						string sql = string.Format("insert into RolePower (RoleId,PowerId) values ('{0}','{1}')", roleId, powerId);
						object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
						objs += Convert.ToInt32(obj);
					}
					if (objs == rolepowers.Length)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return true;
				}
			}
			catch
			{
				return false;
			}
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
		/// <summary>
		/// 分配 菜单按钮 执行事务 先批量删除 再批量插入
		/// </summary>
		public bool DelRolePowerByRoleId(int RoleId)
		{
			string sql = string.Format("delete from RolePower where RoleId = '{0}'", RoleId);
			try
			{
				if (SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null) > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
		}

		public List<string> GetRoleByUsername(string Username)
		{
			List<string> list = new List<string>();
			string sql = string.Format("select * from [UserRole] where Username = '{0}'", Username);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					string userrole = dt.Rows[i][1].ToString();
					list.Add(userrole);
				}
				return list;
			}
			else
				return null;
		}
	}
}
