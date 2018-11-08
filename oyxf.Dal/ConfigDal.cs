using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using oyxf.DBUtility;//Please add references
namespace oyxf.Dal
{
	/// <summary>
	/// 数据访问类:ConfigDal
	/// </summary>
	public partial class ConfigDal
	{
		public ConfigDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ConfigId", "Config"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ConfigId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Config");
			strSql.Append(" where ConfigId=@ConfigId");
			SqlParameter[] parameters = {
					new SqlParameter("@ConfigId", SqlDbType.Int,4)
			};
			parameters[0].Value = ConfigId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(oyxf.Model.Config model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Config(");
			strSql.Append("Copyright,AboutImgUrl,AboutIntro,AboutUrl,NewsUrl,ContactImgUrl,ContactUrl,CompanyName,Address,Postcode,Telephone,Website,Email,ProductUrl)");
			strSql.Append(" values (");
			strSql.Append("@Copyright,@AboutImgUrl,@AboutIntro,@AboutUrl,@NewsUrl,@ContactImgUrl,@ContactUrl,@CompanyName,@Address,@Postcode,@Telephone,@Website,@Email,@ProductUrl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Copyright", SqlDbType.NVarChar,100),
					new SqlParameter("@AboutImgUrl", SqlDbType.VarChar,100),
					new SqlParameter("@AboutIntro", SqlDbType.NVarChar,200),
					new SqlParameter("@AboutUrl", SqlDbType.VarChar,50),
					new SqlParameter("@NewsUrl", SqlDbType.VarChar,50),
					new SqlParameter("@ContactImgUrl", SqlDbType.VarChar,100),
					new SqlParameter("@ContactUrl", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyName", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Postcode", SqlDbType.Int,4),
					new SqlParameter("@Telephone", SqlDbType.VarChar,15),
					new SqlParameter("@Website", SqlDbType.VarChar,30),
					new SqlParameter("@Email", SqlDbType.VarChar,30),
					new SqlParameter("@ProductUrl", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Copyright;
			parameters[1].Value = model.AboutImgUrl;
			parameters[2].Value = model.AboutIntro;
			parameters[3].Value = model.AboutUrl;
			parameters[4].Value = model.NewsUrl;
			parameters[5].Value = model.ContactImgUrl;
			parameters[6].Value = model.ContactUrl;
			parameters[7].Value = model.CompanyName;
			parameters[8].Value = model.Address;
			parameters[9].Value = model.Postcode;
			parameters[10].Value = model.Telephone;
			parameters[11].Value = model.Website;
			parameters[12].Value = model.Email;
			parameters[13].Value = model.ProductUrl;

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
		public bool Update(oyxf.Model.Config model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Config set ");
			strSql.Append("Copyright=@Copyright,");
			strSql.Append("AboutImgUrl=@AboutImgUrl,");
			strSql.Append("AboutIntro=@AboutIntro,");
			strSql.Append("AboutUrl=@AboutUrl,");
			strSql.Append("NewsUrl=@NewsUrl,");
			strSql.Append("ContactImgUrl=@ContactImgUrl,");
			strSql.Append("ContactUrl=@ContactUrl,");
			strSql.Append("CompanyName=@CompanyName,");
			strSql.Append("Address=@Address,");
			strSql.Append("Postcode=@Postcode,");
			strSql.Append("Telephone=@Telephone,");
			strSql.Append("Website=@Website,");
			strSql.Append("Email=@Email,");
			strSql.Append("ProductUrl=@ProductUrl");
			strSql.Append(" where ConfigId=@ConfigId");
			SqlParameter[] parameters = {
					new SqlParameter("@Copyright", SqlDbType.NVarChar,100),
					new SqlParameter("@AboutImgUrl", SqlDbType.VarChar,100),
					new SqlParameter("@AboutIntro", SqlDbType.NVarChar,200),
					new SqlParameter("@AboutUrl", SqlDbType.VarChar,50),
					new SqlParameter("@NewsUrl", SqlDbType.VarChar,50),
					new SqlParameter("@ContactImgUrl", SqlDbType.VarChar,100),
					new SqlParameter("@ContactUrl", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyName", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Postcode", SqlDbType.Int,4),
					new SqlParameter("@Telephone", SqlDbType.VarChar,15),
					new SqlParameter("@Website", SqlDbType.VarChar,30),
					new SqlParameter("@Email", SqlDbType.VarChar,30),
					new SqlParameter("@ProductUrl", SqlDbType.VarChar,50),
					new SqlParameter("@ConfigId", SqlDbType.Int,4)};
			parameters[0].Value = model.Copyright;
			parameters[1].Value = model.AboutImgUrl;
			parameters[2].Value = model.AboutIntro;
			parameters[3].Value = model.AboutUrl;
			parameters[4].Value = model.NewsUrl;
			parameters[5].Value = model.ContactImgUrl;
			parameters[6].Value = model.ContactUrl;
			parameters[7].Value = model.CompanyName;
			parameters[8].Value = model.Address;
			parameters[9].Value = model.Postcode;
			parameters[10].Value = model.Telephone;
			parameters[11].Value = model.Website;
			parameters[12].Value = model.Email;
			parameters[13].Value = model.ProductUrl;
			parameters[14].Value = model.ConfigId;

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
		public bool Delete(int ConfigId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Config ");
			strSql.Append(" where ConfigId=@ConfigId");
			SqlParameter[] parameters = {
					new SqlParameter("@ConfigId", SqlDbType.Int,4)
			};
			parameters[0].Value = ConfigId;

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
		public bool DeleteList(string ConfigIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Config ");
			strSql.Append(" where ConfigId in ("+ConfigIdlist + ")  ");
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
		public oyxf.Model.Config GetModel(int ConfigId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ConfigId,Copyright,AboutImgUrl,AboutIntro,AboutUrl,NewsUrl,ContactImgUrl,ContactUrl,CompanyName,Address,Postcode,Telephone,Website,Email,ProductUrl from Config ");
			strSql.Append(" where ConfigId=@ConfigId");
			SqlParameter[] parameters = {
					new SqlParameter("@ConfigId", SqlDbType.Int,4)
			};
			parameters[0].Value = ConfigId;

			oyxf.Model.Config model=new oyxf.Model.Config();
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
		public oyxf.Model.Config DataRowToModel(DataRow row)
		{
			oyxf.Model.Config model=new oyxf.Model.Config();
			if (row != null)
			{
				if(row["ConfigId"]!=null && row["ConfigId"].ToString()!="")
				{
					model.ConfigId=int.Parse(row["ConfigId"].ToString());
				}
				if(row["Copyright"]!=null)
				{
					model.Copyright=row["Copyright"].ToString();
				}
				if(row["AboutImgUrl"]!=null)
				{
					model.AboutImgUrl=row["AboutImgUrl"].ToString();
				}
				if(row["AboutIntro"]!=null)
				{
					model.AboutIntro=row["AboutIntro"].ToString();
				}
				if(row["AboutUrl"]!=null)
				{
					model.AboutUrl=row["AboutUrl"].ToString();
				}
				if(row["NewsUrl"]!=null)
				{
					model.NewsUrl=row["NewsUrl"].ToString();
				}
				if(row["ContactImgUrl"]!=null)
				{
					model.ContactImgUrl=row["ContactImgUrl"].ToString();
				}
				if(row["ContactUrl"]!=null)
				{
					model.ContactUrl=row["ContactUrl"].ToString();
				}
				if(row["CompanyName"]!=null)
				{
					model.CompanyName=row["CompanyName"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Postcode"]!=null && row["Postcode"].ToString()!="")
				{
					model.Postcode=int.Parse(row["Postcode"].ToString());
				}
				if(row["Telephone"]!=null)
				{
					model.Telephone=row["Telephone"].ToString();
				}
				if(row["Website"]!=null)
				{
					model.Website=row["Website"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["ProductUrl"]!=null)
				{
					model.ProductUrl=row["ProductUrl"].ToString();
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
			strSql.Append("select ConfigId,Copyright,AboutImgUrl,AboutIntro,AboutUrl,NewsUrl,ContactImgUrl,ContactUrl,CompanyName,Address,Postcode,Telephone,Website,Email,ProductUrl ");
			strSql.Append(" FROM Config ");
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
			strSql.Append(" ConfigId,Copyright,AboutImgUrl,AboutIntro,AboutUrl,NewsUrl,ContactImgUrl,ContactUrl,CompanyName,Address,Postcode,Telephone,Website,Email,ProductUrl ");
			strSql.Append(" FROM Config ");
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
			strSql.Append("select count(1) FROM Config ");
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
				strSql.Append("order by T.ConfigId desc");
			}
			strSql.Append(")AS Row, T.*  from Config T ");
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
			parameters[0].Value = "Config";
			parameters[1].Value = "ConfigId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod

		#region  ExtensionMethod
        #region 获取第一条配置
        /// <summary>
        /// 获取第一条配置
        /// </summary>
        /// <returns></returns>
        public oyxf.Model.Config GetModel()
        {
            string sql = @"select top 1 *
                from Config
                order by ConfigId asc";

            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        } 
        #endregion

		#endregion  ExtensionMethod
	}
}

