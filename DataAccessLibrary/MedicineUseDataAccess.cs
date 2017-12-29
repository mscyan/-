using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DataAccessLibrary
{
	public class MedicineUseDataAccess
	{
		//添加一条用药记录
		public bool AddMedicineUse(string medicineTypeID,string medicineID,
			string animalID,string medicinePerson,int amount,string reason)
		{
			string sql = string.Format("insert into MedicineUse" +
				" (MedicineTypeID,MedicineID,AnimalID,MedicineDate,MedicinePerson,MedicineAmount,Reason) " +
				"values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
				medicineTypeID,medicineID,animalID,DateTime.Now.ToLocalTime(),medicinePerson,amount,reason);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//获得所有的用药记录
		public List<MedicineUse> GetPaginationMedicineUse(int pagesize,int index)
		{
			string sql = string.Format("select top {0} * from MedicineUse where MedicineUseID not in (select top {1} MedicineUseID from MedicineUse)",pagesize,(index-1)*pagesize);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<MedicineUse> list = new List<MedicineUse>();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					MedicineUse mu = new MedicineUse(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						dt.Rows[i][2].ToString(),
						dt.Rows[i][3].ToString(),
						DateTime.Parse(dt.Rows[i][4].ToString()),
						dt.Rows[i][5].ToString(),
						int.Parse(dt.Rows[i][6].ToString()),
						dt.Rows[i][7].ToString()
						);
					list.Add(mu);
				}
				return list;
			}
			else
				return null;
		}

		public int GetCount()
		{
			string sql = "select count(*) from MedicineUse";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			return int.Parse(dt.Rows[0][0].ToString());
		}

		public bool UpdateMedicineUseById(string id,string medicinePerson,string reason,int amount)
		{
			string sql = string.Format("update MedicineUse set " +
				"MedicinePerson = '{0}',Reason = '{1}',MedicineAmount = '{2}' where MedicineUseID = '{3}'",
				 medicinePerson, reason, amount, id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//根据ID删除用药记录
		public bool DeleteMedicineUseById(string id)
		{
			string sql = string.Format("delete from MedicineUse where MedicineUseID = '{0}'",id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		public List<MedicineAndAmount> GetAmountPercentage()
		{
			string sql = string.Format("select sum(medicineamount), MedicineID from MedicineUse group by Medicineid");
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<MedicineAndAmount> list = new List<MedicineAndAmount>();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					MedicineAndAmount maa = new MedicineAndAmount(
						new MedicineDataAccess().GetMedicineById(dt.Rows[i][1].ToString()).MedicineName.Trim(),
						double.Parse(dt.Rows[i][0].ToString())
						);
					list.Add(maa);
				}
				return list;
			}
			else
				return null;
		}
	}
}
