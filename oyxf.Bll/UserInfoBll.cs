using System;
using System.Data;
using System.Collections.Generic;
using oyxf.Common;
using oyxf.Model;
namespace oyxf.Bll
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public partial class UserInfoBll
    {
        private readonly oyxf.Dal.UserInfoDal dal = new oyxf.Dal.UserInfoDal();
        public UserInfoBll()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserId)
        {
            return dal.Exists(UserId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(oyxf.Model.UserInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(oyxf.Model.UserInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserId)
        {

            return dal.Delete(UserId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string UserIdlist)
        {
            return dal.DeleteList(oyxf.Common.PageValidate.SafeLongFilter(UserIdlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public oyxf.Model.UserInfo GetModel(int UserId)
        {

            return dal.GetModel(UserId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public oyxf.Model.UserInfo GetModelByCache(int UserId)
        {

            string CacheKey = "UserInfoModel-" + UserId;
            object objModel = oyxf.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(UserId);
                    if (objModel != null)
                    {
                        int ModelCache = oyxf.Common.ConfigHelper.GetConfigInt("ModelCache");
                        oyxf.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (oyxf.Model.UserInfo)objModel;
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
        public List<oyxf.Model.UserInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<oyxf.Model.UserInfo> DataTableToList(DataTable dt)
        {
            List<oyxf.Model.UserInfo> modelList = new List<oyxf.Model.UserInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                oyxf.Model.UserInfo model;
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
        #region 根据用户名获取用户
        /// <summary>
        /// 根据用户名获取用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>用户实体</returns>
        public UserInfo GetModel(string username)
        {
            string where = string.Format("Username='{0}'", username);
            DataSet ds = dal.GetList(where);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                return DataTableToList(ds.Tables[0])[0];
            }
        }
        #endregion

        #region 新增或修改
        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddOrUpdate(oyxf.Model.UserInfo model)
        {
            if (model.UserId <= 0)
            {
                //新增
                if (Add(model) > 0)
                {
                    return true;
                }
            }
            else
            {
                //修改
                if (string.IsNullOrWhiteSpace(model.Password))//是否修改密码
                {
                    //不修改密码
                    return dal.Update(model, false);
                }
                else
                {
                    //修改密码
                    return dal.Update(model, true);
                }
            }

            return false;
        }
        #endregion

        #region 用户名是否已存在
        /// <summary>
        /// 用户名是否已存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsExistUsername(oyxf.Model.UserInfo model)
        {
            if (dal.GetUsernameCount(model) > 0)
            {
                return true;
            }

            return false;
        } 
        #endregion

        public UserInfo GetModel(string username,string password)
        {
            return dal.GetModel(username,password);
        }
        #endregion  ExtensionMethod
    }
}

