using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DataAccessLibrary
{
	public class CheckDataAccess
	{
		public bool AddCheck(string checkposition,string checkperson,string checkresult,string animalid,string animalstate)
		{
			string code = CodeProvider.getCodeForCheck();
			string sql = string.Format("insert into CheckInfo values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
				code,DateTime.Now.ToLocalTime(),checkposition,checkperson,checkresult,animalid,animalstate);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		public List<HealthCheck> GetPaginationHealthCheck(int pagesize,int index)
		{
			string sql = string.Format("select top {0} * from CheckInfo where CheckID not in (select top {1} CheckID from CheckInfo)", pagesize, (index - 1) * pagesize);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<HealthCheck> list = new List<HealthCheck>();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					HealthCheck hc = new HealthCheck(
						dt.Rows[i][0].ToString(),
						DateTime.Parse(dt.Rows[i][1].ToString()),
						dt.Rows[i][2].ToString(),
						dt.Rows[i][3].ToString(),
						dt.Rows[i][4].ToString(),
						dt.Rows[i][5].ToString(),
						dt.Rows[i][6].ToString()
						);
					list.Add(hc);
				}
				return list;
			}
			else
				return null;
		}

		public int GetCount()
		{
			string sql = "select count(*) from CheckInfo";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			return int.Parse(dt.Rows[0][0].ToString());
		}

		public bool UpdateHealthCheckById(string id,string checkPerson,string checkresult,string animalstate)
		{
			string sql = string.Format("update CheckInfo set CheckPerson = '{0}' ,CheckResult = '{1}',AnimalState = '{2}' where CheckID = '{3}'",checkPerson,checkresult,animalstate,id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		public bool DeleteHealthCheckById(string id)
		{
			string sql = string.Format("delete from CheckInfo where CheckID = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		public HealthCheck GetCheckByAnimalId(string animalID)
		{
			string sql = string.Format("select * from CheckInfo where AnimalID = '{0}'",animalID);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				HealthCheck hc = new HealthCheck(
					dt.Rows[0][0].ToString(),
					DateTime.Parse(dt.Rows[0][1].ToString()),
					dt.Rows[0][2].ToString(),
					dt.Rows[0][3].ToString(),
					dt.Rows[0][4].ToString(),
					dt.Rows[0][5].ToString(),
					dt.Rows[0][6].ToString()
					);
				return hc;
			}
			else
				return null;
		}
	}
}
