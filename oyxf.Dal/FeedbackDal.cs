using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using oyxf.DBUtility;//Please add references
namespace oyxf.Dal
{
	/// <summary>
	/// 数据访问类:FeedbackDal
	/// </summary>
	public partial class FeedbackDal
	{
		public FeedbackDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MsgId", "Feedback"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MsgId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Feedback");
			strSql.Append(" where MsgId=@MsgId");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgId", SqlDbType.Int,4)
			};
			parameters[0].Value = MsgId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(oyxf.Model.Feedback model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Feedback(");
			strSql.Append("Name,Email,QQ,Msg,CreateDate,Status,ReplyMsg,ReplyUserId,ReplyDate)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Email,@QQ,@Msg,@CreateDate,@Status,@ReplyMsg,@ReplyUserId,@ReplyDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,10),
					new SqlParameter("@Email", SqlDbType.VarChar,30),
					new SqlParameter("@QQ", SqlDbType.BigInt,8),
					new SqlParameter("@Msg", SqlDbType.NVarChar,100),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@ReplyMsg", SqlDbType.NVarChar,100),
					new SqlParameter("@ReplyUserId", SqlDbType.Int,4),
					new SqlParameter("@ReplyDate", SqlDbType.DateTime)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Email;
			parameters[2].Value = model.QQ;
			parameters[3].Value = model.Msg;
			parameters[4].Value = model.CreateDate;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.ReplyMsg;
			parameters[7].Value = model.ReplyUserId;
			parameters[8].Value = model.ReplyDate;

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
		public bool Update(oyxf.Model.Feedback model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Feedback set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Email=@Email,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("Msg=@Msg,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("Status=@Status,");
			strSql.Append("ReplyMsg=@ReplyMsg,");
			strSql.Append("ReplyUserId=@ReplyUserId,");
			strSql.Append("ReplyDate=@ReplyDate");
			strSql.Append(" where MsgId=@MsgId");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,10),
					new SqlParameter("@Email", SqlDbType.VarChar,30),
					new SqlParameter("@QQ", SqlDbType.BigInt,8),
					new SqlParameter("@Msg", SqlDbType.NVarChar,100),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@ReplyMsg", SqlDbType.NVarChar,100),
					new SqlParameter("@ReplyUserId", SqlDbType.Int,4),
					new SqlParameter("@ReplyDate", SqlDbType.DateTime),
					new SqlParameter("@MsgId", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Email;
			parameters[2].Value = model.QQ;
			parameters[3].Value = model.Msg;
			parameters[4].Value = model.CreateDate;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.ReplyMsg;
			parameters[7].Value = model.ReplyUserId;
			parameters[8].Value = model.ReplyDate;
			parameters[9].Value = model.MsgId;

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
		public bool Delete(int MsgId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Feedback ");
			strSql.Append(" where MsgId=@MsgId");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgId", SqlDbType.Int,4)
			};
			parameters[0].Value = MsgId;

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
		public bool DeleteList(string MsgIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Feedback ");
			strSql.Append(" where MsgId in ("+MsgIdlist + ")  ");
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
		public oyxf.Model.Feedback GetModel(int MsgId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MsgId,Name,Email,QQ,Msg,CreateDate,Status,ReplyMsg,ReplyUserId,ReplyDate from Feedback ");
			strSql.Append(" where MsgId=@MsgId");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgId", SqlDbType.Int,4)
			};
			parameters[0].Value = MsgId;

			oyxf.Model.Feedback model=new oyxf.Model.Feedback();
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
		public oyxf.Model.Feedback DataRowToModel(DataRow row)
		{
			oyxf.Model.Feedback model=new oyxf.Model.Feedback();
			if (row != null)
			{
				if(row["MsgId"]!=null && row["MsgId"].ToString()!="")
				{
					model.MsgId=int.Parse(row["MsgId"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["QQ"]!=null && row["QQ"].ToString()!="")
				{
					model.QQ=long.Parse(row["QQ"].ToString());
				}
				if(row["Msg"]!=null)
				{
					model.Msg=row["Msg"].ToString();
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["ReplyMsg"]!=null)
				{
					model.ReplyMsg=row["ReplyMsg"].ToString();
				}
				if(row["ReplyUserId"]!=null && row["ReplyUserId"].ToString()!="")
				{
					model.ReplyUserId=int.Parse(row["ReplyUserId"].ToString());
				}
				if(row["ReplyDate"]!=null && row["ReplyDate"].ToString()!="")
				{
					model.ReplyDate=DateTime.Parse(row["ReplyDate"].ToString());
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
			strSql.Append("select MsgId,Name,Email,QQ,Msg,CreateDate,Status,ReplyMsg,ReplyUserId,ReplyDate ");
			strSql.Append(" FROM Feedback ");
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
			strSql.Append(" MsgId,Name,Email,QQ,Msg,CreateDate,Status,ReplyMsg,ReplyUserId,ReplyDate ");
			strSql.Append(" FROM Feedback ");
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
			strSql.Append("select count(1) FROM Feedback ");
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
				strSql.Append("order by T.MsgId desc");
			}
			strSql.Append(")AS Row, T.*  from Feedback T ");
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
			parameters[0].Value = "Feedback";
			parameters[1].Value = "MsgId";
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

