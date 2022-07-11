using System;
using System.Text;
using System.Security.Cryptography;
namespace Maticsoft.Common.DEncrypt
{
	/// <summary>
	/// 腕善呴儂假鎢ㄗ慇洷樓躇ㄘ﹝
	/// </summary>
	public class HashEncode
	{
		public HashEncode()
		{
			//
			// TODO: 婓森揭氝樓凳婖滲杅軀憮
			//
		}
		/// <summary>
		/// 腕善呴儂慇洷樓躇趼睫揹
		/// </summary>
		/// <returns></returns>
		public static string GetSecurity()
		{			
			string Security = HashEncoding(GetRandomValue());		
			return Security;
		}
		/// <summary>
		/// 腕善珨跺呴儂杅硉
		/// </summary>
		/// <returns></returns>
		public static string GetRandomValue()
		{			
			Random Seed = new Random();
			string RandomVaule = Seed.Next(1, int.MaxValue).ToString();
			return RandomVaule;
		}
		/// <summary>
		/// 慇洷樓躇珨跺趼睫揹
		/// </summary>
		/// <param name="Security"></param>
		/// <returns></returns>
		public static string HashEncoding(string Security)
		{						
			byte[] Value;
			UnicodeEncoding Code = new UnicodeEncoding();
			byte[] Message = Code.GetBytes(Security);
			SHA512Managed Arithmetic = new SHA512Managed();
			Value = Arithmetic.ComputeHash(Message);
			Security = "";
			foreach(byte o in Value)
			{
				Security += (int) o + "O";
			}
			return Security;
		}
	}
}
