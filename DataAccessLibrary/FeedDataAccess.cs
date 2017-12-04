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
	/// 饲料(仓库)记录
	/// </summary>
	public class FeedDataAccess
	{
		//添加一条记录
		public bool AddFeedInfo(string feedname, string feedtypeID,string feedtypeName,int duration,string provider,int amount)
		{
			string code = CodeProvider.getCodeForFeed();
			string sql = string.Format("insert into [Feed] values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",code, feedname, feedtypeID,feedtypeName,duration,provider,amount,DateTime.Now.ToLocalTime());
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//获得所有饲料信息
		public List<Feed> GetAllFeedInfo()
		{
			List<Feed> list = new List<Feed>();
			string sql = "select * from Feed";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if(dt.Rows.Count>0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					Feed feed = new Feed(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						dt.Rows[i][2].ToString(),
						dt.Rows[i][3].ToString(),
						int.Parse(dt.Rows[i][4].ToString()),
						dt.Rows[i][5].ToString(),
						int.Parse(dt.Rows[i][6].ToString()),
						DateTime.Parse(dt.Rows[i][7].ToString())
						);
					list.Add(feed);
				}
				return list;
			}
			return null;
		}

		public Feed GetFeedByID(string id)
		{
			string sql = string.Format("select * from where FeedID = '{0}'", id);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				Feed feed = new Feed(
						dt.Rows[0][0].ToString(),
						dt.Rows[0][1].ToString(),
						dt.Rows[0][2].ToString(),
						dt.Rows[0][3].ToString(),
						int.Parse(dt.Rows[0][4].ToString()),
						dt.Rows[0][5].ToString(),
						int.Parse(dt.Rows[0][6].ToString()),
						DateTime.Parse(dt.Rows[0][7].ToString())
						);
				return feed;
			}
			else
				return null;
		}

		//通过ID更新饲料
		public bool UpdateFeedInfoById(string id,int Usedamount)
		{
			string sql = string.Format("select top 1 * from Feed where FeedID = '{0}'", id);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			int amount = int.Parse(dt.Rows[0][6].ToString());
			sql = string.Format("update Feed set Amount = '{0}' where FeedID = '{1}'", amount - Usedamount, id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//通过ID删除一条记录
		public bool DeleteFeedInfoById(string id)
		{
			string sql = string.Format("delete from Feed where FeedID = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if(Convert.ToInt32(obj)>0)
			{
				return true;
			}
			else
				return false;
		}
	}
}
