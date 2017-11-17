using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DataAccessLibrary
{
	public class AnimalDataAccess
	{
		//添加一条动物记录
		public bool AddAnimal(string animalType,string farmID,string feedType)
		{
			string uniqueCode = CodeProvider.getCodeForAnimal(farmID).ToUpper();
			DateTime birth = DateTime.Now.ToLocalTime();
			string sql = string.Format("insert into Animal values ('{0}','{1}','{2}','{3}','{4}')",uniqueCode,animalType,birth,farmID,feedType);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, 
				CommandType.Text, sql, 
				new SqlParameter("@AnimalID", uniqueCode),
				new SqlParameter("@AnimalType",animalType),
				new SqlParameter("@AnimalBirth",birth),
				new SqlParameter("@FarmID",farmID),
				new SqlParameter("@FeedType",feedType));
			if(Convert.ToInt32(obj)>0)
			{
				return true;
			}
			else
				return false;
		}

		//查询所有动物
		public List<Animal> getAllAnimals()
		{
			List<Animal> list = new List<Animal>();
			Animal animal = new Animal();
			string sql = string.Format("select * from Animal");
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					animal = new Animal(
					dt.Rows[i][0].ToString(),
					dt.Rows[i][1].ToString().Trim(),
					DateTime.Parse(dt.Rows[i][2].ToString()),
					dt.Rows[i][3].ToString(),
					dt.Rows[i][4].ToString()
					);
					list.Add(animal);
				}
				return list;
			}
			else
			{
				return null;
			}
		}

		//通过动物标识码查找动物
		public Animal getAnimalByUniqueCode(string uniqueCode)
		{
			Animal animal = null;
			string sql = string.Format("select * from Animal where AnimalID = '{0}'",uniqueCode);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				animal = new Animal(
					dt.Rows[0][0].ToString(),
					dt.Rows[0][1].ToString().Trim(),
					DateTime.Parse(dt.Rows[0][2].ToString()),
					dt.Rows[0][3].ToString(),
					dt.Rows[0][4].ToString()
					);
				return animal ;
			}
			else
				return null;
		}

		//删除单条记录
		public bool deleteSingleAnimalByUniqueCode(string uniquecode)
		{
			string sql = string.Format("delete from Animal where AnimalID = '{0}", uniquecode);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
			{
				return true;
			}
			else
				return false;
		}
	}
}
