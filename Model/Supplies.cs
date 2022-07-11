using System;
namespace PE2.Model
{
    /// <summary>
    /// Supplies:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Supplies
    {
        public Supplies()
        { }
        #region Model
        private int _supplies_sn;
        private string _supplies_no;
        private string _supplies_class;
        private string _supplies_c_no;
        private string _supplies_name;
        private int? _supplies_price;
        private int? _supplies_add;
        private int? _supplies_in;
        private int? _supplies_out;
        private int? _supplies_r_in;
        private int? _supplies_r_out;
        private int? _supplies_limit;
        private int? _supplies_warm;
        private int? _supplies_stock;
        private string _supplies_file;
        private string _note;
        private int? _user_sn;
        private DateTime? _input_date;
        private int? _valid = 1;
        private int? _place_code_sn;
        /// <summary>
        /// 
        /// </summary>
        public int Supplies_sn
        {
            set { _supplies_sn = value; }
            get { return _supplies_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Supplies_no
        {
            set { _supplies_no = value; }
            get { return _supplies_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Supplies_Class
        {
            set { _supplies_class = value; }
            get { return _supplies_class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Supplies_C_No
        {
            set { _supplies_c_no = value; }
            get { return _supplies_c_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Supplies_Name
        {
            set { _supplies_name = value; }
            get { return _supplies_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Supplies_Price
        {
            set { _supplies_price = value; }
            get { return _supplies_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Supplies_Add
        {
            set { _supplies_add = value; }
            get { return _supplies_add; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Supplies_In
        {
            set { _supplies_in = value; }
            get { return _supplies_in; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Supplies_Out
        {
            set { _supplies_out = value; }
            get { return _supplies_out; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Supplies_R_IN
        {
            set { _supplies_r_in = value; }
            get { return _supplies_r_in; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Supplies_R_OUT
        {
            set { _supplies_r_out = value; }
            get { return _supplies_r_out; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Supplies_Limit
        {
            set { _supplies_limit = value; }
            get { return _supplies_limit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Supplies_Warm
        {
            set { _supplies_warm = value; }
            get { return _supplies_warm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Supplies_Stock
        {
            set { _supplies_stock = value; }
            get { return _supplies_stock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Supplies_File
        {
            set { _supplies_file = value; }
            get { return _supplies_file; }
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
        public DateTime? Input_date
        {
            set { _input_date = value; }
            get { return _input_date; }
        }
        /// <summary>
        /// 
        /// </summary>
      
        /// <summary>
        /// 
        /// </summary>
        public int? Place_code_sn
        {
            set { _place_code_sn = value; }
            get { return _place_code_sn; }
        }
        #endregion Model

    }
}

