using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class HealthCheck
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="checkID">检疫单号</param>
		/// <param name="checkDate">检疫日期</param>
		/// <param name="checkPosition">检疫地点</param>
		/// <param name="checkPerson">检疫人员</param>
		/// <param name="checkResult">检疫结果</param>
		/// <param name="animalUniqueCode">牲畜唯一标识码</param>
		/// <param name="animalState">检疫状态</param>
		public HealthCheck(string checkID,DateTime checkDate,string checkPosition,string checkPerson,string checkResult,string animalUniqueCode,string animalState)
		{
			this.checkID = checkID;
			this.checkDate = checkDate;
			this.checkPosition = checkPosition;
			this.checkPerson = checkPerson;
			this.checkResult = checkResult;
			this.animalUniqueCode = animalUniqueCode;
			this.animalState = animalState;
		}

		private string checkID;
		private DateTime checkDate;
		private string checkPosition;
		private string checkPerson;
		private string checkResult;
		private string animalUniqueCode;
		private string animalState;

		/// <summary>
		/// 检疫单号
		/// </summary>
		public string CheckID
		{
			get { return checkID; }
			set { checkID = value; }
		}

		/// <summary>
		/// 检疫日期
		/// </summary>
		public DateTime CheckDate
		{
			get { return checkDate; }
			set { checkDate = value; }
		}

		/// <summary>
		/// 检疫地点
		/// </summary>
		public string CheckPosition
		{
			get { return checkPosition; }
			set { checkPosition = value; }
		}

		/// <summary>
		/// 检疫人员
		/// </summary>
		public string CheckPerson
		{
			get { return checkPerson; }
			set { checkPerson = value; }
		}

		/// <summary>
		/// 检疫结果
		/// </summary>
		public string CheckResult
		{
			get { return checkResult; }
			set { checkResult = value; }
		}

		/// <summary>
		/// 牲畜唯一标识码
		/// </summary>
		public string AnimalUniqueCode
		{
			get { return animalUniqueCode; }
			set { animalUniqueCode = value; }
		}

		/// <summary>
		/// 检疫状态
		/// </summary>
		public string AnimalState
		{
			get { return animalState; }
			set { animalState = value; }
		}
	}
}
