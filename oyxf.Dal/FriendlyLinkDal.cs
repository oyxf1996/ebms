using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using oyxf.DBUtility;//Please add references
namespace oyxf.Dal
{
	/// <summary>
	/// 数据访问类:FriendlyLinkDal
	/// </summary>
	public partial class FriendlyLinkDal
	{
		public FriendlyLinkDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("LinkId", "FriendlyLink"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LinkId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FriendlyLink");
			strSql.Append(" where LinkId=@LinkId");
			SqlParameter[] parameters = {
					new SqlParameter("@LinkId", SqlDbType.Int,4)
			};
			parameters[0].Value = LinkId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(oyxf.Model.FriendlyLink model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FriendlyLink(");
			strSql.Append("Name,Url,Status,SortIndex)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Url,@Status,@SortIndex)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Url", SqlDbType.VarChar,200),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@SortIndex", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Url;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.SortIndex;

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
		public bool Update(oyxf.Model.FriendlyLink model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FriendlyLink set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Url=@Url,");
			strSql.Append("Status=@Status,");
			strSql.Append("SortIndex=@SortIndex");
			strSql.Append(" where LinkId=@LinkId");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Url", SqlDbType.VarChar,200),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@SortIndex", SqlDbType.Int,4),
					new SqlParameter("@LinkId", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Url;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.SortIndex;
			parameters[4].Value = model.LinkId;

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
		public bool Delete(int LinkId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FriendlyLink ");
			strSql.Append(" where LinkId=@LinkId");
			SqlParameter[] parameters = {
					new SqlParameter("@LinkId", SqlDbType.Int,4)
			};
			parameters[0].Value = LinkId;

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
		public bool DeleteList(string LinkIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FriendlyLink ");
			strSql.Append(" where LinkId in ("+LinkIdlist + ")  ");
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
		public oyxf.Model.FriendlyLink GetModel(int LinkId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LinkId,Name,Url,Status,SortIndex from FriendlyLink ");
			strSql.Append(" where LinkId=@LinkId");
			SqlParameter[] parameters = {
					new SqlParameter("@LinkId", SqlDbType.Int,4)
			};
			parameters[0].Value = LinkId;

			oyxf.Model.FriendlyLink model=new oyxf.Model.FriendlyLink();
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
		public oyxf.Model.FriendlyLink DataRowToModel(DataRow row)
		{
			oyxf.Model.FriendlyLink model=new oyxf.Model.FriendlyLink();
			if (row != null)
			{
				if(row["LinkId"]!=null && row["LinkId"].ToString()!="")
				{
					model.LinkId=int.Parse(row["LinkId"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
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
			strSql.Append("select LinkId,Name,Url,Status,SortIndex ");
			strSql.Append(" FROM FriendlyLink ");
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
			strSql.Append(" LinkId,Name,Url,Status,SortIndex ");
			strSql.Append(" FROM FriendlyLink ");
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
			strSql.Append("select count(1) FROM FriendlyLink ");
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
				strSql.Append("order by T.LinkId desc");
			}
			strSql.Append(")AS Row, T.*  from FriendlyLink T ");
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
			parameters[0].Value = "FriendlyLink";
			parameters[1].Value = "LinkId";
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

