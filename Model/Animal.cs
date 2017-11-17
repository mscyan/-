using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Animal
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="uniqueCode">唯一标识码</param>
		/// <param name="animalType">牲畜种类</param>
		/// <param name="birth">入栏时间</param>
		/// <param name="farmID">养殖场ID</param>
		/// <param name="feedType">适用饲料种类</param>
		public Animal(string uniqueCode,string animalType,DateTime birth,string farmID,string feedType)
		{
			this.uniqueCode = uniqueCode;
			this.animalType = animalType;
			this.birth = birth;
			this.farmID = farmID;
			this.feedType = feedType;
		}

		public Animal()
		{
		}

		private string uniqueCode;
		/// <summary>
		/// 唯一标识码
		/// </summary>
		public string UniqueCode
		{
			get { return uniqueCode; }
			set { uniqueCode = value; }
		}

		private string animalType;
		/// <summary>
		/// 牲畜种类
		/// </summary>
		public string AnimalType
		{
			get { return animalType; }
			set { animalType = value; }
		}

		private DateTime birth;
		/// <summary>
		/// 入栏时间
		/// </summary>
		public DateTime Birth
		{
			get { return birth; }
			set { birth = value; }
		}

		private string farmID;
		/// <summary>
		/// 养殖场ID
		/// </summary>
		public string FarmID
		{
			get { return farmID; }
			set { farmID = value; }
		}

		private string feedType;
		/// <summary>
		/// 适用饲料种类
		/// </summary>
		public string FeedType
		{
			get { return feedType; }
			set { feedType = value; }
		}

		
	}
}
