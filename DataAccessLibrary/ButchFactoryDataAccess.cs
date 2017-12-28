using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DataAccessLibrary
{
	public class ButchFactoryDataAccess
	{
		public bool AddButchFactory()
		{
			return false;
		}

		//获取所有屠宰场
		public List<ButchFactory> GetAllButchFactory()
		{
			List<ButchFactory> list = new List<ButchFactory>();
			string sql = "select * from [ButchTable]";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					ButchFactory bf = new ButchFactory(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						dt.Rows[i][2].ToString(),
						dt.Rows[i][3].ToString(),
						dt.Rows[i][4].ToString());
					list.Add(bf);
				}
				return list;
			}
			else
				return null;
		}

		public ButchFactory GetButchFactoryById(string id)
		{
			string sql = string.Format("select * from [ButchTable] where ButchID = '{0}'",id);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				ButchFactory bf = new ButchFactory(
					dt.Rows[0][0].ToString(),
					dt.Rows[0][1].ToString(),
					dt.Rows[0][2].ToString(),
					dt.Rows[0][3].ToString(),
					dt.Rows[0][4].ToString());
				return bf;
			}
			else
				return null;
		}

		//根据id删除指定屠宰场
		public bool DeleteButchFactoryById(string id)
		{
			string sql = string.Format("delete from ButchTable where ButchID = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}
