using System;
using System.Data;
using System.Collections.Generic;
using oyxf.Common;
using oyxf.Model;
using System.Linq;
namespace oyxf.Bll
{
    /// <summary>
    /// 分类
    /// </summary>
    public partial class CategoryBll
    {
        private readonly oyxf.Dal.CategoryDal dal = new oyxf.Dal.CategoryDal();
        public CategoryBll()
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
        public bool Exists(int CategoryId)
        {
            return dal.Exists(CategoryId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(oyxf.Model.Category model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(oyxf.Model.Category model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int CategoryId)
        {

            return dal.Delete(CategoryId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CategoryIdlist)
        {
            return dal.DeleteList(oyxf.Common.PageValidate.SafeLongFilter(CategoryIdlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public oyxf.Model.Category GetModel(int CategoryId)
        {

            return dal.GetModel(CategoryId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public oyxf.Model.Category GetModelByCache(int CategoryId)
        {

            string CacheKey = "CategoryModel-" + CategoryId;
            object objModel = oyxf.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(CategoryId);
                    if (objModel != null)
                    {
                        int ModelCache = oyxf.Common.ConfigHelper.GetConfigInt("ModelCache");
                        oyxf.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (oyxf.Model.Category)objModel;
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
        public List<oyxf.Model.Category> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<oyxf.Model.Category> DataTableToList(DataTable dt)
        {
            List<oyxf.Model.Category> modelList = new List<oyxf.Model.Category>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                oyxf.Model.Category model;
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

        #region 获取分页数据
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <param name="recordCount"></param>
        /// <param name="where"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<oyxf.Model.Category> GetPage(int pageIndex, int pageSize, string orderBy, out int recordCount, string where = "", string fields = "*")
        {
            DataSet ds = dal.GetPage("Category", pageIndex, pageSize, orderBy, out recordCount, where, fields);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)//非空判断
            {
                return null;
            }
            List<oyxf.Model.Category> list = DataTableToList(ds.Tables[0]); //获取当前页数据
            List<int> listParentId = list.Select(o => o.ParentId).ToList(); //拿到当前页父级Id集合

            string ids = string.Join(",", listParentId.ToArray()); //拼接父级Id
            List<oyxf.Model.Category> listParentCategory = GetModelList("CategoryId in(" + ids + ")"); //获取父级Category数据

            for (int i = 0; i < list.Count; i++) //将当前页数据扩展的ParentCategoryName赋值为对应的Name
            {
                if (list[i].ParentId == 0)
                {
                    list[i].ParentCategoryName = "顶级分类";
                    continue;
                }
                oyxf.Model.Category parentCategory = listParentCategory.SingleOrDefault(o => o.CategoryId == list[i].ParentId);
                list[i].ParentCategoryName = parentCategory != null ? parentCategory.Name : "";
            }
            return list;
        }
        #endregion

        #region 删除分类项
        /// <summary>
        /// 删除分类项
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        public bool DeleteCategory(int CategoryId)
        {
            oyxf.Model.Category model = GetModel(CategoryId);//当前要删除的分类

            if (dal.DeleteCategory(CategoryId) > 0)
            {
                //删除之后，要判断原父节点是否还有子节点                
                string where = "ParentId=" + model.ParentId;
                if (dal.GetRecordCount(where) <= 0)//原父节点没有子节点 
                {
                    //修改原父节点的HasChildren
                    UpdateHasChildren(model.ParentId, false);
                }
                else
                {
                    UpdateHasChildren(model.ParentId, true);
                }

                return true;
            }

            return false;
        }
        #endregion

        #region 根据分类ID更新HasChildren
        /// <summary>
        /// 根据分类ID更新HasChildren
        /// </summary>
        /// <param name="categoryId">分类ID</param>
        /// <param name="hasChildren">是否子分类</param>
        /// <returns></returns>
        public bool UpdateHasChildren(int categoryId, bool hasChildren)
        {
            if (dal.UpdateHasChildren(categoryId, hasChildren) > 0)
            {
                return true;
            }

            return false;
        }
        #endregion

        List<oyxf.Model.Category> listDropDownList = new List<Category>();//全局变量

        #region 获得所有的父级分类下拉列表
        /// <summary>
        /// 获得所有的父级分类列表
        /// </summary>
        /// <param name="strCategoryId">要排除的分类ID</param>
        /// <returns></returns>
        public List<oyxf.Model.Category> GetCategoryDropDownList(int strCategoryId)
        {
            listDropDownList.Clear();//获取分类前先清空，因为可能多次调用
            string whereStr = "";
            if (strCategoryId > 0)//排除当前ID的分类及其子分类
            {
                whereStr = string.Format("IdPath not like (select top 1 IdPath from dbo.Category where CategoryId={0})+'%'", strCategoryId);
            }
            //新增页：读取所有的父级分类
            List<oyxf.Model.Category> list = GetModelList(whereStr); //所有数据

            //if (strCategoryId > 0)//排除当前ID的分类及其子分类
            //{
            //    oyxf.Model.Category exceptedCategory = list.SingleOrDefault(o => o.CategoryId == strCategoryId);
            //    list.RemoveAll(o => o.IdPath.StartsWith(exceptedCategory.IdPath));
            //}

            list = list.OrderBy(o => o.ParentId).ThenBy(o => o.SortIndex).ToList();//所有排序后的数据
            foreach (var parent in list.FindAll(o => o.ParentId == 0)) //遍历所有的顶级分类
            {
                listDropDownList.Add(new oyxf.Model.Category()//添加所有的顶级分类
                {
                    Name = parent.Name,
                    CategoryId = parent.CategoryId
                });

                //当前顶级分类下所有的子分类
                GetChildren(list, parent.CategoryId);

            }
            return listDropDownList;
        }
        #endregion

        #region 递归添加listDropDownList数据
        /// <summary>
        /// 递归添加listDropDownList数据
        /// </summary>
        /// <param name="listAll"></param>
        /// <param name="parentId"></param>
        private void GetChildren(List<oyxf.Model.Category> listAll, int parentId)
        {
            //指定ParentId下的子分类
            foreach (oyxf.Model.Category child in listAll.FindAll(o => o.ParentId == parentId))
            {
                //child.Depth
                //2 --
                //3 ----
                //4 ------
                string strPrefix = string.Empty;
                for (int i = 0; i < child.Depth - 1; i++)
                {
                    strPrefix += "--";
                }
                listDropDownList.Add(new oyxf.Model.Category()//添加子分类
                {
                    Name = strPrefix + child.Name,
                    CategoryId = child.CategoryId
                });
                //子分类下的子分类
                GetChildren(listAll, child.CategoryId);
            }
        }

        #endregion

        #region 修改父级分类
        /// <summary>
        /// 修改父级分类
        /// </summary>
        /// <param name="oldParentCategory">原父级分类</param>
        /// <param name="newParentCategory">现父级分类</param>
        /// <param name="beMovedCategory">所移动的分类</param>
        /// <param name="movedCategory">移动后的分类</param>
        /// <returns></returns>
        public int UpdateFatherCategory(Model.Category oldParentCategory, Model.Category newParentCategory, Model.Category beMovedCategory, Model.Category movedCategory)
        {
            return dal.UpdateFatherCategory(oldParentCategory, newParentCategory, beMovedCategory, movedCategory);
        } 
        #endregion

        /// <summary>
        /// 更新Content
        /// </summary>
        /// <param name="model"></param>
        public bool UpdateContent(Category model)
        {
            return dal.UpdateContent(model);
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns></returns>
        public Model.Category GetModel(string url)
        {
            return dal.GetModel(url);
        }

        #endregion  ExtensionMethod

    }
}

