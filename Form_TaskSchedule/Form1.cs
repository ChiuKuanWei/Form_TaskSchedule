using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Form_TaskSchedule.Moudle;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Threading;
using System.Net;
using System.IO;
using WMPLib;
using Form_TaskSchedule.Module;

namespace Form_TaskSchedule
{
    public partial class Form1 : Form
    {
        #region 移動表單位置變數
        bool beginMove = false;  //初始化鼠标位置
        int currentXPosition = 0;  //當前表單X位置
        int currentYPosition = 0;  //當前表單Y位置
        #endregion

        /// <summary>
        /// 偵測是否已播放鈴聲
        /// </summary>
        private Boolean bPlayer = false;

        public Form1()
        {
            InitializeComponent();
            this.gB_Process.Paint += groupBox_Paint;
            this.gB_CountDown.Paint += groupBox_Paint;
            this.gB_Date.Paint += groupBox_Paint;
            this.gB_Action.Paint += groupBox_Paint;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label_Title.Text += " Ver:" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString();  //取得版本號
            lbl_Status.Text = "就緒!";

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd tt HH:mm:ss";
            dateTimePicker1.Value = DateTime.Now;

            // -------------- 檢查是否有設定鎖定時間(倒數) -----------------
            DataTable _dt = new DataTable();
            _dt = SQLData_Module.Table_Date_Show(@"SELECT * FROM [TaskSchedule_DB].[dbo].[Table_Date] where [Col_Note] ='倒數處理'");
            if (_dt != null && _dt.Rows.Count != 0)
            {
                txt_Day.Text = _dt.Rows[0]["Col_Date"].ToString();
                txt_Hour.Text = _dt.Rows[0]["Col_Hour"].ToString();
                txt_Minute.Text = _dt.Rows[0]["Col_Minute"].ToString();
                txt_Second.Text = _dt.Rows[0]["Col_Second"].ToString();
            }
            // -------------------------------------------------------

            // -------------- 檢查是否有設定鎖定時間(日期) -----------------
            //_dt = frm_NotifySet.Table_Date_Show(@"SELECT * FROM [TaskSchedule_DB].[dbo].[Table_Date] where [Col_Note] ='日期處理'");
            //if (_dt != null && _dt.Rows.Count != 0)
            //{
            //    string sDay = _dt.Rows[0]["Col_Date"].ToString();
            //    string sHour = _dt.Rows[0]["Col_Hour"].ToString();
            //    string sMinute = _dt.Rows[0]["Col_Minute"].ToString();
            //    string sSecond = _dt.Rows[0]["Col_Second"].ToString();
            //    dateTimePicker1.Value = Convert.ToDateTime(sDay + " " + sHour + ":" + sMinute + ":" + sSecond);
            //}
            // -------------------------------------------------------
        }

        /// <summary>
        /// 設定GroupBox邊線顏色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void groupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gBox = (GroupBox)sender;
            e.Graphics.Clear(gBox.BackColor);
            e.Graphics.DrawString(gBox.Text, gBox.Font, Brushes.Black, 10, 1);
            var vSize = e.Graphics.MeasureString(gBox.Text, gBox.Font);  //{Width = 105.125 Height = 21.1874981}
            e.Graphics.DrawLine(Pens.Black, 1, vSize.Height / 2, 8, vSize.Height / 2);  //左上線
            e.Graphics.DrawLine(Pens.Black, vSize.Width + 8, vSize.Height / 2, gBox.Width - 2, vSize.Height / 2);  //右上線
            e.Graphics.DrawLine(Pens.Black, 1, vSize.Height / 2, 1, gBox.Height - 2);  //左線
            e.Graphics.DrawLine(Pens.Black, 1, gBox.Height - 2, gBox.Width - 2, gBox.Height - 2);  //底線
            e.Graphics.DrawLine(Pens.Black, gBox.Width - 2, vSize.Height / 2, gBox.Width - 2, gBox.Height - 2);  //右線
        }

