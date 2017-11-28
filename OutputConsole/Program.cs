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

			Console.WriteLine(ada.getAllAnimals().Count()); 
			ada.deleteSingleAnimalByUniqueCode("98711434RH");
			Console.WriteLine(ada.getAllAnimals().Count());

			Console.Read();
		}
	}
}
