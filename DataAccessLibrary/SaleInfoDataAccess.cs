using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLibrary
{
	public class SaleInfoDataAccess
	{
		//添加一条商品的记录
		public bool AddSaleInfo(string marketID, string animalUniqueCode, string saleDate, string salePosition, string saleType)
		{
			string code = CodeProvider.getCodeForSales();
			string sql = string.Format("insert into Sales values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",code,marketID,null,salePosition,animalUniqueCode,saleType,"尚未售出","无");
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//查询出所有的商品记录
		public List<SaleInfo> getAllSaleInfo()
		{
			List<SaleInfo> list = new List<SaleInfo>();
			string sql = "select * from Sales";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if(dt.Rows.Count>0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					SaleInfo saleinfo = new SaleInfo(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						DateTime.Parse(dt.Rows[i][2].ToString()),
						dt.Rows[i][3].ToString().Trim(),
						dt.Rows[i][4].ToString().Trim(),
						dt.Rows[i][5].ToString().Trim(),
						dt.Rows[i][6].ToString().Trim(),
						dt.Rows[i][7].ToString().Trim());
				list.Add(saleinfo);
				}
				return list;
			}
			else
				return null;
		}

		public int GetCount()
		{
			string sql = "select count(*) from Sales";
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			return int.Parse(dt.Rows[0][0].ToString());
		}

		public List<SaleInfo> GetPaginationSaleInfo(int pagesize,int pageindex)
		{
			List<SaleInfo> list = new List<SaleInfo>();
			string sql = string.Format("select top {0} * from Sales where SaleID not in (select top {1} SaleID from Sales)",pagesize,(pageindex-1)*pagesize);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					SaleInfo saleinfo = new SaleInfo(
						dt.Rows[i][0].ToString(),
						dt.Rows[i][1].ToString(),
						DateTime.Parse(dt.Rows[i][2].ToString()),
						dt.Rows[i][3].ToString().Trim(),
						dt.Rows[i][4].ToString().Trim(),
						dt.Rows[i][5].ToString().Trim(),
						dt.Rows[i][6].ToString().Trim(),
						dt.Rows[i][7].ToString().Trim());
					list.Add(saleinfo);
				}
				return list;
			}
			else
				return null;
		}

		public SaleInfo GetSaleInfoById(string saleID)
		{
			string sql = string.Format("select * from Sales where SaleID = '{0}'",saleID);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				SaleInfo saleinfo = new SaleInfo(
					dt.Rows[0][0].ToString(),
					dt.Rows[0][1].ToString(),
					DateTime.Parse(dt.Rows[0][2].ToString()),
					dt.Rows[0][3].ToString().Trim(),
					dt.Rows[0][4].ToString().Trim(),
					dt.Rows[0][5].ToString().Trim(),
					dt.Rows[0][6].ToString().Trim(),
					dt.Rows[0][7].ToString().Trim());
				return saleinfo;
			}
			else
				return null;
		}

		//修改商品记录的信息
		public bool UpdateSaleInfo(string id,string hasSaled,DateTime saletime)
		{
			string sql = string.Format("update Sales set HasSaled = '{0}',SaleDate = '{1}' where SaleID = '{2}'", hasSaled,saletime, id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//根据id删除指定的售卖记录
		public bool DeleteSaleInfoById(string id)
		{
			string sql = string.Format("delete from Sales where SaleID = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		public bool MarkUnsafeSaleByAnimalId(string id)
		{
			string sql = string.Format("update Sales set SaleState = '出问题' where AnimalID = '{0}'", id);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}
