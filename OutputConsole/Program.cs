using DataAccessLibrary;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			AnimalDataAccess ada = new AnimalDataAccess();
			//ada.AddAnimal("猪", "HBRH7823SC", "糠或者饲料");
			//ada.AddAnimal("牛", "HBRH7823SC", "干草或者饲料");
			//ada.AddAnimal("羊", "HBRH7823SC", "干草或者饲料");

			//List<Animal> list = new List<Animal>();
			//list = ada.getAllAnimals();
			//foreach (var item in list)
			//{
			//	Console.WriteLine(item.UniqueCode + " --- " + item.Birth + " --- " + item.FarmID + " --- " + item.AnimalType + " --- " + item.FeedType);
			//}

			SaleInfoDataAccess sida = new SaleInfoDataAccess();
			//sida.AddSaleInfo("XQDRF124CS", "A101418RH7", null, "天津市西青区", "羊腿");

			List<SaleInfo> list = sida.getAllSaleInfo();
			foreach (var item in list)
			{
				Console.WriteLine(item.SaleID+" - "+item.MarketID + " - " + item.SaleDate + " - " + item.SalePosition + " - " + item.SaleType + " - " + item.AnimalUniqueCode + " - " + item.HasSaled);
			}

			Console.Read();
		}
	}
}
