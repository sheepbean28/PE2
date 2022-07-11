using System;
namespace PE2.Model
{
    /// <summary>
    /// ShieldingBox:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ShieldingBox
    {
        public ShieldingBox()
        { }
        #region Model
        private int _shieldingbox_sn;
        private string _assets_sn;
        private string _asset_no;
        private DateTime? _cp_date;
        private DateTime? _limit_date;
        private string _sieldingbox_no;
        private string _shieldingbox_class;
        private string _shieldingbox_type;
        private decimal? _cp2g_open;
        private decimal? _cp2g_close;
        private decimal? _cp2g_shileld;
        private decimal? _cp5g_open;
        private decimal? _cp5g_close;
        private decimal? _cp5g_shileld;
        private decimal? _leakage;
        private string _leakage_no;
        private string _note;
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
        public string Assets_sn
        {
            set { _assets_sn = value; }
            get { return _assets_sn; }
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
        public decimal? Cp2G_Close
        {
            set { _cp2g_close = value; }
            get { return _cp2g_close; }
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
        public string Note
        {
            set { _note = value; }
            get { return _note; }
        }
        #endregion Model

    }
}

