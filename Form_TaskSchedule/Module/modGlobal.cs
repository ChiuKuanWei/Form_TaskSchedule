using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_TaskSchedule.Module
{
    public class modGlobal
    {
        #region Func.:Layouts 設定DataGridView顯示格式
        public static void Layouts(DataGridView dgSelect, Color BackgroundColor, Color RowsBackColor, Color AlternatebackColor, Boolean AutoGenerateColumns, Color HeaderColor, Boolean HeaderVisual, Boolean RowHeadersVisible, Boolean AllowUserToAddRows, Color HeaderForeColor, int headerHeight)
        {
            //設定欄位寬度調整=自動延展整個顯示區域
            dgSelect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;



            #region 欄位寬度調整說明
            //DataGridViewAutoSizeColumnsMode 定義值來指定要如何調整資料行的寬度。 
            //成員名稱                       說明 
            //AllCells                       資料行寬度調整以適合資料行中的所有儲存格的內容 (包括標題儲存格)。   
            //AllCellsExceptHeader           資料行寬度調整以適合資料行中的所有儲存格的內容 (不包括標題儲存格)。   
            //ColumnHeader                   資料行寬度調整以適合資料行行首儲存格的內容。   
            //DisplayedCells                 資料行寬度調整以適合資料行中的所有儲存格的內容 (位在目前顯示在螢幕上的資料列中)，包括標題儲存格。   
            //DisplayedCellsExceptHeader     資料行寬度調整以適合資料行中的所有儲存格的內容 (位在目前顯示在螢幕上的資料列中)，不包括標題儲存格。   
            //Fill                           資料行寬度調整使得所有資料行的寬度可以剛好填滿控制項的顯示區，且必須要使用水平捲動方式，才能讓資料行寬度維持在  DataGridViewColumn.MinimumWidth 屬性值之上。相對的資料行寬度是由相對的  DataGridViewColumn.FillWeight 屬性值所決定。  
            //None                           資料行寬度不會自動調整。   
            #endregion

            //Grid Background Color 
            dgSelect.BackgroundColor = BackgroundColor;

            //Grid Back Color 
            dgSelect.RowsDefaultCellStyle.BackColor = RowsBackColor;

            //GridColumnStylesCollection Alternate Rows Backcolr
            dgSelect.AlternatingRowsDefaultCellStyle.BackColor = AlternatebackColor;

            //Auto generated here set to true or false.
            dgSelect.AutoGenerateColumns = AutoGenerateColumns;
            //dgSelect.DefaultCellStyle.Font = new Font("Verdana", 10.25f, FontStyle.Regular);
            //dgSelect.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            //Column Header Back Color
            dgSelect.ColumnHeadersDefaultCellStyle.BackColor = HeaderColor;
            dgSelect.ColumnHeadersDefaultCellStyle.ForeColor = HeaderForeColor;
            dgSelect.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 12);
            dgSelect.ColumnHeadersHeight = headerHeight;
            dgSelect.DefaultCellStyle.Font = new Font("微軟正黑體", 12);
            //Header Visisble
            dgSelect.EnableHeadersVisualStyles = HeaderVisual;

            //Row Header Back Color
            dgSelect.RowHeadersDefaultCellStyle.BackColor = HeaderColor;

            // to Hide the Last Empty row here we use false.
            dgSelect.AllowUserToAddRows = AllowUserToAddRows;

            //設定選取時的顏色
            dgSelect.DefaultCellStyle.SelectionBackColor = Color.Green;
        }
        #endregion
    }
}
