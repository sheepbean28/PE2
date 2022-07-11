using System;
namespace PE2.Model
{
	/// <summary>
	/// InFixture:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class InFixture
	{
		public InFixture()
		{}
		#region Model
		private int _fixture_sn;
		private int _in_sn;
		private int _user_sn;
		private int _out_sn;
		private string _note;
		private DateTime _create_date;
        private DateTime _in_date;
		private int _look;
		private int _clean;
		private int _valid;
		private int? _place_sn;
		/// <summary>
		/// 
		/// </summary>
		public int Fixture_sn
		{
			set{ _fixture_sn=value;}
			get{return _fixture_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int In_sn
		{
			set{ _in_sn=value;}
			get{return _in_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int User_sn
		{
			set{ _user_sn=value;}
			get{return _user_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Out_sn
		{
			set{ _out_sn=value;}
			get{return _out_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Create_date
		{
			set{ _create_date=value;}
			get{return _create_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime In_date
		{
			set{ _in_date=value;}
			get{return _in_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Look
		{
			set{ _look=value;}
			get{return _look;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Clean
		{
			set{ _clean=value;}
			get{return _clean;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Valid
		{
			set{ _valid=value;}
			get{return _valid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Place_sn
		{
			set{ _place_sn=value;}
			get{return _place_sn;}
		}
		#endregion Model

	}
}

