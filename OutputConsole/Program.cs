using DataAccessLibrary;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OutputConsole
{
	class Program
	{
		static void Main(string[] args)
		{

			//Console.WriteLine( new UserDataAccess().IsUserExist("yanchao"));

			//Console.WriteLine(ConfigurationManager.ConnectionStrings["connectionStringss"].ToString());
			//Console.WriteLine(ConfigurationManager.ConnectionStrings[0].Name.ToString());
			//Console.WriteLine(ConfigurationManager.AppSettings["ConnectionString"]);
			Console.WriteLine(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

			Console.WriteLine("abc	");

			//Console.WriteLine(new UserDataAccess().IsUserExist("yanchao"));

			Console.Read();
		}
	}
}
