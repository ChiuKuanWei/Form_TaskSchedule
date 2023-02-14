using Form_TaskSchedule.Module;
using Form_TaskSchedule.Moudle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_TaskSchedule
{
    public partial class frm_NotifySet : Form
    {
        /// <summary>
        /// 控制項狀態
        /// </summary>
        private string StatusType = "Initial";

        /// <summary>
        /// DataGridView選取當前列索引
        /// </summary>
        private int iDGVRowIndex = 0;

        /// <summary>
        /// 選取推播Token
        /// </summary>
        public string sToken = "";

        public frm_NotifySet()
        {
            InitializeComponent();
        }

        private void frm_NotifySet_Load(object sender, EventArgs e)
        {
            #region 1.  Checked DKDMS.exe Execution
            //取得此process的名稱
            String name = Process.GetCurrentProcess().ProcessName;
            //取得所有與目前process名稱相同的process
            Process[] ps = Process.GetProcessesByName(name);
            //ps.Length > 1 表示此proces已重複執行
            if (ps.Length > 1)
            {
                System.Environment.Exit(System.Environment.ExitCode);
            }
            #endregion
            
            SetControlsStatus("Initial");  
        }

        private void ShowData()
        {
            DataTable dt = new DataTable();           
            dt = frm_NotifySet_Module.Table_Date_Show(@"SELECT * FROM [TaskSchedule_DB].[dbo].[Table_Notify] order by [Create_DateTime] DESC");
            dgv_Data.DataSource = dt;
            dgv_Data.Columns["ID"].HeaderText = "群組編號";
            dgv_Data.Columns["Group_Name"].HeaderText = "群組名稱";
            dgv_Data.Columns["Group_Token"].HeaderText = "群組Token";
            dgv_Data.Columns["Create_DateTime"].HeaderText = "建立時間";
            #region 在Datatable加入checkbox
            DataColumn dtcCheck = new DataColumn("選擇");
            dtcCheck.DataType = Type.GetType("System.Boolean");
            dtcCheck.DefaultValue = false;
            dt.Columns.Add(dtcCheck);
            dgv_Data.Columns["選擇"].DisplayIndex = 0;
            #endregion

            foreach (DataGridViewColumn col in dgv_Data.Columns)
            {
                //設定欄位不能切換排序
                col.SortMode = DataGridViewColumnSortMode.NotSortable;    
                col.ReadOnly = true;
            }
            modGlobal.Layouts(dgv_Data, Color.LightSteelBlue, Color.AliceBlue, Color.LightSkyBlue, false, Color.SteelBlue, false, false, false, Color.White, 40);
            switch (StatusType)
            {
                case "Initial":
                case "Insert":
                    if (dgv_Data.Rows.Count != 0)
                    {
                        dgv_Data.CurrentCell = dgv_Data.Rows[0].Cells[0];
                        iDGVRowIndex = dgv_Data.CurrentRow.Index;
                        txt_GroupName.Text = dgv_Data.Rows[0].Cells["Group_Name"].Value.ToString();
                        txt_Token.Text = dgv_Data.Rows[0].Cells["Group_Token"].Value.ToString();
                    }                                      
                    break;
                case "Update":
                    dgv_Data.CurrentCell = dgv_Data.Rows[iDGVRowIndex].Cells[0];
                    txt_GroupName.Text = dgv_Data.Rows[iDGVRowIndex].Cells["Group_Name"].Value.ToString();
                    txt_Token.Text = dgv_Data.Rows[iDGVRowIndex].Cells["Group_Token"].Value.ToString();
                    break;
                case "Delete":
                    iDGVRowIndex = iDGVRowIndex - 1;
                    if(iDGVRowIndex < 0)
                    {
                        if(dgv_Data.Rows.Count != 0)
                        {
                            dgv_Data.CurrentCell = dgv_Data.Rows[0].Cells[0];
                            iDGVRowIndex = dgv_Data.CurrentRow.Index;
                            txt_GroupName.Text = dgv_Data.Rows[0].Cells["Group_Name"].Value.ToString();
                            txt_Token.Text = dgv_Data.Rows[0].Cells["Group_Token"].Value.ToString();
                        }
                        else
                        {
                            txt_GroupName.Text = "";
                            txt_Token.Text = "";
                        }
                    }
                    else
                    {
                        dgv_Data.CurrentCell = dgv_Data.Rows[iDGVRowIndex].Cells[0];
                        txt_GroupName.Text = dgv_Data.Rows[iDGVRowIndex].Cells["Group_Name"].Value.ToString();
                        txt_Token.Text = dgv_Data.Rows[iDGVRowIndex].Cells["Group_Token"].Value.ToString();
                    }
                    StatusType = "Initial";
                    break;
            }
        }

        private void frm_NotifySet_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(DialogResult != DialogResult.OK)
            {
                DialogResult = DialogResult.No;
            }
            
        }

        #region 切換控制元件狀態
        /// <summary>
        /// 切換控制元件狀態
        /// </summary>
        /// <param name="strType"></param>
        private void SetControlsStatus(string strType)
        {
            switch (strType)
            {
                case "Initial":
                    foreach (TextBox tb in pnl_Top.Controls.OfType<TextBox>())
                    {
                        tb.ReadOnly = true;
                    }

                    btn_Add.Enabled = true;
                    btn_Update.Enabled = true;
                    btn_Delete.Enabled = true;
                    btn_Cancel.Enabled = false;
                    btn_Add.Text = "新增";
                    btn_Update.Text = "修改";
                    ShowData();
                    break;
                case "Insert":
                    foreach (TextBox tb in pnl_Top.Controls.OfType<TextBox>())
                    {
                        tb.ReadOnly = false;
                        tb.Text = string.Empty;
                    }
                    
                    btn_Update.Enabled = false;
                    btn_Delete.Enabled = false;
                    btn_Cancel.Enabled = true;
                    txt_GroupName.Focus();
                    btn_Add.Text = "儲存";
                    break;
                case "Update":
                    txt_Token.ReadOnly = false;                   
                    btn_Add.Enabled = false;
                    btn_Delete.Enabled = false;
                    btn_Cancel.Enabled = true;
                    btn_Update.Text = "儲存";
                    break;
            }
            StatusType = strType;
        }
        #endregion

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (StatusType == "Initial")
            {
                SetControlsStatus("Insert");
            }
            else
            {
                #region 判斷TextBox是否為空值
                if (txt_GroupName.Text == "")
                {
                    MessageBox.Show("請輸入群組名稱!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_GroupName.Focus();
                    txt_GroupName.SelectAll();
                    return;
                }
                if (txt_Token.Text == "")
                {
                    MessageBox.Show("請輸入群組Token!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Token.Focus();
                    txt_Token.SelectAll();
                    return;
                }               
                #endregion             

                Boolean bInsert = frm_NotifySet_Module.AddNew(txt_GroupName.Text.Trim(), txt_Token.Text.Trim());
                if (bInsert)
                {
                    MessageBox.Show("新增成功!" , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
 
                SetControlsStatus("Initial");                             
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (dgv_Data.RowCount > 0)
            {
                if (StatusType == "Initial")
                {
                    SetControlsStatus("Update");
                }
                else
                {                  
                    if (txt_Token.Text == "")
                    {
                        MessageBox.Show("請輸入群組Token!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_Token.Focus();
                        txt_Token.SelectAll();
                        return;
                    }
                                   

                    Boolean bUpdate = frm_NotifySet_Module.UpdateNew(dgv_Data.CurrentRow.Cells["ID"].Value.ToString(), txt_Token.Text.Trim());
                    if (bUpdate)
                    {
                        MessageBox.Show("修改成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    SetControlsStatus("Initial");
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            SetControlsStatus("Initial");
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_Data.RowCount > 0)
            {               
                DialogResult result = MessageBox.Show("確認刪除?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    StatusType = "Delete";
                    Boolean bDelete = frm_NotifySet_Module.Delete(dgv_Data.CurrentRow.Cells["ID"].Value.ToString());
                    if (bDelete)
                    {
                        MessageBox.Show("刪除成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);                                            
                    }
                    ShowData();
                }
            }
        }

        private void dgv_Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            iDGVRowIndex = dgv_Data.CurrentRow.Index;
            txt_GroupName.Text = dgv_Data.CurrentRow.Cells["Group_Name"].Value.ToString();
            txt_Token.Text = dgv_Data.CurrentRow.Cells["Group_Token"].Value.ToString();
        }

        private void dgv_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)  //因原本checkbox欄位索引在4，只是我用DisplayIndex把此欄位索引變為0
            {
                dgv_Data.EndEdit();
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgv_Data.CurrentRow.Cells["選擇"];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (!flag)
                {
                    DialogResult result = MessageBox.Show("確認選擇此推播群組?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        sToken = dgv_Data.CurrentRow.Cells["Group_Token"].Value.ToString();
                        DialogResult = DialogResult.OK;
                    }
                }              
            }
        }
    }
}
