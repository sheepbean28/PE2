using System;
namespace PE2.Model
{
    /// <summary>
    /// User:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class User
    {
        public User()
        { }
        #region Model
        private int _user_sn;
        private string _user_no;
        private string _user_name;
        private DateTime? _login_date;
        private int _valid;
        private string _password;
        private int? _power;
        private int? _place_sn;
        /// <summary>
        /// 
        /// </summary>
        public int User_sn
        {
            set { _user_sn = value; }
            get { return _user_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string User_no
        {
            set { _user_no = value; }
            get { return _user_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string User_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Login_date
        {
            set { _login_date = value; }
            get { return _login_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Valid
        {
            set { _valid = value; }
            get { return _valid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Power
        {
            set { _power = value; }
            get { return _power; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Place_sn
        {
            set { _place_sn = value; }
            get { return _place_sn; }
        }
        #endregion Model

    }
}

