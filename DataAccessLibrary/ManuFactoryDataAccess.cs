using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DataAccessLibrary
{
	public class ManuFactoryDataAccess
	{
		public bool AddManuFactory()
		{

			return false;
		}

		//获取所有加工厂
		public List<ManuFactory> GetAllManuFactory()
		{
			List<ManuFactory> list = new List<ManuFactory>();
			string sql = "select * from [ManuTable]";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					ManuFactory mf = new ManuFactory(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						dt.Rows[i][2].ToString(),
						dt.Rows[i][3].ToString(),
						dt.Rows[i][4].ToString());
					list.Add(mf);
				}
				return list;
			}
			else
				return null;
		}

		public ManuFactory GetManuFactoryById(string id)
		{
			string sql = string.Format("select * from [ManuTable] where ManuID = '{0}'",id);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				ManuFactory mf = new ManuFactory(
					dt.Rows[0][0].ToString(),
					dt.Rows[0][1].ToString(),
					dt.Rows[0][2].ToString(),
					dt.Rows[0][3].ToString(),
					dt.Rows[0][4].ToString());
				return mf;
			}
			else
				return null;
		}

		public bool DeleteManuFactoryById(string id)
		{
			string sql = string.Format("delete from [ManuTable] where ManuId = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}
