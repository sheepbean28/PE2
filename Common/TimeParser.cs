using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common
{
    public class TimeParser
    {
        /// <summary>
        /// 參鏃蛌遙傖煦笘
        /// </summary>
        /// <returns></returns>
        public static int SecondToMinute(int Second)
        {
            decimal mm = (decimal)((decimal)Second / (decimal)60);
            return Convert.ToInt32(Math.Ceiling(mm));           
        }

        #region 殿隙議爛議堎郔綴珨毞
        /// <summary>
        /// 殿隙議爛議堎郔綴珨毞
        /// </summary>
        /// <param name="year">爛爺</param>
        /// <param name="month">堎爺</param>
        /// <returns></returns>
        public static int GetMonthLastDate(int year, int month)
        {
            DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
            int Day = lastDay.Day;
            return Day;
        }
        #endregion

        #region 殿隙奀潔船
        public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                //TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                //TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                //TimeSpan ts = ts1.Subtract(ts2).Duration();
                TimeSpan ts = DateTime2 - DateTime1;
                if (ts.Days >=1)
                {
                    dateDiff = DateTime1.Month.ToString() + "堎" + DateTime1.Day.ToString() + "";
                }
                else
                {
                    if (ts.Hours > 1)
                    {
                        dateDiff = ts.Hours.ToString() + "苤奀";
                    }
                    else
                    {
                        dateDiff = ts.Minutes.ToString() + "煦笘";
                    }
                }
            }
            catch
            { }
            return dateDiff;
        }
        #endregion
    }
}
