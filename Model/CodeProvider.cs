using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class CodeProvider
	{
		//为动物生成标识码
		public static string getCodeForAnimal(string farmID)
		{
			byte[] bt = new byte[1];
			bt[0] = (byte)Convert.ToInt32(new Random().Next() % 9 + 97);
			string first = DateTime.Now.Day.ToString();//1
			string filetime = DateTime.Now.ToFileTime().ToString();
			string second = filetime.Substring(filetime.Length-2,2);//2
			string third = farmID.Substring(2, 3);//3
			string fourth = DateTime.Now.Minute.ToString().Substring(0,1);//1
			return string.Format(Encoding.ASCII.GetString(bt).ToString() + (new Random().Next()%8).ToString()+(new Random().Next()%9+ first + second + third + fourth).ToString()).Substring(0,10);
		}

		//为工厂生成标识码
		public static string getCodeForCompany(string position,string name,string type)
		{
			string code = position + name +
				(new Random().Next()%9).ToString()+
				(new Random().Next() % 9).ToString() +
				(new Random().Next() % 9).ToString() +
				(new Random().Next() % 9).ToString() +
				type;
			return code.ToUpper().Substring(0,10);
		}

		//为商品生成标识码
		public static string getCodeForSales(string animalUniqueCode,string marketID)
		{
			//string marketID, string animalUniqueCode, DateTime saleDate,string salePosition,string saleType
			string filetime = DateTime.Now.ToFileTime().ToString();
			string second = filetime.Substring(filetime.Length - 3, 3);
			//2 2 1 3
			string code = animalUniqueCode.Substring(0, 2) + marketID.Substring(0,2)+ (new Random().Next() % 9).ToString() + second + (new Random().Next() % 9).ToString()+ (new Random().Next() % 9).ToString();
			return code.ToUpper();
		}

		//为饲料种类生成标识码
		public static string getCodeForFeedType()
		{
			string filetime = DateTime.Now.ToFileTime().ToString();
			string second = filetime.Substring(filetime.Length - 10, 10);
			return second;
		}

		//为饲料生成标识码
		public static string getCodeForFeed()
		{
			string filetime = DateTime.Now.ToFileTime().ToString();
			string second = filetime.Substring(filetime.Length - 10, 10);
			return second;
		}

		//为药品种类生成标识码
		public static string getCodeForMedicineType()
		{
			string filetime = DateTime.Now.ToFileTime().ToString();
			string second = filetime.Substring(filetime.Length - 10, 10);
			return second;
		}

		//为药品生成标识码
		public static string getCodeForMedicine()
		{
			string filetime = DateTime.Now.ToFileTime().ToString();
			string second = filetime.Substring(filetime.Length - 10, 10);
			return second;
		}

		//为加工工作提供标识码
		public static string getCodeForManuWork(string manuID,string animalID)
		{
			string filetime = DateTime.Now.ToFileTime().ToString();
			string second = filetime.Substring(filetime.Length - 3, 3);
			return second + manuID.Substring(0, 3) + animalID.Substring(0, 4);
		}

		//为屠宰工作提供标识码
		public static string getCodeForButchWork(string butchID,string animalID)
		{
			string filetime = DateTime.Now.ToFileTime().ToString();
			string second = filetime.Substring(filetime.Length - 3, 3);
			return second + butchID.Substring(0, 3) + animalID.Substring(0, 4) ;
		}
	}
}
