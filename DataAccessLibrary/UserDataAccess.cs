using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
using System.Data;

namespace DataAccessLibrary
{
	public class UserDataAccess
	{
		/// <summary>
		/// 添加用户
		/// </summary>
		/// <returns></returns>
		public bool AddUser(string username,string password,string Tel,string companyid)
		{
			string sql = string.Format("insert into [User] values ('{0}','{1}','{2}','{3}')",username,password,Tel,companyid);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true; 
			else
				return false;
		}

		/// <summary>
		/// 列出所有当前用户
		/// </summary>
		/// <returns></returns>
		public List<User> GetAllUserList()
		{
			List<User> list = new List<User>();
			string sql = string.Format("select * from [User]");
			DataTable userTable = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql,null);
			if (userTable.Rows.Count > 0)
			{
				for (int i = 0; i < userTable.Rows.Count; i++)
				{
					list.Add(new User(
						userTable.Rows[i][0].ToString(),
						userTable.Rows[i][1].ToString(),
						userTable.Rows[i][2].ToString()));
				}
				return list;
			}
			else
				return null;
		}

		/// <summary>
		/// 判断用户是否存在,注册时检测用户名是否存在
		/// </summary>
		public bool IsUserExist(string username)
		{
			string sql = string.Format("select top 1 * from [User] where username = '{0}'",username);
			DataTable userTable = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, new SqlParameter("@Username", username));
			if(userTable.Rows.Count>0)
			{
				return true;
			}
			else
				return false;
		}

		//根据username/password获得用户
		public User GetUserByUsername(string username,string password)
		{
			string sql = string.Format("select top 1 * from [User] where username = '{0}' and [password] = '{1}'", username,password);
			User user = null;
			DataTable userTable = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, new SqlParameter("@Username",username),new SqlParameter("@Password",password));
			if(userTable.Rows.Count>0)
			{
				user = new User(
					userTable.Rows[0][0].ToString(),
					userTable.Rows[0][1].ToString(),
					userTable.Rows[0][2].ToString()
					);
				return user;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 用户信息更新
		/// </summary>
		/// <returns>是否修改成功</returns>
		public bool UpdateUser(string username,string password,string Tel)
		{
			string sql = string.Format("update [User] set [Password] = @Password,Tel = @Tel where Username = @Username");
			SqlParameter[] paras =
			{
				new SqlParameter("@Username",username),
				new SqlParameter("@Password",password),
				new SqlParameter("@Tel",Tel)
			};
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, paras);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		/// <summary>
		/// 删除
		/// </summary>
		/// <returns></returns>
		public bool DeleteUser()
		{
			return false;
		}
	}
}
