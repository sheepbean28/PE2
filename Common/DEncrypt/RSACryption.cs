using System; 
using System.Text; 
using System.Security.Cryptography; 
namespace Maticsoft.Common.DEncrypt
{ 
	/// <summary> 
	/// RSA樓躇賤躇摯RSA靡睿桄痐
	/// </summary> 
	public class RSACryption 
	{ 		
		public RSACryption() 
		{ 			
		} 
		

		#region RSA 樓躇賤躇 

		#region RSA 腔躇埥莉汜 
	
		/// <summary>
		/// RSA 腔躇埥莉汜 莉汜佌埥 睿鼠埥 
		/// </summary>
		/// <param name="xmlKeys"></param>
		/// <param name="xmlPublicKey"></param>
		public void RSAKey(out string xmlKeys,out string xmlPublicKey) 
		{ 			
				System.Security.Cryptography.RSACryptoServiceProvider rsa=new RSACryptoServiceProvider(); 
				xmlKeys=rsa.ToXmlString(true); 
				xmlPublicKey = rsa.ToXmlString(false); 			
		} 
		#endregion 

		#region RSA腔樓躇滲杅 
		//############################################################################## 
		//RSA 源宒樓躇 
		//佽隴KEY斛剕岆XML腔俴宒,殿隙腔岆趼睫揹 
		//婓衄珨萸剒猁佽隴ㄐㄐ蜆樓躇源宒衄 酗僅 癹秶腔ㄐㄐ 
		//############################################################################## 

		//RSA腔樓躇滲杅  string
		public string RSAEncrypt(string xmlPublicKey,string m_strEncryptString ) 
		{ 
			
			byte[] PlainTextBArray; 
			byte[] CypherTextBArray; 
			string Result; 
			RSACryptoServiceProvider rsa=new RSACryptoServiceProvider(); 
			rsa.FromXmlString(xmlPublicKey); 
			PlainTextBArray = (new UnicodeEncoding()).GetBytes(m_strEncryptString); 
			CypherTextBArray = rsa.Encrypt(PlainTextBArray, false); 
			Result=Convert.ToBase64String(CypherTextBArray); 
			return Result; 
			
		} 
		//RSA腔樓躇滲杅 byte[]
		public string RSAEncrypt(string xmlPublicKey,byte[] EncryptString ) 
		{ 
			
			byte[] CypherTextBArray; 
			string Result; 
			RSACryptoServiceProvider rsa=new RSACryptoServiceProvider(); 
			rsa.FromXmlString(xmlPublicKey); 
			CypherTextBArray = rsa.Encrypt(EncryptString, false); 
			Result=Convert.ToBase64String(CypherTextBArray); 
			return Result; 
			
		} 
		#endregion 

		#region RSA腔賤躇滲杅 
		//RSA腔賤躇滲杅  string
		public string RSADecrypt(string xmlPrivateKey, string m_strDecryptString ) 
		{			
			byte[] PlainTextBArray; 
			byte[] DypherTextBArray; 
			string Result; 
			System.Security.Cryptography.RSACryptoServiceProvider rsa=new RSACryptoServiceProvider(); 
			rsa.FromXmlString(xmlPrivateKey); 
			PlainTextBArray =Convert.FromBase64String(m_strDecryptString); 
			DypherTextBArray=rsa.Decrypt(PlainTextBArray, false); 
			Result=(new UnicodeEncoding()).GetString(DypherTextBArray); 
			return Result; 
			
		} 

		//RSA腔賤躇滲杅  byte
		public string RSADecrypt(string xmlPrivateKey, byte[] DecryptString ) 
		{			
			byte[] DypherTextBArray; 
			string Result; 
			System.Security.Cryptography.RSACryptoServiceProvider rsa=new RSACryptoServiceProvider(); 
			rsa.FromXmlString(xmlPrivateKey); 
			DypherTextBArray=rsa.Decrypt(DecryptString, false); 
			Result=(new UnicodeEncoding()).GetString(DypherTextBArray); 
			return Result; 
			
		} 
		#endregion 

		#endregion 

		#region RSA杅趼靡 

		#region 鳳Hash鏡扴桶 
		//鳳Hash鏡扴桶 
		public bool GetHash(string m_strSource, ref byte[] HashData) 
		{ 			
			//植趼睫揹笢腕Hash鏡扴 
			byte[] Buffer; 
			System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5"); 
			Buffer = System.Text.Encoding.GetEncoding("GB2312").GetBytes(m_strSource); 
			HashData = MD5.ComputeHash(Buffer); 

			return true; 			
		} 

		//鳳Hash鏡扴桶 
		public bool GetHash(string m_strSource, ref string strHashData) 
		{ 
			
			//植趼睫揹笢腕Hash鏡扴 
			byte[] Buffer; 
			byte[] HashData; 
			System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5"); 
			Buffer = System.Text.Encoding.GetEncoding("GB2312").GetBytes(m_strSource); 
			HashData = MD5.ComputeHash(Buffer); 

			strHashData = Convert.ToBase64String(HashData); 
			return true; 
			
		} 

