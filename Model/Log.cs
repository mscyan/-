using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	/// <summary>
	/// 日志类
	/// </summary>
	public class Log
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="logID">操作批次ID</param>
		/// <param name="logTime">操作时间</param>
		/// <param name="logUser">操作人员</param>
		/// <param name="logAction">操作信息</param>
		/// <param name="logResult">操作结果</param>
		public Log(string logID, DateTime logTime, string logUser, string logAction, string logResult)
		{
			this.logID = logID;
			this.logTime = logTime;
			this.logUser = logUser;
			this.logAction = logAction;
			this.logResult = logResult;
		}

		private string logID;
		/// <summary>
		/// 操作批次ID
		/// </summary>
		public string LogID
		{
			get { return logID; }
			set { logID = value; }
		}

		private DateTime logTime;
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime LogTime
		{
			get { return logTime; }
			set { logTime = value; }
		}

		private string logUser;
		/// <summary>
		/// 操作人员
		/// </summary>
		public string LogUser
		{
			get { return logUser; }
			set { logUser = value; }
		}

		private string logAction;
		/// <summary>
		/// 操作信息
		/// </summary>
		public string LogAction
		{
			get { return logAction; }
			set { logAction = value; }
		}

		private string logResult;
		/// <summary>
		/// 操作结果
		/// </summary>
		public string LogResult
		{
			get { return logResult; }
			set { logResult = value; }
		}
	}
}
