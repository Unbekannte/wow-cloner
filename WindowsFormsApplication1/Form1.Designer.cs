namespace copyWoWtoVM
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_Source_full = new System.Windows.Forms.TextBox();
            this.textBox_Dest_full = new System.Windows.Forms.TextBox();
            this.button_Copy_mini = new System.Windows.Forms.Button();
            this.button_Delete_mini = new System.Windows.Forms.Button();
            this.label_Status_full = new System.Windows.Forms.Label();
            this.button_Postal_mini = new System.Windows.Forms.Button();
            this.progressBar_Status_full = new System.Windows.Forms.ProgressBar();
            this.button_Auctinator_mini = new System.Windows.Forms.Button();
            this.radioButton_EU_full = new System.Windows.Forms.RadioButton();
            this.radioButton_RU_full = new System.Windows.Forms.RadioButton();
            this.radioButton_CopyWTF_full = new System.Windows.Forms.RadioButton();
            this.button_CopySome_full = new System.Windows.Forms.Button();
            this.textBox_from_full = new System.Windows.Forms.TextBox();
            this.textBox_to_full = new System.Windows.Forms.TextBox();
            this.label_from_full = new System.Windows.Forms.Label();
            this.label_to_full = new System.Windows.Forms.Label();
            this.checkBox_Relogger_full = new System.Windows.Forms.CheckBox();
            this.textBox_PathHB_full = new System.Windows.Forms.TextBox();
            this.textBox_PathVM_full = new System.Windows.Forms.TextBox();
            this.richTextBox_Log_full = new System.Windows.Forms.RichTextBox();
            this.checkBox_Proxifier_full = new System.Windows.Forms.CheckBox();
            this.label_Source_full = new System.Windows.Forms.Label();
            this.label_Dest_full = new System.Windows.Forms.Label();
            this.label_PathHB_full = new System.Windows.Forms.Label();
            this.label_PathVM_full = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_mini = new System.Windows.Forms.TabPage();
            this.checkBox_225_15_mini = new System.Windows.Forms.CheckBox();
            this.radioButton_CopyWTF_mini = new System.Windows.Forms.RadioButton();
            this.checkBox_Proxifier_mini = new System.Windows.Forms.CheckBox();
            this.radioButton_RU_mini = new System.Windows.Forms.RadioButton();
            this.radioButton_EU_mini = new System.Windows.Forms.RadioButton();
            this.checkBox_Relogger_mini = new System.Windows.Forms.CheckBox();
            this.richTextBox_Log_mini = new System.Windows.Forms.RichTextBox();
            this.label_Status_mini = new System.Windows.Forms.Label();
            this.progressBar_Status_mini = new System.Windows.Forms.ProgressBar();
            this.comboBox_QS_mini = new System.Windows.Forms.ComboBox();
            this.label_PathHB_mini = new System.Windows.Forms.Label();
            this.label_PathVM_mini = new System.Windows.Forms.Label();
            this.label_Dest_mini = new System.Windows.Forms.Label();
            this.label_Source_mini = new System.Windows.Forms.Label();
            this.textBox_PathVM_mini = new System.Windows.Forms.TextBox();
            this.textBox_PathHB_mini = new System.Windows.Forms.TextBox();
            this.textBox_Dest_mini = new System.Windows.Forms.TextBox();
            this.textBox_Source_mini = new System.Windows.Forms.TextBox();
            this.tab_full = new System.Windows.Forms.TabPage();
            this.listBox_Available_full = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_Auctinaor_full = new System.Windows.Forms.CheckBox();
            this.checkBox_Postal_full = new System.Windows.Forms.CheckBox();
            this.button_DeleteSome_full = new System.Windows.Forms.Button();
            this.button_DeleteAll_full = new System.Windows.Forms.Button();
            this.listViewEx1 = new ListViewEmbeddedControls.ListViewEx();
            this.column_Info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_IsLeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Tasks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tab_mini.SuspendLayout();
            this.tab_full.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Source_full
            // 
            this.textBox_Source_full.Location = new System.Drawing.Point(65, 94);
            this.textBox_Source_full.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Source_full.Name = "textBox_Source_full";
            this.textBox_Source_full.Size = new System.Drawing.Size(161, 22);
            this.textBox_Source_full.TabIndex = 0;
            this.textBox_Source_full.Text = "Z:\\VM\\wow1";
            this.textBox_Source_full.TextChanged += new System.EventHandler(this.textBox_TextChanged_full);
            this.textBox_Source_full.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_Source_full_MouseDoubleClick);
            // 
            // textBox_Dest_full
            // 
            this.textBox_Dest_full.Location = new System.Drawing.Point(65, 145);
            this.textBox_Dest_full.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Dest_full.Name = "textBox_Dest_full";
            this.textBox_Dest_full.Size = new System.Drawing.Size(161, 22);
            this.textBox_Dest_full.TabIndex = 1;
            this.textBox_Dest_full.Text = "C:\\wow";
            this.textBox_Dest_full.TextChanged += new System.EventHandler(this.textBox_TextChanged_full);
            this.textBox_Dest_full.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_Dest_full_MouseDoubleClick);
            // 
            // button_Copy_mini
            // 
            this.button_Copy_mini.Location = new System.Drawing.Point(35, 290);
            this.button_Copy_mini.Margin = new System.Windows.Forms.Padding(4);
            this.button_Copy_mini.Name = "button_Copy_mini";
            this.button_Copy_mini.Size = new System.Drawing.Size(200, 52);
            this.button_Copy_mini.TabIndex = 4;
            this.button_Copy_mini.Text = "Копировать";
            this.button_Copy_mini.UseVisualStyleBackColor = true;
            this.button_Copy_mini.Click += new System.EventHandler(this.button_Copy_mini_Click);
            // 
            // button_Delete_mini
            // 
            this.button_Delete_mini.Location = new System.Drawing.Point(21, 7);
            this.button_Delete_mini.Margin = new System.Windows.Forms.Padding(4);
            this.button_Delete_mini.Name = "button_Delete_mini";
            this.button_Delete_mini.Size = new System.Drawing.Size(200, 65);
            this.button_Delete_mini.TabIndex = 5;
            this.button_Delete_mini.Text = "Удалить С:\\вов";
            this.button_Delete_mini.UseVisualStyleBackColor = true;
            this.button_Delete_mini.Click += new System.EventHandler(this.button_Delete_mini_Click);
            // 
            // label_Status_full
            // 
            this.label_Status_full.AutoSize = true;
            this.label_Status_full.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Status_full.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Status_full.Location = new System.Drawing.Point(389, 334);
            this.label_Status_full.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Status_full.Name = "label_Status_full";
            this.label_Status_full.Size = new System.Drawing.Size(119, 25);
            this.label_Status_full.TabIndex = 6;
            this.label_Status_full.Text = "Состояние";
            // 
            // button_Postal_mini
            // 
            this.button_Postal_mini.Location = new System.Drawing.Point(256, 7);
            this.button_Postal_mini.Margin = new System.Windows.Forms.Padding(4);
            this.button_Postal_mini.Name = "button_Postal_mini";
            this.button_Postal_mini.Size = new System.Drawing.Size(112, 48);
            this.button_Postal_mini.TabIndex = 7;
            this.button_Postal_mini.Text = "Установить Postal";
            this.button_Postal_mini.UseVisualStyleBackColor = true;
            this.button_Postal_mini.Click += new System.EventHandler(this.button_Postal_mini_Click);
            // 
            // progressBar_Status_full
            // 
            this.progressBar_Status_full.Location = new System.Drawing.Point(5, 334);
            this.progressBar_Status_full.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar_Status_full.Name = "progressBar_Status_full";
            this.progressBar_Status_full.Size = new System.Drawing.Size(376, 25);
            this.progressBar_Status_full.Step = 25;
            this.progressBar_Status_full.TabIndex = 9;
            // 
            // button_Auctinator_mini
            // 
            this.button_Auctinator_mini.Location = new System.Drawing.Point(383, 7);
            this.button_Auctinator_mini.Margin = new System.Windows.Forms.Padding(4);
            this.button_Auctinator_mini.Name = "button_Auctinator_mini";
            this.button_Auctinator_mini.Size = new System.Drawing.Size(109, 48);
            this.button_Auctinator_mini.TabIndex = 10;
            this.button_Auctinator_mini.Text = "Установить Auctionator";
            this.button_Auctinator_mini.UseVisualStyleBackColor = true;
            this.button_Auctinator_mini.Click += new System.EventHandler(this.button_Auctinator_mini_Click);
            // 
            // radioButton_EU_full
            // 
            this.radioButton_EU_full.AutoSize = true;
            this.radioButton_EU_full.Location = new System.Drawing.Point(389, 305);
            this.radioButton_EU_full.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_EU_full.Name = "radioButton_EU_full";
            this.radioButton_EU_full.Size = new System.Drawing.Size(45, 21);
            this.radioButton_EU_full.TabIndex = 11;
            this.radioButton_EU_full.Text = "eu";
            this.radioButton_EU_full.UseVisualStyleBackColor = true;
            // 
            // radioButton_RU_full
            // 
            this.radioButton_RU_full.AutoSize = true;
            this.radioButton_RU_full.Location = new System.Drawing.Point(336, 305);
            this.radioButton_RU_full.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_RU_full.Name = "radioButton_RU_full";
            this.radioButton_RU_full.Size = new System.Drawing.Size(42, 21);
            this.radioButton_RU_full.TabIndex = 12;
            this.radioButton_RU_full.Text = "ru";
            this.radioButton_RU_full.UseVisualStyleBackColor = true;
            // 
            // radioButton_CopyWTF_full
            // 
            this.radioButton_CopyWTF_full.AutoSize = true;
            this.radioButton_CopyWTF_full.Checked = true;
            this.radioButton_CopyWTF_full.Location = new System.Drawing.Point(447, 305);
            this.radioButton_CopyWTF_full.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_CopyWTF_full.Name = "radioButton_CopyWTF_full";
            this.radioButton_CopyWTF_full.Size = new System.Drawing.Size(80, 21);
            this.radioButton_CopyWTF_full.TabIndex = 13;
            this.radioButton_CopyWTF_full.TabStop = true;
            this.radioButton_CopyWTF_full.Text = "copy wtf";
            this.radioButton_CopyWTF_full.UseVisualStyleBackColor = true;
            // 
            // button_CopySome_full
            // 
            this.button_CopySome_full.Location = new System.Drawing.Point(31, 261);
            this.button_CopySome_full.Margin = new System.Windows.Forms.Padding(4);
            this.button_CopySome_full.Name = "button_CopySome_full";
            this.button_CopySome_full.Size = new System.Drawing.Size(280, 65);
            this.button_CopySome_full.TabIndex = 14;
            this.button_CopySome_full.Text = "Копировать \r\n\\wow1\\wow1.exe\r\n-  \\wow2\\wow2.exe";
            this.button_CopySome_full.UseVisualStyleBackColor = true;
            this.button_CopySome_full.Click += new System.EventHandler(this.button_CopySome_full_Click);
            // 
            // textBox_from_full
            // 
            this.textBox_from_full.Location = new System.Drawing.Point(340, 261);
            this.textBox_from_full.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_from_full.Name = "textBox_from_full";
            this.textBox_from_full.Size = new System.Drawing.Size(61, 22);
            this.textBox_from_full.TabIndex = 15;
            this.textBox_from_full.Text = "1";
            this.textBox_from_full.TextChanged += new System.EventHandler(this.textBox_TextChanged_full);
            // 
            // textBox_to_full
            // 
            this.textBox_to_full.Location = new System.Drawing.Point(440, 261);
            this.textBox_to_full.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_to_full.Name = "textBox_to_full";
            this.textBox_to_full.Size = new System.Drawing.Size(61, 22);
            this.textBox_to_full.TabIndex = 16;
            this.textBox_to_full.Text = "2";
            this.textBox_to_full.TextChanged += new System.EventHandler(this.textBox_TextChanged_full);
            // 
            // label_from_full
            // 
            this.label_from_full.AutoSize = true;
            this.label_from_full.Location = new System.Drawing.Point(357, 241);
            this.label_from_full.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_from_full.Name = "label_from_full";
            this.label_from_full.Size = new System.Drawing.Size(23, 17);
            this.label_from_full.TabIndex = 17;
            this.label_from_full.Text = "от";
            // 
            // label_to_full
            // 
            this.label_to_full.AutoSize = true;
            this.label_to_full.Location = new System.Drawing.Point(459, 241);
            this.label_to_full.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_to_full.Name = "label_to_full";
            this.label_to_full.Size = new System.Drawing.Size(24, 17);
            this.label_to_full.TabIndex = 18;
            this.label_to_full.Text = "до";
            // 
            // checkBox_Relogger_full
            // 
            this.checkBox_Relogger_full.AutoSize = true;
            this.checkBox_Relogger_full.Location = new System.Drawing.Point(361, 190);
            this.checkBox_Relogger_full.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Relogger_full.Name = "checkBox_Relogger_full";
            this.checkBox_Relogger_full.Size = new System.Drawing.Size(147, 38);
            this.checkBox_Relogger_full.TabIndex = 19;
            this.checkBox_Relogger_full.Text = "Добавить запись \r\nв HBRelog\r\n";
            this.checkBox_Relogger_full.UseVisualStyleBackColor = true;
            this.checkBox_Relogger_full.CheckedChanged += new System.EventHandler(this.checkBox_full_ProxyAndRelog_CheckedChanged);
            // 
            // textBox_PathHB_full
            // 
            this.textBox_PathHB_full.Location = new System.Drawing.Point(380, 94);
            this.textBox_PathHB_full.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_PathHB_full.Name = "textBox_PathHB_full";
            this.textBox_PathHB_full.Size = new System.Drawing.Size(136, 22);
            this.textBox_PathHB_full.TabIndex = 20;
            this.textBox_PathHB_full.Text = "Z:\\VM\\zzzx";
            this.textBox_PathHB_full.TextChanged += new System.EventHandler(this.textBox_TextChanged_full);
            this.textBox_PathHB_full.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_PathHB_full_MouseDoubleClick);
            // 
            // textBox_PathVM_full
            // 
            this.textBox_PathVM_full.Location = new System.Drawing.Point(380, 145);
            this.textBox_PathVM_full.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_PathVM_full.Name = "textBox_PathVM_full";
            this.textBox_PathVM_full.Size = new System.Drawing.Size(136, 22);
            this.textBox_PathVM_full.TabIndex = 21;
            this.textBox_PathVM_full.Text = "Z:\\VM";
            this.textBox_PathVM_full.TextChanged += new System.EventHandler(this.textBox_TextChanged_full);
            this.textBox_PathVM_full.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_PathVM_full_MouseDoubleClick);
            // 
            // richTextBox_Log_full
            // 
            this.richTextBox_Log_full.Location = new System.Drawing.Point(5, 366);
            this.richTextBox_Log_full.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_Log_full.Name = "richTextBox_Log_full";
            this.richTextBox_Log_full.Size = new System.Drawing.Size(278, 212);
            this.richTextBox_Log_full.TabIndex = 22;
            this.richTextBox_Log_full.Text = "";
            this.richTextBox_Log_full.TextChanged += new System.EventHandler(this.richTextBox_Log_full_TextChanged);
            // 
            // checkBox_Proxifier_full
            // 
            this.checkBox_Proxifier_full.AutoSize = true;
            this.checkBox_Proxifier_full.Location = new System.Drawing.Point(157, 190);
            this.checkBox_Proxifier_full.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Proxifier_full.Name = "checkBox_Proxifier_full";
            this.checkBox_Proxifier_full.Size = new System.Drawing.Size(144, 38);
            this.checkBox_Proxifier_full.TabIndex = 23;
            this.checkBox_Proxifier_full.Text = "Добавить записи\r\nв Proxifier";
            this.checkBox_Proxifier_full.UseVisualStyleBackColor = true;
            this.checkBox_Proxifier_full.CheckedChanged += new System.EventHandler(this.checkBox_full_ProxyAndRelog_CheckedChanged);
            // 
            // label_Source_full
            // 
            this.label_Source_full.AutoSize = true;
            this.label_Source_full.Location = new System.Drawing.Point(5, 97);
            this.label_Source_full.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Source_full.Name = "label_Source_full";
            this.label_Source_full.Size = new System.Drawing.Size(53, 17);
            this.label_Source_full.TabIndex = 24;
            this.label_Source_full.Text = "откуда";
            // 
            // label_Dest_full
            // 
            this.label_Dest_full.AutoSize = true;
            this.label_Dest_full.Location = new System.Drawing.Point(17, 149);
            this.label_Dest_full.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Dest_full.Name = "label_Dest_full";
            this.label_Dest_full.Size = new System.Drawing.Size(38, 17);
            this.label_Dest_full.TabIndex = 25;
            this.label_Dest_full.Text = "куда";
            // 
            // label_PathHB_full
            // 
            this.label_PathHB_full.AutoSize = true;
            this.label_PathHB_full.Location = new System.Drawing.Point(299, 97);
            this.label_PathHB_full.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_PathHB_full.Name = "label_PathHB_full";
            this.label_PathHB_full.Size = new System.Drawing.Size(70, 17);
            this.label_PathHB_full.TabIndex = 27;
            this.label_PathHB_full.Text = "папка HB";
            // 
            // label_PathVM_full
            // 
            this.label_PathVM_full.AutoSize = true;
            this.label_PathVM_full.Location = new System.Drawing.Point(297, 149);
            this.label_PathVM_full.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_PathVM_full.Name = "label_PathVM_full";
            this.label_PathVM_full.Size = new System.Drawing.Size(71, 17);
            this.label_PathVM_full.TabIndex = 26;
            this.label_PathVM_full.Text = "папка VM";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab_mini);
            this.tabControl1.Controls.Add(this.tab_full);
            this.tabControl1.Location = new System.Drawing.Point(0, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(732, 798);
            this.tabControl1.TabIndex = 30;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tab_mini
            // 
            this.tab_mini.Controls.Add(this.checkBox_225_15_mini);
            this.tab_mini.Controls.Add(this.radioButton_CopyWTF_mini);
            this.tab_mini.Controls.Add(this.checkBox_Proxifier_mini);
            this.tab_mini.Controls.Add(this.radioButton_RU_mini);
            this.tab_mini.Controls.Add(this.radioButton_EU_mini);
            this.tab_mini.Controls.Add(this.checkBox_Relogger_mini);
            this.tab_mini.Controls.Add(this.richTextBox_Log_mini);
            this.tab_mini.Controls.Add(this.label_Status_mini);
            this.tab_mini.Controls.Add(this.progressBar_Status_mini);
            this.tab_mini.Controls.Add(this.comboBox_QS_mini);
            this.tab_mini.Controls.Add(this.label_PathHB_mini);
            this.tab_mini.Controls.Add(this.label_PathVM_mini);
            this.tab_mini.Controls.Add(this.label_Dest_mini);
            this.tab_mini.Controls.Add(this.label_Source_mini);
            this.tab_mini.Controls.Add(this.textBox_PathVM_mini);
            this.tab_mini.Controls.Add(this.textBox_PathHB_mini);
            this.tab_mini.Controls.Add(this.textBox_Dest_mini);
            this.tab_mini.Controls.Add(this.textBox_Source_mini);
            this.tab_mini.Controls.Add(this.button_Delete_mini);
            this.tab_mini.Controls.Add(this.button_Postal_mini);
            this.tab_mini.Controls.Add(this.button_Auctinator_mini);
            this.tab_mini.Controls.Add(this.button_Copy_mini);
            this.tab_mini.Location = new System.Drawing.Point(4, 25);
            this.tab_mini.Margin = new System.Windows.Forms.Padding(4);
            this.tab_mini.Name = "tab_mini";
            this.tab_mini.Padding = new System.Windows.Forms.Padding(4);
            this.tab_mini.Size = new System.Drawing.Size(724, 769);
            this.tab_mini.TabIndex = 0;
            this.tab_mini.Text = "Mini";
            this.tab_mini.UseVisualStyleBackColor = true;
            // 
            // checkBox_225_15_mini
            // 
            this.checkBox_225_15_mini.AutoSize = true;
            this.checkBox_225_15_mini.Location = new System.Drawing.Point(365, 278);
            this.checkBox_225_15_mini.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_225_15_mini.Name = "checkBox_225_15_mini";
            this.checkBox_225_15_mini.Size = new System.Drawing.Size(119, 21);
            this.checkBox_225_15_mini.TabIndex = 37;
            this.checkBox_225_15_mini.Text = "4h/15m Tasks";
            this.checkBox_225_15_mini.UseVisualStyleBackColor = true;
            // 
            // radioButton_CopyWTF_mini
            // 
            this.radioButton_CopyWTF_mini.AutoSize = true;
            this.radioButton_CopyWTF_mini.Checked = true;
            this.radioButton_CopyWTF_mini.Location = new System.Drawing.Point(391, 306);
            this.radioButton_CopyWTF_mini.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_CopyWTF_mini.Name = "radioButton_CopyWTF_mini";
            this.radioButton_CopyWTF_mini.Size = new System.Drawing.Size(80, 21);
            this.radioButton_CopyWTF_mini.TabIndex = 33;
            this.radioButton_CopyWTF_mini.TabStop = true;
            this.radioButton_CopyWTF_mini.Text = "copy wtf";
            this.radioButton_CopyWTF_mini.UseVisualStyleBackColor = true;
            // 
            // checkBox_Proxifier_mini
            // 
            this.checkBox_Proxifier_mini.AutoSize = true;
            this.checkBox_Proxifier_mini.Location = new System.Drawing.Point(85, 188);
            this.checkBox_Proxifier_mini.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Proxifier_mini.Name = "checkBox_Proxifier_mini";
            this.checkBox_Proxifier_mini.Size = new System.Drawing.Size(141, 38);
            this.checkBox_Proxifier_mini.TabIndex = 32;
            this.checkBox_Proxifier_mini.Text = "добавить записи\r\nв Proxifier";
            this.checkBox_Proxifier_mini.UseVisualStyleBackColor = true;
            this.checkBox_Proxifier_mini.CheckedChanged += new System.EventHandler(this.checkBox_mini_CheckedChanged);
            // 
            // radioButton_RU_mini
            // 
            this.radioButton_RU_mini.AutoSize = true;
            this.radioButton_RU_mini.Location = new System.Drawing.Point(265, 306);
            this.radioButton_RU_mini.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_RU_mini.Name = "radioButton_RU_mini";
            this.radioButton_RU_mini.Size = new System.Drawing.Size(42, 21);
            this.radioButton_RU_mini.TabIndex = 32;
            this.radioButton_RU_mini.Text = "ru";
            this.radioButton_RU_mini.UseVisualStyleBackColor = true;
            // 
            // radioButton_EU_mini
            // 
            this.radioButton_EU_mini.AutoSize = true;
            this.radioButton_EU_mini.Location = new System.Drawing.Point(319, 306);
            this.radioButton_EU_mini.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_EU_mini.Name = "radioButton_EU_mini";
            this.radioButton_EU_mini.Size = new System.Drawing.Size(45, 21);
            this.radioButton_EU_mini.TabIndex = 31;
            this.radioButton_EU_mini.Text = "eu";
            this.radioButton_EU_mini.UseVisualStyleBackColor = true;
            // 
            // checkBox_Relogger_mini
            // 
            this.checkBox_Relogger_mini.AutoSize = true;
            this.checkBox_Relogger_mini.Location = new System.Drawing.Point(293, 188);
            this.checkBox_Relogger_mini.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Relogger_mini.Name = "checkBox_Relogger_mini";
            this.checkBox_Relogger_mini.Size = new System.Drawing.Size(144, 38);
            this.checkBox_Relogger_mini.TabIndex = 31;
            this.checkBox_Relogger_mini.Text = "добавить запись \r\nв релогер\r\n";
            this.checkBox_Relogger_mini.UseVisualStyleBackColor = true;
            this.checkBox_Relogger_mini.CheckedChanged += new System.EventHandler(this.checkBox_mini_CheckedChanged);
            // 
            // richTextBox_Log_mini
            // 
            this.richTextBox_Log_mini.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Log_mini.Location = new System.Drawing.Point(8, 423);
            this.richTextBox_Log_mini.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_Log_mini.Name = "richTextBox_Log_mini";
            this.richTextBox_Log_mini.Size = new System.Drawing.Size(708, 338);
            this.richTextBox_Log_mini.TabIndex = 32;
            this.richTextBox_Log_mini.Text = "";
            this.richTextBox_Log_mini.TextChanged += new System.EventHandler(this.richTextBox_Log_mini_TextChanged);
            // 
            // label_Status_mini
            // 
            this.label_Status_mini.AutoSize = true;
            this.label_Status_mini.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Status_mini.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Status_mini.Location = new System.Drawing.Point(16, 395);
            this.label_Status_mini.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Status_mini.Name = "label_Status_mini";
            this.label_Status_mini.Size = new System.Drawing.Size(119, 25);
            this.label_Status_mini.TabIndex = 31;
            this.label_Status_mini.Text = "Состояние";
            // 
            // progressBar_Status_mini
            // 
            this.progressBar_Status_mini.Location = new System.Drawing.Point(8, 367);
            this.progressBar_Status_mini.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar_Status_mini.Name = "progressBar_Status_mini";
            this.progressBar_Status_mini.Size = new System.Drawing.Size(333, 25);
            this.progressBar_Status_mini.Step = 25;
            this.progressBar_Status_mini.TabIndex = 32;
            // 
            // comboBox_QS_mini
            // 
            this.comboBox_QS_mini.FormattingEnabled = true;
            this.comboBox_QS_mini.Location = new System.Drawing.Point(21, 246);
            this.comboBox_QS_mini.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_QS_mini.Name = "comboBox_QS_mini";
            this.comboBox_QS_mini.Size = new System.Drawing.Size(469, 24);
            this.comboBox_QS_mini.TabIndex = 36;
            this.comboBox_QS_mini.SelectedIndexChanged += new System.EventHandler(this.comboBox_QS_mini_SelectedIndexChanged);
            // 
            // label_PathHB_mini
            // 
            this.label_PathHB_mini.AutoSize = true;
            this.label_PathHB_mini.Location = new System.Drawing.Point(273, 97);
            this.label_PathHB_mini.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_PathHB_mini.Name = "label_PathHB_mini";
            this.label_PathHB_mini.Size = new System.Drawing.Size(70, 17);
            this.label_PathHB_mini.TabIndex = 35;
            this.label_PathHB_mini.Text = "папка HB";
            // 
            // label_PathVM_mini
            // 
            this.label_PathVM_mini.AutoSize = true;
            this.label_PathVM_mini.Location = new System.Drawing.Point(272, 149);
            this.label_PathVM_mini.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_PathVM_mini.Name = "label_PathVM_mini";
            this.label_PathVM_mini.Size = new System.Drawing.Size(71, 17);
            this.label_PathVM_mini.TabIndex = 34;
            this.label_PathVM_mini.Text = "папка VM";
            // 
            // label_Dest_mini
            // 
            this.label_Dest_mini.AutoSize = true;
            this.label_Dest_mini.Location = new System.Drawing.Point(24, 149);
            this.label_Dest_mini.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Dest_mini.Name = "label_Dest_mini";
            this.label_Dest_mini.Size = new System.Drawing.Size(38, 17);
            this.label_Dest_mini.TabIndex = 33;
            this.label_Dest_mini.Text = "куда";
            // 
            // label_Source_mini
            // 
            this.label_Source_mini.AutoSize = true;
            this.label_Source_mini.Location = new System.Drawing.Point(12, 97);
            this.label_Source_mini.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Source_mini.Name = "label_Source_mini";
            this.label_Source_mini.Size = new System.Drawing.Size(53, 17);
            this.label_Source_mini.TabIndex = 32;
            this.label_Source_mini.Text = "откуда";
            // 
            // textBox_PathVM_mini
            // 
            this.textBox_PathVM_mini.Location = new System.Drawing.Point(355, 145);
            this.textBox_PathVM_mini.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_PathVM_mini.Name = "textBox_PathVM_mini";
            this.textBox_PathVM_mini.Size = new System.Drawing.Size(136, 22);
            this.textBox_PathVM_mini.TabIndex = 31;
            this.textBox_PathVM_mini.Text = "Z:\\VM";
            this.textBox_PathVM_mini.TextChanged += new System.EventHandler(this.textBox_TextChanged_mini);
            this.textBox_PathVM_mini.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_PathVM_mini_MouseDoubleClick);
            // 
            // textBox_PathHB_mini
            // 
            this.textBox_PathHB_mini.Location = new System.Drawing.Point(355, 94);
            this.textBox_PathHB_mini.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_PathHB_mini.Name = "textBox_PathHB_mini";
            this.textBox_PathHB_mini.Size = new System.Drawing.Size(136, 22);
            this.textBox_PathHB_mini.TabIndex = 30;
            this.textBox_PathHB_mini.Text = "Z:\\VM\\zzzx";
            this.textBox_PathHB_mini.TextChanged += new System.EventHandler(this.textBox_TextChanged_mini);
            this.textBox_PathHB_mini.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_PathHB_mini_MouseDoubleClick);
            // 
            // textBox_Dest_mini
            // 
            this.textBox_Dest_mini.Location = new System.Drawing.Point(72, 145);
            this.textBox_Dest_mini.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Dest_mini.Name = "textBox_Dest_mini";
            this.textBox_Dest_mini.Size = new System.Drawing.Size(161, 22);
            this.textBox_Dest_mini.TabIndex = 29;
            this.textBox_Dest_mini.Text = "C:\\wow";
            this.textBox_Dest_mini.TextChanged += new System.EventHandler(this.textBox_TextChanged_mini);
            this.textBox_Dest_mini.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_Dest_mini_MouseDoubleClick);
            // 
            // textBox_Source_mini
            // 
            this.textBox_Source_mini.Location = new System.Drawing.Point(72, 94);
            this.textBox_Source_mini.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Source_mini.Name = "textBox_Source_mini";
            this.textBox_Source_mini.Size = new System.Drawing.Size(161, 22);
            this.textBox_Source_mini.TabIndex = 28;
            this.textBox_Source_mini.Text = "Z:\\VM\\wow1";
            this.textBox_Source_mini.TextChanged += new System.EventHandler(this.textBox_TextChanged_mini);
            this.textBox_Source_mini.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_Source_mini_MouseDoubleClick);
            // 
            // tab_full
            // 
            this.tab_full.Controls.Add(this.listViewEx1);
            this.tab_full.Controls.Add(this.listBox_Available_full);
            this.tab_full.Controls.Add(this.label1);
            this.tab_full.Controls.Add(this.checkBox_Auctinaor_full);
            this.tab_full.Controls.Add(this.checkBox_Postal_full);
            this.tab_full.Controls.Add(this.button_DeleteSome_full);
            this.tab_full.Controls.Add(this.button_DeleteAll_full);
            this.tab_full.Controls.Add(this.textBox_Source_full);
            this.tab_full.Controls.Add(this.checkBox_Proxifier_full);
            this.tab_full.Controls.Add(this.textBox_Dest_full);
            this.tab_full.Controls.Add(this.richTextBox_Log_full);
            this.tab_full.Controls.Add(this.textBox_PathHB_full);
            this.tab_full.Controls.Add(this.checkBox_Relogger_full);
            this.tab_full.Controls.Add(this.label_PathHB_full);
            this.tab_full.Controls.Add(this.label_to_full);
            this.tab_full.Controls.Add(this.textBox_PathVM_full);
            this.tab_full.Controls.Add(this.label_from_full);
            this.tab_full.Controls.Add(this.label_PathVM_full);
            this.tab_full.Controls.Add(this.textBox_to_full);
            this.tab_full.Controls.Add(this.label_Source_full);
            this.tab_full.Controls.Add(this.textBox_from_full);
            this.tab_full.Controls.Add(this.label_Dest_full);
            this.tab_full.Controls.Add(this.button_CopySome_full);
            this.tab_full.Controls.Add(this.radioButton_CopyWTF_full);
            this.tab_full.Controls.Add(this.label_Status_full);
            this.tab_full.Controls.Add(this.radioButton_RU_full);
            this.tab_full.Controls.Add(this.progressBar_Status_full);
            this.tab_full.Controls.Add(this.radioButton_EU_full);
            this.tab_full.Location = new System.Drawing.Point(4, 25);
            this.tab_full.Margin = new System.Windows.Forms.Padding(4);
            this.tab_full.Name = "tab_full";
            this.tab_full.Padding = new System.Windows.Forms.Padding(4);
            this.tab_full.Size = new System.Drawing.Size(724, 769);
            this.tab_full.TabIndex = 1;
            this.tab_full.Text = "Full";
            this.tab_full.UseVisualStyleBackColor = true;
            // 
            // listBox_Available_full
            // 
            this.listBox_Available_full.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Available_full.FormattingEnabled = true;
            this.listBox_Available_full.ItemHeight = 16;
            this.listBox_Available_full.Location = new System.Drawing.Point(284, 366);
            this.listBox_Available_full.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_Available_full.Name = "listBox_Available_full";
            this.listBox_Available_full.Size = new System.Drawing.Size(432, 212);
            this.listBox_Available_full.TabIndex = 33;
            this.listBox_Available_full.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_Available_full_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(411, 265);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = " - ";
            // 
            // checkBox_Auctinaor_full
            // 
            this.checkBox_Auctinaor_full.AutoSize = true;
            this.checkBox_Auctinaor_full.Location = new System.Drawing.Point(11, 177);
            this.checkBox_Auctinaor_full.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Auctinaor_full.Name = "checkBox_Auctinaor_full";
            this.checkBox_Auctinaor_full.Size = new System.Drawing.Size(110, 38);
            this.checkBox_Auctinaor_full.TabIndex = 31;
            this.checkBox_Auctinaor_full.Text = "Установить \r\nAuctinator";
            this.checkBox_Auctinaor_full.UseVisualStyleBackColor = true;
            this.checkBox_Auctinaor_full.CheckedChanged += new System.EventHandler(this.checkBox_full_PostalAndAuc_CheckedChanged);
            // 
            // checkBox_Postal_full
            // 
            this.checkBox_Postal_full.AutoSize = true;
            this.checkBox_Postal_full.Location = new System.Drawing.Point(11, 217);
            this.checkBox_Postal_full.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Postal_full.Name = "checkBox_Postal_full";
            this.checkBox_Postal_full.Size = new System.Drawing.Size(110, 38);
            this.checkBox_Postal_full.TabIndex = 30;
            this.checkBox_Postal_full.Text = "Установить \r\nPostal";
            this.checkBox_Postal_full.UseVisualStyleBackColor = true;
            this.checkBox_Postal_full.CheckedChanged += new System.EventHandler(this.checkBox_full_PostalAndAuc_CheckedChanged);
            // 
            // button_DeleteSome_full
            // 
            this.button_DeleteSome_full.Location = new System.Drawing.Point(320, 9);
            this.button_DeleteSome_full.Margin = new System.Windows.Forms.Padding(4);
            this.button_DeleteSome_full.Name = "button_DeleteSome_full";
            this.button_DeleteSome_full.Size = new System.Drawing.Size(221, 66);
            this.button_DeleteSome_full.TabIndex = 29;
            this.button_DeleteSome_full.Text = "Удалить \r\nd\\GAMES\\wow4 - wow8";
            this.button_DeleteSome_full.UseVisualStyleBackColor = true;
            this.button_DeleteSome_full.Click += new System.EventHandler(this.button_DeleteSome_full_Click);
            // 
            // button_DeleteAll_full
            // 
            this.button_DeleteAll_full.Location = new System.Drawing.Point(19, 9);
            this.button_DeleteAll_full.Margin = new System.Windows.Forms.Padding(4);
            this.button_DeleteAll_full.Name = "button_DeleteAll_full";
            this.button_DeleteAll_full.Size = new System.Drawing.Size(209, 66);
            this.button_DeleteAll_full.TabIndex = 28;
            this.button_DeleteAll_full.Text = "Удалить все в папке d\\GAMES";
            this.button_DeleteAll_full.UseVisualStyleBackColor = true;
            this.button_DeleteAll_full.Click += new System.EventHandler(this.button_DeleteAll_full_Click);
            // 
            // listViewEx1
            // 
            this.listViewEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewEx1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Info,
            this.column_IsLeader,
            this.column_Tasks});
            this.listViewEx1.Location = new System.Drawing.Point(5, 577);
            this.listViewEx1.Margin = new System.Windows.Forms.Padding(4);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(711, 184);
            this.listViewEx1.TabIndex = 34;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            this.listViewEx1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewEx1_MouseDoubleClick);
            // 
            // column_Info
            // 
            this.column_Info.Text = "Инфо";
            this.column_Info.Width = 404;
            // 
            // column_IsLeader
            // 
            this.column_IsLeader.Text = "Лид";
            this.column_IsLeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_IsLeader.Width = 32;
            // 
            // column_Tasks
            // 
            this.column_Tasks.Text = "Tasks";
            this.column_Tasks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_Tasks.Width = 43;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 803);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "WoW_Cloner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_mini.ResumeLayout(false);
            this.tab_mini.PerformLayout();
            this.tab_full.ResumeLayout(false);
            this.tab_full.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Source_full;
        private System.Windows.Forms.TextBox textBox_Dest_full;
        private System.Windows.Forms.Button button_Copy_mini;
        private System.Windows.Forms.Button button_Delete_mini;
        private System.Windows.Forms.Label label_Status_full;
        private System.Windows.Forms.Button button_Postal_mini;
        private System.Windows.Forms.ProgressBar progressBar_Status_full;
        private System.Windows.Forms.Button button_Auctinator_mini;
        private System.Windows.Forms.RadioButton radioButton_EU_full;
        private System.Windows.Forms.RadioButton radioButton_RU_full;
        private System.Windows.Forms.RadioButton radioButton_CopyWTF_full;
        private System.Windows.Forms.Button button_CopySome_full;
        private System.Windows.Forms.TextBox textBox_from_full;
        private System.Windows.Forms.TextBox textBox_to_full;
        private System.Windows.Forms.Label label_from_full;
        private System.Windows.Forms.Label label_to_full;
        private System.Windows.Forms.CheckBox checkBox_Relogger_full;
        private System.Windows.Forms.TextBox textBox_PathHB_full;
        private System.Windows.Forms.TextBox textBox_PathVM_full;
        private System.Windows.Forms.RichTextBox richTextBox_Log_full;
        private System.Windows.Forms.CheckBox checkBox_Proxifier_full;
        private System.Windows.Forms.Label label_Source_full;
        private System.Windows.Forms.Label label_Dest_full;
        private System.Windows.Forms.Label label_PathHB_full;
        private System.Windows.Forms.Label label_PathVM_full;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_mini;
        private System.Windows.Forms.RadioButton radioButton_CopyWTF_mini;
        private System.Windows.Forms.CheckBox checkBox_Proxifier_mini;
        private System.Windows.Forms.RadioButton radioButton_RU_mini;
        private System.Windows.Forms.RadioButton radioButton_EU_mini;
        private System.Windows.Forms.CheckBox checkBox_Relogger_mini;
        private System.Windows.Forms.RichTextBox richTextBox_Log_mini;
        private System.Windows.Forms.Label label_Status_mini;
        private System.Windows.Forms.ProgressBar progressBar_Status_mini;
        private System.Windows.Forms.ComboBox comboBox_QS_mini;
        private System.Windows.Forms.Label label_PathHB_mini;
        private System.Windows.Forms.Label label_PathVM_mini;
        private System.Windows.Forms.Label label_Dest_mini;
        private System.Windows.Forms.Label label_Source_mini;
        private System.Windows.Forms.TextBox textBox_PathVM_mini;
        private System.Windows.Forms.TextBox textBox_PathHB_mini;
        private System.Windows.Forms.TextBox textBox_Dest_mini;
        private System.Windows.Forms.TextBox textBox_Source_mini;
        private System.Windows.Forms.TabPage tab_full;
        private System.Windows.Forms.CheckBox checkBox_Postal_full;
        private System.Windows.Forms.Button button_DeleteSome_full;
        private System.Windows.Forms.Button button_DeleteAll_full;
        private System.Windows.Forms.CheckBox checkBox_Auctinaor_full;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_Available_full;
        private ListViewEmbeddedControls.ListViewEx listViewEx1;
        private System.Windows.Forms.ColumnHeader column_Info;
        private System.Windows.Forms.ColumnHeader column_IsLeader;
        private System.Windows.Forms.ColumnHeader column_Tasks;
        private System.Windows.Forms.CheckBox checkBox_225_15_mini;
    }
}

