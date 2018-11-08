using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using oyxf.DBUtility;//Please add references
namespace oyxf.Dal
{
    /// <summary>
    /// 数据访问类:UserInfoDal
    /// </summary>
    public partial class UserInfoDal
    {
        public UserInfoDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UserId", "UserInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserInfo");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
            parameters[0].Value = UserId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(oyxf.Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserInfo(");
            strSql.Append("Username,Password,RealName,Phone,UserType,Status,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@Username,@Password,@RealName,@Phone,@UserType,@Status,@CreateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.VarChar,16),
					new SqlParameter("@Password", SqlDbType.Char,32),
					new SqlParameter("@RealName", SqlDbType.NVarChar,10),
					new SqlParameter("@Phone", SqlDbType.VarChar,15),
					new SqlParameter("@UserType", SqlDbType.TinyInt,1),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.Username;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.RealName;
            parameters[3].Value = model.Phone;
            parameters[4].Value = model.UserType;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.CreateDate;

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
        public bool Update(oyxf.Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ");
            strSql.Append("Username=@Username,");
            strSql.Append("Password=@Password,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("UserType=@UserType,");
            strSql.Append("Status=@Status,");
            strSql.Append("CreateDate=@CreateDate");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.VarChar,16),
					new SqlParameter("@Password", SqlDbType.Char,32),
					new SqlParameter("@RealName", SqlDbType.NVarChar,10),
					new SqlParameter("@Phone", SqlDbType.VarChar,15),
					new SqlParameter("@UserType", SqlDbType.TinyInt,1),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = model.Username;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.RealName;
            parameters[3].Value = model.Phone;
            parameters[4].Value = model.UserType;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.CreateDate;
            parameters[7].Value = model.UserId;

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
        public bool Delete(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserInfo ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
            parameters[0].Value = UserId;

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
        public bool DeleteList(string UserIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserInfo ");
            strSql.Append(" where UserId in (" + UserIdlist + ")  ");
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
        public oyxf.Model.UserInfo GetModel(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,Username,Password,RealName,Phone,UserType,Status,CreateDate from UserInfo ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
            parameters[0].Value = UserId;

            oyxf.Model.UserInfo model = new oyxf.Model.UserInfo();
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
        public oyxf.Model.UserInfo DataRowToModel(DataRow row)
        {
            oyxf.Model.UserInfo model = new oyxf.Model.UserInfo();
            if (row != null)
            {
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["Username"] != null)
                {
                    model.Username = row["Username"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["UserType"] != null && row["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(row["UserType"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
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
            strSql.Append("select UserId,Username,Password,RealName,Phone,UserType,Status,CreateDate ");
            strSql.Append(" FROM UserInfo ");
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
            strSql.Append(" UserId,Username,Password,RealName,Phone,UserType,Status,CreateDate ");
            strSql.Append(" FROM UserInfo ");
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
            strSql.Append("select count(1) FROM UserInfo ");
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
                strSql.Append("order by T.UserId desc");
            }
            strSql.Append(")AS Row, T.*  from UserInfo T ");
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
            parameters[0].Value = "UserInfo";
            parameters[1].Value = "UserId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region  ExtensionMethod
        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">用户信息实体</param>
        /// <param name="isModifyPassword">是否修改密码</param>
        /// <returns></returns>
        public bool Update(oyxf.Model.UserInfo model, bool isModifyPassword)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ");
            strSql.Append("Username=@Username,");

            if (isModifyPassword)//修改密码
            {
                strSql.Append("Password=@Password,");
            }

            strSql.Append("RealName=@RealName,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("UserType=@UserType,");
            strSql.Append("Status=@Status,");
            strSql.Append("CreateDate=@CreateDate");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.VarChar,16),
					new SqlParameter("@RealName", SqlDbType.NVarChar,10),
					new SqlParameter("@Phone", SqlDbType.VarChar,15),
					new SqlParameter("@UserType", SqlDbType.TinyInt,1),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = model.Username;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.Phone;
            parameters[3].Value = model.UserType;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.UserId;

            if (isModifyPassword)
            {
                //parameters[7] = model.Password;//不能这么添加元素
                SqlParameter[] sps = new SqlParameter[parameters.Length + 1];
                parameters.CopyTo(sps, 0);
                sps[sps.Length - 1] = new SqlParameter("@Password", SqlDbType.Char, 32);
                sps[sps.Length - 1].Value = model.Password;
            }

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
        #endregion

        #region 根据用户名获取记录数
        /// <summary>
        /// 根据用户名获取记录数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetUsernameCount(oyxf.Model.UserInfo model)
        {
            string sql = string.Format(@"select COUNT(*)
                from userinfo
                where Username=@Username and UserId!=@UserId");
            SqlParameter[] sps = new SqlParameter[]
            {
                new SqlParameter("@Username",SqlDbType.VarChar,16),
                new SqlParameter("@UserId",SqlDbType.Int),
            };
            sps[0].Value = model.Username;
            sps[1].Value = model.UserId;

            object obj = DbHelperSQL.GetSingle(sql, sps);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }

            return 0;
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public oyxf.Model.UserInfo GetModel(string username,string password)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,Username,Password,RealName,Phone,UserType,Status,CreateDate from UserInfo ");
            strSql.Append(" where Username=@username and Password=@password");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,50),
					new SqlParameter("@password", SqlDbType.VarChar,50)
			};
            parameters[0].Value = username;
            parameters[1].Value = password;

            oyxf.Model.UserInfo model = new oyxf.Model.UserInfo();
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
        #endregion

        #endregion  ExtensionMethod
    }
}

