using System;
namespace PE2.Model
{
    /// <summary>
    /// v_Calibrate:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_Calibrate
    {
        public v_Calibrate()
        { }
        #region Model
        private int? _assets_sn;
        private string _assts_no;
        private string _assts_id;
        private string _assts_name;
        private string _assts_eq_id;
        private string _assts_eq_name;
        private int? _assts_quantity;
        private string _assts_customer;
        private int? _place_sn;
        private string _place_assets_sn;
        private string _place_assets_detail_sn;
        private int? _lastuser_sn;
        private DateTime? _lastchange_date;
        private string _note;
        private string _sysnote;
        private string _assts_station;
        private int? _assts_station_num;
        private int? _assts_sttatus;
        private string _place_name;
        private string _floor;
        private int? _floor_sn;
        private int _calibrate_sn;
        private string _eq_id;
        private string _eq_no;
        private string _eq_name;
        private string _eq_factory;
        private string _eq_factory_no;
        private string _eq_assets_no;
        private string _cp_date_range;
        private DateTime? _last_cp_date;
        private DateTime? _next_cp_date;
        private string _cp_place;
        private string _cp_type;
        private string _cp_note;
        private string _cp_note1;
        private int? _cp_status;
        private int? _last_cp_log_sn;
        /// <summary>
        /// 
        /// </summary>
        public int? Assets_sn
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
        public int? Place_sn
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
        public int? LastUser_sn
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
        public int? Assts_Station_num
        {
            set { _assts_station_num = value; }
            get { return _assts_station_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Assts_Sttatus
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
        public int? Floor_sn
        {
            set { _floor_sn = value; }
            get { return _floor_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Calibrate_sn
        {
            set { _calibrate_sn = value; }
            get { return _calibrate_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Eq_id
        {
            set { _eq_id = value; }
            get { return _eq_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Eq_no
        {
            set { _eq_no = value; }
            get { return _eq_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Eq_name
        {
            set { _eq_name = value; }
            get { return _eq_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Eq_factory
        {
            set { _eq_factory = value; }
            get { return _eq_factory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Eq_factory_no
        {
            set { _eq_factory_no = value; }
            get { return _eq_factory_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Eq_Assets_no
        {
            set { _eq_assets_no = value; }
            get { return _eq_assets_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Cp_Date_Range
        {
            set { _cp_date_range = value; }
            get { return _cp_date_range; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Last_Cp_Date
        {
            set { _last_cp_date = value; }
            get { return _last_cp_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Next_Cp_Date
        {
            set { _next_cp_date = value; }
            get { return _next_cp_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Cp_Place
        {
            set { _cp_place = value; }
            get { return _cp_place; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Cp_Type
        {
            set { _cp_type = value; }
            get { return _cp_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Cp_Note
        {
            set { _cp_note = value; }
            get { return _cp_note; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Cp_Note1
        {
            set { _cp_note1 = value; }
            get { return _cp_note1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Cp_Status
        {
            set { _cp_status = value; }
            get { return _cp_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Last_Cp_Log_sn
        {
            set { _last_cp_log_sn = value; }
            get { return _last_cp_log_sn; }
        }
        #endregion Model

    }
}

