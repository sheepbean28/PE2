using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace Maticsoft.DBUtility
{
    public enum EffentNextType
    {
        /// <summary>
        /// 勤坻逄曆拸睡荌砒 
        /// </summary>
        None,
        /// <summary>
        /// 絞逄曆斛剕峈"select count(1) from .."跡宒ㄛ彆湔婓寀樟哿硒俴ㄛ祥湔婓隙幗岈昢
        /// </summary>
        WhenHaveContine,
        /// <summary>
        /// 絞逄曆斛剕峈"select count(1) from .."跡宒ㄛ彆祥湔婓寀樟哿硒俴ㄛ湔婓隙幗岈昢
        /// </summary>
        WhenNoHaveContine,
        /// <summary>
        /// 絞逄曆荌砒善腔俴杅斛剕湮衾0ㄛ瘁寀隙幗岈昢
        /// </summary>
        ExcuteEffectRows,
        /// <summary>
        /// 竘楷岈璃-絞逄曆斛剕峈"select count(1) from .."跡宒ㄛ彆祥湔婓寀樟哿硒俴ㄛ湔婓隙幗岈昢
        /// </summary>
        SolicitationEvent
    }   
    public class CommandInfo
    {
        public object ShareObject = null;
        public object OriginalData = null;
        event EventHandler _solicitationEvent;
        public event EventHandler SolicitationEvent
        {
            add
            {
                _solicitationEvent += value;
            }
            remove
            {
                _solicitationEvent -= value;
            }
        }
        public void OnSolicitationEvent()
        {
            if (_solicitationEvent != null)
            {
                _solicitationEvent(this,new EventArgs());
            }
        }
        public string CommandText;
        public System.Data.Common.DbParameter[] Parameters;
        public EffentNextType EffentNextType = EffentNextType.None;
        public CommandInfo()
        {

        }
        public CommandInfo(string sqlText, SqlParameter[] para)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
        }
        public CommandInfo(string sqlText, SqlParameter[] para, EffentNextType type)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
            this.EffentNextType = type;
        }
    }
}
