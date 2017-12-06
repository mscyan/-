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
		//添加一条喂养记录
		public bool AddFeedUse(string feedID,string animalID,string feedPerson,int feedAmount)
		{
			string sql = string.Format("insert into FeedUse (FeedID,AnimalID,FeedDate,FeedPerson,FeedAmount) values ('{0}','{1}','{2}','{3}','{4}')",feedID,animalID,DateTime.Now.ToLocalTime(),feedPerson,feedAmount);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			new FeedDataAccess().UpdateFeedInfoById(feedID, feedAmount);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//获得所有喂养记录
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

		public List<FeedUse> GetPaginationFeedUse(int pagesize,int pageindex)
		{
			List<FeedUse> list = new List<FeedUse>();
			string sql = string.Format("select top {0} * from FeedUse where FeedUseID not in (select top {1} FeedUseID from FeedUse)", pagesize, (pageindex - 1) * pagesize);
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

		public int GetCount()
		{
			string sql = "select count(*) from FeedUse";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			return int.Parse(dt.Rows[0][0].ToString());
		}

		//根据ID删除指定用药记录
		public bool DeleteFeedUseById(string id)
		{
			string sql = string.Format("delete from FeedUse where FeedUseID = '{0}'", int.Parse(id));
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}
