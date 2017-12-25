using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class ButchWorkInfo
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="butchWorkInfoID">屠宰工作批次编号</param>
		/// <param name="butchFactoryID">屠宰场编号</param>
		/// <param name="butchDate">屠宰日期</param>
		/// <param name="butchInfo">屠宰信息</param>
		/// <param name="animalUniqueCode">牲畜唯一标识码</param>
		/// <param name="animalState">牲畜当前状态信息</param>
		public ButchWorkInfo(string butchWorkInfoID,string butchFactoryID,DateTime butchDate,string butchInfo,string animalUniqueCode,string animalState,string videoSource)
		{
			this.butchWorkInfoID = butchWorkInfoID;
			this.butchFactoryID = butchFactoryID;
			this.butchDate = butchDate;
			this.butchInfo = butchInfo;
			this.animalUniqueCode = animalUniqueCode;
			this.animalState = animalState;
			this.videoSource = videoSource;
		}

		private string butchWorkInfoID;
		/// <summary>
		/// 屠宰工作批次编号
		/// </summary>
		public string ButchWorkInfoID
		{
			get { return butchWorkInfoID; }
			set { butchWorkInfoID = value; }
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

		private DateTime butchDate;
		/// <summary>
		/// 屠宰日期
		/// </summary>
		public DateTime ButchDate
		{
			get { return butchDate; }
			set { butchDate = value; }
		}

		private string butchInfo;
		/// <summary>
		/// 屠宰信息
		/// </summary>
		public string ButchInfo
		{
			get { return butchInfo; }
			set { butchInfo = value; }
		}

		private string animalUniqueCode;
		/// <summary>
		/// 牲畜唯一标识码
		/// </summary>
		public string AnimalUniqueCode
		{
			get { return animalUniqueCode; }
			set { animalUniqueCode = value; }
		}

		private string animalState;
		/// <summary>
		/// 牲畜当前状态信息
		/// </summary>
		public string AnimalState
		{
			get { return animalState; }
			set { animalState = value; }
		}

		private string videoSource;
		public string VideoSource
		{
			get { return videoSource; }
			set { videoSource = value; }
		}
	}
}
