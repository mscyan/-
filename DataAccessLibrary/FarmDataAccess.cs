using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DataAccessLibrary
{
	public class FarmDataAccess
	{
		public bool AddFarm()
		{
			return false;
		}

		//获取所有的养殖场
		public List<Farm> GetAllFarm()
		{
			List<Farm> list = new List<Farm>();
			string sql = "select * from [Farm]";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					Farm farm = new Farm(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						dt.Rows[i][2].ToString(),
						dt.Rows[i][3].ToString(),
						dt.Rows[i][4].ToString());
					list.Add(farm);
				}
				return list;
			}
			else
				return null;
		}

		public Farm GetFarmById(string id)
		{
			string sql = string.Format("select * from [Farm] where FarmID = '{0}'",id);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				Farm farm = new Farm(
					dt.Rows[0][0].ToString(),
					dt.Rows[0][1].ToString(),
					dt.Rows[0][2].ToString(),
					dt.Rows[0][3].ToString(),
					dt.Rows[0][4].ToString());
				return farm;
			}
			else
				return null;
		}

		public bool DeleteFarmById(string id)
		{
			string sql = string.Format("delete from [Farm] where FarmID = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}
