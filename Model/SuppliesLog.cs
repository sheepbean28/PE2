using System;
namespace PE2.Model
{
    /// <summary>
    /// SuppliesLog:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SuppliesLog
    {
        public SuppliesLog()
        { }
        #region Model
        private int _supplieslog_sn;
        private int? _supplies_sn;
        private int? _stockbefore;
        private int _quantity;
        private int _type;
        private string _note;
        private int? _user_sn;
        private DateTime? _supplies_date = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public int SuppliesLog_sn
        {
            set { _supplieslog_sn = value; }
            get { return _supplieslog_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Supplies_sn
        {
            set { _supplies_sn = value; }
            get { return _supplies_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? StockBefore
        {
            set { _stockbefore = value; }
            get { return _stockbefore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
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
        public int? User_sn
        {
            set { _user_sn = value; }
            get { return _user_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Supplies_date
        {
            set { _supplies_date = value; }
            get { return _supplies_date; }
        }
        #endregion Model

    }
}

