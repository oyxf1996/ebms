using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using oyxf.DBUtility;//Please add references
namespace oyxf.Dal
{
	/// <summary>
	/// 数据访问类:BannerDal
	/// </summary>
	public partial class BannerDal
	{
		public BannerDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("BannerId", "Banner"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int BannerId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Banner");
			strSql.Append(" where BannerId=@BannerId");
			SqlParameter[] parameters = {
					new SqlParameter("@BannerId", SqlDbType.Int,4)
			};
			parameters[0].Value = BannerId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(oyxf.Model.Banner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Banner(");
			strSql.Append("ImgUrl,Title,Url,Status,SortIndex)");
			strSql.Append(" values (");
			strSql.Append("@ImgUrl,@Title,@Url,@Status,@SortIndex)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,100),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Url", SqlDbType.VarChar,100),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@SortIndex", SqlDbType.Int,4)};
			parameters[0].Value = model.ImgUrl;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Url;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.SortIndex;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(oyxf.Model.Banner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Banner set ");
			strSql.Append("ImgUrl=@ImgUrl,");
			strSql.Append("Title=@Title,");
			strSql.Append("Url=@Url,");
			strSql.Append("Status=@Status,");
			strSql.Append("SortIndex=@SortIndex");
			strSql.Append(" where BannerId=@BannerId");
			SqlParameter[] parameters = {
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,100),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Url", SqlDbType.VarChar,100),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@SortIndex", SqlDbType.Int,4),
					new SqlParameter("@BannerId", SqlDbType.Int,4)};
			parameters[0].Value = model.ImgUrl;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Url;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.SortIndex;
			parameters[5].Value = model.BannerId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int BannerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Banner ");
			strSql.Append(" where BannerId=@BannerId");
			SqlParameter[] parameters = {
					new SqlParameter("@BannerId", SqlDbType.Int,4)
			};
			parameters[0].Value = BannerId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string BannerIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Banner ");
			strSql.Append(" where BannerId in ("+BannerIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public oyxf.Model.Banner GetModel(int BannerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BannerId,ImgUrl,Title,Url,Status,SortIndex from Banner ");
			strSql.Append(" where BannerId=@BannerId");
			SqlParameter[] parameters = {
					new SqlParameter("@BannerId", SqlDbType.Int,4)
			};
			parameters[0].Value = BannerId;

			oyxf.Model.Banner model=new oyxf.Model.Banner();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public oyxf.Model.Banner DataRowToModel(DataRow row)
		{
			oyxf.Model.Banner model=new oyxf.Model.Banner();
			if (row != null)
			{
				if(row["BannerId"]!=null && row["BannerId"].ToString()!="")
				{
					model.BannerId=int.Parse(row["BannerId"].ToString());
				}
				if(row["ImgUrl"]!=null)
				{
					model.ImgUrl=row["ImgUrl"].ToString();
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Url"]!=null)
				{
					model.Url=row["Url"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["SortIndex"]!=null && row["SortIndex"].ToString()!="")
				{
					model.SortIndex=int.Parse(row["SortIndex"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select BannerId,ImgUrl,Title,Url,Status,SortIndex ");
			strSql.Append(" FROM Banner ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" BannerId,ImgUrl,Title,Url,Status,SortIndex ");
			strSql.Append(" FROM Banner ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Banner ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.BannerId desc");
			}
			strSql.Append(")AS Row, T.*  from Banner T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Banner";
			parameters[1].Value = "BannerId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

