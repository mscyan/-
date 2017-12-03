using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DataAccessLibrary
{
	/// <summary>
	/// 饲料喂养记录
	/// </summary>
	public class FeedUseDataAccess
	{
		public List<FeedUse> GetAllFeedUseData()
		{
			List<FeedUse> list = new List<FeedUse>();
			string sql = "select * from FeedUse";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					FeedUse fu = new FeedUse(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						dt.Rows[i][2].ToString(),
						DateTime.Parse(dt.Rows[i][3].ToString()),
						dt.Rows[i][4].ToString(),
						int.Parse(dt.Rows[i][5].ToString())
						);
					list.Add(fu);
				}
				return list;
			}
			else
				return null;
		}
	}
}
