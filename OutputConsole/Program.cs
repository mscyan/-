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
			var s = ada.GetPaginationAnimals(5, 1);
			Console.WriteLine(s.Count);
			Console.WriteLine(ada.GetPaginationAnimals(5,2).Count);
			Console.WriteLine(ada.GetPaginationAnimals(5,3).Count);

			foreach (var item in s)
			{
				Console.WriteLine(item.AnimalID);
			}

			Console.Read();
		}
	}
}
