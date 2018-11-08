using System;
using System.Data;
using System.Collections.Generic;
using oyxf.Common;
using oyxf.Model;
namespace oyxf.Bll
{
	/// <summary>
	/// Banner
	/// </summary>
	public partial class BannerBll
	{
		private readonly oyxf.Dal.BannerDal dal=new oyxf.Dal.BannerDal();
		public BannerBll()
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
		public bool Exists(int BannerId)
		{
			return dal.Exists(BannerId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(oyxf.Model.Banner model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(oyxf.Model.Banner model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int BannerId)
		{
			
			return dal.Delete(BannerId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string BannerIdlist )
		{
			return dal.DeleteList(oyxf.Common.PageValidate.SafeLongFilter(BannerIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public oyxf.Model.Banner GetModel(int BannerId)
		{
			
			return dal.GetModel(BannerId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public oyxf.Model.Banner GetModelByCache(int BannerId)
		{
			
			string CacheKey = "BannerModel-" + BannerId;
			object objModel = oyxf.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(BannerId);
					if (objModel != null)
					{
						int ModelCache = oyxf.Common.ConfigHelper.GetConfigInt("ModelCache");
						oyxf.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (oyxf.Model.Banner)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<oyxf.Model.Banner> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<oyxf.Model.Banner> DataTableToList(DataTable dt)
		{
			List<oyxf.Model.Banner> modelList = new List<oyxf.Model.Banner>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				oyxf.Model.Banner model;
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

		#endregion  ExtensionMethod
	}
}

