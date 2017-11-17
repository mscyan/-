using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	class ButchFactory
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="butchID">屠宰场编号</param>
		/// <param name="butchName">屠宰场名称</param>
		/// <param name="butchPerson">负责人</param>
		/// <param name="butchPosition">屠宰场地点</param>
		/// <param name="butchTel">屠宰场电话</param>
		public ButchFactory(string butchID,string butchName,string butchPerson,string butchPosition,string butchTel)
		{
			this.butchFactoryID = butchID;
			this.butchFactoryName = butchName;
			this.butchPerson = butchPerson;
			this.butchPosition = butchPosition;
			this.butchTel = butchTel;
		}

		private string butchFactoryID;
		/// <summary>
		/// 屠宰场编号
		/// </summary>
		public string ButchFactoryID
		{
			get { return butchFactoryID; }
			set { butchFactoryID = value; }
		}

		private string butchFactoryName;
		/// <summary>
		/// 屠宰场名称
		/// </summary>
		public string ButchFactoryName
		{
			get { return butchFactoryName; }
			set { butchFactoryName = value; }
		}

		private string butchPerson;
		/// <summary>
		/// 负责人
		/// </summary>
		public string ButchPerson
		{
			get { return butchPerson; }
			set { butchPerson = value; }
		}

		private string butchPosition;
		/// <summary>
		/// 屠宰场地点
		/// </summary>
		public string ButchPostion
		{
			get { return butchPosition; }
			set { butchPosition = value; }
		}

		private string butchTel;
		/// <summary>
		/// 屠宰场电话
		/// </summary>
		public string ButchTel
		{
			get { return butchTel; }
			set { butchTel = value; }
		}
	}
}
