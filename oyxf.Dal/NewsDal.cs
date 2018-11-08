using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using oyxf.DBUtility;//Please add references
namespace oyxf.Dal
{
	/// <summary>
	/// 数据访问类:NewsDal
	/// </summary>
    public partial class NewsDal : BaseDal
	{
		public NewsDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("NewsId", "News"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int NewsId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from News");
			strSql.Append(" where NewsId=@NewsId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(oyxf.Model.News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into News(");
			strSql.Append("CategoryId,Title,Content,Status,Click,CreateUserId,CreateDate,UpdateUserId,UpdateDate)");
			strSql.Append(" values (");
			strSql.Append("@CategoryId,@Title,@Content,@Status,@Click,@CreateUserId,@CreateDate,@UpdateUserId,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.NVarChar,2000),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@CreateUserId", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserId", SqlDbType.Int,4),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
			parameters[0].Value = model.CategoryId;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.Click;
			parameters[5].Value = model.CreateUserId;
			parameters[6].Value = model.CreateDate;
			parameters[7].Value = model.UpdateUserId;
			parameters[8].Value = model.UpdateDate;

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
		public bool Update(oyxf.Model.News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update News set ");
			strSql.Append("CategoryId=@CategoryId,");
			strSql.Append("Title=@Title,");
			strSql.Append("Content=@Content,");
			strSql.Append("Status=@Status,");
			strSql.Append("Click=@Click,");
			strSql.Append("CreateUserId=@CreateUserId,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateUserId=@UpdateUserId,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where NewsId=@NewsId");
			SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.NVarChar,2000),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@CreateUserId", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserId", SqlDbType.Int,4),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@NewsId", SqlDbType.Int,4)};
			parameters[0].Value = model.CategoryId;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.Click;
			parameters[5].Value = model.CreateUserId;
			parameters[6].Value = model.CreateDate;
			parameters[7].Value = model.UpdateUserId;
			parameters[8].Value = model.UpdateDate;
			parameters[9].Value = model.NewsId;

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
		public bool Delete(int NewsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from News ");
			strSql.Append(" where NewsId=@NewsId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsId;

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
		public bool DeleteList(string NewsIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from News ");
			strSql.Append(" where NewsId in ("+NewsIdlist + ")  ");
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
		public oyxf.Model.News GetModel(int NewsId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 NewsId,CategoryId,Title,Content,Status,Click,CreateUserId,CreateDate,UpdateUserId,UpdateDate from News ");
			strSql.Append(" where NewsId=@NewsId");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsId;

			oyxf.Model.News model=new oyxf.Model.News();
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
		public oyxf.Model.News DataRowToModel(DataRow row)
		{
			oyxf.Model.News model=new oyxf.Model.News();
			if (row != null)
			{
				if(row["NewsId"]!=null && row["NewsId"].ToString()!="")
				{
					model.NewsId=int.Parse(row["NewsId"].ToString());
				}
				if(row["CategoryId"]!=null && row["CategoryId"].ToString()!="")
				{
					model.CategoryId=int.Parse(row["CategoryId"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["Click"]!=null && row["Click"].ToString()!="")
				{
					model.Click=int.Parse(row["Click"].ToString());
				}
				if(row["CreateUserId"]!=null && row["CreateUserId"].ToString()!="")
				{
					model.CreateUserId=int.Parse(row["CreateUserId"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["UpdateUserId"]!=null && row["UpdateUserId"].ToString()!="")
				{
					model.UpdateUserId=int.Parse(row["UpdateUserId"].ToString());
				}
				if(row["UpdateDate"]!=null && row["UpdateDate"].ToString()!="")
				{
					model.UpdateDate=DateTime.Parse(row["UpdateDate"].ToString());
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
			strSql.Append("select NewsId,CategoryId,Title,Content,Status,Click,CreateUserId,CreateDate,UpdateUserId,UpdateDate ");
			strSql.Append(" FROM News ");
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
			strSql.Append(" NewsId,CategoryId,Title,Content,Status,Click,CreateUserId,CreateDate,UpdateUserId,UpdateDate ");
			strSql.Append(" FROM News ");
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
			strSql.Append("select count(1) FROM News ");
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
				strSql.Append("order by T.NewsId desc");
			}
			strSql.Append(")AS Row, T.*  from News T ");
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
			parameters[0].Value = "News";
			parameters[1].Value = "NewsId";
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