		//鳳Hash鏡扴桶 
		public bool GetHash(System.IO.FileStream objFile, ref byte[] HashData) 
		{ 
			
			//植恅璃笢腕Hash鏡扴 
			System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5"); 
			HashData = MD5.ComputeHash(objFile); 
			objFile.Close(); 

			return true; 
			
		} 

		//鳳Hash鏡扴桶 
		public bool GetHash(System.IO.FileStream objFile, ref string strHashData) 
		{ 
			
			//植恅璃笢腕Hash鏡扴 
			byte[] HashData; 
			System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5"); 
			HashData = MD5.ComputeHash(objFile); 
			objFile.Close(); 

			strHashData = Convert.ToBase64String(HashData); 

			return true; 
			
		} 
		#endregion 

		#region RSA靡 
		//RSA靡 
		public bool SignatureFormatter(string p_strKeyPrivate, byte[] HashbyteSignature, ref byte[] EncryptedSignatureData) 
		{ 
			
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPrivate); 
				System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA); 
				//扢离靡腔呾楊峈MD5 
				RSAFormatter.SetHashAlgorithm("MD5"); 
				//硒俴靡 
				EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature); 

				return true; 
			
		} 

		//RSA靡 
		public bool SignatureFormatter(string p_strKeyPrivate, byte[] HashbyteSignature, ref string m_strEncryptedSignatureData) 
		{ 
			
				byte[] EncryptedSignatureData; 

				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPrivate); 
				System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA); 
				//扢离靡腔呾楊峈MD5 
				RSAFormatter.SetHashAlgorithm("MD5"); 
				//硒俴靡 
				EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature); 

				m_strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData); 

				return true; 
			
		} 

		//RSA靡 
		public bool SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature, ref byte[] EncryptedSignatureData) 
		{ 
			
				byte[] HashbyteSignature; 

				HashbyteSignature = Convert.FromBase64String(m_strHashbyteSignature); 
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPrivate); 
				System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA); 
				//扢离靡腔呾楊峈MD5 
				RSAFormatter.SetHashAlgorithm("MD5"); 
				//硒俴靡 
				EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature); 

				return true; 
			
		} 

		//RSA靡 
		public bool SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature, ref string m_strEncryptedSignatureData) 
		{ 
			
				byte[] HashbyteSignature; 
				byte[] EncryptedSignatureData; 

				HashbyteSignature = Convert.FromBase64String(m_strHashbyteSignature); 
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPrivate); 
				System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA); 
				//扢离靡腔呾楊峈MD5 
				RSAFormatter.SetHashAlgorithm("MD5"); 
				//硒俴靡 
				EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature); 

				m_strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData); 

				return true; 
			
		} 
		#endregion 

		#region RSA 靡桄痐 

		public bool SignatureDeformatter(string p_strKeyPublic, byte[] HashbyteDeformatter, byte[] DeformatterData) 
		{ 
			
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPublic); 
				System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA); 
				//硌隅賤躇腔奀緊HASH呾楊峈MD5 
				RSADeformatter.SetHashAlgorithm("MD5"); 

				if(RSADeformatter.VerifySignature(HashbyteDeformatter,DeformatterData)) 
				{ 
					return true; 
				} 
				else 
				{ 
					return false; 
				} 
			
		} 

		public bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter, byte[] DeformatterData) 
		{ 
			
				byte[] HashbyteDeformatter; 

				HashbyteDeformatter = Convert.FromBase64String(p_strHashbyteDeformatter); 

				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPublic); 
				System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA); 
				//硌隅賤躇腔奀緊HASH呾楊峈MD5 
				RSADeformatter.SetHashAlgorithm("MD5"); 

				if(RSADeformatter.VerifySignature(HashbyteDeformatter,DeformatterData)) 
				{ 
					return true; 
				} 
				else 
				{ 
					return false; 
				} 
			
		} 

		public bool SignatureDeformatter(string p_strKeyPublic, byte[] HashbyteDeformatter, string p_strDeformatterData) 
		{ 
			
				byte[] DeformatterData; 

				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPublic); 
				System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA); 
				//硌隅賤躇腔奀緊HASH呾楊峈MD5 
				RSADeformatter.SetHashAlgorithm("MD5"); 

				DeformatterData =Convert.FromBase64String(p_strDeformatterData); 

				if(RSADeformatter.VerifySignature(HashbyteDeformatter,DeformatterData)) 
				{ 
					return true; 
				} 
				else 
				{ 
					return false; 
				} 
			
		} 

		public bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter, string p_strDeformatterData) 
		{ 
			
				byte[] DeformatterData; 
				byte[] HashbyteDeformatter; 

				HashbyteDeformatter = Convert.FromBase64String(p_strHashbyteDeformatter); 
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPublic); 
				System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA); 
				//硌隅賤躇腔奀緊HASH呾楊峈MD5 
				RSADeformatter.SetHashAlgorithm("MD5"); 

				DeformatterData =Convert.FromBase64String(p_strDeformatterData); 

				if(RSADeformatter.VerifySignature(HashbyteDeformatter,DeformatterData)) 
				{ 
					return true; 
				} 
				else 
				{ 
					return false; 
				} 
			
		} 


		#endregion 


		#endregion 

	} 
} 
