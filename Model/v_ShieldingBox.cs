using System;
namespace PE2.Model
{
    /// <summary>
    /// v_ShieldingBox:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_ShieldingBox
    {
        public v_ShieldingBox()
        { }
        #region Model
        private int _assets_sn;
        private string _assts_no;
        private string _assts_id;
        private string _assts_name;
        private string _assts_eq_id;
        private string _assts_eq_name;
        private int? _assts_quantity;
        private string _assts_customer;
        private int _place_sn;
        private string _place_assets_sn;
        private string _place_assets_detail_sn;
        private int _lastuser_sn;
        private DateTime? _lastchange_date;
        private string _note;
        private string _sysnote;
        private string _assts_station;
        private int _assts_station_num;
        private int _assts_sttatus;
        private string _place_name;
        private string _floor;
        private int _floor_sn;
        private int _shieldingbox_sn;
        private string _asset_no;
        private DateTime? _cp_date;
        private DateTime? _limit_date;
        private string _sieldingbox_no;
        private string _shieldingbox_class;
        private string _shieldingbox_type;
        private decimal? _cp2g_open;
        private decimal? _cp2g_shileld;
        private decimal? _cp2g_close;
        private decimal? _cp5g_open;
        private decimal? _cp5g_close;
        private decimal? _cp5g_shileld;
        private decimal? _leakage;
        private string _leakage_no;
        private string _expr1;
        /// <summary>
        /// 
        /// </summary>
        public int Assets_sn
        {
            set { _assets_sn = value; }
            get { return _assets_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Assts_no
        {
            set { _assts_no = value; }
            get { return _assts_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Assts_id
        {
            set { _assts_id = value; }
            get { return _assts_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Assts_name
        {
            set { _assts_name = value; }
            get { return _assts_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Assts_eq_id
        {
            set { _assts_eq_id = value; }
            get { return _assts_eq_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Assts_eq_name
        {
            set { _assts_eq_name = value; }
            get { return _assts_eq_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Assts_Quantity
        {
            set { _assts_quantity = value; }
            get { return _assts_quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Assts_Customer
        {
            set { _assts_customer = value; }
            get { return _assts_customer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Place_sn
        {
            set { _place_sn = value; }
            get { return _place_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Place_Assets_sn
        {
            set { _place_assets_sn = value; }
            get { return _place_assets_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Place_Assets_Detail_sn
        {
            set { _place_assets_detail_sn = value; }
            get { return _place_assets_detail_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LastUser_sn
        {
            set { _lastuser_sn = value; }
            get { return _lastuser_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastChange_date
        {
            set { _lastchange_date = value; }
            get { return _lastchange_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Note
        {
            set { _note = value; }
            get { return _note; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SysNote
        {
            set { _sysnote = value; }
            get { return _sysnote; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Assts_Station
        {
            set { _assts_station = value; }
            get { return _assts_station; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Assts_Station_num
        {
            set { _assts_station_num = value; }
            get { return _assts_station_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Assts_Sttatus
        {
            set { _assts_sttatus = value; }
            get { return _assts_sttatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Place_name
        {
            set { _place_name = value; }
            get { return _place_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Floor
        {
            set { _floor = value; }
            get { return _floor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Floor_sn
        {
            set { _floor_sn = value; }
            get { return _floor_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ShieldingBox_sn
        {
            set { _shieldingbox_sn = value; }
            get { return _shieldingbox_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string asset_no
        {
            set { _asset_no = value; }
            get { return _asset_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Cp_date
        {
            set { _cp_date = value; }
            get { return _cp_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Limit_date
        {
            set { _limit_date = value; }
            get { return _limit_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SieldingBox_no
        {
            set { _sieldingbox_no = value; }
            get { return _sieldingbox_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShieldingBox_Class
        {
            set { _shieldingbox_class = value; }
            get { return _shieldingbox_class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShieldingBox_Type
        {
            set { _shieldingbox_type = value; }
            get { return _shieldingbox_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Cp2G_Open
        {
            set { _cp2g_open = value; }
            get { return _cp2g_open; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Cp2G_Shileld
        {
            set { _cp2g_shileld = value; }
            get { return _cp2g_shileld; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Cp2G_Close
        {
            set { _cp2g_close = value; }
            get { return _cp2g_close; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Cp5G_Open
        {
            set { _cp5g_open = value; }
            get { return _cp5g_open; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Cp5G_Close
        {
            set { _cp5g_close = value; }
            get { return _cp5g_close; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Cp5G_Shileld
        {
            set { _cp5g_shileld = value; }
            get { return _cp5g_shileld; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Leakage
        {
            set { _leakage = value; }
            get { return _leakage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Leakage_no
        {
            set { _leakage_no = value; }
            get { return _leakage_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Expr1
        {
            set { _expr1 = value; }
            get { return _expr1; }
        }
        #endregion Model

    }
}

