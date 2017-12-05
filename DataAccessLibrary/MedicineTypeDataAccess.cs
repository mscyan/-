using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DataAccessLibrary
{
	public class MedicineTypeDataAccess
	{
		//添加新的药品种类
		public bool AddMedicine(string medicinetype_name)
		{
			string code = CodeProvider.getCodeForMedicineType();
			string sql = string.Format("insert into MedicineType values ('{0}','{1}')", code, medicinetype_name);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//获得所有药品种类
		public List<MedicineType> GetPaginationMedicineType(int pagesize,int index)
		{
			string sql = string.Format("select top {0} * from MedicineType where MedicineTypeID not in (select top {1} MedicineTypeID from MedicineType)",pagesize,pagesize*(index-1));
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<MedicineType> list = new List<MedicineType>();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					MedicineType mt = new MedicineType(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString());
					list.Add(mt);
				}
				return list;
			}
			else
				return null;
		}

		public List<MedicineType> GetAllMedicineType()
		{
			string sql = string.Format("select * from MedicineType");
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<MedicineType> list = new List<MedicineType>();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					MedicineType mt = new MedicineType(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString());
					list.Add(mt);
				}
				return list;
			}
			else
				return null;
		}

		public int GetCount()
		{
			string sql = "select count(*) from MedicineType";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			return int.Parse(dt.Rows[0][0].ToString());
		}

		//根据id删除药品种类
		public bool DeleteMedicineTypeById(string id)
		{
			string sql = string.Format("delete from MedicineType where MedicineTypeID = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//更新药品种类表
		public bool UpdateMedicineTypeID(string id, string new_name)
		{
			string sql = string.Format("update MedicineType set MedicineTypeName = '{0}' where MedicineTypeID = '{1}'",new_name,id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}
