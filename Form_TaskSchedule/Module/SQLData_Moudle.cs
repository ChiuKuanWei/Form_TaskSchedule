using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_TaskSchedule.Moudle
{
    public static class SQLData_Module
    {

        private static string SQLConn = ConfigurationManager.ConnectionStrings["DB_CON"].ToString();  //資料庫連線

        #region 載入資料庫內容
        /// <summary>
        /// 載入資料庫內容
        /// </summary>
        /// <param name="sCMD">資料庫指令輸入</param>
        public static DataTable Table_Date_Show(string sCMD)
        {
            DataTable _dt = new DataTable();

            try
            {
                using (SqlConnection _sqlconn = new SqlConnection(SQLConn))
                {
                    _sqlconn.Open();
                    SqlDataAdapter _Adapter = new SqlDataAdapter(sCMD, _sqlconn);
                    _Adapter.Fill(_dt);
                    if (_sqlconn.State == ConnectionState.Open) _sqlconn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("搜索資料庫失敗:" + ex.Message , "工作排程系統" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                return null;
            }

            return _dt;
        }
        #endregion

        #region 新增
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sDate">天</param>
        /// <param name="sHour">小時</param>
        /// <param name="sMinute">分鐘</param>
        /// <param name="sSecond">秒</param>
        /// <param name="sNote">處理模式</param>
        /// <returns></returns>
        public static Boolean AddNew(string sDate, string sHour, string sMinute, string sSecond, string sNote)
        {
            var sqlQuery = @"INSERT INTO [TaskSchedule_DB].[dbo].[Table_Date]([Col_Date],[Col_Hour],[Col_Minute],[Col_Second],[Col_Note])
                            VALUES(@Col_Date,@Col_Hour,@Col_Minute,@Col_Second,@Col_Note)";


            try
            {
                using (SqlConnection _sqlconn = new SqlConnection(SQLConn))
                {
                    _sqlconn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, _sqlconn))
                    {
                        cmd.Parameters.AddWithValue("@Col_Date", sDate);
                        cmd.Parameters.AddWithValue("@Col_Hour", sHour);
                        cmd.Parameters.AddWithValue("@Col_Minute", sMinute);
                        cmd.Parameters.AddWithValue("@Col_Second", sSecond);
                        cmd.Parameters.AddWithValue("@Col_Note", sNote);                       
                        cmd.ExecuteNonQuery();
                    }
                    _sqlconn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("鎖定時間失敗:" + ex.Message, "工作排程系統", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion        

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sDate">天</param>
        /// <param name="sHour">小時</param>
        /// <param name="sMinute">分鐘</param>
        /// <param name="sSecond">秒</param>
        /// <param name="sNote">處理模式</param>
        /// <returns></returns>
        public static Boolean UpdateNew(string sDate, string sHour, string sMinute, string sSecond, string sNote)
        {
            var sqlQuery = @"Update [TaskSchedule_DB].[dbo].[Table_Date] SET [Col_Date]=@Col_Date,[Col_Hour]=@Col_Hour,[Col_Minute]=@Col_Minute,[Col_Second]=@Col_Second 
                             WHERE [Col_Note]='" + sNote + "'";           

            try
            {
                using (SqlConnection _sqlconn = new SqlConnection(SQLConn))
                {
                    _sqlconn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, _sqlconn))
                    {
                        cmd.Parameters.AddWithValue("@Col_Date", sDate);
                        cmd.Parameters.AddWithValue("@Col_Hour", sHour);
                        cmd.Parameters.AddWithValue("@Col_Minute", sMinute);
                        cmd.Parameters.AddWithValue("@Col_Second", sSecond);                      
                        cmd.ExecuteNonQuery();
                    }
                    _sqlconn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("鎖定時間失敗:" + ex.Message, "工作排程系統", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion
    }
}
