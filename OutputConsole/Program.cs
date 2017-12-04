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
			//AnimalDataAccess ada = new AnimalDataAccess();

			////Console.WriteLine(ada.getAllAnimals().Count()); 
			////ada.deleteSingleAnimalByUniqueCode("98711434RH");
			////Console.WriteLine(ada.getAllAnimals().Count());

			//Console.WriteLine(nameof(UserDataAccess));
			//ButchWorkDataAccess bwda = new ButchWorkDataAccess();
			////bool isaltersuccess = bwda.UpdateButchWork("950JHBG161","已屠宰完成","已屠宰了了");
			//bool isaltersuccess = bwda.DeleteButchWorkById("950JHBG161");
			//Console.WriteLine(isaltersuccess);

			FeedDataAccess fda = new FeedDataAccess();
			bool aa = fda.UpdateFeedInfoById("2195332514","20");
			Console.WriteLine(aa);

			Console.Read();
		}
	}
}
