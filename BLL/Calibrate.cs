using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PE2.Model;
namespace PE2.BLL
{
    /// <summary>
    /// Calibrate
    /// </summary>
    public partial class Calibrate
    {
        private readonly PE2.DAL.Calibrate dal = new PE2.DAL.Calibrate();
        public Calibrate()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Calibrate_sn)
        {
            return dal.Exists(Calibrate_sn);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PE2.Model.Calibrate model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PE2.Model.Calibrate model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Calibrate_sn)
        {

            return dal.Delete(Calibrate_sn);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Calibrate_snlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(Calibrate_snlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PE2.Model.Calibrate GetModel(int Calibrate_sn)
        {

            return dal.GetModel(Calibrate_sn);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public PE2.Model.Calibrate GetModelByCache(int Calibrate_sn)
        {

            string CacheKey = "CalibrateModel-" + Calibrate_sn;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Calibrate_sn);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (PE2.Model.Calibrate)objModel;
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
        public List<PE2.Model.Calibrate> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PE2.Model.Calibrate> DataTableToList(DataTable dt)
        {
            List<PE2.Model.Calibrate> modelList = new List<PE2.Model.Calibrate>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PE2.Model.Calibrate model;
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

