using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC食品溯源.DataAnalysis
{
	public class FeedAnalysis
	{
		public static int MaxReduce(int[] arra,int len)
		{
			int MaxSum = 0;
			int TotalSum = 0;
			for(int i = 0; i < len; i++)
			{
				TotalSum += arra[i];
				if (TotalSum <= 0)
				{
					TotalSum = 0;
				}
				else if(MaxSum<TotalSum)
				{
					MaxSum = TotalSum;
				}
			}

			return MaxSum;
		}
	}
}