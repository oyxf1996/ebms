using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using oyxf.DBUtility;

namespace oyxf.Dal
{
    public class BaseDal
    {
        #region 分页存储过程
        /// <summary>
        /// 分页存储过程
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="orderBy">排序表达式</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="where">条件表达式</param>
        /// <param name="fields">查询字段表达式</param>
        /// <returns>分页数据</returns>
        public DataSet GetPage(string table, int pageIndex, int pageSize, string orderBy, out int recordCount, string where, string fields)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@Table", SqlDbType.NVarChar,20),
					new SqlParameter("@Where", SqlDbType.NVarChar,500),
					new SqlParameter("@Fields", SqlDbType.NVarChar,500),
					new SqlParameter("@OrderBy", SqlDbType.NVarChar,500),
					new SqlParameter("@Total", SqlDbType.Int),
					};
            parameters[0].Value = pageIndex;
            parameters[1].Value = pageSize;
            parameters[2].Value = table;
            parameters[3].Value = !string.IsNullOrWhiteSpace(where) ? where : "1=1";
            parameters[4].Value = fields;
            parameters[5].Value = orderBy;
            parameters[6].Direction = ParameterDirection.Output;

            DataSet ds = DbHelperSQL.ExecuteProcedure("proc_Pager", parameters);
            recordCount = Convert.ToInt32(parameters[6].Value);

            return ds;
        } 
        #endregion

    }
}
