using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DataAccessLibrary
{
	public class MarketDataAccess
	{
		public bool AddMarket()
		{

			return false;
		}

		//获取所有零售点
		public List<Market> GetAllMarket()
		{
			List<Market> list = new List<Market>();
			string sql = "select * from [Market]";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					Market mt = new Market(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						dt.Rows[i][2].ToString(),
						dt.Rows[i][3].ToString(),
						dt.Rows[i][4].ToString());
					list.Add(mt);
				}
				return list;
			}
			else
				return null;
		}

		//根据id删除指定零售点
		public bool DeleteMarketById(string id)
		{
			string sql = string.Format("delete from Market where MarketID = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}
