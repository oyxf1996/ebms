using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using oyxf.DBUtility;//Please add references

namespace oyxf.Dal
{
    /// <summary>
    /// 数据访问类:CategoryDal
    /// </summary>
    public partial class CategoryDal : BaseDal
    {
        public CategoryDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("CategoryId", "Category");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Category");
            strSql.Append(" where CategoryId=@CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4)
			};
            parameters[0].Value = CategoryId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(oyxf.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Category(");
            strSql.Append("Name,Type,ParentId,Status,SortIndex,Url,Content,IdPath,Depth,HasChildren)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Type,@ParentId,@Status,@SortIndex,@Url,@Content,@IdPath,@Depth,@HasChildren)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Type", SqlDbType.TinyInt,1),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@SortIndex", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.VarChar,100),
					new SqlParameter("@Content", SqlDbType.NVarChar,2000),
					new SqlParameter("@IdPath", SqlDbType.VarChar,100),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@HasChildren", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.SortIndex;
            parameters[5].Value = model.Url;
            parameters[6].Value = model.Content;
            parameters[7].Value = model.IdPath;
            parameters[8].Value = model.Depth;
            parameters[9].Value = model.HasChildren;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(oyxf.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Category set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Type=@Type,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("Status=@Status,");
            strSql.Append("SortIndex=@SortIndex,");
            strSql.Append("Url=@Url,");
            strSql.Append("Content=@Content,");
            strSql.Append("IdPath=@IdPath,");
            strSql.Append("Depth=@Depth,");
            strSql.Append("HasChildren=@HasChildren");
            strSql.Append(" where CategoryId=@CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Type", SqlDbType.TinyInt,1),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@SortIndex", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.VarChar,100),
					new SqlParameter("@Content", SqlDbType.NVarChar,2000),
					new SqlParameter("@IdPath", SqlDbType.VarChar,100),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@HasChildren", SqlDbType.TinyInt,1),
					new SqlParameter("@CategoryId", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.SortIndex;
            parameters[5].Value = model.Url;
            parameters[6].Value = model.Content;
            parameters[7].Value = model.IdPath;
            parameters[8].Value = model.Depth;
            parameters[9].Value = model.HasChildren;
            parameters[10].Value = model.CategoryId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int CategoryId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Category ");
            strSql.Append(" where CategoryId=@CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4)
			};
            parameters[0].Value = CategoryId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string CategoryIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Category ");
            strSql.Append(" where CategoryId in (" + CategoryIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public oyxf.Model.Category GetModel(int CategoryId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CategoryId,Name,Type,ParentId,Status,SortIndex,Url,Content,IdPath,Depth,HasChildren from Category ");
            strSql.Append(" where CategoryId=@CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.Int,4)
			};
            parameters[0].Value = CategoryId;

            oyxf.Model.Category model = new oyxf.Model.Category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public oyxf.Model.Category DataRowToModel(DataRow row)
        {
            oyxf.Model.Category model = new oyxf.Model.Category();
            if (row != null)
            {
                if (row["CategoryId"] != null && row["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(row["CategoryId"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["ParentId"] != null && row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["SortIndex"] != null && row["SortIndex"].ToString() != "")
                {
                    model.SortIndex = int.Parse(row["SortIndex"].ToString());
                }
                if (row["Url"] != null)
                {
                    model.Url = row["Url"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["IdPath"] != null)
                {
                    model.IdPath = row["IdPath"].ToString();
                }
                if (row["Depth"] != null && row["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(row["Depth"].ToString());
                }
                if (row["HasChildren"] != null && row["HasChildren"].ToString() != "")
                {
                    model.HasChildren = int.Parse(row["HasChildren"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CategoryId,Name,Type,ParentId,Status,SortIndex,Url,Content,IdPath,Depth,HasChildren ");
            strSql.Append(" FROM Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" CategoryId,Name,Type,ParentId,Status,SortIndex,Url,Content,IdPath,Depth,HasChildren ");
            strSql.Append(" FROM Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.CategoryId desc");
            }
            strSql.Append(")AS Row, T.*  from Category T ");
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
            parameters[0].Value = "Category";
            parameters[1].Value = "CategoryId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region  ExtensionMethod

        #region 删除分类
        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="categoryId">分类ID</param>
        /// <returns>受影响的行数</returns>
        public int DeleteCategory(int CategoryId)
        {
            string sqlString = "delete from dbo.Category where IdPath like (select IdPath from dbo.Category where CategoryId=@CategoryId)+'%'";
            SqlParameter p = new SqlParameter("@CategoryId", CategoryId);
            return DbHelperSQL.ExecuteSql(sqlString, p);
        }
        #endregion

        #region 根据分类ID更新HasChildren
        /// <summary>
        /// 根据分类ID更新HasChildren
        /// </summary>
        /// <param name="categoryId">分类ID</param>
        /// <param name="hasChildren">是否子分类</param>
        /// <returns></returns>
        public int UpdateHasChildren(int categoryId, bool hasChildren)
        {
            string sql = "update Category set HasChildren=@HasChildren where CategoryId=@CategoryId";
            SqlParameter[] sps = new SqlParameter[]
            {
                new SqlParameter("@HasChildren",Convert.ToInt32(hasChildren)),
                new SqlParameter("@CategoryId",categoryId),
            };

            return DbHelperSQL.ExecuteSql(sql, sps);
        }
        #endregion

        #region 根据ParentId得到Name
        /// <summary>
        /// 根据ParentId得到Name
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        public DataSet GetAllParentName()
        {
            string sqlString = "select a.ParentId,b.Name from (select distinct ParentId from dbo.Category) a left join (select CategoryId,Name from Category) b on a.ParentId=b.CategoryId";
            return DbHelperSQL.Query(sqlString);
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
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(" update Category set Name='{0}',Type={1},ParentId={2},Status={3},SortIndex={4},Url='{5}',Content='{6}',",movedCategory.Name,movedCategory.Type,movedCategory.ParentId,movedCategory.Status,movedCategory.SortIndex,movedCategory.Url,movedCategory.Content));
            sb.Append(string.Format(" IdPath=STUFF(IdPath,1,LEN('{0}'),'{1}'),", oldParentCategory.IdPath, newParentCategory == null ? "," : newParentCategory.IdPath));
            sb.Append(string.Format(" Depth={0}+1+(Depth-{1}) ", newParentCategory == null ? 0 : newParentCategory.Depth, beMovedCategory.Depth));
            sb.Append(string.Format(" where CategoryId in (select CategoryId from Category where IdPath like (select IdPath from Category where CategoryId={0})+'%')", beMovedCategory.CategoryId));
            sb.Append(string.Format(" update Category set ParentId={0} where CategoryId={1} ", movedCategory.ParentId, beMovedCategory.CategoryId));
            sb.Append(string.Format(" if not exists(select * from Category where ParentId={0}) ", beMovedCategory.ParentId));
            sb.Append(string.Format(" update Category set HasChildren=0 where CategoryId={0} ", beMovedCategory.ParentId));
            sb.Append(string.Format(" update Category set HasChildren=1 where CategoryId={0} ", movedCategory.ParentId));
            return DbHelperSQL.ExecuteSql(sb.ToString());
        } 
        #endregion

        #region 更新Content
        /// <summary>
        /// 更新Content
        /// </summary>
        /// <param name="model"></param>
        public bool UpdateContent(Model.Category model)
        {
            string sqlString = "update Category set Content=@content where CategoryId=@categoryId";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@content",SqlDbType.NVarChar,2000),
                new SqlParameter("@categoryId",SqlDbType.Int),
            };
            paras[0].Value = model.Content;
            paras[1].Value = model.CategoryId;
            if (DbHelperSQL.ExecuteSql(sqlString, paras) > 0)
            {
                return true;
            }
            return false;
        } 
        #endregion

        public Model.Category GetModel(string url)
        {
            string sqlString = "select top 1 * from dbo.Category where Url=@url";
            SqlParameter para = new SqlParameter("@url",SqlDbType.VarChar,50);
            para.Value = url;
            DataSet ds= DbHelperSQL.Query(sqlString,para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        #endregion  ExtensionMethod
    }
}

