using System;
namespace PE2.Model
{
    /// <summary>
    /// Code:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Code
    {
        public Code()
        { }
        #region Model
        private int _code_sn;
        private int _class_sn;
        private string _code_name;
        private string _code_value;
        private string _code_note;
        /// <summary>
        /// 
        /// </summary>
        public int Code_sn
        {
            set { _code_sn = value; }
            get { return _code_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Class_sn
        {
            set { _class_sn = value; }
            get { return _class_sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code_name
        {
            set { _code_name = value; }
            get { return _code_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code_value
        {
            set { _code_value = value; }
            get { return _code_value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code_note
        {
            set { _code_note = value; }
            get { return _code_note; }
        }
        #endregion Model

    }
}

