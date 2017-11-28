using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DataAccessLibrary
{
	public class PowerDataAccess
	{
		//添加权限
		public bool AddPower(string name)
		{
			string sql = string.Format("insert into [Power] (PowerName) values ('{0}')",name);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//返回所有权限
		public List<Power> GetAllPower()
		{
			List<Power> list = new List<Power>();
			string sql = "select * from [Power]";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if(dt.Rows.Count>0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					Power p = new Power();
					p.ID = dt.Rows[i][0].ToString();
					p.PowerName = dt.Rows[i][1].ToString();
					list.Add(p);
				}
				return list;
			}
			else
				return null;
		}

		//更新权限信息
		public bool UpdatePowerByID(string id,string name)
		{
			string sql = string.Format("update [Power] set PowerName = '{0}' where PowerID = '{1}'", name, id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//根据ID删除指定权限
		public bool DeletePowerByID(string id)
		{
			string sql = string.Format("delete from [Power] where PowerID = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}
