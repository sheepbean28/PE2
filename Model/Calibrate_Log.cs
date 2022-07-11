using System;
namespace PE2.Model
{
    /// <summary>
    /// Calibrate_Log:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Calibrate_Log
    {
        public Calibrate_Log()
        { }
        #region Model
        private int _calibrate_log_sn;
        private int _calibrate_sn;
        private DateTime? _start_date;
        private DateTime? _end_date;
        private string _note;
        private string _returnnote;
        /// <summary>
        /// 
        /// </summary>
        public int Calibrate_Log_sn
        {
            set { _calibrate_log_sn = value; }
            get { return _calibrate_log_sn; }
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
        public DateTime? Start_Date
        {
            set { _start_date = value; }
            get { return _start_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? End_Date
        {
            set { _end_date = value; }
            get { return _end_date; }
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
        public string ReturnNote
        {
            set { _returnnote = value; }
            get { return _returnnote; }
        }
        #endregion Model

    }
}

