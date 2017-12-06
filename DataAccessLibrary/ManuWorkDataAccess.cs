using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DataAccessLibrary
{
	public class ManuWorkDataAccess
	{
		//添加加工操作
		public bool AddManuWorkInfo(string manuID,string animalID,string manuInfo)
		{
			string code = CodeProvider.getCodeForManuWork(manuID,animalID);
			string sql = string.Format("insert into ManuWork values ('{0}','{1}','{2}','{3}','{4}')", code, manuID, DateTime.Now.ToLocalTime(), animalID,manuInfo);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//获取所有的加工工作操作信息
		public List<ManuWorkInfo> GetAllManuWork()
		{
			string sql = "select * from [ManuWork]";
			List<ManuWorkInfo> list = new List<ManuWorkInfo>();
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					ManuWorkInfo mwi = new ManuWorkInfo(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						DateTime.Parse(dt.Rows[i][2].ToString()),
						dt.Rows[i][3].ToString(),
						dt.Rows[i][4].ToString()
						);
					list.Add(mwi);
				}
				return list;
			}
			else
				return null;
		}

		public List<ManuWorkInfo> GetAllManuWork(int pagesize,int pageindex)
		{
			string sql = string.Format("select top {0} * from ManuWork where ManuWorkID not in (select top {1} ManuWorkID from ManuWork)", pagesize, (pageindex - 1) * pagesize);
			List<ManuWorkInfo> list = new List<ManuWorkInfo>();
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					ManuWorkInfo mwi = new ManuWorkInfo(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						DateTime.Parse(dt.Rows[i][2].ToString()),
						dt.Rows[i][3].ToString(),
						dt.Rows[i][4].ToString()
						);
					list.Add(mwi);
				}
				return list;
			}
			else
				return null;
		}

		public int GetCount()
		{
			string sql = "select count(*) from ManuWork";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			return int.Parse(dt.Rows[0][0].ToString());
		}

		//更新表
		public bool UpdateManuWorkInfoById(string id,string manuInfo)
		{
			string sql = string.Format("update ManuWork set ManuInfo = '{0}' where ManuWorkID = '{1}'",manuInfo,id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//根据id删除指定的加工工作
		public bool DeleteManuWorkInfoById(string id)
		{
			string sql = string.Format("delete from ManuWork where ManuWorkID = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}
