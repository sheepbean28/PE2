using System;
namespace PE2.Model
{
	/// <summary>
	/// Place:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Place
	{
		public Place()
		{}
		#region Model
		private int _place_sn;
		private string _place_name;
		private string _place_id;
		private int _refer_sn;
		private int _class;
		/// <summary>
		/// 
		/// </summary>
		public int Place_sn
		{
			set{ _place_sn=value;}
			get{return _place_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Place_name
		{
			set{ _place_name=value;}
			get{return _place_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Place_id
		{
			set{ _place_id=value;}
			get{return _place_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Refer_sn
		{
			set{ _refer_sn=value;}
			get{return _refer_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Class
		{
			set{ _class=value;}
			get{return _class;}
		}
		#endregion Model

	}
}

