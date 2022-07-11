using System;
namespace PE2.Model
{
    /// <summary>
    /// Assets:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Assets
    {
        public Assets()
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
        #endregion Model

    }
}

