using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	class ManuFactory:Company
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="manuID">加工厂编号</param>
		/// <param name="manuPerson">负责人</param>
		/// <param name="manuFactoryName">加工厂名称</param>
		/// <param name="manuPosition">加工厂地点</param>
		/// <param name="manuTel">加工厂电话</param>
		public ManuFactory(string manuID,string manuFactoryName, string manuPerson, string manuPosition, string manuTel)
		{
			this.manuFactoryID = manuID;
			this.manuPerson = manuPerson;
			this.manuPosition = manuPosition;
			this.manuFactoryName = manuFactoryName;
			this.manuTel = manuTel;
		}

		private string manuFactoryID;
		/// <summary>
		/// 加工厂编号
		/// </summary>
		public string ManuFactoryID
		{
			get { return manuFactoryID; }
			set { manuFactoryID = value; }
		}

		private string manuFactoryName;
		/// <summary>
		/// 加工厂名称
		/// </summary>
		public string ManuFactoryName
		{
			get { return manuFactoryName; }
			set { manuFactoryName = value; }
		}

		private string manuPerson;
		/// <summary>
		/// 负责人
		/// </summary>
		public string ManuPerson
		{
			get { return manuPerson; }
			set { manuPerson = value; }
		}

		private string manuPosition;
		/// <summary>
		/// 加工厂地点
		/// </summary>
		public string ManuPostion
		{
			get { return manuPosition; }
			set { manuPosition = value; }
		}

		private string manuTel;
		/// <summary>
		/// 加工厂电话
		/// </summary>
		public string ManuTel
		{
			get { return manuTel; }
			set { manuTel = value; }
		}
	}
}
