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
    public static class frm_NotifySet_Module
    {
        static string sCONN = ConfigurationManager.ConnectionStrings["DB_CON"].ToString();


        #region 載入資料庫內容
        /// <summary>
        /// 載入資料庫內容
        /// </summary>
        /// <param name="sCMD"></param>
        public static DataTable Table_Date_Show(string sCMD)
        {
            DataTable _dt = new DataTable();

            try
            {
                using (SqlConnection _sqlconn = new SqlConnection(sCONN))
                {
                    _sqlconn.Open();
                    SqlDataAdapter _Adapter = new SqlDataAdapter(sCMD, _sqlconn);
                    _Adapter.Fill(_dt);
                    if (_sqlconn.State == ConnectionState.Open) _sqlconn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("搜索資料庫失敗:" + ex.Message, "群組推播維護", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return _dt;
        }
        #endregion

        #region 檢查群組名稱是否已存在資料庫裡
        /// <summary>
        /// 檢查產品編號是否已存在資料庫裡
        /// </summary>
        /// <param name="sProductNo">產品編號</param>
        /// <returns></returns>
        public static int Check_GroupName(string sGroupName)
        {
            var sqlQuery = @"select * FROM [TaskSchedule_DB].[dbo].[Table_Notify] where [Group_Name] = '" + sGroupName + "'";
            DataTable _dt = new DataTable();
            try
            {
                using (SqlConnection _sqlconn = new SqlConnection(sCONN))
                {
                    _sqlconn.Open();
                    SqlDataAdapter _adapter = new SqlDataAdapter(sqlQuery, _sqlconn);
                    _adapter.Fill(_dt);
                    _sqlconn.Close();
                }
                if (_dt.Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("檢查群組名稱是否已存在失敗:" + ex.Message, "群組推播維護", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        #endregion       

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sGroupName">群組名稱</param>
        /// <param name="sGroupToken">群組Token</param>
        /// <returns></returns>
        public static Boolean AddNew(string sGroupName, string sGroupToken)
        {
            var sqlQuery = @"INSERT INTO [TaskSchedule_DB].[dbo].[Table_Notify]([Group_Name],[Group_Token],[Create_DateTime])
                             VALUES(@Group_Name,@Group_Token,@Create_DateTime)";

            int iRepeat = Check_GroupName(sGroupName);

            if (iRepeat == 1)
            {
                MessageBox.Show("此群組名稱已新增過!", "群組推播維護", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (iRepeat == -1)
            {
                return false;
            }
            else
            {
                try
                {
                    using (SqlConnection _sqlconn = new SqlConnection(sCONN))
                    {
                        _sqlconn.Open();
                        using (SqlCommand cmd = new SqlCommand(sqlQuery, _sqlconn))
                        {
                            cmd.Parameters.AddWithValue("@Group_Name", sGroupName);
                            cmd.Parameters.AddWithValue("@Group_Token", sGroupToken);
                            cmd.Parameters.AddWithValue("@Create_DateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.ExecuteNonQuery();
                        }
                        _sqlconn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("新增失敗:" + ex.Message, "群組推播維護", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sID">群組編號</param>
        /// <param name="sToken">Token碼</param>
        /// <returns></returns>
        public static Boolean UpdateNew(string sID, string sToken)
        {
            var sqlQuery = @"Update [TaskSchedule_DB].[dbo].[Table_Notify] SET [Group_Token]=@Group_Token WHERE [ID]=@ID";

            try
            {
                using (SqlConnection _sqlconn = new SqlConnection(sCONN))
                {
                    _sqlconn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, _sqlconn))
                    {
                        cmd.Parameters.AddWithValue("@ID", sID);
                        cmd.Parameters.AddWithValue("@Group_Token", sToken);                        
                        cmd.ExecuteNonQuery();
                    }
                    _sqlconn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失敗:" + ex.Message, "群組推播維護", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        #region 刪除
        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="sID">群組編號</param>
        /// <returns></returns>
        public static Boolean Delete(string sID)
        {
            var sqlQuery = @"Delete from [TaskSchedule_DB].[dbo].[Table_Notify] where ID = @ID";

            try
            {
                using (SqlConnection _sqlconn = new SqlConnection(sCONN))
                {
                    _sqlconn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, _sqlconn))
                    {
                        cmd.Parameters.AddWithValue("@ID", sID);
                        cmd.ExecuteNonQuery();
                    }
                    _sqlconn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("刪除失敗:" + ex.Message, "群組推播維護", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion       

    }
}
