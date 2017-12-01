using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DataAccessLibrary
{
	public class ButchWorkDataAccess
	{
		//添加屠宰信息
		public bool AddButchWork(string butchID,string butchInfo,string animalID,string animalstate)
		{
			string code = CodeProvider.getCodeForButchWork();
			string sql = string.Format("insert into ButchWork values ('{0}','{1}','{2}','{3}','{4}','{5}')", code, butchID, DateTime.Now.ToLocalTime(), butchInfo, animalID, animalstate);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//获得所有屠宰操作信息
		public List<ButchWorkInfo> GetAllButchWorkInfo()
		{
			string sql = "select * from [ButchWork]";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<ButchWorkInfo> list = new List<ButchWorkInfo>();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					ButchWorkInfo bwi = new ButchWorkInfo(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						DateTime.Parse(dt.Rows[i][2].ToString()),
						dt.Rows[i][3].ToString(),
						dt.Rows[i][4].ToString(),
						dt.Rows[i][5].ToString()
						);
					list.Add(bwi);
				}
				return list;
			}
			else
				return null;
		}

		//根据id删除指定屠宰操作
		public bool DeleteButchWorkById(string id)
		{
			string sql = string.Format("delete from ButchWork where ButchWorkID = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}
