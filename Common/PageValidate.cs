using System;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Globalization;
namespace Maticsoft.Common
{
	/// <summary>
	/// 珜醱杅擂苺桄濬
    /// Copyright (C) Maticsoft 2004-2012
	/// </summary>
	public class PageValidate
	{
        private static Regex RegPhone = new Regex("^[0-9]+[-]?[0-9]+[-]?[0-9]$");
		private static Regex RegNumber = new Regex("^[0-9]+$");
		private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
		private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
		private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //脹歎衾^[+-]?\d+[.]?\d+$
		private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 荎恅趼譫麼杅趼腔趼睫揹ㄛ睿 [a-zA-Z0-9] 逄楊珨欴 
		private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");

		public PageValidate()
		{
		}


		#region 杅趼趼睫揹潰脤		
        public static bool IsPhone(string inputData)
        {
            Match m = RegPhone.Match(inputData);
            return m.Success;
        }
		/// <summary>
		/// 潰脤Request脤戙趼睫揹腔瑩硉ㄛ岆瘁岆杅趼ㄛ郔湮酗僅癹秶
		/// </summary>
		/// <param name="req">Request</param>
		/// <param name="inputKey">Request腔瑩硉</param>
		/// <param name="maxLen">郔湮酗僅</param>
		/// <returns>殿隙Request脤戙趼睫揹</returns>
		public static string FetchInputDigit(HttpRequest req, string inputKey, int maxLen)
		{
			string retVal = string.Empty;
			if(inputKey != null && inputKey != string.Empty)
			{
				retVal = req.QueryString[inputKey];
				if(null == retVal)
					retVal = req.Form[inputKey];
				if(null != retVal)
				{
					retVal = SqlText(retVal, maxLen);
					if(!IsNumber(retVal))
						retVal = string.Empty;
				}
			}
			if(retVal == null)
				retVal = string.Empty;
			return retVal;
		}		
		/// <summary>
		/// 岆瘁杅趼趼睫揹
		/// </summary>
		/// <param name="inputData">怀趼睫揹</param>
		/// <returns></returns>
		public static bool IsNumber(string inputData)
		{
			Match m = RegNumber.Match(inputData);
			return m.Success;
		}

		/// <summary>
		/// 岆瘁杅趼趼睫揹 褫湍淏蛹瘍
		/// </summary>
		/// <param name="inputData">怀趼睫揹</param>
		/// <returns></returns>
		public static bool IsNumberSign(string inputData)
		{
			Match m = RegNumberSign.Match(inputData);
			return m.Success;
		}		
		/// <summary>
		/// 岆瘁岆腹萸杅
		/// </summary>
		/// <param name="inputData">怀趼睫揹</param>
		/// <returns></returns>
		public static bool IsDecimal(string inputData)
		{
			Match m = RegDecimal.Match(inputData);
			return m.Success;
		}		
		/// <summary>
		/// 岆瘁岆腹萸杅 褫湍淏蛹瘍
		/// </summary>
		/// <param name="inputData">怀趼睫揹</param>
		/// <returns></returns>
		public static bool IsDecimalSign(string inputData)
		{
			Match m = RegDecimalSign.Match(inputData);
			return m.Success;
		}		

		#endregion

		#region 笢恅潰聆

		/// <summary>
		/// 潰聆岆瘁衄笢恅趼睫
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsHasCHZN(string inputData)
		{
			Match m = RegCHZN.Match(inputData);
			return m.Success;
		}	

		#endregion

		#region 蚘璃華硊
		/// <summary>
		/// 岆瘁岆腹萸杅 褫湍淏蛹瘍
		/// </summary>
		/// <param name="inputData">怀趼睫揹</param>
		/// <returns></returns>
		public static bool IsEmail(string inputData)
		{
			Match m = RegEmail.Match(inputData);
			return m.Success;
		}		

		#endregion

        #region 跡宒瓚剿
        /// <summary>
        /// 跡宒趼睫揹瓚剿
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTime(string str)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    DateTime.Parse(str);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        } 
        #endregion

        #region 坻

