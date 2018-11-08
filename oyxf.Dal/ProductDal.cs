using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using oyxf.DBUtility;
using oyxf.Model;//Please add references
namespace oyxf.Dal
{
	/// <summary>
	/// 数据访问类:ProductDal
	/// </summary>
	public partial class ProductDal:BaseDal
	{
		public ProductDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ProductId", "Product"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProductId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Product");
			strSql.Append(" where ProductId=@ProductId");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4)
			};
			parameters[0].Value = ProductId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(oyxf.Model.Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Product(");
			strSql.Append("CategoryId,Name,Brand,Type,Description,Content,ImgUrl,ThumbUrl,Status,Click,SortIndex,CreateUserId,CreateDate,UpdateUserId,UpdateDate)");
			strSql.Append(" values (");
			strSql.Append("@CategoryId,@Name,@Brand,@Type,@Description,@Content,@ImgUrl,@ThumbUrl,@Status,@Click,@SortIndex,@CreateUserId,@CreateDate,@UpdateUserId,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Brand", SqlDbType.NVarChar,20),
					new SqlParameter("@Type", SqlDbType.NVarChar,20),
					new SqlParameter("@Description", SqlDbType.NVarChar,200),
					new SqlParameter("@Content", SqlDbType.NVarChar,2000),
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,100),
					new SqlParameter("@ThumbUrl", SqlDbType.VarChar,100),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@SortIndex", SqlDbType.Int,4),
					new SqlParameter("@CreateUserId", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserId", SqlDbType.Int,4),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
			parameters[0].Value = model.CategoryId;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Brand;
			parameters[3].Value = model.Type;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.ImgUrl;
			parameters[7].Value = model.ThumbUrl;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.Click;
			parameters[10].Value = model.SortIndex;
			parameters[11].Value = model.CreateUserId;
			parameters[12].Value = model.CreateDate;
			parameters[13].Value = model.UpdateUserId;
			parameters[14].Value = model.UpdateDate;

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
		public bool Update(oyxf.Model.Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Product set ");
			strSql.Append("CategoryId=@CategoryId,");
			strSql.Append("Name=@Name,");
			strSql.Append("Brand=@Brand,");
			strSql.Append("Type=@Type,");
			strSql.Append("Description=@Description,");
			strSql.Append("Content=@Content,");
			strSql.Append("ImgUrl=@ImgUrl,");
			strSql.Append("ThumbUrl=@ThumbUrl,");
			strSql.Append("Status=@Status,");
			strSql.Append("Click=@Click,");
			strSql.Append("SortIndex=@SortIndex,");
			strSql.Append("CreateUserId=@CreateUserId,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateUserId=@UpdateUserId,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ProductId=@ProductId");
			SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Brand", SqlDbType.NVarChar,20),
					new SqlParameter("@Type", SqlDbType.NVarChar,20),
					new SqlParameter("@Description", SqlDbType.NVarChar,200),
					new SqlParameter("@Content", SqlDbType.NVarChar,2000),
					new SqlParameter("@ImgUrl", SqlDbType.VarChar,100),
					new SqlParameter("@ThumbUrl", SqlDbType.VarChar,100),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@SortIndex", SqlDbType.Int,4),
					new SqlParameter("@CreateUserId", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserId", SqlDbType.Int,4),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ProductId", SqlDbType.Int,4)};
			parameters[0].Value = model.CategoryId;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Brand;
			parameters[3].Value = model.Type;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.ImgUrl;
			parameters[7].Value = model.ThumbUrl;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.Click;
			parameters[10].Value = model.SortIndex;
			parameters[11].Value = model.CreateUserId;
			parameters[12].Value = model.CreateDate;
			parameters[13].Value = model.UpdateUserId;
			parameters[14].Value = model.UpdateDate;
			parameters[15].Value = model.ProductId;

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
		public bool Delete(int ProductId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Product ");
			strSql.Append(" where ProductId=@ProductId");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4)
			};
			parameters[0].Value = ProductId;

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
		public bool DeleteList(string ProductIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Product ");
			strSql.Append(" where ProductId in ("+ProductIdlist + ")  ");
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
		public oyxf.Model.Product GetModel(int ProductId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProductId,CategoryId,Name,Brand,Type,Description,Content,ImgUrl,ThumbUrl,Status,Click,SortIndex,CreateUserId,CreateDate,UpdateUserId,UpdateDate from Product ");
			strSql.Append(" where ProductId=@ProductId");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4)
			};
			parameters[0].Value = ProductId;

			oyxf.Model.Product model=new oyxf.Model.Product();
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
		public oyxf.Model.Product DataRowToModel(DataRow row)
		{
			oyxf.Model.Product model=new oyxf.Model.Product();
			if (row != null)
			{
				if(row["ProductId"]!=null && row["ProductId"].ToString()!="")
				{
					model.ProductId=int.Parse(row["ProductId"].ToString());
				}
				if(row["CategoryId"]!=null && row["CategoryId"].ToString()!="")
				{
					model.CategoryId=int.Parse(row["CategoryId"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Brand"]!=null)
				{
					model.Brand=row["Brand"].ToString();
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["ImgUrl"]!=null)
				{
					model.ImgUrl=row["ImgUrl"].ToString();
				}
				if(row["ThumbUrl"]!=null)
				{
					model.ThumbUrl=row["ThumbUrl"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["Click"]!=null && row["Click"].ToString()!="")
				{
					model.Click=int.Parse(row["Click"].ToString());
				}
				if(row["SortIndex"]!=null && row["SortIndex"].ToString()!="")
				{
					model.SortIndex=int.Parse(row["SortIndex"].ToString());
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
		public DataSet GetList(string strWhere,string strOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProductId,CategoryId,Name,Brand,Type,Description,Content,ImgUrl,ThumbUrl,Status,Click,SortIndex,CreateUserId,CreateDate,UpdateUserId,UpdateDate ");
			strSql.Append(" FROM Product ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            if (strOrder.Trim()!="")
            {
                strSql.Append(" order by "+strOrder);
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
			strSql.Append(" ProductId,CategoryId,Name,Brand,Type,Description,Content,ImgUrl,ThumbUrl,Status,Click,SortIndex,CreateUserId,CreateDate,UpdateUserId,UpdateDate ");
			strSql.Append(" FROM Product ");
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
			strSql.Append("select count(1) FROM Product ");
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
				strSql.Append("order by T.ProductId desc");
			}
			strSql.Append(")AS Row, T.*  from Product T ");
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
			parameters[0].Value = "Product";
			parameters[1].Value = "ProductId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 得到某一产品及其所有子产品
        /// </summary>
        /// <param name="p">某一产品的CategoryId</param>
        /// <returns></returns>
        public DataSet GetProAndSubPro(int p)
        {
            string sqlString="select * from Product where CategoryId in (select CategoryId from Category where IdPath like (select IdPath from Category where CategoryId=@num)+'%')";
            SqlParameter[] paras=new SqlParameter[]{
                new SqlParameter("@num",SqlDbType.Int)
            };
            paras[0].Value=p;
            return DbHelperSQL.Query(sqlString, paras);
        }

		#endregion  ExtensionMethod

        
    }
}

