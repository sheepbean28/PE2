using System;
namespace PE2.Model
{
    /// <summary>
    /// Calibrate:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Calibrate
    {
        public Calibrate()
        { }
        #region Model
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
        private int? _assets_sn;
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
        /// <summary>
        /// 
        /// </summary>
        public int? Assets_sn
        {
            set { _assets_sn = value; }
            get { return _assets_sn; }
        }
        #endregion Model

    }
}

