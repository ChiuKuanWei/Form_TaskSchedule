namespace Form_TaskSchedule
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gB_Process = new System.Windows.Forms.GroupBox();
            this.rB_Date = new System.Windows.Forms.RadioButton();
            this.rB_CountDown = new System.Windows.Forms.RadioButton();
            this.label_Title = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_WindowState = new System.Windows.Forms.Button();
            this.gB_CountDown = new System.Windows.Forms.GroupBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Lock = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Second = new System.Windows.Forms.TextBox();
            this.txt_Minute = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Hour = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Day = new System.Windows.Forms.TextBox();
            this.gB_Date = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn_Resets = new System.Windows.Forms.Button();
            this.btn_Locks = new System.Windows.Forms.Button();
            this.timer_DateTime = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip_DateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.gB_Action = new System.Windows.Forms.GroupBox();
            this.txt_Content = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Notify = new System.Windows.Forms.TextBox();
            this.btn_Review = new System.Windows.Forms.Button();
            this.rB_Notify = new System.Windows.Forms.RadioButton();
            this.rB_Sleep = new System.Windows.Forms.RadioButton();
            this.rB_ReStart = new System.Windows.Forms.RadioButton();
            this.rB_ShutDown = new System.Windows.Forms.RadioButton();
            this.gB_Else = new System.Windows.Forms.GroupBox();
            this.txt_Remainder2 = new System.Windows.Forms.TextBox();
            this.txt_Remainder1 = new System.Windows.Forms.TextBox();
            this.txt_Music = new System.Windows.Forms.TextBox();
            this.btn_Music = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.timer_CountDown = new System.Windows.Forms.Timer(this.components);
            this.timer_Date = new System.Windows.Forms.Timer(this.components);
            this.gB_Process.SuspendLayout();
            this.gB_CountDown.SuspendLayout();
            this.gB_Date.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.gB_Action.SuspendLayout();
            this.gB_Else.SuspendLayout();
            this.SuspendLayout();
            // 
            // gB_Process
            // 
            this.gB_Process.Controls.Add(this.rB_Date);
            this.gB_Process.Controls.Add(this.rB_CountDown);
            this.gB_Process.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gB_Process.Location = new System.Drawing.Point(12, 93);
            this.gB_Process.Name = "gB_Process";
            this.gB_Process.Size = new System.Drawing.Size(542, 89);
            this.gB_Process.TabIndex = 0;
            this.gB_Process.TabStop = false;
            this.gB_Process.Text = "選擇動作方式";
            // 
            // rB_Date
            // 
            this.rB_Date.AutoSize = true;
            this.rB_Date.Location = new System.Drawing.Point(187, 42);
            this.rB_Date.Name = "rB_Date";
            this.rB_Date.Size = new System.Drawing.Size(93, 20);
            this.rB_Date.TabIndex = 1;
            this.rB_Date.Text = "日期處理";
            this.rB_Date.UseVisualStyleBackColor = true;
            this.rB_Date.CheckedChanged += new System.EventHandler(this.rB_Date_CheckedChanged);
            // 
            // rB_CountDown
            // 
            this.rB_CountDown.AutoSize = true;
            this.rB_CountDown.Checked = true;
            this.rB_CountDown.Location = new System.Drawing.Point(37, 42);
            this.rB_CountDown.Name = "rB_CountDown";
            this.rB_CountDown.Size = new System.Drawing.Size(93, 20);
            this.rB_CountDown.TabIndex = 0;
            this.rB_CountDown.TabStop = true;
            this.rB_CountDown.Text = "倒數處理";
            this.rB_CountDown.UseVisualStyleBackColor = true;
            this.rB_CountDown.CheckedChanged += new System.EventHandler(this.rB_CountDown_CheckedChanged);
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("新細明體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Title.ForeColor = System.Drawing.Color.Red;
            this.label_Title.Location = new System.Drawing.Point(12, 36);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(231, 35);
            this.label_Title.TabIndex = 1;
            this.label_Title.Text = "工作排程系統";
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Close.Location = new System.Drawing.Point(1088, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btn_Close.Size = new System.Drawing.Size(34, 37);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.TabStop = false;
            this.btn_Close.Text = "x";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_WindowState
            // 
            this.btn_WindowState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_WindowState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_WindowState.FlatAppearance.BorderSize = 0;
            this.btn_WindowState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_WindowState.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_WindowState.Location = new System.Drawing.Point(1048, 12);
            this.btn_WindowState.Name = "btn_WindowState";
            this.btn_WindowState.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btn_WindowState.Size = new System.Drawing.Size(34, 37);
            this.btn_WindowState.TabIndex = 3;
            this.btn_WindowState.TabStop = false;
            this.btn_WindowState.Text = "-";
            this.btn_WindowState.UseVisualStyleBackColor = false;
            this.btn_WindowState.Click += new System.EventHandler(this.btn_WindowState_Click);
            // 
            // gB_CountDown
            // 
            this.gB_CountDown.Controls.Add(this.btn_Reset);
            this.gB_CountDown.Controls.Add(this.btn_Lock);
            this.gB_CountDown.Controls.Add(this.label4);
            this.gB_CountDown.Controls.Add(this.label3);
            this.gB_CountDown.Controls.Add(this.txt_Second);
            this.gB_CountDown.Controls.Add(this.txt_Minute);
            this.gB_CountDown.Controls.Add(this.label2);
            this.gB_CountDown.Controls.Add(this.txt_Hour);
            this.gB_CountDown.Controls.Add(this.label1);
            this.gB_CountDown.Controls.Add(this.txt_Day);
            this.gB_CountDown.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gB_CountDown.Location = new System.Drawing.Point(12, 199);
            this.gB_CountDown.Name = "gB_CountDown";
            this.gB_CountDown.Size = new System.Drawing.Size(542, 133);
            this.gB_CountDown.TabIndex = 4;
            this.gB_CountDown.TabStop = false;
            this.gB_CountDown.Text = "倒數處理";
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(126, 85);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(93, 28);
            this.btn_Reset.TabIndex = 8;
            this.btn_Reset.Text = "重設時間";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Lock
            // 
            this.btn_Lock.Location = new System.Drawing.Point(27, 85);
            this.btn_Lock.Name = "btn_Lock";
            this.btn_Lock.Size = new System.Drawing.Size(93, 28);
            this.btn_Lock.TabIndex = 7;
            this.btn_Lock.Text = "鎖定時間";
            this.btn_Lock.UseVisualStyleBackColor = true;
            this.btn_Lock.Click += new System.EventHandler(this.btn_Lock_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "秒";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "分";
            // 
            // txt_Second
            // 
            this.txt_Second.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_Second.Location = new System.Drawing.Point(287, 41);
            this.txt_Second.Name = "txt_Second";
            this.txt_Second.Size = new System.Drawing.Size(43, 27);
            this.txt_Second.TabIndex = 5;
            this.txt_Second.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Second.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Second_KeyPress);
            // 
            // txt_Minute
            // 
            this.txt_Minute.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_Minute.Location = new System.Drawing.Point(206, 39);
            this.txt_Minute.Name = "txt_Minute";
            this.txt_Minute.Size = new System.Drawing.Size(43, 27);
            this.txt_Minute.TabIndex = 4;
            this.txt_Minute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Minute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Minute_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "小時";
            // 
            // txt_Hour
            // 
            this.txt_Hour.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_Hour.Location = new System.Drawing.Point(108, 39);
            this.txt_Hour.Name = "txt_Hour";
            this.txt_Hour.Size = new System.Drawing.Size(43, 27);
            this.txt_Hour.TabIndex = 2;
            this.txt_Hour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Hour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Hour_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "天";
            // 
            // txt_Day
            // 
            this.txt_Day.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_Day.Location = new System.Drawing.Point(27, 38);
            this.txt_Day.Name = "txt_Day";
            this.txt_Day.Size = new System.Drawing.Size(43, 27);
            this.txt_Day.TabIndex = 0;
            this.txt_Day.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Day.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Day_KeyPress);
            // 
            // gB_Date
            // 
            this.gB_Date.Controls.Add(this.dateTimePicker1);
            this.gB_Date.Controls.Add(this.btn_Resets);
            this.gB_Date.Controls.Add(this.btn_Locks);
            this.gB_Date.Enabled = false;
            this.gB_Date.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gB_Date.Location = new System.Drawing.Point(12, 352);
            this.gB_Date.Name = "gB_Date";
            this.gB_Date.Size = new System.Drawing.Size(542, 177);
            this.gB_Date.TabIndex = 9;
            this.gB_Date.TabStop = false;
            this.gB_Date.Text = "日期處理";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(27, 55);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(284, 27);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // btn_Resets
            // 
            this.btn_Resets.Location = new System.Drawing.Point(126, 113);
            this.btn_Resets.Name = "btn_Resets";
            this.btn_Resets.Size = new System.Drawing.Size(93, 28);
            this.btn_Resets.TabIndex = 8;
            this.btn_Resets.Text = "重設時間";
            this.btn_Resets.UseVisualStyleBackColor = true;
            this.btn_Resets.Click += new System.EventHandler(this.btn_Resets_Click);
            // 
            // btn_Locks
            // 
            this.btn_Locks.Location = new System.Drawing.Point(27, 113);
            this.btn_Locks.Name = "btn_Locks";
            this.btn_Locks.Size = new System.Drawing.Size(93, 28);
            this.btn_Locks.TabIndex = 7;
            this.btn_Locks.Text = "鎖定時間";
            this.btn_Locks.UseVisualStyleBackColor = true;
            this.btn_Locks.Click += new System.EventHandler(this.btn_Locks_Click);
            // 
            // timer_DateTime
            // 
            this.timer_DateTime.Enabled = true;
            this.timer_DateTime.Tick += new System.EventHandler(this.timer_DateTime_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_DateTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 606);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1143, 29);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip_DateTime
            // 
            this.toolStrip_DateTime.BackColor = System.Drawing.Color.Silver;
            this.toolStrip_DateTime.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStrip_DateTime.Margin = new System.Windows.Forms.Padding(4, 3, 0, 2);
            this.toolStrip_DateTime.Name = "toolStrip_DateTime";
            this.toolStrip_DateTime.Size = new System.Drawing.Size(90, 24);
            this.toolStrip_DateTime.Text = "目前時間:";
            // 
            // gB_Action
            // 
            this.gB_Action.Controls.Add(this.txt_Content);
            this.gB_Action.Controls.Add(this.label5);
            this.gB_Action.Controls.Add(this.txt_Notify);
            this.gB_Action.Controls.Add(this.btn_Review);
            this.gB_Action.Controls.Add(this.rB_Notify);
            this.gB_Action.Controls.Add(this.rB_Sleep);
            this.gB_Action.Controls.Add(this.rB_ReStart);
            this.gB_Action.Controls.Add(this.rB_ShutDown);
            this.gB_Action.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gB_Action.Location = new System.Drawing.Point(570, 93);
            this.gB_Action.Name = "gB_Action";
            this.gB_Action.Size = new System.Drawing.Size(542, 239);
            this.gB_Action.TabIndex = 2;
            this.gB_Action.TabStop = false;
            this.gB_Action.Text = "動作";
            // 
            // txt_Content
            // 
            this.txt_Content.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt_Content.Location = new System.Drawing.Point(155, 195);
            this.txt_Content.Name = "txt_Content";
            this.txt_Content.Size = new System.Drawing.Size(311, 23);
            this.txt_Content.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "推播訊息:";
            // 
            // txt_Notify
            // 
            this.txt_Notify.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt_Notify.Location = new System.Drawing.Point(155, 165);
            this.txt_Notify.Name = "txt_Notify";
            this.txt_Notify.ReadOnly = true;
            this.txt_Notify.Size = new System.Drawing.Size(311, 23);
            this.txt_Notify.TabIndex = 10;
            // 
            // btn_Review
            // 
            this.btn_Review.Location = new System.Drawing.Point(472, 162);
            this.btn_Review.Name = "btn_Review";
            this.btn_Review.Size = new System.Drawing.Size(57, 28);
            this.btn_Review.TabIndex = 9;
            this.btn_Review.Text = "預覽";
            this.btn_Review.UseVisualStyleBackColor = true;
            this.btn_Review.Click += new System.EventHandler(this.btn_Review_Click);
            // 
            // rB_Notify
            // 
            this.rB_Notify.AutoSize = true;
            this.rB_Notify.Location = new System.Drawing.Point(28, 166);
            this.rB_Notify.Name = "rB_Notify";
            this.rB_Notify.Size = new System.Drawing.Size(127, 20);
            this.rB_Notify.TabIndex = 4;
            this.rB_Notify.TabStop = true;
            this.rB_Notify.Text = "執行群組推播";
            this.rB_Notify.UseVisualStyleBackColor = true;
            this.rB_Notify.CheckedChanged += new System.EventHandler(this.rB_Notify_CheckedChanged);
            // 
            // rB_Sleep
            // 
            this.rB_Sleep.AutoSize = true;
            this.rB_Sleep.Location = new System.Drawing.Point(28, 124);
            this.rB_Sleep.Name = "rB_Sleep";
            this.rB_Sleep.Size = new System.Drawing.Size(59, 20);
            this.rB_Sleep.TabIndex = 3;
            this.rB_Sleep.TabStop = true;
            this.rB_Sleep.Text = "睡眠";
            this.rB_Sleep.UseVisualStyleBackColor = true;
            // 
            // rB_ReStart
            // 
            this.rB_ReStart.AutoSize = true;
            this.rB_ReStart.Location = new System.Drawing.Point(28, 83);
            this.rB_ReStart.Name = "rB_ReStart";
            this.rB_ReStart.Size = new System.Drawing.Size(93, 20);
            this.rB_ReStart.TabIndex = 2;
            this.rB_ReStart.TabStop = true;
            this.rB_ReStart.Text = "重新開機";
            this.rB_ReStart.UseVisualStyleBackColor = true;
            // 
            // rB_ShutDown
            // 
            this.rB_ShutDown.AutoSize = true;
            this.rB_ShutDown.Location = new System.Drawing.Point(28, 42);
            this.rB_ShutDown.Name = "rB_ShutDown";
            this.rB_ShutDown.Size = new System.Drawing.Size(59, 20);
            this.rB_ShutDown.TabIndex = 1;
            this.rB_ShutDown.TabStop = true;
            this.rB_ShutDown.Text = "關機";
            this.rB_ShutDown.UseVisualStyleBackColor = true;
            // 
            // gB_Else
            // 
            this.gB_Else.Controls.Add(this.txt_Remainder2);
            this.gB_Else.Controls.Add(this.txt_Remainder1);
            this.gB_Else.Controls.Add(this.txt_Music);
            this.gB_Else.Controls.Add(this.btn_Music);
            this.gB_Else.Controls.Add(this.label9);
            this.gB_Else.Controls.Add(this.label8);
            this.gB_Else.Controls.Add(this.checkBox2);
            this.gB_Else.Controls.Add(this.checkBox1);
            this.gB_Else.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gB_Else.Location = new System.Drawing.Point(570, 352);
            this.gB_Else.Name = "gB_Else";
            this.gB_Else.Size = new System.Drawing.Size(542, 177);
            this.gB_Else.TabIndex = 11;
            this.gB_Else.TabStop = false;
            this.gB_Else.Text = "其他設定";
            // 
            // txt_Remainder2
            // 
            this.txt_Remainder2.Enabled = false;
            this.txt_Remainder2.Location = new System.Drawing.Point(68, 85);
            this.txt_Remainder2.Name = "txt_Remainder2";
            this.txt_Remainder2.Size = new System.Drawing.Size(53, 27);
            this.txt_Remainder2.TabIndex = 13;
            this.txt_Remainder2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Remainder1
            // 
            this.txt_Remainder1.Enabled = false;
            this.txt_Remainder1.Location = new System.Drawing.Point(68, 37);
            this.txt_Remainder1.Name = "txt_Remainder1";
            this.txt_Remainder1.Size = new System.Drawing.Size(53, 27);
            this.txt_Remainder1.TabIndex = 12;
            this.txt_Remainder1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Music
            // 
            this.txt_Music.Enabled = false;
            this.txt_Music.Location = new System.Drawing.Point(68, 129);
            this.txt_Music.Name = "txt_Music";
            this.txt_Music.ReadOnly = true;
            this.txt_Music.Size = new System.Drawing.Size(295, 27);
            this.txt_Music.TabIndex = 11;
            this.txt_Music.Visible = false;
            // 
            // btn_Music
            // 
            this.btn_Music.Enabled = false;
            this.btn_Music.Location = new System.Drawing.Point(372, 129);
            this.btn_Music.Name = "btn_Music";
            this.btn_Music.Size = new System.Drawing.Size(57, 28);
            this.btn_Music.TabIndex = 10;
            this.btn_Music.Text = "預覽";
            this.btn_Music.UseVisualStyleBackColor = true;
            this.btn_Music.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(130, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "分鐘時播放鈴聲";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(129, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "分鐘時視窗至頂顯示";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(18, 88);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(43, 20);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "剩";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(43, 20);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "剩";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(840, 549);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 21);
            this.label10.TabIndex = 12;
            this.label10.Text = "狀態:";
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl_Status.ForeColor = System.Drawing.Color.Red;
            this.lbl_Status.Location = new System.Drawing.Point(901, 549);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(76, 21);
            this.lbl_Status.TabIndex = 13;
            this.lbl_Status.Text = "顯示區";
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Start.Location = new System.Drawing.Point(1019, 546);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(93, 28);
            this.btn_Start.TabIndex = 9;
            this.btn_Start.Text = "開始執行";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // timer_CountDown
            // 
            this.timer_CountDown.Interval = 1000;
            this.timer_CountDown.Tick += new System.EventHandler(this.timer_CountDown_Tick);
            // 
            // timer_Date
            // 
            this.timer_Date.Tick += new System.EventHandler(this.timer_Date_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1143, 635);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gB_Else);
            this.Controls.Add(this.gB_Action);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gB_Date);
            this.Controls.Add(this.gB_CountDown);
            this.Controls.Add(this.btn_WindowState);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.gB_Process);
            this.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.gB_Process.ResumeLayout(false);
            this.gB_Process.PerformLayout();
            this.gB_CountDown.ResumeLayout(false);
            this.gB_CountDown.PerformLayout();
            this.gB_Date.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gB_Action.ResumeLayout(false);
            this.gB_Action.PerformLayout();
            this.gB_Else.ResumeLayout(false);
            this.gB_Else.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gB_Process;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_WindowState;
        private System.Windows.Forms.RadioButton rB_Date;
        private System.Windows.Forms.RadioButton rB_CountDown;
        private System.Windows.Forms.GroupBox gB_CountDown;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Lock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Second;
        private System.Windows.Forms.TextBox txt_Minute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Hour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Day;
        private System.Windows.Forms.GroupBox gB_Date;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btn_Resets;
        private System.Windows.Forms.Button btn_Locks;
        private System.Windows.Forms.Timer timer_DateTime;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox gB_Action;
        private System.Windows.Forms.TextBox txt_Notify;
        private System.Windows.Forms.Button btn_Review;
        private System.Windows.Forms.RadioButton rB_Notify;
        private System.Windows.Forms.RadioButton rB_Sleep;
        private System.Windows.Forms.RadioButton rB_ReStart;
        private System.Windows.Forms.RadioButton rB_ShutDown;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip_DateTime;
        private System.Windows.Forms.GroupBox gB_Else;
        private System.Windows.Forms.Button btn_Music;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txt_Remainder2;
        private System.Windows.Forms.TextBox txt_Remainder1;
        private System.Windows.Forms.TextBox txt_Music;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Timer timer_CountDown;
        private System.Windows.Forms.Timer timer_Date;
        private System.Windows.Forms.TextBox txt_Content;
        private System.Windows.Forms.Label label5;
    }
}

