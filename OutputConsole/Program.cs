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

			var animalList = new AnimalDataAccess().GetPaginationAnimals(15, 1);
			foreach (var item in animalList)
			{
				var animals = new FeedUseDataAccess().GetTopTenFeedUseByAnimalId(item.AnimalID);
				if(animals!=null)
				{
					var amounts = from animal in animals
								  orderby animal.FeedDate
								  select animal.FeedAmount;
					int[] abs = amounts.ToArray<int>();
					for(int i = 0; i < abs.Length; i++)
					{
						Console.Write(abs[i]+" ");
					}
					Console.WriteLine();
				}
			}


			Console.Read();
		}
	}
}
