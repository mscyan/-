using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DataAccessLibrary
{
	public class LogDataAccess
	{
		//添加一条日志
		public bool AddLog(DateTime logTime,string logUser,string logAction,string logResult)
		{
			string sql = string.Format("insert into [Log] ('LogTime','LogUser','LogAction','LogResult" +
				"') values ('{0}','{1}','{2}','{3}')",logTime,logUser,logAction,logResult);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if(Convert.ToInt32(obj)>0)
			{
				return true;
			}
			else
				return false;
		}

		//查询出所有日志记录
		public List<Log> GetAllLog()
		{
			List<Log> list = new List<Log>();
			string sql = "select * from [Log]";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if(dt.Rows.Count>0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					Log log = new Log(
						dt.Rows[i][0].ToString(),
						DateTime.Parse(dt.Rows[i][1].ToString()),
						dt.Rows[i][2].ToString(),
						dt.Rows[i][3].ToString(),
						dt.Rows[i][4].ToString()
						);
					list.Add(log);
				}
				return list;
			}
			else
				return null;
		}

		//查询某段时间内的操作日志记录
		public List<Log> GetLogsBetweenTime(DateTime startTime, DateTime endTime)
		{
			List<Log> list = new List<Log>();
			string sql = string.Format("select * from [Log] where LogTime > {0} and LogTime < {1}",startTime,endTime);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					Log log = new Log(
						dt.Rows[i][0].ToString(),
						DateTime.Parse(dt.Rows[i][1].ToString()),
						dt.Rows[i][2].ToString(),
						dt.Rows[i][3].ToString(),
						dt.Rows[i][4].ToString()
						);
					list.Add(log);
				}
				return list;
			}
			else
				return null;
		}

		//根据ID删除记录
		public bool DeleteLogByID(string logID)
		{
			string sql = string.Format("delete from [Log] where LogID = {0}", int.Parse(logID));
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
