using System;
using System.Security.Cryptography;  
using System.Text;
namespace Maticsoft.Common.DEncrypt
{
	/// <summary>
	/// Encrypt 腔晡猁佽隴﹝
    /// Copyright (C) Maticsoft
	/// </summary>
	public class DEncrypt
	{
		/// <summary>
		/// 凳婖源楊
		/// </summary>
		public DEncrypt()  
		{  
		} 

		#region 妏蚚 吽躇埥趼睫揹 樓躇/賤躇string

		/// <summary>
		/// 妏蚚吽躇埥趼睫揹樓躇string
		/// </summary>
		/// <param name="original">隴恅</param>
		/// <returns>躇恅</returns>
		public static string Encrypt(string original)
		{
			return Encrypt(original,"MATICSOFT");
		}
		/// <summary>
		/// 妏蚚吽躇埥趼睫揹賤躇string
		/// </summary>
		/// <param name="original">躇恅</param>
		/// <returns>隴恅</returns>
		public static string Decrypt(string original)
		{
			return Decrypt(original,"MATICSOFT",System.Text.Encoding.Default);
		}

		#endregion

		#region 妏蚚 跤隅躇埥趼睫揹 樓躇/賤躇string
		/// <summary>
		/// 妏蚚跤隅躇埥趼睫揹樓躇string
		/// </summary>
		/// <param name="original">埻宎恅趼</param>
		/// <param name="key">躇埥</param>
		/// <param name="encoding">趼睫晤鎢源偶</param>
		/// <returns>躇恅</returns>
		public static string Encrypt(string original, string key)  
		{  
			byte[] buff = System.Text.Encoding.Default.GetBytes(original);  
			byte[] kb = System.Text.Encoding.Default.GetBytes(key);
			return Convert.ToBase64String(Encrypt(buff,kb));      
		}
		/// <summary>
		/// 妏蚚跤隅躇埥趼睫揹賤躇string
		/// </summary>
		/// <param name="original">躇恅</param>
		/// <param name="key">躇埥</param>
		/// <returns>隴恅</returns>
		public static string Decrypt(string original, string key)
		{
			return Decrypt(original,key,System.Text.Encoding.Default);
		}

		/// <summary>
		/// 妏蚚跤隅躇埥趼睫揹賤躇string,殿隙硌隅晤鎢源宒隴恅
		/// </summary>
		/// <param name="encrypted">躇恅</param>
		/// <param name="key">躇埥</param>
		/// <param name="encoding">趼睫晤鎢源偶</param>
		/// <returns>隴恅</returns>
		public static string Decrypt(string encrypted, string key,Encoding encoding)  
		{       
			byte[] buff = Convert.FromBase64String(encrypted);  
			byte[] kb = System.Text.Encoding.Default.GetBytes(key);
			return encoding.GetString(Decrypt(buff,kb));      
		}  
		#endregion

		#region 妏蚚 吽躇埥趼睫揹 樓躇/賤躇/byte[]
		/// <summary>
		/// 妏蚚吽躇埥趼睫揹賤躇byte[]
		/// </summary>
		/// <param name="encrypted">躇恅</param>
		/// <param name="key">躇埥</param>
		/// <returns>隴恅</returns>
		public static byte[] Decrypt(byte[] encrypted)  
		{  
			byte[] key = System.Text.Encoding.Default.GetBytes("MATICSOFT"); 
			return Decrypt(encrypted,key);     
		}
		/// <summary>
		/// 妏蚚吽躇埥趼睫揹樓躇
		/// </summary>
		/// <param name="original">埻宎杅擂</param>
		/// <param name="key">躇埥</param>
		/// <returns>躇恅</returns>
		public static byte[] Encrypt(byte[] original)  
		{  
			byte[] key = System.Text.Encoding.Default.GetBytes("MATICSOFT"); 
			return Encrypt(original,key);     
		}  
		#endregion

		#region  妏蚚 跤隅躇埥 樓躇/賤躇/byte[]

		/// <summary>
		/// 汜傖MD5晡猁
		/// </summary>
		/// <param name="original">杅擂埭</param>
		/// <returns>晡猁</returns>
		public static byte[] MakeMD5(byte[] original)
		{
			MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();   
			byte[] keyhash = hashmd5.ComputeHash(original);       
			hashmd5 = null;  
			return keyhash;
		}


		/// <summary>
		/// 妏蚚跤隅躇埥樓躇
		/// </summary>
		/// <param name="original">隴恅</param>
		/// <param name="key">躇埥</param>
		/// <returns>躇恅</returns>
		public static byte[] Encrypt(byte[] original, byte[] key)  
		{  
			TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();       
			des.Key =  MakeMD5(key);
			des.Mode = CipherMode.ECB;  
     
			return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);     
		}  

		/// <summary>
		/// 妏蚚跤隅躇埥賤躇杅擂
		/// </summary>
		/// <param name="encrypted">躇恅</param>
		/// <param name="key">躇埥</param>
		/// <returns>隴恅</returns>
		public static byte[] Decrypt(byte[] encrypted, byte[] key)  
		{  
			TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();  
			des.Key =  MakeMD5(key);    
			des.Mode = CipherMode.ECB;  

			return des.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
		}  
  
		#endregion

		

		
	}
}
