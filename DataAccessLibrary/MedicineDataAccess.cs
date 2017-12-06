using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DataAccessLibrary
{
	public class MedicineDataAccess
	{
		//添加一条药品
		public bool AddMedicine(string medicineName,string medicineTypeID,
			string medicineTypeName,int duration,string provider,int amount)
		{
			string code = CodeProvider.getCodeForMedicine();
			string sql = string.Format("insert into Medicine values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",code,
				medicineName,medicineTypeID,medicineTypeName,duration,provider,amount,DateTime.Now.ToLocalTime());
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		public Medicine GetMedicineById(string id)
		{
			string sql = string.Format("select * from Medicine where MedicineID = '{0}'", id);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				Medicine m = new Medicine(
						dt.Rows[0][0].ToString(),
						dt.Rows[0][1].ToString(),
						dt.Rows[0][2].ToString(),
						dt.Rows[0][3].ToString(),
						int.Parse(dt.Rows[0][4].ToString()),
						dt.Rows[0][5].ToString(),
						int.Parse(dt.Rows[0][6].ToString()),
						DateTime.Parse(dt.Rows[0][7].ToString()));
				return m ;
			}
			else
				return null;
		}

		public List<Medicine> GetAllMedicine()
		{
			string sql = string.Format("select * from Medicine");
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<Medicine> list = new List<Medicine>();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					Medicine m = new Medicine(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						dt.Rows[i][2].ToString(),
						dt.Rows[i][3].ToString(),
						int.Parse(dt.Rows[i][4].ToString()),
						dt.Rows[i][5].ToString(),
						int.Parse(dt.Rows[i][6].ToString()),
						DateTime.Parse(dt.Rows[i][7].ToString())

						);
					list.Add(m);
				}
				return list;
			}
			else
				return null;
		}

		//获得分页显示的药品
		public List<Medicine> GetPaginationMedicine(int pagesize,int index)
		{
			string sql = string.Format("select top {0} * from Medicine where MedicineID not in (select top {1} MedicineID from Medicine)", pagesize, pagesize * (index - 1));
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<Medicine> list = new List<Medicine>();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					Medicine m = new Medicine(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						dt.Rows[i][2].ToString(),
						dt.Rows[i][3].ToString(),
						int.Parse(dt.Rows[i][4].ToString()),
						dt.Rows[i][5].ToString(),
						int.Parse(dt.Rows[i][6].ToString()),
						DateTime.Parse(dt.Rows[i][7].ToString())

						);
					list.Add(m);
				}
				return list;
			}
			else
				return null;
		}

		public int GetCount()
		{
			string sql = "select count(*) from Medicine";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			return int.Parse(dt.Rows[0][0].ToString());
		}

		//根据id更新药品信息
		public bool UpdateMedicineById(string id,int usedAmount)
		{
			string sql = string.Format("select top 1 * from Medicine where MedicineID = '{0}'",id);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			int amount = int.Parse(dt.Rows[0][6].ToString());
			sql = string.Format("update Medicine set Amount = '{0}' where MedicineID = '{1}'", amount - usedAmount, id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		public bool UpdateMedicineById(string medicine_id, string medicine_name, int duration, string provider, int amount, DateTime addtime)
		{
			string sql = string.Format("update Medicine set " +
				"MedicineName = '{0}', Duration = '{1}' ,MedicineProvider = '{2}',Amount = '{3}',AddTime = '{4}' where MedicineID = '{5}'",
				medicine_name,duration,provider,amount,addtime,medicine_id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//根据ID删除指定药品
		public bool DeleteMedicineById(string id)
		{
			string sql = string.Format("delete from Medicine where MedicineID = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}
