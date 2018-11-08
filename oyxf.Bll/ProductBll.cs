using System;
using System.Data;
using System.Collections.Generic;
using oyxf.Common;
using oyxf.Model;
namespace oyxf.Bll
{
	/// <summary>
	/// 产品
	/// </summary>
	public partial class ProductBll
	{
		private readonly oyxf.Dal.ProductDal dal=new oyxf.Dal.ProductDal();
		public ProductBll()
		{}
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
		public bool Exists(int ProductId)
		{
			return dal.Exists(ProductId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(oyxf.Model.Product model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(oyxf.Model.Product model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ProductId)
		{
			
			return dal.Delete(ProductId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProductIdlist )
		{
			return dal.DeleteList(oyxf.Common.PageValidate.SafeLongFilter(ProductIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public oyxf.Model.Product GetModel(int ProductId)
		{
			
			return dal.GetModel(ProductId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public oyxf.Model.Product GetModelByCache(int ProductId)
		{
			
			string CacheKey = "ProductModel-" + ProductId;
			object objModel = oyxf.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductId);
					if (objModel != null)
					{
						int ModelCache = oyxf.Common.ConfigHelper.GetConfigInt("ModelCache");
						oyxf.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (oyxf.Model.Product)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere,"");
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<oyxf.Model.Product> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere,"");
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<oyxf.Model.Product> GetModelList(string strWhere,string strOrder)
        {
            DataSet ds = dal.GetList(strWhere, strOrder);
            return DataTableToList(ds.Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<oyxf.Model.Product> DataTableToList(DataTable dt)
		{
			List<oyxf.Model.Product> modelList = new List<oyxf.Model.Product>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				oyxf.Model.Product model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

        /// <summary>
        /// 得到某一产品及其所有子产品
        /// </summary>
        /// <param name="p">某一产品的CategoryId</param>
        /// <returns></returns>
        public List<Product> GetProAndSubPro(int p)
        {
            DataSet ds = dal.GetProAndSubPro(p);
            return DataTableToList(ds.Tables[0]);

        }

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
        public List<oyxf.Model.Product> GetPage(int pageIndex, int pageSize, string orderBy, out int recordCount, string where = "", string fields = "*")
        {
            DataSet ds = dal.GetPage("Product", pageIndex, pageSize, orderBy, out recordCount, where, fields);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)//非空判断
            {
                return null;
            }
            List<oyxf.Model.Product> list = DataTableToList(ds.Tables[0]);

            return list;
        }
        #endregion
		#endregion  ExtensionMethod

       
    }
}

