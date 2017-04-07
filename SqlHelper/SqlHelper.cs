using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Mylibrary
{
    /// <summary>
    /// 数据库类
    /// </summary>
    public class SqlHelper
    {
        private SqlHelper() { }

        public static readonly string sqlConn = "server=192.168.242.128;uid=sa;pwd=Along123;database=ddlcms;";
        private volatile static SqlHelper Helper = null;
        private static readonly object lockHelper = new object();
        public static SqlHelper CreateHelper()
        {
            if (Helper is null)
            {
                lock (lockHelper)
                {
                    if (Helper is null)
                    {
                        Helper = new SqlHelper();
                    }
                }
            }
            return Helper;
        }


        #region 返回受影响行数
        /// <summary>
        /// 返回受影响行数
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static int GetCount(string _sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(_sql, conn))
                {
                    return comm.ExecuteNonQuery();
                }
            }
        }

        public static int GetCount(SqlCommand _comm)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                try
                {
                    _comm.Connection = conn;
                    return _comm.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// 异步的返回受影响行数
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static async Task<int> GetCountAsync(string _sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand())
                {
                    return await comm.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task<int> GetCountAsync(SqlCommand _comm)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                _comm.Connection = conn;
                int count = await _comm.ExecuteNonQueryAsync();
                return count;
            }
        }

        #endregion

        #region 返回1行列值
        /// <summary>
        /// 返回第一个的值
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static object GetValue(string _sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(_sql, conn))
                {
                    return comm.ExecuteScalar();
                }
            }
        }
        public static object GetValue(SqlCommand _comm)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                _comm.Connection = conn;
                return _comm.ExecuteScalar();
            }
        }
        /// <summary>
        /// 异步的返回第一个的值
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static async Task<object> GetValueAsync(string _sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(_sql, conn))
                {
                    return await comm.ExecuteScalarAsync();
                }
            }
        }
        public static async Task<object> GetValueAsync(SqlCommand _comm)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                _comm.Connection = conn;
                return await _comm.ExecuteScalarAsync();
            }
        }


        /// <summary>
        /// 返回第一个的字符串
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static string GetStrValue(string _sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(_sql, conn))
                {
                    return Convert.ToString(comm.ExecuteScalar());
                }
            }
        }
        public static string GetStrValue(SqlCommand _comm)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                _comm.Connection = conn;
                return Convert.ToString(_comm.ExecuteScalar());
            }
        }
        /// <summary>
        /// 异步的返回第一个的字符串
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static async Task<string> GetStrValueAsync(string _sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(_sql, conn))
                {
                    return Convert.ToString(await comm.ExecuteScalarAsync());
                }
            }
        }
        public static async Task<string> GetStrValueAsync(SqlCommand _comm)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                _comm.Connection = conn;
                return Convert.ToString(await _comm.ExecuteScalarAsync());
            }
        }

        /// <summary>
        /// 返回第一个的数值
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static int GetIntValue(string _sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(_sql, conn))
                {
                    return Convert.ToInt32(comm.ExecuteScalar());
                }
            }
        }
        public static int GetIntValue(SqlCommand _comm)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                _comm.Connection = conn;
                return Convert.ToInt32(_comm.ExecuteScalar());
            }
        }
        /// <summary>
        /// 异步的返回第一个的数值
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static async Task<int> GetIntValueAsync(string _sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(_sql, conn))
                {
                    return Convert.ToInt32(await comm.ExecuteScalarAsync());
                }
            }
        }
        public static async Task<int> GetIntValueAsync(SqlCommand _comm)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                _comm.Connection = conn;
                return Convert.ToInt32(await _comm.ExecuteScalarAsync());
            }
        }


        /// <summary>
        /// 返回第一个的小鼠
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static double GetDoubleValue(string _sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(_sql, conn))
                {
                    return Convert.ToDouble(comm.ExecuteScalar());
                }
            }
        }
        public static double GetDoubleValue(SqlCommand _comm)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                _comm.Connection = conn;
                return Convert.ToDouble(_comm.ExecuteScalar());
            }
        }
        /// <summary>
        /// 异步的返回第一个的小数
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static async Task<double> GetDoubleValueAsync(string _sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(_sql, conn))
                {
                    return Convert.ToDouble(await comm.ExecuteScalarAsync());
                }
            }
        }
        public static async Task<double> GetDoubleValueAsync(SqlCommand _comm)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                _comm.Connection = conn;
                return Convert.ToDouble(await _comm.ExecuteScalarAsync());
            }
        }


        /// <summary>
        /// 返回第一个的布尔值
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static bool GetBoolValue(string _sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(_sql, conn))
                {
                    return Convert.ToBoolean(comm.ExecuteScalar());
                }
            }
        }
        public static bool GetBoolValue(SqlCommand _comm)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                _comm.Connection = conn;
                return Convert.ToBoolean(_comm.ExecuteScalar());
            }
        }
        /// <summary>
        /// 异步的返回第一个的布尔值
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static async Task<bool> GetBoolValueAsync(string _sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(_sql, conn))
                {
                    return Convert.ToBoolean(await comm.ExecuteScalarAsync());
                }
            }
        }
        public static async Task<bool> GetBoolValueAsync(SqlCommand _comm)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                _comm.Connection = conn;
                return Convert.ToBoolean(await _comm.ExecuteScalarAsync());
            }
        }

        #endregion

        #region  返回DATATABLE
        /// <summary>
        /// 返回一个datatable
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static DataTable GetDt(string _sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(_sql, conn))
                {
                    try
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (dt != null)
                        {
                            dt.Dispose();
                        }
                    }
                }
            }
        }
        #endregion

        #region 返回DATASET
        /// <summary>
        /// 返回一个dataset
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static DataSet GetDs(string _sql)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                conn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(_sql, conn))
                {
                    try
                    {
                        sda.Fill(ds);
                        return ds;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (ds != null)
                        {
                            ds.Dispose();
                        }
                    }
                }
            }
        }

        #endregion

        #region 数据库参数操作
        /// <summary>
        /// 快速的对查询字符串上参数
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public static SqlCommand CommToModelPara(object _obj)
        {
            try
            {
                var comm = new SqlCommand();
                foreach (PropertyInfo p in _obj.GetType().GetProperties())
                {
                    comm.Parameters.Add(new SqlParameter(string.Format("@{0}", p.Name), p.GetValue(_obj)));
                }
                return comm;
            }
            catch
            {
                return new SqlCommand();
            }
        }
        /// <summary>
        /// 快速的对模型赋值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objmodel"></param>
        /// <param name="dtRow"></param>
        /// <returns></returns>
        public static T TableRowToModel<T>(T objmodel, DataRow dtRow)
        {
            //获取model的类型
            Type modelType = typeof(T);
            //获取model中的属性
            PropertyInfo[] modelpropertys = modelType.GetProperties();
            //遍历model每一个属性并赋值DataRow对应的列
            foreach (PropertyInfo pi in modelpropertys)
            {
                //获取属性名称
                String name = pi.Name;
                if (dtRow.Table.Columns.Contains(name))
                {
                    //非泛型
                    if (!pi.PropertyType.IsGenericType)
                    {
                        pi.SetValue(objmodel, string.IsNullOrEmpty(dtRow[name].ToString()) ? null : Convert.ChangeType(dtRow[name], pi.PropertyType), null);
                    }
                    //泛型Nullable<>
                    else
                    {
                        Type genericTypeDefinition = pi.PropertyType.GetGenericTypeDefinition();
                        //model属性是可为null类型，进行赋null值
                        if (genericTypeDefinition == typeof(Nullable<>))
                        {
                            //返回指定可以为 null 的类型的基础类型参数
                            pi.SetValue(objmodel, string.IsNullOrEmpty(dtRow[name].ToString()) ? null : Convert.ChangeType(dtRow[name], Nullable.GetUnderlyingType(pi.PropertyType)), null);
                        }
                    }
                }
            }
            return objmodel;
        }



        #endregion







    }
}