        /// <summary>
		/// 潰脤趼睫揹郔湮酗僅ㄛ殿隙硌隅酗僅腔揹
		/// </summary>
		/// <param name="sqlInput">怀趼睫揹</param>
		/// <param name="maxLength">郔湮酗僅</param>
		/// <returns></returns>			
		public static string SqlText(string sqlInput, int maxLength)
		{			
			if(sqlInput != null && sqlInput != string.Empty)
			{
				sqlInput = sqlInput.Trim();							
				if(sqlInput.Length > maxLength)//偌郔湮酗僅諍趼睫揹
					sqlInput = sqlInput.Substring(0, maxLength);
			}
			return sqlInput;
		}		
		/// <summary>
		/// 趼睫揹晤鎢
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static string HtmlEncode(string inputData)
		{
			return HttpUtility.HtmlEncode(inputData);
		}
		/// <summary>
		/// 扢离Label珆尨Encode腔趼睫揹
		/// </summary>
		/// <param name="lbl"></param>
		/// <param name="txtInput"></param>
		public static void SetLabel(Label lbl, string txtInput)
		{
			lbl.Text = HtmlEncode(txtInput);
		}
		public static void SetLabel(Label lbl, object inputObj)
		{
			SetLabel(lbl, inputObj.ToString());
		}		
		//趼睫揹燴
		public static string InputText(string inputString, int maxLength) 
		{			
			StringBuilder retVal = new StringBuilder();

			// 潰脤岆瘁峈諾
			if ((inputString != null) && (inputString != String.Empty)) 
			{
				inputString = inputString.Trim();
				
				//潰脤酗僅
				if (inputString.Length > maxLength)
					inputString = inputString.Substring(0, maxLength);
				
				//杸遙峉玸趼睫
				for (int i = 0; i < inputString.Length; i++) 
				{
					switch (inputString[i]) 
					{
						case '"':
							retVal.Append("&quot;");
							break;
						case '<':
							retVal.Append("&lt;");
							break;
						case '>':
							retVal.Append("&gt;");
							break;
						default:
							retVal.Append(inputString[i]);
							break;
					}
				}				
				retVal.Replace("'", " ");// 杸遙等竘瘍
			}
			return retVal.ToString();
			
		}
		/// <summary>
		/// 蛌遙傖 HTML code
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>string</returns>
		public static string Encode(string str)
		{			
			str = str.Replace("&","&amp;");
			str = str.Replace("'","''");
			str = str.Replace("\"","&quot;");
			str = str.Replace(" ","&nbsp;");
			str = str.Replace("<","&lt;");
			str = str.Replace(">","&gt;");
			str = str.Replace("\n","<br>");
			return str;
		}
		/// <summary>
		///賤昴html傖 籵恅掛
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>string</returns>
		public static string Decode(string str)
		{			
			str = str.Replace("<br>","\n");
			str = str.Replace("&gt;",">");
			str = str.Replace("&lt;","<");
			str = str.Replace("&nbsp;"," ");
			str = str.Replace("&quot;","\"");
			return str;
		}

        public static string SqlTextClear(string sqlText)
        {
            if (sqlText == null)
            {
                return null;
            }
            if (sqlText == "")
            {
                return "";
            }
            sqlText = sqlText.Replace(",", "");//壺,
            sqlText = sqlText.Replace("<", "");//壺<
            sqlText = sqlText.Replace(">", "");//壺>
            sqlText = sqlText.Replace("--", "");//壺--
            sqlText = sqlText.Replace("'", "");//壺'
            sqlText = sqlText.Replace("\"", "");//壺"
            sqlText = sqlText.Replace("=", "");//壺=
            sqlText = sqlText.Replace("%", "");//壺%
            sqlText = sqlText.Replace(" ", "");//壺諾跡
            return sqlText;
        }
		#endregion

        #region 岆瘁蚕杻隅趼睫郪傖
        public static bool isContainSameChar(string strInput)
        {
            string charInput = string.Empty;
            if (!string.IsNullOrEmpty(strInput))
            {
                charInput = strInput.Substring(0, 1);
            }
            return isContainSameChar(strInput, charInput, strInput.Length);
        }

        public static bool isContainSameChar(string strInput, string charInput, int lenInput)
        {
            if (string.IsNullOrEmpty(charInput))
            {
                return false;
            }
            else
            {
                Regex RegNumber = new Regex(string.Format("^([{0}])+$", charInput));
                //Regex RegNumber = new Regex(string.Format("^([{0}]{{1}})+$", charInput,lenInput));
                Match m = RegNumber.Match(strInput);
                return m.Success;
            }
        }
        #endregion

        #region 潰脤怀腔統杅岆祥岆議虳隅砱疑腔杻忷趼睫ㄩ涴跺源楊醴蚚衾躇鎢怀腔假潰脤
        /// <summary>
        /// 潰脤怀腔統杅岆祥岆議虳隅砱疑腔杻忷趼睫ㄩ涴跺源楊醴蚚衾躇鎢怀腔假潰脤
        /// </summary>
        public static bool isContainSpecChar(string strInput)
        {
            string[] list = new string[] { "123456", "654321" };
            bool result = new bool();
            for (int i = 0; i < list.Length; i++)
            {
                if (strInput == list[i])
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        #endregion

        public static string SafeLongFilter(string text, long defaultValue, char split = ',')
        {
            if (text.Trim().Length < 1) 
                return defaultValue.ToString(CultureInfo.InvariantCulture);
            string[] tmpSplit = text.Split(new[] { split }, StringSplitOptions.RemoveEmptyEntries);
            if (tmpSplit.Length < 1) 
                return defaultValue.ToString(CultureInfo.InvariantCulture);

            long tmp;
            for (int i = 0; i < tmpSplit.Length; i++)
            {
                if (long.TryParse(tmpSplit[i], out tmp))
                    tmpSplit[i] = tmp.ToString(CultureInfo.InvariantCulture);
                else
                    tmpSplit[i] = defaultValue.ToString(CultureInfo.InvariantCulture);
            }
            return string.Join(split.ToString(CultureInfo.InvariantCulture), tmpSplit);
        }

    }
}
