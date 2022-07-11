using System;
namespace PE2.Model
{
	/// <summary>
	/// Fixture:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Fixture
	{
		public Fixture()
		{}
		#region Model
		private int _fixture_sn;
		private string _fixture_no;
		private string _fixture_car;
		private string _fixture_car1;
		private string _fixture_car2;
		private string _fixture_name;
		private string _fixture_usefor;
		private string _fixture_no_old;
		private string _fixture_lic_old;
		private string _fixture_sn_old;
		private int _status;
		private int _quantity;
		private int? _lastout_sn;
		private DateTime? _lastout_date;
		private DateTime? _create_date;
		private DateTime? _limit_date;
		private string _note;
		private int? _lastin_sn;
		private DateTime? _lastin_date;
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
		public string Fixture_no
		{
			set{ _fixture_no=value;}
			get{return _fixture_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fixture_car
		{
			set{ _fixture_car=value;}
			get{return _fixture_car;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fixture_car1
		{
			set{ _fixture_car1=value;}
			get{return _fixture_car1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fixture_car2
		{
			set{ _fixture_car2=value;}
			get{return _fixture_car2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fixture_name
		{
			set{ _fixture_name=value;}
			get{return _fixture_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fixture_usefor
		{
			set{ _fixture_usefor=value;}
			get{return _fixture_usefor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fixture_no_old
		{
			set{ _fixture_no_old=value;}
			get{return _fixture_no_old;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fixture_lic_old
		{
			set{ _fixture_lic_old=value;}
			get{return _fixture_lic_old;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fixture_sn_old
		{
			set{ _fixture_sn_old=value;}
			get{return _fixture_sn_old;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LastOut_sn
		{
			set{ _lastout_sn=value;}
			get{return _lastout_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastOut_date
		{
			set{ _lastout_date=value;}
			get{return _lastout_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Create_date
		{
			set{ _create_date=value;}
			get{return _create_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Limit_date
		{
			set{ _limit_date=value;}
			get{return _limit_date;}
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
		public int? LastIn_sn
		{
			set{ _lastin_sn=value;}
			get{return _lastin_sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastIn_date
		{
			set{ _lastin_date=value;}
			get{return _lastin_date;}
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

