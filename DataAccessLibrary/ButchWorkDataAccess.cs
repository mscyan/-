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
		public bool AddButchWork(string butchID,string butchInfo,string animalID,string animalstate,string videoSource)
		{
			string code = CodeProvider.getCodeForButchWork(butchID,animalID);
			string sql = string.Format("insert into ButchWork values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", code, butchID, DateTime.Now.ToLocalTime(), butchInfo, animalID, animalstate,videoSource);
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
						dt.Rows[i][0].ToString().Trim(),
						dt.Rows[i][1].ToString().Trim(),
						DateTime.Parse(dt.Rows[i][2].ToString()),
						dt.Rows[i][3].ToString().Trim(),
						dt.Rows[i][4].ToString().Trim(),
						dt.Rows[i][5].ToString().Trim(),
						dt.Rows[i][6].ToString().Trim()
						);
					list.Add(bwi);
				}
				return list;
			}
			else
				return null;
		}

		public List<ButchWorkInfo> GetPaginationButchWorkInfo(int pagesize,int pageindex)
		{
			string sql = string.Format("select top {0} * from ButchWork where ButchWorkID not in (select top {1} ButchWorkID from ButchWork)", pagesize, (pageindex - 1) * pagesize);
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
						dt.Rows[i][4].ToString().Trim(),
						dt.Rows[i][5].ToString().Trim(),
						dt.Rows[i][6].ToString().Trim()
						);
					list.Add(bwi);
				}
				return list;
			}
			else
				return null;
		}

		public int GetCount()
		{
			string sql = "select count(*) from ButchWork";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			return int.Parse(dt.Rows[0][0].ToString());
		}

		public bool UpdateButchWork(string id,string butchinfo,string animalstate)
		{
			string sql = string.Format("update ButchWork set ButchInfo = '{0}' ,AnimalState = '{1}' where ButchWorkID = '{2}'", butchinfo, animalstate, id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
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
