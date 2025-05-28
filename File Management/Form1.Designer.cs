namespace File_Management
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.gbProcessBy = new System.Windows.Forms.GroupBox();
            this.rd_process_by_date_modified = new System.Windows.Forms.RadioButton();
            this.rd_process_by_date_created = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.groupBoxTarget = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rd_then_path_None = new System.Windows.Forms.RadioButton();
            this.rd_then_path_year = new System.Windows.Forms.RadioButton();
            this.rd_then_path_year_month_day_2 = new System.Windows.Forms.RadioButton();
            this.rd_then_path_year_month_2 = new System.Windows.Forms.RadioButton();
            this.rd_then_path_year_month_day = new System.Windows.Forms.RadioButton();
            this.rd_then_path_year_month = new System.Windows.Forms.RadioButton();
            this.btnDestClear = new System.Windows.Forms.Button();
            this.btnDestAdd = new System.Windows.Forms.Button();
            this.txt_dest_path = new System.Windows.Forms.TextBox();
            this.groupBoxSource = new System.Windows.Forms.GroupBox();
            this.btnSourceScan = new System.Windows.Forms.Button();
            this.groupBoxImages = new System.Windows.Forms.GroupBox();
            this.cbException = new System.Windows.Forms.CheckBox();
            this.cbOptional = new System.Windows.Forms.CheckBox();
            this.btnResetException = new System.Windows.Forms.Button();
            this.btnResetOptional = new System.Windows.Forms.Button();
            this.txt_format_exception = new System.Windows.Forms.TextBox();
            this.txt_format_optional = new System.Windows.Forms.TextBox();
            this.txt_format_images = new System.Windows.Forms.TextBox();
            this.txt_format_videos = new System.Windows.Forms.TextBox();
            this.cbDocuments = new System.Windows.Forms.CheckBox();
            this.cbVideos = new System.Windows.Forms.CheckBox();
            this.cbImages = new System.Windows.Forms.CheckBox();
            this.txt_format_documents = new System.Windows.Forms.TextBox();
            this.btnResetImages = new System.Windows.Forms.Button();
            this.btnResetVideos = new System.Windows.Forms.Button();
            this.btnResetDocuments = new System.Windows.Forms.Button();
            this.txt_source_path = new System.Windows.Forms.TextBox();
            this.btnSourceAdd = new System.Windows.Forms.Button();
            this.btnSourceClear = new System.Windows.Forms.Button();
            this.dgvListFiles = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeBytes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_taken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.media_created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_modified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.listLog = new System.Windows.Forms.ListBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tab.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbProcessBy.SuspendLayout();
            this.groupBoxTarget.SuspendLayout();
            this.groupBoxSource.SuspendLayout();
            this.groupBoxImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFiles)).BeginInit();
            this.tabLog.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabMain);
            this.tab.Controls.Add(this.tabLog);
            this.tab.Controls.Add(this.tabAbout);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1029, 608);
            this.tab.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.panel1);
            this.tabMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(4, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1021, 579);
            this.tabMain.TabIndex = 2;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnResume);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.gbProcessBy);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.btnMove);
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.Controls.Add(this.groupBoxTarget);
            this.panel1.Controls.Add(this.groupBoxSource);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 573);
            this.panel1.TabIndex = 0;
            // 
            // btnResume
            // 
            this.btnResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResume.Enabled = false;
            this.btnResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.ForeColor = System.Drawing.Color.Blue;
            this.btnResume.Location = new System.Drawing.Point(815, 515);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(85, 49);
            this.btnResume.TabIndex = 17;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.Color.Orange;
            this.btnPause.Location = new System.Drawing.Point(734, 515);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 49);
            this.btnPause.TabIndex = 16;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Red;
            this.btnStop.Location = new System.Drawing.Point(906, 515);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(91, 49);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // gbProcessBy
            // 
            this.gbProcessBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProcessBy.Controls.Add(this.rd_process_by_date_modified);
            this.gbProcessBy.Controls.Add(this.rd_process_by_date_created);
            this.gbProcessBy.Location = new System.Drawing.Point(18, 341);
            this.gbProcessBy.Name = "gbProcessBy";
            this.gbProcessBy.Size = new System.Drawing.Size(979, 50);
            this.gbProcessBy.TabIndex = 14;
            this.gbProcessBy.TabStop = false;
            this.gbProcessBy.Text = "Process By";
            // 
            // rd_process_by_date_modified
            // 
            this.rd_process_by_date_modified.AutoSize = true;
            this.rd_process_by_date_modified.Enabled = false;
            this.rd_process_by_date_modified.Location = new System.Drawing.Point(150, 21);
            this.rd_process_by_date_modified.Name = "rd_process_by_date_modified";
            this.rd_process_by_date_modified.Size = new System.Drawing.Size(109, 20);
            this.rd_process_by_date_modified.TabIndex = 1;
            this.rd_process_by_date_modified.Text = "Date Modified";
            this.rd_process_by_date_modified.UseVisualStyleBackColor = true;
            // 
            // rd_process_by_date_created
            // 
            this.rd_process_by_date_created.AutoSize = true;
            this.rd_process_by_date_created.Checked = true;
            this.rd_process_by_date_created.Enabled = false;
            this.rd_process_by_date_created.Location = new System.Drawing.Point(13, 21);
            this.rd_process_by_date_created.Name = "rd_process_by_date_created";
            this.rd_process_by_date_created.Size = new System.Drawing.Size(105, 20);
            this.rd_process_by_date_created.TabIndex = 0;
            this.rd_process_by_date_created.TabStop = true;
            this.rd_process_by_date_created.Text = "Date Created";
            this.rd_process_by_date_created.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(18, 486);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(979, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMove.BackColor = System.Drawing.Color.White;
            this.btnMove.Enabled = false;
            this.btnMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMove.Image = ((System.Drawing.Image)(resources.GetObject("btnMove.Image")));
            this.btnMove.Location = new System.Drawing.Point(366, 515);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(320, 49);
            this.btnMove.TabIndex = 12;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = false;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.BackColor = System.Drawing.Color.Transparent;
            this.btnCopy.Enabled = false;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(36, 515);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(320, 49);
            this.btnCopy.TabIndex = 11;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // groupBoxTarget
            // 
            this.groupBoxTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTarget.Controls.Add(this.label2);
            this.groupBoxTarget.Controls.Add(this.label1);
            this.groupBoxTarget.Controls.Add(this.rd_then_path_None);
            this.groupBoxTarget.Controls.Add(this.rd_then_path_year);
            this.groupBoxTarget.Controls.Add(this.rd_then_path_year_month_day_2);
            this.groupBoxTarget.Controls.Add(this.rd_then_path_year_month_2);
            this.groupBoxTarget.Controls.Add(this.rd_then_path_year_month_day);
            this.groupBoxTarget.Controls.Add(this.rd_then_path_year_month);
            this.groupBoxTarget.Controls.Add(this.btnDestClear);
            this.groupBoxTarget.Controls.Add(this.btnDestAdd);
            this.groupBoxTarget.Controls.Add(this.txt_dest_path);
            this.groupBoxTarget.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTarget.Location = new System.Drawing.Point(18, 397);
            this.groupBoxTarget.Name = "groupBoxTarget";
            this.groupBoxTarget.Size = new System.Drawing.Size(979, 83);
            this.groupBoxTarget.TabIndex = 5;
            this.groupBoxTarget.TabStop = false;
            this.groupBoxTarget.Text = "Target";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Structure";
            // 
            // rd_then_path_None
            // 
            this.rd_then_path_None.AutoSize = true;
            this.rd_then_path_None.Enabled = false;
            this.rd_then_path_None.Location = new System.Drawing.Point(121, 49);
            this.rd_then_path_None.Name = "rd_then_path_None";
            this.rd_then_path_None.Size = new System.Drawing.Size(58, 20);
            this.rd_then_path_None.TabIndex = 10;
            this.rd_then_path_None.Text = "None";
            this.rd_then_path_None.UseVisualStyleBackColor = true;
            // 
            // rd_then_path_year
            // 
            this.rd_then_path_year.AutoSize = true;
            this.rd_then_path_year.Enabled = false;
            this.rd_then_path_year.Location = new System.Drawing.Point(186, 49);
            this.rd_then_path_year.Name = "rd_then_path_year";
            this.rd_then_path_year.Size = new System.Drawing.Size(61, 20);
            this.rd_then_path_year.TabIndex = 9;
            this.rd_then_path_year.Text = "\\yyyy\\";
            this.rd_then_path_year.UseVisualStyleBackColor = true;
            // 
            // rd_then_path_year_month_day_2
            // 
            this.rd_then_path_year_month_day_2.AutoSize = true;
            this.rd_then_path_year_month_day_2.BackColor = System.Drawing.Color.Transparent;
            this.rd_then_path_year_month_day_2.Enabled = false;
            this.rd_then_path_year_month_day_2.Location = new System.Drawing.Point(582, 49);
            this.rd_then_path_year_month_day_2.Name = "rd_then_path_year_month_day_2";
            this.rd_then_path_year_month_day_2.Size = new System.Drawing.Size(193, 20);
            this.rd_then_path_year_month_day_2.TabIndex = 8;
            this.rd_then_path_year_month_day_2.Text = "\\yyyy\\yyyy-mm\\yyyy-mm-dd";
            this.rd_then_path_year_month_day_2.UseVisualStyleBackColor = false;
            // 
            // rd_then_path_year_month_2
            // 
            this.rd_then_path_year_month_2.AutoSize = true;
            this.rd_then_path_year_month_2.Enabled = false;
            this.rd_then_path_year_month_2.Location = new System.Drawing.Point(457, 49);
            this.rd_then_path_year_month_2.Name = "rd_then_path_year_month_2";
            this.rd_then_path_year_month_2.Size = new System.Drawing.Size(119, 20);
            this.rd_then_path_year_month_2.TabIndex = 7;
            this.rd_then_path_year_month_2.Text = "\\yyyy\\yyyy-mm\\";
            this.rd_then_path_year_month_2.UseVisualStyleBackColor = true;
            // 
            // rd_then_path_year_month_day
            // 
            this.rd_then_path_year_month_day.AutoSize = true;
            this.rd_then_path_year_month_day.Checked = true;
            this.rd_then_path_year_month_day.Enabled = false;
            this.rd_then_path_year_month_day.Location = new System.Drawing.Point(348, 49);
            this.rd_then_path_year_month_day.Name = "rd_then_path_year_month_day";
            this.rd_then_path_year_month_day.Size = new System.Drawing.Size(103, 20);
            this.rd_then_path_year_month_day.TabIndex = 8;
            this.rd_then_path_year_month_day.TabStop = true;
            this.rd_then_path_year_month_day.Text = "\\yyyy\\mm\\dd";
            this.rd_then_path_year_month_day.UseVisualStyleBackColor = true;
            // 
            // rd_then_path_year_month
            // 
            this.rd_then_path_year_month.AutoSize = true;
            this.rd_then_path_year_month.Enabled = false;
            this.rd_then_path_year_month.Location = new System.Drawing.Point(253, 49);
            this.rd_then_path_year_month.Name = "rd_then_path_year_month";
            this.rd_then_path_year_month.Size = new System.Drawing.Size(87, 20);
            this.rd_then_path_year_month.TabIndex = 7;
            this.rd_then_path_year_month.Text = "\\yyyy\\mm\\";
            this.rd_then_path_year_month.UseVisualStyleBackColor = true;
            // 
            // btnDestClear
            // 
            this.btnDestClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDestClear.Enabled = false;
            this.btnDestClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDestClear.Location = new System.Drawing.Point(928, 20);
            this.btnDestClear.Name = "btnDestClear";
            this.btnDestClear.Size = new System.Drawing.Size(34, 24);
            this.btnDestClear.TabIndex = 5;
            this.btnDestClear.Text = "X";
            this.btnDestClear.UseVisualStyleBackColor = true;
            this.btnDestClear.Click += new System.EventHandler(this.btnDestClear_Click);
            // 
            // btnDestAdd
            // 
            this.btnDestAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDestAdd.Enabled = false;
            this.btnDestAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDestAdd.Location = new System.Drawing.Point(888, 20);
            this.btnDestAdd.Name = "btnDestAdd";
            this.btnDestAdd.Size = new System.Drawing.Size(34, 24);
            this.btnDestAdd.TabIndex = 4;
            this.btnDestAdd.Text = "...";
            this.btnDestAdd.UseVisualStyleBackColor = true;
            this.btnDestAdd.Click += new System.EventHandler(this.btnDestAdd_Click);
            // 
            // txt_dest_path
            // 
            this.txt_dest_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_dest_path.Enabled = false;
            this.txt_dest_path.Location = new System.Drawing.Point(121, 21);
            this.txt_dest_path.Name = "txt_dest_path";
            this.txt_dest_path.Size = new System.Drawing.Size(761, 22);
            this.txt_dest_path.TabIndex = 2;
            this.txt_dest_path.Text = "D:\\TESTING";
            this.txt_dest_path.TextChanged += new System.EventHandler(this.txt_dest_path_TextChanged);
            // 
            // groupBoxSource
            // 
            this.groupBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSource.Controls.Add(this.btnSourceScan);
            this.groupBoxSource.Controls.Add(this.groupBoxImages);
            this.groupBoxSource.Controls.Add(this.txt_source_path);
            this.groupBoxSource.Controls.Add(this.btnSourceAdd);
            this.groupBoxSource.Controls.Add(this.btnSourceClear);
            this.groupBoxSource.Controls.Add(this.dgvListFiles);
            this.groupBoxSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSource.Location = new System.Drawing.Point(18, 12);
            this.groupBoxSource.Name = "groupBoxSource";
            this.groupBoxSource.Size = new System.Drawing.Size(979, 323);
            this.groupBoxSource.TabIndex = 4;
            this.groupBoxSource.TabStop = false;
            this.groupBoxSource.Text = "Source";
            // 
            // btnSourceScan
            // 
            this.btnSourceScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSourceScan.BackColor = System.Drawing.Color.White;
            this.btnSourceScan.Enabled = false;
            this.btnSourceScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSourceScan.Image = ((System.Drawing.Image)(resources.GetObject("btnSourceScan.Image")));
            this.btnSourceScan.Location = new System.Drawing.Point(888, 56);
            this.btnSourceScan.Name = "btnSourceScan";
            this.btnSourceScan.Size = new System.Drawing.Size(74, 133);
            this.btnSourceScan.TabIndex = 4;
            this.btnSourceScan.Text = "Scan";
            this.btnSourceScan.UseVisualStyleBackColor = false;
            this.btnSourceScan.Click += new System.EventHandler(this.btnSourceScan_Click);
            // 
            // groupBoxImages
            // 
            this.groupBoxImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxImages.Controls.Add(this.cbException);
            this.groupBoxImages.Controls.Add(this.cbOptional);
            this.groupBoxImages.Controls.Add(this.btnResetException);
            this.groupBoxImages.Controls.Add(this.btnResetOptional);
            this.groupBoxImages.Controls.Add(this.txt_format_exception);
            this.groupBoxImages.Controls.Add(this.txt_format_optional);
            this.groupBoxImages.Controls.Add(this.txt_format_images);
            this.groupBoxImages.Controls.Add(this.txt_format_videos);
            this.groupBoxImages.Controls.Add(this.cbDocuments);
            this.groupBoxImages.Controls.Add(this.cbVideos);
            this.groupBoxImages.Controls.Add(this.cbImages);
            this.groupBoxImages.Controls.Add(this.txt_format_documents);
            this.groupBoxImages.Controls.Add(this.btnResetImages);
            this.groupBoxImages.Controls.Add(this.btnResetVideos);
            this.groupBoxImages.Controls.Add(this.btnResetDocuments);
            this.groupBoxImages.Location = new System.Drawing.Point(18, 50);
            this.groupBoxImages.Name = "groupBoxImages";
            this.groupBoxImages.Size = new System.Drawing.Size(864, 173);
            this.groupBoxImages.TabIndex = 3;
            this.groupBoxImages.TabStop = false;
            this.groupBoxImages.Text = "File Format";
            // 
            // cbException
            // 
            this.cbException.AutoSize = true;
            this.cbException.Enabled = false;
            this.cbException.Location = new System.Drawing.Point(6, 134);
            this.cbException.Name = "cbException";
            this.cbException.Size = new System.Drawing.Size(85, 20);
            this.cbException.TabIndex = 6;
            this.cbException.Text = "Exception";
            this.cbException.UseVisualStyleBackColor = true;
            this.cbException.CheckedChanged += new System.EventHandler(this.cbException_CheckedChanged);
            // 
            // cbOptional
            // 
            this.cbOptional.AutoSize = true;
            this.cbOptional.Enabled = false;
            this.cbOptional.Location = new System.Drawing.Point(6, 106);
            this.cbOptional.Name = "cbOptional";
            this.cbOptional.Size = new System.Drawing.Size(76, 20);
            this.cbOptional.TabIndex = 6;
            this.cbOptional.Text = "Optional";
            this.cbOptional.UseVisualStyleBackColor = true;
            this.cbOptional.CheckedChanged += new System.EventHandler(this.cbOptional_CheckedChanged);
            // 
            // btnResetException
            // 
            this.btnResetException.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetException.Enabled = false;
            this.btnResetException.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetException.Location = new System.Drawing.Point(822, 130);
            this.btnResetException.Name = "btnResetException";
            this.btnResetException.Size = new System.Drawing.Size(34, 24);
            this.btnResetException.TabIndex = 5;
            this.btnResetException.Text = "R";
            this.btnResetException.UseVisualStyleBackColor = true;
            this.btnResetException.Click += new System.EventHandler(this.btnResetException_Click);
            // 
            // btnResetOptional
            // 
            this.btnResetOptional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetOptional.Enabled = false;
            this.btnResetOptional.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetOptional.Location = new System.Drawing.Point(822, 103);
            this.btnResetOptional.Name = "btnResetOptional";
            this.btnResetOptional.Size = new System.Drawing.Size(34, 24);
            this.btnResetOptional.TabIndex = 5;
            this.btnResetOptional.Text = "R";
            this.btnResetOptional.UseVisualStyleBackColor = true;
            this.btnResetOptional.Click += new System.EventHandler(this.btnResetOptional_Click);
            // 
            // txt_format_exception
            // 
            this.txt_format_exception.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_format_exception.Enabled = false;
            this.txt_format_exception.Location = new System.Drawing.Point(103, 132);
            this.txt_format_exception.Name = "txt_format_exception";
            this.txt_format_exception.Size = new System.Drawing.Size(711, 22);
            this.txt_format_exception.TabIndex = 2;
            // 
            // txt_format_optional
            // 
            this.txt_format_optional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_format_optional.Enabled = false;
            this.txt_format_optional.Location = new System.Drawing.Point(103, 104);
            this.txt_format_optional.Name = "txt_format_optional";
            this.txt_format_optional.Size = new System.Drawing.Size(711, 22);
            this.txt_format_optional.TabIndex = 2;
            // 
            // txt_format_images
            // 
            this.txt_format_images.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_format_images.Enabled = false;
            this.txt_format_images.Location = new System.Drawing.Point(103, 19);
            this.txt_format_images.Name = "txt_format_images";
            this.txt_format_images.Size = new System.Drawing.Size(711, 22);
            this.txt_format_images.TabIndex = 0;
            this.txt_format_images.Text = "jpg jpeg jpe jfif png bmp ico gif tif tiff heif hdr webp dib heic hif svg";
            // 
            // txt_format_videos
            // 
            this.txt_format_videos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_format_videos.Enabled = false;
            this.txt_format_videos.Location = new System.Drawing.Point(103, 47);
            this.txt_format_videos.Name = "txt_format_videos";
            this.txt_format_videos.Size = new System.Drawing.Size(711, 22);
            this.txt_format_videos.TabIndex = 0;
            this.txt_format_videos.Text = "3gp avi amv flv mkv mp4 wmp webm";
            // 
            // cbDocuments
            // 
            this.cbDocuments.AutoSize = true;
            this.cbDocuments.Enabled = false;
            this.cbDocuments.Location = new System.Drawing.Point(6, 77);
            this.cbDocuments.Name = "cbDocuments";
            this.cbDocuments.Size = new System.Drawing.Size(94, 20);
            this.cbDocuments.TabIndex = 0;
            this.cbDocuments.Text = "Documents";
            this.cbDocuments.UseVisualStyleBackColor = true;
            this.cbDocuments.CheckedChanged += new System.EventHandler(this.cbDocuments_CheckedChanged);
            // 
            // cbVideos
            // 
            this.cbVideos.AutoSize = true;
            this.cbVideos.Checked = true;
            this.cbVideos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVideos.Enabled = false;
            this.cbVideos.Location = new System.Drawing.Point(6, 49);
            this.cbVideos.Name = "cbVideos";
            this.cbVideos.Size = new System.Drawing.Size(69, 20);
            this.cbVideos.TabIndex = 0;
            this.cbVideos.Text = "Videos";
            this.cbVideos.UseVisualStyleBackColor = true;
            this.cbVideos.CheckedChanged += new System.EventHandler(this.cbVideos_CheckedChanged);
            // 
            // cbImages
            // 
            this.cbImages.AutoSize = true;
            this.cbImages.Checked = true;
            this.cbImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbImages.Enabled = false;
            this.cbImages.Location = new System.Drawing.Point(6, 21);
            this.cbImages.Name = "cbImages";
            this.cbImages.Size = new System.Drawing.Size(71, 20);
            this.cbImages.TabIndex = 0;
            this.cbImages.Text = "Images";
            this.cbImages.UseVisualStyleBackColor = true;
            this.cbImages.CheckedChanged += new System.EventHandler(this.cbImages_CheckedChanged);
            // 
            // txt_format_documents
            // 
            this.txt_format_documents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_format_documents.Enabled = false;
            this.txt_format_documents.Location = new System.Drawing.Point(103, 75);
            this.txt_format_documents.Name = "txt_format_documents";
            this.txt_format_documents.Size = new System.Drawing.Size(711, 22);
            this.txt_format_documents.TabIndex = 0;
            this.txt_format_documents.Text = "txt rtf doc docx dot dotx htm html mht mhtml odt pdf xml";
            // 
            // btnResetImages
            // 
            this.btnResetImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetImages.Location = new System.Drawing.Point(822, 18);
            this.btnResetImages.Name = "btnResetImages";
            this.btnResetImages.Size = new System.Drawing.Size(34, 24);
            this.btnResetImages.TabIndex = 1;
            this.btnResetImages.Text = "R";
            this.btnResetImages.UseVisualStyleBackColor = true;
            this.btnResetImages.Click += new System.EventHandler(this.btnResetImages_Click);
            // 
            // btnResetVideos
            // 
            this.btnResetVideos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetVideos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetVideos.Location = new System.Drawing.Point(822, 46);
            this.btnResetVideos.Name = "btnResetVideos";
            this.btnResetVideos.Size = new System.Drawing.Size(34, 24);
            this.btnResetVideos.TabIndex = 1;
            this.btnResetVideos.Text = "R";
            this.btnResetVideos.UseVisualStyleBackColor = true;
            this.btnResetVideos.Click += new System.EventHandler(this.btnResetVideos_Click);
            // 
            // btnResetDocuments
            // 
            this.btnResetDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetDocuments.Location = new System.Drawing.Point(822, 74);
            this.btnResetDocuments.Name = "btnResetDocuments";
            this.btnResetDocuments.Size = new System.Drawing.Size(34, 24);
            this.btnResetDocuments.TabIndex = 1;
            this.btnResetDocuments.Text = "R";
            this.btnResetDocuments.UseVisualStyleBackColor = true;
            this.btnResetDocuments.Click += new System.EventHandler(this.btnResetDocuments_Click);
            // 
            // txt_source_path
            // 
            this.txt_source_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_source_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_source_path.Location = new System.Drawing.Point(18, 21);
            this.txt_source_path.Name = "txt_source_path";
            this.txt_source_path.Size = new System.Drawing.Size(864, 22);
            this.txt_source_path.TabIndex = 2;
            this.txt_source_path.Text = "H:\\2025.05";
            this.txt_source_path.TextChanged += new System.EventHandler(this.txt_source_path_TextChanged);
            // 
            // btnSourceAdd
            // 
            this.btnSourceAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSourceAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSourceAdd.Location = new System.Drawing.Point(888, 20);
            this.btnSourceAdd.Name = "btnSourceAdd";
            this.btnSourceAdd.Size = new System.Drawing.Size(34, 24);
            this.btnSourceAdd.TabIndex = 1;
            this.btnSourceAdd.Text = "...";
            this.btnSourceAdd.UseVisualStyleBackColor = true;
            this.btnSourceAdd.Click += new System.EventHandler(this.btnSourceAdd_Click);
            // 
            // btnSourceClear
            // 
            this.btnSourceClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSourceClear.Enabled = false;
            this.btnSourceClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSourceClear.Location = new System.Drawing.Point(928, 20);
            this.btnSourceClear.Name = "btnSourceClear";
            this.btnSourceClear.Size = new System.Drawing.Size(34, 24);
            this.btnSourceClear.TabIndex = 0;
            this.btnSourceClear.Text = "X";
            this.btnSourceClear.UseVisualStyleBackColor = true;
            this.btnSourceClear.Click += new System.EventHandler(this.btnSourceClear_Click);
            // 
            // dgvListFiles
            // 
            this.dgvListFiles.AllowUserToAddRows = false;
            this.dgvListFiles.AllowUserToDeleteRows = false;
            this.dgvListFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.path,
            this.file_name,
            this.sizeView,
            this.sizeBytes,
            this.date_taken,
            this.media_created,
            this.date_created,
            this.date_modified,
            this.status,
            this.Action});
            this.dgvListFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvListFiles.Location = new System.Drawing.Point(18, 229);
            this.dgvListFiles.Name = "dgvListFiles";
            this.dgvListFiles.ReadOnly = true;
            this.dgvListFiles.ShowEditingIcon = false;
            this.dgvListFiles.Size = new System.Drawing.Size(944, 79);
            this.dgvListFiles.TabIndex = 1;
            this.dgvListFiles.TabStop = false;
            this.dgvListFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListFiles_CellClick);
            this.dgvListFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListFiles_CellContentClick);
            this.dgvListFiles.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListFiles_CellMouseEnter);
            this.dgvListFiles.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListFiles_CellMouseLeave);
            // 
            // no
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.no.DefaultCellStyle = dataGridViewCellStyle1;
            this.no.HeaderText = "No";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Width = 50;
            // 
            // path
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.path.DefaultCellStyle = dataGridViewCellStyle2;
            this.path.HeaderText = "File Location";
            this.path.Name = "path";
            this.path.ReadOnly = true;
            // 
            // file_name
            // 
            this.file_name.HeaderText = "File Name";
            this.file_name.Name = "file_name";
            this.file_name.ReadOnly = true;
            // 
            // sizeView
            // 
            this.sizeView.HeaderText = "Size Auto";
            this.sizeView.Name = "sizeView";
            this.sizeView.ReadOnly = true;
            // 
            // sizeBytes
            // 
            this.sizeBytes.HeaderText = "Size Bytes";
            this.sizeBytes.Name = "sizeBytes";
            this.sizeBytes.ReadOnly = true;
            // 
            // date_taken
            // 
            this.date_taken.HeaderText = "Date Taken (Camera)";
            this.date_taken.Name = "date_taken";
            this.date_taken.ReadOnly = true;
            this.date_taken.Width = 150;
            // 
            // media_created
            // 
            this.media_created.HeaderText = "Media Created (Movie)";
            this.media_created.Name = "media_created";
            this.media_created.ReadOnly = true;
            this.media_created.Width = 180;
            // 
            // date_created
            // 
            this.date_created.HeaderText = "Date Created";
            this.date_created.Name = "date_created";
            this.date_created.ReadOnly = true;
            this.date_created.Width = 150;
            // 
            // date_modified
            // 
            this.date_modified.HeaderText = "Date Modified";
            this.date_modified.Name = "date_modified";
            this.date_modified.ReadOnly = true;
            this.date_modified.Width = 150;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.status.DefaultCellStyle = dataGridViewCellStyle3;
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 69;
            // 
            // Action
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Action.DefaultCellStyle = dataGridViewCellStyle4;
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Width = 80;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.btnClearLog);
            this.tabLog.Controls.Add(this.listLog);
            this.tabLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLog.Location = new System.Drawing.Point(4, 25);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(1354, 579);
            this.tabLog.TabIndex = 1;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClearLog.Location = new System.Drawing.Point(484, 501);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 32);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // listLog
            // 
            this.listLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listLog.FormattingEnabled = true;
            this.listLog.ItemHeight = 16;
            this.listLog.Location = new System.Drawing.Point(3, 3);
            this.listLog.Name = "listLog";
            this.listLog.ScrollAlwaysVisible = true;
            this.listLog.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listLog.Size = new System.Drawing.Size(1017, 484);
            this.listLog.TabIndex = 0;
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.panel2);
            this.tabAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAbout.Location = new System.Drawing.Point(4, 25);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(1354, 579);
            this.tabAbout.TabIndex = 0;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1348, 573);
            this.panel2.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Create By: daripray"});
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1348, 573);
            this.listBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 608);
            this.Controls.Add(this.tab);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FMS - FIles Management System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tab.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbProcessBy.ResumeLayout(false);
            this.gbProcessBy.PerformLayout();
            this.groupBoxTarget.ResumeLayout(false);
            this.groupBoxTarget.PerformLayout();
            this.groupBoxSource.ResumeLayout(false);
            this.groupBoxSource.PerformLayout();
            this.groupBoxImages.ResumeLayout(false);
            this.groupBoxImages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFiles)).EndInit();
            this.tabLog.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxTarget;
        private System.Windows.Forms.GroupBox groupBoxSource;
        private System.Windows.Forms.DataGridView dgvListFiles;
        private System.Windows.Forms.TextBox txt_source_path;
        private System.Windows.Forms.Button btnSourceAdd;
        private System.Windows.Forms.Button btnSourceClear;
        private System.Windows.Forms.TextBox txt_dest_path;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnDestClear;
        private System.Windows.Forms.Button btnDestAdd;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.RadioButton rd_then_path_year_month_day;
        private System.Windows.Forms.RadioButton rd_then_path_year_month;
        private System.Windows.Forms.RadioButton rd_then_path_year;
        private System.Windows.Forms.TextBox txt_format_documents;
        private System.Windows.Forms.GroupBox groupBoxImages;
        private System.Windows.Forms.TextBox txt_format_images;
        private System.Windows.Forms.RadioButton rd_then_path_None;
        private System.Windows.Forms.RadioButton rd_then_path_year_month_day_2;
        private System.Windows.Forms.RadioButton rd_then_path_year_month_2;
        private System.Windows.Forms.TextBox txt_format_videos;
        private System.Windows.Forms.Button btnResetDocuments;
        private System.Windows.Forms.Button btnResetVideos;
        private System.Windows.Forms.Button btnResetImages;
        private System.Windows.Forms.CheckBox cbDocuments;
        private System.Windows.Forms.CheckBox cbVideos;
        private System.Windows.Forms.CheckBox cbImages;
        private System.Windows.Forms.Button btnSourceScan;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox cbOptional;
        private System.Windows.Forms.Button btnResetOptional;
        private System.Windows.Forms.TextBox txt_format_optional;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cbException;
        private System.Windows.Forms.Button btnResetException;
        private System.Windows.Forms.TextBox txt_format_exception;
        private System.Windows.Forms.GroupBox gbProcessBy;
        private System.Windows.Forms.RadioButton rd_process_by_date_modified;
        private System.Windows.Forms.RadioButton rd_process_by_date_created;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn path;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeView;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeBytes;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_taken;
        private System.Windows.Forms.DataGridViewTextBoxColumn media_created;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_created;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_modified;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
    }
}

