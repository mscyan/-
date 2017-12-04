using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DataAccessLibrary
{
	public class FeedTypeDataAccess
	{
		//添加一条饲料种类信息
		public bool AddFeedType(string typename)
		{
			string code = CodeProvider.getCodeForFeedType();
			string sql = string.Format("insert into FeedType values ('{0}','{1}')", code, typename);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if(Convert.ToInt32(obj)>0)
			{
				return true;
			}
			else
				return false;
		}

		//获得所有饲料种类信息
		public List<FeedType> GetAllFeedType()
		{
			List<FeedType> list = new List<FeedType>();
			string sql = "select * from FeedType";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if(dt.Rows.Count>0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					FeedType ft = new FeedType(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString().Trim());
					list.Add(ft);
				}
				return list;
			}
			else
				return null;
		}

		//通过id获取种类名
		public string GetNameByID(string id)
		{
			string sql = string.Format("select FeedTypeName from FeedType where FeedTypeID = '{0}'", id);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if(dt.Rows.Count>0)
			{
				return dt.Rows[0][0].ToString();
			}
			else
			{
				return null;
			}
		}

		//更新饲料名称
		public bool UpdateNameByID(string id,string newName)
		{
			string sql = string.Format("update FeedType set FeedTypeName = '{0}' where FeedTypeID = '{1}'", newName, id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if(Convert.ToInt32(obj)>0)
			{
				return true;
			}
			else
				return false;
		}

		//根据id删除某条记录
		public bool DeleteRowByID(string id)
		{
			string sql = string.Format("delete from FeedType where FeedTypeID = '{0}'",id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
			{
				return true;
			}
			else
				return false;
		}
	}
}
