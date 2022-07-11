using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PE2.Model;
namespace PE2.BLL
{
    /// <summary>
    /// v_Calibrate
    /// </summary>
    public partial class v_Calibrate
    {
        private readonly PE2.DAL.v_Calibrate dal = new PE2.DAL.v_Calibrate();
        public v_Calibrate()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Assets_sn, string Assts_no, string Assts_id, string Assts_name, string Assts_eq_id, string Assts_eq_name, int Assts_Quantity, string Assts_Customer, int Place_sn, string Place_Assets_sn, string Place_Assets_Detail_sn, int LastUser_sn, DateTime LastChange_date, string Note, string SysNote, string Assts_Station, int Assts_Station_num, int Assts_Sttatus, string Place_name, string Floor, int Floor_sn, int Calibrate_sn, string Eq_id, string Eq_no, string Eq_name, string Eq_factory, string Eq_factory_no, string Eq_Assets_no, string Cp_Date_Range, DateTime Last_Cp_Date, DateTime Next_Cp_Date, string Cp_Place, string Cp_Type, string Cp_Note, string Cp_Note1, int Cp_Status, int Last_Cp_Log_sn)
        {
            return dal.Exists(Assets_sn, Assts_no, Assts_id, Assts_name, Assts_eq_id, Assts_eq_name, Assts_Quantity, Assts_Customer, Place_sn, Place_Assets_sn, Place_Assets_Detail_sn, LastUser_sn, LastChange_date, Note, SysNote, Assts_Station, Assts_Station_num, Assts_Sttatus, Place_name, Floor, Floor_sn, Calibrate_sn, Eq_id, Eq_no, Eq_name, Eq_factory, Eq_factory_no, Eq_Assets_no, Cp_Date_Range, Last_Cp_Date, Next_Cp_Date, Cp_Place, Cp_Type, Cp_Note, Cp_Note1, Cp_Status, Last_Cp_Log_sn);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PE2.Model.v_Calibrate model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PE2.Model.v_Calibrate model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Assets_sn, string Assts_no, string Assts_id, string Assts_name, string Assts_eq_id, string Assts_eq_name, int Assts_Quantity, string Assts_Customer, int Place_sn, string Place_Assets_sn, string Place_Assets_Detail_sn, int LastUser_sn, DateTime LastChange_date, string Note, string SysNote, string Assts_Station, int Assts_Station_num, int Assts_Sttatus, string Place_name, string Floor, int Floor_sn, int Calibrate_sn, string Eq_id, string Eq_no, string Eq_name, string Eq_factory, string Eq_factory_no, string Eq_Assets_no, string Cp_Date_Range, DateTime Last_Cp_Date, DateTime Next_Cp_Date, string Cp_Place, string Cp_Type, string Cp_Note, string Cp_Note1, int Cp_Status, int Last_Cp_Log_sn)
        {

            return dal.Delete(Assets_sn, Assts_no, Assts_id, Assts_name, Assts_eq_id, Assts_eq_name, Assts_Quantity, Assts_Customer, Place_sn, Place_Assets_sn, Place_Assets_Detail_sn, LastUser_sn, LastChange_date, Note, SysNote, Assts_Station, Assts_Station_num, Assts_Sttatus, Place_name, Floor, Floor_sn, Calibrate_sn, Eq_id, Eq_no, Eq_name, Eq_factory, Eq_factory_no, Eq_Assets_no, Cp_Date_Range, Last_Cp_Date, Next_Cp_Date, Cp_Place, Cp_Type, Cp_Note, Cp_Note1, Cp_Status, Last_Cp_Log_sn);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PE2.Model.v_Calibrate GetModel(int Assets_sn, string Assts_no, string Assts_id, string Assts_name, string Assts_eq_id, string Assts_eq_name, int Assts_Quantity, string Assts_Customer, int Place_sn, string Place_Assets_sn, string Place_Assets_Detail_sn, int LastUser_sn, DateTime LastChange_date, string Note, string SysNote, string Assts_Station, int Assts_Station_num, int Assts_Sttatus, string Place_name, string Floor, int Floor_sn, int Calibrate_sn, string Eq_id, string Eq_no, string Eq_name, string Eq_factory, string Eq_factory_no, string Eq_Assets_no, string Cp_Date_Range, DateTime Last_Cp_Date, DateTime Next_Cp_Date, string Cp_Place, string Cp_Type, string Cp_Note, string Cp_Note1, int Cp_Status, int Last_Cp_Log_sn)
        {

            return dal.GetModel(Assets_sn, Assts_no, Assts_id, Assts_name, Assts_eq_id, Assts_eq_name, Assts_Quantity, Assts_Customer, Place_sn, Place_Assets_sn, Place_Assets_Detail_sn, LastUser_sn, LastChange_date, Note, SysNote, Assts_Station, Assts_Station_num, Assts_Sttatus, Place_name, Floor, Floor_sn, Calibrate_sn, Eq_id, Eq_no, Eq_name, Eq_factory, Eq_factory_no, Eq_Assets_no, Cp_Date_Range, Last_Cp_Date, Next_Cp_Date, Cp_Place, Cp_Type, Cp_Note, Cp_Note1, Cp_Status, Last_Cp_Log_sn);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public PE2.Model.v_Calibrate GetModelByCache(int Assets_sn, string Assts_no, string Assts_id, string Assts_name, string Assts_eq_id, string Assts_eq_name, int Assts_Quantity, string Assts_Customer, int Place_sn, string Place_Assets_sn, string Place_Assets_Detail_sn, int LastUser_sn, DateTime LastChange_date, string Note, string SysNote, string Assts_Station, int Assts_Station_num, int Assts_Sttatus, string Place_name, string Floor, int Floor_sn, int Calibrate_sn, string Eq_id, string Eq_no, string Eq_name, string Eq_factory, string Eq_factory_no, string Eq_Assets_no, string Cp_Date_Range, DateTime Last_Cp_Date, DateTime Next_Cp_Date, string Cp_Place, string Cp_Type, string Cp_Note, string Cp_Note1, int Cp_Status, int Last_Cp_Log_sn)
        {

            string CacheKey = "v_CalibrateModel-" + Assets_sn + Assts_no + Assts_id + Assts_name + Assts_eq_id + Assts_eq_name + Assts_Quantity + Assts_Customer + Place_sn + Place_Assets_sn + Place_Assets_Detail_sn + LastUser_sn + LastChange_date + Note + SysNote + Assts_Station + Assts_Station_num + Assts_Sttatus + Place_name + Floor + Floor_sn + Calibrate_sn + Eq_id + Eq_no + Eq_name + Eq_factory + Eq_factory_no + Eq_Assets_no + Cp_Date_Range + Last_Cp_Date + Next_Cp_Date + Cp_Place + Cp_Type + Cp_Note + Cp_Note1 + Cp_Status + Last_Cp_Log_sn;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Assets_sn, Assts_no, Assts_id, Assts_name, Assts_eq_id, Assts_eq_name, Assts_Quantity, Assts_Customer, Place_sn, Place_Assets_sn, Place_Assets_Detail_sn, LastUser_sn, LastChange_date, Note, SysNote, Assts_Station, Assts_Station_num, Assts_Sttatus, Place_name, Floor, Floor_sn, Calibrate_sn, Eq_id, Eq_no, Eq_name, Eq_factory, Eq_factory_no, Eq_Assets_no, Cp_Date_Range, Last_Cp_Date, Next_Cp_Date, Cp_Place, Cp_Type, Cp_Note, Cp_Note1, Cp_Status, Last_Cp_Log_sn);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (PE2.Model.v_Calibrate)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PE2.Model.v_Calibrate> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PE2.Model.v_Calibrate> DataTableToList(DataTable dt)
        {
            List<PE2.Model.v_Calibrate> modelList = new List<PE2.Model.v_Calibrate>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PE2.Model.v_Calibrate model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