        /// <summary>
        /// 關閉表單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        /// <summary>
        /// 縮放視窗大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_WindowState_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }

        }

        #region 移動表單位置(參考網址:https://blog.csdn.net/weixin_44634727/article/details/109142673)
        /// <summary>
        /// 獲取鼠標按下時的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = e.Location.X;
                currentYPosition = e.Location.Y;
                beginMove = true;
            }
        }

        /// <summary>
        /// 獲取鼠標移動到的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                this.Left += e.Location.X - currentXPosition;  //根據鼠標x坐標確定窗體的左邊坐標x
                this.Top += e.Location.Y - currentYPosition;  //根據鼠標的y坐標窗體的頂部，即Y坐標
            }
        }

        /// <summary>
        /// 釋放鼠標時的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //回初始狀態
                beginMove = false;
            }
        }

        #endregion

        private void timer_DateTime_Tick(object sender, EventArgs e)
        {
            toolStrip_DateTime.Text = "目前時間 : " + DateTime.Now.ToString("yyyy/MM/dd tt HH:mm:ss");
        }

        #region 選項切換設定區

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_Remainder1.Enabled = true;
                txt_Remainder1.Focus();
            }
            else
            {
                txt_Remainder1.Text = "";
                txt_Remainder1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txt_Remainder2.Enabled = true;
                txt_Remainder2.Focus();
                //btn_Music.Enabled = true;
            }
            else
            {
                txt_Remainder2.Text = "";
                txt_Remainder2.Enabled = false;
                //btn_Music.Enabled = false;
            }
        }

        private void rB_CountDown_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_CountDown.Checked)
            {
                gB_CountDown.Enabled = true;
            }
            else
            {
                //資料庫連線
                gB_CountDown.Enabled = false;
            }
        }

        private void rB_Date_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_Date.Checked)
            {
                gB_Date.Enabled = true;
            }
            else
            {
                //資料庫連線
                gB_Date.Enabled = false;
            }
        }

        #endregion

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Boolean bSet = false;  //是否有設定排程時間
            if (btn_Start.Text == "開始執行")
            {
                Boolean bAction = false;  //檢查是否有選擇動作
                foreach (RadioButton RB in gB_Action.Controls.OfType<RadioButton>())
                {
                    if (RB.Checked)
                    {
                        if (RB.Name == "rB_Notify")
                        {
                            if (txt_Content.Text == "")
                            {
                                MessageBox.Show("請輸入推播訊息!", "工作排程系統", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txt_Content.Focus();
                                return;
                            }
                        }
                        bAction = true;
                        break;
                    }
                }
                if (!bAction)
                {
                    MessageBox.Show("請勾選動作區域!", "工作排程系統", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (rB_CountDown.Checked)
                {
                    foreach (TextBox TB in gB_CountDown.Controls.OfType<TextBox>())
                    {
                        if (TB.Text.Trim().Length != 2)
                        {
                            MessageBox.Show("輸入格式必須為2位數!", "工作排程系統", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TB.Focus();
                            TB.SelectAll();
                            return;
                        }
                    }
                    foreach (TextBox TB in gB_CountDown.Controls.OfType<TextBox>())
                    {
                        if (TB.Text != "00")
                        {
                            bSet = true;
                        }
                    }

                    if (bSet)
                    {
                        timer_CountDown.Enabled = true;
                        foreach (TextBox TB in gB_CountDown.Controls.OfType<TextBox>())
                        {
                            TB.ReadOnly = true;
                        }
                        btn_Lock.Enabled = false;
                        btn_Reset.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("請設定好倒數時間!", "工作排程系統", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (rB_Date.Checked)
                {
                    timer_Date.Enabled = true;
                    dateTimePicker1.Enabled = false;
                    btn_Locks.Enabled = false;
                    btn_Resets.Enabled = false;
                }
               
                gB_Process.Enabled = false;
                gB_Action.Enabled = false;
                gB_Else.Enabled = false;
                lbl_Status.Text = "執行中...";
                btn_Start.Text = "取消執行";
                if (checkBox2.Checked)
                {
                    bPlayer = false;
                }
            }
            else
            {
                if (rB_CountDown.Checked)
                {
                    timer_CountDown.Enabled = false;
                    foreach (TextBox TB in gB_CountDown.Controls.OfType<TextBox>())
                    {
                        TB.ReadOnly = false;
                    }
                    btn_Lock.Enabled = true;
                    btn_Reset.Enabled = true;
                }

                if (rB_Date.Checked)
                {
                    timer_Date.Enabled = false;
                    dateTimePicker1.Enabled = true;
                    btn_Locks.Enabled = true;
                    btn_Resets.Enabled = true;
                }

                gB_Process.Enabled = true;
                gB_Action.Enabled = true;
                gB_Else.Enabled = true;
                lbl_Status.Text = "就緒!";
                btn_Start.Text = "開始執行";
                this.TopMost = false;
            }
        }

        // ------------------------------------- 倒數處理區 ------------------------------------------------
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            foreach (TextBox tB in gB_CountDown.Controls.OfType<TextBox>())
            {
                tB.Text = "00";
            }
        }

        private void btn_Lock_Click(object sender, EventArgs e)
        {
            foreach (TextBox TB in gB_CountDown.Controls.OfType<TextBox>())
            {
                if (TB.Text.Trim().Length != 2)
                {
                    MessageBox.Show("輸入格式必須為2位數!", "工作排程系統", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TB.Focus();
                    TB.SelectAll();
                    return;
                }
            }
            DataTable _dt = new DataTable();
            _dt = SQLData_Module.Table_Date_Show(@"SELECT * FROM [TaskSchedule_DB].[dbo].[Table_Date] where [Col_Note] ='倒數處理'");
            if (_dt != null && _dt.Rows.Count == 0)
            {
                if (SQLData_Module.AddNew(txt_Day.Text.Trim(), txt_Hour.Text.Trim(), txt_Minute.Text.Trim(), txt_Second.Text.Trim(), "倒數處理"))
                {
                    MessageBox.Show("鎖定時間成功!", "工作排程系統", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (_dt != null && _dt.Rows.Count != 0)
            {
                if (SQLData_Module.UpdateNew(txt_Day.Text.Trim(), txt_Hour.Text.Trim(), txt_Minute.Text.Trim(), txt_Second.Text.Trim(), "倒數處理"))
                {
                    MessageBox.Show("鎖定時間成功!", "工作排程系統", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void timer_CountDown_Tick(object sender, EventArgs e)
        {
            timer_CountDown.Stop();

            if (txt_Second.Text == "00")
            {
                if (txt_Minute.Text != "00")
                {
                    txt_Second.Text = "59";
                    int iMinute = Int32.Parse(txt_Minute.Text);
                    iMinute--;
                    txt_Minute.Text = iMinute.ToString("d2");
                }
                else
                {
                    if (txt_Hour.Text != "00")
                    {
                        txt_Second.Text = "59";
                        txt_Minute.Text = "59";
                        int iHour = Int32.Parse(txt_Hour.Text);
                        iHour--;
                        txt_Hour.Text = iHour.ToString("d2");
                    }
                    else
                    {
                        if (txt_Day.Text != "00")
                        {
                            txt_Hour.Text = "23";
                            txt_Second.Text = "59";
                            txt_Minute.Text = "59";
                            int iDay = Int32.Parse(txt_Day.Text);
                            iDay--;
                            txt_Day.Text = iDay.ToString("d2");
                        }
                        else
                        {
                            //執行倒數完的事情及初始
                            MessageBox.Show("倒數處理完成!", "工作排程系統", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            timer_CountDown.Enabled = false;
                            foreach (TextBox TB in gB_CountDown.Controls.OfType<TextBox>())
                            {
                                TB.ReadOnly = false;
                            }
                            btn_Lock.Enabled = true;
                            btn_Reset.Enabled = true;
                            lbl_Status.Text = "就緒!";
                            btn_Start.Text = "開始執行";
                            return;
                        }
                    }
                }
            }
            else
            {
                int iSecond = Int32.Parse(txt_Second.Text);
                iSecond--;
                txt_Second.Text = iSecond.ToString("d2");
            }

            timer_CountDown.Start();
        }

        #region TextBox只能輸入數字設定
        private void txt_Day_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只讓使用者輸入數字
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_Hour_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只讓使用者輸入數字
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_Minute_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只讓使用者輸入數字
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_Second_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只讓使用者輸入數字
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        #endregion

        // -------------------------------------------------------------------------------------------------

        // ------------------------------------- 日期處理區 ------------------------------------------------
        private void btn_Resets_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd tt HH:mm:ss";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btn_Locks_Click(object sender, EventArgs e)
        {
            DataTable _dt = new DataTable();
            _dt = SQLData_Module.Table_Date_Show(@"SELECT * FROM [TaskSchedule_DB].[dbo].[Table_Date] where [Col_Note] ='日期處理'");
            if (_dt != null && _dt.Rows.Count == 0)
            {
                if (SQLData_Module.AddNew(dateTimePicker1.Value.ToString("yyyy/MM/dd tt"), dateTimePicker1.Value.ToString("HH"), dateTimePicker1.Value.ToString("mm"), dateTimePicker1.Value.ToString("ss"), "日期處理"))
                {
                    MessageBox.Show("鎖定時間成功!", "工作排程系統", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (_dt != null && _dt.Rows.Count != 0)
            {
                if (SQLData_Module.UpdateNew(dateTimePicker1.Value.ToString("yyyy/MM/dd tt"), dateTimePicker1.Value.ToString("HH"), dateTimePicker1.Value.ToString("mm"), dateTimePicker1.Value.ToString("ss"), "日期處理"))
                {
                    MessageBox.Show("鎖定時間成功!", "工作排程系統", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void timer_Date_Tick(object sender, EventArgs e)
        {
            timer_Date.Stop();

            DateTime dt1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            DateTime dt2 = DateTime.Parse(dateTimePicker1.Text.Substring(0, dateTimePicker1.Text.LastIndexOf(':')));   //2023/02/08 下午 21:10:40
            TimeSpan ts = dt2.Subtract(dt1);
            double Mins = Math.Floor(ts.TotalMinutes);  //分鐘取整數

            if (checkBox1.Checked)  //視窗至頂
            {
                double dMin = Convert.ToDouble(txt_Remainder1.Text.Trim());
                if(Mins == dMin)
                {
                    this.TopMost = true;
                }
            }

            if (checkBox2.Checked)  //視窗至頂
            {
                double dMin2 = Convert.ToDouble(txt_Remainder2.Text.Trim());
                if (Mins == dMin2)
                {                  
                    if (!bPlayer)
                    {
                        MP3Player.PlayMusic(Application.StartupPath + "\\叮咚.mp3");
                        bPlayer = true;
                    }                   
                }
            }

            if (DateTime.Now.ToString("yyyy/MM/dd tt HH:mm:ss") == dateTimePicker1.Text)
            {
                //執行倒數完的事情及初始               

                foreach (RadioButton RB in gB_Action.Controls.OfType<RadioButton>())
                {
                    if (RB.Checked)
                    {
                        if (RB.Text == "關機")
                        {
                            Shutdown();
                        }
                        if (RB.Text == "重新開機")
                        {
                            Restart();
                        }
                        if (RB.Text == "睡眠")
                        {
                            dateTimePicker1.Enabled = true;
                            btn_Locks.Enabled = true;
                            btn_Resets.Enabled = true;
                            gB_Process.Enabled = true;
                            gB_Action.Enabled = true;
                            gB_Else.Enabled = true;
                            lbl_Status.Text = "就緒!";
                            btn_Start.Text = "開始執行";
                            this.TopMost = false;
                            Sleep();
                        }
                        if (RB.Text == "執行群組推播")
                        {
                            if (SendMessage(txt_Content.Text.Trim(), txt_Notify.Text.Trim()))
                            {
                                MessageBox.Show("推播訊息成功!", "工作排程系統", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            dateTimePicker1.Enabled = true;
                            btn_Locks.Enabled = true;
                            btn_Resets.Enabled = true;
                            gB_Process.Enabled = true;
                            gB_Action.Enabled = true;
                            gB_Else.Enabled = true;
                            lbl_Status.Text = "就緒!";
                            btn_Start.Text = "開始執行";
                            this.TopMost = false;
                        }
                        break;
                    }
                }
                return;
            }

            timer_Date.Start();
        }

        // -------------------------------------------------------------------------------------------------

        // ------------------------------------- 動作執行區 ------------------------------------------------

        //執行命令
        private void Exec(string str)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.StandardInput.WriteLine(str + "&exit");
                    process.StandardInput.AutoFlush = true;
                    process.WaitForExit();
                    process.Close();
                }
            }
            catch
            {
            }
        }

        //執行關機
        private void Shutdown()
        {
            Exec("shutdown -s -f -t 5");
        }

        //執行重啟動作
        private void Restart()
        {
            Exec("shutdown -r -f -t 5");
        }

        //執行睡眠
        private void Sleep()
        {
            SetWaitForWakeUpTime();
        }

        [DllImport("kernel32.dll")]
        public static extern SafeWaitHandle CreateWaitableTimer(IntPtr lpTimerAttributes, bool bManualReset, string lpTimerName);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWaitableTimer(SafeWaitHandle hTimer, [In] ref long pDueTime, int lPeriod, IntPtr pfnCompletionRoutine, IntPtr lpArgToCompletionRoutine, bool fResume);

        private void SetWaitForWakeUpTime()
        {
            long duetime = DateTime.Now.AddSeconds(30).ToFileTime();  //一分鐘左右喚醒
            using (SafeWaitHandle handle = CreateWaitableTimer(IntPtr.Zero, true, "Waitabletimer"))
            {
                if (SetWaitableTimer(handle, ref duetime, 0, IntPtr.Zero, IntPtr.Zero, true))
                {
                    using (EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.AutoReset))
                    {
                        wh.SafeWaitHandle = handle;
                        Application.SetSuspendState(PowerState.Suspend, true, false);
                        wh.WaitOne();
                    }
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
        }

        private void btn_Review_Click(object sender, EventArgs e)
        {
            frm_NotifySet _frm_NotifySet = new frm_NotifySet();
            _frm_NotifySet.StartPosition = FormStartPosition.CenterScreen;
            if(_frm_NotifySet.ShowDialog() == DialogResult.OK)
            {
                txt_Notify.Text = _frm_NotifySet.sToken;
                rB_Notify.Checked = true;
                txt_Content.Focus();
            }
        }

        /// <summary>
        /// 傳送訊息至LINE推播
        /// </summary>
        /// <param name="sMessage">傳送訊息</param>
        /// <param name="sToken">Token驗證碼</param>
        /// <returns></returns>
        private Boolean SendMessage(string sMessage, string sToken)
        {
            try
            {
                string url = "https://notify-api.line.me/api/notify";
                //要傳送的文字內容
                string postData = "message=" + WebUtility.HtmlEncode("\r\n" + sMessage);
                //string postData = "imageFile=" + WebUtility.HtmlEncode("\r\n" + message);            
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                Uri target = new Uri(url);
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                //System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebRequest request = WebRequest.Create(target);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                request.Headers.Add("Authorization", "Bearer " + sToken);

                using (var dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                //取得響應
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();//回傳JSON
                responseString = "[" + responseString + "]";
                //取得目前剩餘發送數量
                String str = string.Empty;
                for (int i = 0; i < response.Headers.Keys.Count; i++)
                {
                    str += response.Headers.Keys[i] + ":" + response.Headers.Get(i) + "\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("推播訊息異常，請檢查權杖碼設定是否正確或者是沒申請權杖碼給群組:" + ex.Message , "工作排程系統", MessageBoxButtons.OK , MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void rB_Notify_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_Notify.Checked)
            {
                if(txt_Notify.Text == "")
                {
                    btn_Review.PerformClick();
                }               
            }
            else
            {
                txt_Notify.Text = "";
                txt_Content.Text = "";
            }
        }

        // -------------------------------------------------------------------------------------------------
    }
}

