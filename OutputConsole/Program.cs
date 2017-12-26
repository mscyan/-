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
			Console.WriteLine();

			bool sab = new DataAccessLibrary.SaleInfoDataAccess().MarkUnsafeSaleByAnimalId("B312898RH7");
			Console.WriteLine(sab);
			Console.Read();
		}
	}
}
