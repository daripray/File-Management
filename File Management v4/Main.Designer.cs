namespace File_Management_v4
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            splitter1 = new Splitter();
            groupBox1 = new GroupBox();
            dgvScan = new DataGridView();
            checkBox = new DataGridViewCheckBoxColumn();
            no = new DataGridViewTextBoxColumn();
            dirPath = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            type = new DataGridViewTextBoxColumn();
            size = new DataGridViewTextBoxColumn();
            originalStatus = new DataGridViewTextBoxColumn();
            dateTaken = new DataGridViewTextBoxColumn();
            mediaCreated = new DataGridViewTextBoxColumn();
            dateCreated = new DataGridViewTextBoxColumn();
            fileStatus = new DataGridViewTextBoxColumn();
            copyStatus = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            tabControl1 = new TabControl();
            tabPageScan = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            gbPicturePreview = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            picBox = new PictureBox();
            rtBoxMetaFiles = new RichTextBox();
            gbScanParams = new GroupBox();
            panel3 = new Panel();
            radioOri = new RadioButton();
            radioNonOri = new RadioButton();
            radioAll = new RadioButton();
            label5 = new Label();
            label1 = new Label();
            txtScanPath = new TextBox();
            btnCancelScan = new Button();
            txtExtVideo = new TextBox();
            btnScan = new Button();
            txtExtImage = new TextBox();
            chkKeyExcl = new CheckBox();
            txtExtDocument = new TextBox();
            chkKeyIncl = new CheckBox();
            txtKeyIncl = new TextBox();
            chkDocument = new CheckBox();
            txtKeyExcl = new TextBox();
            chkVideo = new CheckBox();
            btnScanBrowse = new Button();
            chkImage = new CheckBox();
            tabPagePrefixFound = new TabPage();
            richTextBoxPrefixFound = new RichTextBox();
            label6 = new Label();
            tabPageProcess = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox3 = new GroupBox();
            panel4 = new Panel();
            checkBoxMoveDeleteFiles = new CheckBox();
            radioButtonProcessMove = new RadioButton();
            radioButtonProcessCopy = new RadioButton();
            buttonProcess = new Button();
            gBoxCopyImages = new GroupBox();
            radioProcessImageAll = new RadioButton();
            radioProcessImageOri = new RadioButton();
            radioProcessImageNonOri = new RadioButton();
            gBoxCopyVideos = new GroupBox();
            radioProcessVideoAll = new RadioButton();
            radioProcessVideoOri = new RadioButton();
            radioProcessVideoNonOri = new RadioButton();
            checkBoxCopyImages = new CheckBox();
            checkBoxCopyVideos = new CheckBox();
            checkBoxCopyDocs = new CheckBox();
            comboBoxCopySubFolder = new ComboBox();
            lblCopyPathFinalPreview = new Label();
            label3 = new Label();
            label8 = new Label();
            label4 = new Label();
            label2 = new Label();
            txtCopyPath = new TextBox();
            btnCopyStop = new Button();
            btnCopyBrowse = new Button();
            tabPageValidasi = new TabPage();
            panel5 = new Panel();
            groupBox4 = new GroupBox();
            groupBox2 = new GroupBox();
            panel6 = new Panel();
            checkBox1 = new CheckBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            groupBox5 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton5 = new RadioButton();
            groupBox6 = new GroupBox();
            radioButton6 = new RadioButton();
            radioButton7 = new RadioButton();
            radioButton8 = new RadioButton();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            label7 = new Label();
            label9 = new Label();
            tabPageLog = new TabPage();
            tableLayoutPanel3 = new TableLayoutPanel();
            rtBoxLog = new RichTextBox();
            lstBoxLog = new ListBox();
            statusStrip1 = new StatusStrip();
            progressBarGlobal = new ToolStripProgressBar();
            labelProgress = new ToolStripStatusLabel();
            progressBarPerFile = new ToolStripProgressBar();
            folderBrowserScan = new FolderBrowserDialog();
            bgWorkerScan = new System.ComponentModel.BackgroundWorker();
            bgWorkerCopy = new System.ComponentModel.BackgroundWorker();
            folderBrowserCopy = new FolderBrowserDialog();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScan).BeginInit();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageScan.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            gbPicturePreview.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            gbScanParams.SuspendLayout();
            panel3.SuspendLayout();
            tabPagePrefixFound.SuspendLayout();
            tabPageProcess.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox3.SuspendLayout();
            panel4.SuspendLayout();
            gBoxCopyImages.SuspendLayout();
            gBoxCopyVideos.SuspendLayout();
            tabPageValidasi.SuspendLayout();
            panel5.SuspendLayout();
            groupBox2.SuspendLayout();
            panel6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            tabPageLog.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(splitter1);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(statusStrip1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1181, 775);
            panel1.TabIndex = 0;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Margin = new Padding(3, 4, 3, 4);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 743);
            splitter1.TabIndex = 7;
            splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(dgvScan);
            groupBox1.Location = new Point(18, 411);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1144, 331);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Data";
            // 
            // dgvScan
            // 
            dgvScan.AllowUserToAddRows = false;
            dgvScan.AllowUserToDeleteRows = false;
            dgvScan.AllowUserToOrderColumns = true;
            dgvScan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScan.Columns.AddRange(new DataGridViewColumn[] { checkBox, no, dirPath, name, type, size, originalStatus, dateTaken, mediaCreated, dateCreated, fileStatus, copyStatus });
            dgvScan.Dock = DockStyle.Fill;
            dgvScan.Location = new Point(3, 24);
            dgvScan.Margin = new Padding(3, 4, 3, 4);
            dgvScan.Name = "dgvScan";
            dgvScan.ReadOnly = true;
            dgvScan.RowHeadersWidth = 51;
            dgvScan.Size = new Size(1138, 303);
            dgvScan.TabIndex = 3;
            dgvScan.CellClick += dgvScan_CellClick;
            dgvScan.ColumnHeaderMouseClick += dgvScan_ColumnHeaderMouseClick;
            dgvScan.SelectionChanged += dgvScan_SelectionChanged;
            // 
            // checkBox
            // 
            checkBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            checkBox.HeaderText = "Pilih";
            checkBox.MinimumWidth = 6;
            checkBox.Name = "checkBox";
            checkBox.ReadOnly = true;
            checkBox.Resizable = DataGridViewTriState.False;
            checkBox.Width = 43;
            // 
            // no
            // 
            no.HeaderText = "No";
            no.MinimumWidth = 6;
            no.Name = "no";
            no.ReadOnly = true;
            no.Width = 50;
            // 
            // dirPath
            // 
            dirPath.HeaderText = "Directory";
            dirPath.MinimumWidth = 6;
            dirPath.Name = "dirPath";
            dirPath.ReadOnly = true;
            dirPath.Width = 150;
            // 
            // name
            // 
            name.HeaderText = "Name";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 125;
            // 
            // type
            // 
            type.HeaderText = "Type";
            type.MinimumWidth = 6;
            type.Name = "type";
            type.ReadOnly = true;
            type.Width = 70;
            // 
            // size
            // 
            size.HeaderText = "Size (B)";
            size.MinimumWidth = 6;
            size.Name = "size";
            size.ReadOnly = true;
            size.Width = 70;
            // 
            // originalStatus
            // 
            originalStatus.HeaderText = "Original Status";
            originalStatus.MinimumWidth = 6;
            originalStatus.Name = "originalStatus";
            originalStatus.ReadOnly = true;
            originalStatus.Width = 70;
            // 
            // dateTaken
            // 
            dateTaken.HeaderText = "Date Taken";
            dateTaken.MinimumWidth = 6;
            dateTaken.Name = "dateTaken";
            dateTaken.ReadOnly = true;
            dateTaken.Width = 120;
            // 
            // mediaCreated
            // 
            mediaCreated.HeaderText = "Media Created";
            mediaCreated.MinimumWidth = 6;
            mediaCreated.Name = "mediaCreated";
            mediaCreated.ReadOnly = true;
            mediaCreated.Width = 120;
            // 
            // dateCreated
            // 
            dateCreated.HeaderText = "Date Created";
            dateCreated.MinimumWidth = 6;
            dateCreated.Name = "dateCreated";
            dateCreated.ReadOnly = true;
            dateCreated.Width = 120;
            // 
            // fileStatus
            // 
            fileStatus.HeaderText = "Quality Status";
            fileStatus.MinimumWidth = 6;
            fileStatus.Name = "fileStatus";
            fileStatus.ReadOnly = true;
            fileStatus.Width = 125;
            // 
            // copyStatus
            // 
            copyStatus.HeaderText = "Process Status";
            copyStatus.MinimumWidth = 6;
            copyStatus.Name = "copyStatus";
            copyStatus.ReadOnly = true;
            copyStatus.Width = 125;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(tabControl1);
            panel2.Location = new Point(14, 16);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1154, 392);
            panel2.TabIndex = 5;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPageScan);
            tabControl1.Controls.Add(tabPagePrefixFound);
            tabControl1.Controls.Add(tabPageProcess);
            tabControl1.Controls.Add(tabPageValidasi);
            tabControl1.Controls.Add(tabPageLog);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1154, 392);
            tabControl1.TabIndex = 2;
            tabControl1.Selected += tabControl1_Selected;
            // 
            // tabPageScan
            // 
            tabPageScan.Controls.Add(tableLayoutPanel1);
            tabPageScan.Location = new Point(4, 29);
            tabPageScan.Margin = new Padding(3, 4, 3, 4);
            tabPageScan.Name = "tabPageScan";
            tabPageScan.Padding = new Padding(3, 4, 3, 4);
            tabPageScan.Size = new Size(1146, 359);
            tabPageScan.TabIndex = 0;
            tabPageScan.Text = "Scan Images";
            tabPageScan.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0428467F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.9571533F));
            tableLayoutPanel1.Controls.Add(gbPicturePreview, 1, 0);
            tableLayoutPanel1.Controls.Add(gbScanParams, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 4);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1140, 351);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // gbPicturePreview
            // 
            gbPicturePreview.Controls.Add(tableLayoutPanel4);
            gbPicturePreview.Dock = DockStyle.Fill;
            gbPicturePreview.Location = new Point(573, 4);
            gbPicturePreview.Margin = new Padding(3, 4, 3, 4);
            gbPicturePreview.Name = "gbPicturePreview";
            gbPicturePreview.Padding = new Padding(3, 4, 3, 4);
            gbPicturePreview.Size = new Size(564, 343);
            gbPicturePreview.TabIndex = 10;
            gbPicturePreview.TabStop = false;
            gbPicturePreview.Text = "Preview";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(picBox, 0, 0);
            tableLayoutPanel4.Controls.Add(rtBoxMetaFiles, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 24);
            tableLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(558, 315);
            tableLayoutPanel4.TabIndex = 3;
            // 
            // picBox
            // 
            picBox.Dock = DockStyle.Fill;
            picBox.Location = new Point(3, 4);
            picBox.Margin = new Padding(3, 4, 3, 4);
            picBox.Name = "picBox";
            picBox.Size = new Size(273, 307);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.TabIndex = 0;
            picBox.TabStop = false;
            // 
            // rtBoxMetaFiles
            // 
            rtBoxMetaFiles.Dock = DockStyle.Fill;
            rtBoxMetaFiles.Location = new Point(282, 4);
            rtBoxMetaFiles.Margin = new Padding(3, 4, 3, 4);
            rtBoxMetaFiles.Name = "rtBoxMetaFiles";
            rtBoxMetaFiles.Size = new Size(273, 307);
            rtBoxMetaFiles.TabIndex = 2;
            rtBoxMetaFiles.Text = "";
            // 
            // gbScanParams
            // 
            gbScanParams.Controls.Add(panel3);
            gbScanParams.Controls.Add(label5);
            gbScanParams.Controls.Add(label1);
            gbScanParams.Controls.Add(txtScanPath);
            gbScanParams.Controls.Add(btnCancelScan);
            gbScanParams.Controls.Add(txtExtVideo);
            gbScanParams.Controls.Add(btnScan);
            gbScanParams.Controls.Add(txtExtImage);
            gbScanParams.Controls.Add(chkKeyExcl);
            gbScanParams.Controls.Add(txtExtDocument);
            gbScanParams.Controls.Add(chkKeyIncl);
            gbScanParams.Controls.Add(txtKeyIncl);
            gbScanParams.Controls.Add(chkDocument);
            gbScanParams.Controls.Add(txtKeyExcl);
            gbScanParams.Controls.Add(chkVideo);
            gbScanParams.Controls.Add(btnScanBrowse);
            gbScanParams.Controls.Add(chkImage);
            gbScanParams.Dock = DockStyle.Fill;
            gbScanParams.Location = new Point(3, 4);
            gbScanParams.Margin = new Padding(3, 4, 3, 4);
            gbScanParams.Name = "gbScanParams";
            gbScanParams.Padding = new Padding(3, 4, 3, 4);
            gbScanParams.Size = new Size(564, 343);
            gbScanParams.TabIndex = 9;
            gbScanParams.TabStop = false;
            gbScanParams.Text = "Parameter";
            // 
            // panel3
            // 
            panel3.Controls.Add(radioOri);
            panel3.Controls.Add(radioNonOri);
            panel3.Controls.Add(radioAll);
            panel3.Location = new Point(137, 271);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(491, 44);
            panel3.TabIndex = 9;
            // 
            // radioOri
            // 
            radioOri.AutoSize = true;
            radioOri.Enabled = false;
            radioOri.Location = new Point(73, 11);
            radioOri.Margin = new Padding(3, 4, 3, 4);
            radioOri.Name = "radioOri";
            radioOri.Size = new Size(50, 24);
            radioOri.TabIndex = 0;
            radioOri.Text = "Ori";
            radioOri.UseVisualStyleBackColor = true;
            // 
            // radioNonOri
            // 
            radioNonOri.AutoSize = true;
            radioNonOri.Enabled = false;
            radioNonOri.Location = new Point(145, 11);
            radioNonOri.Margin = new Padding(3, 4, 3, 4);
            radioNonOri.Name = "radioNonOri";
            radioNonOri.Size = new Size(84, 24);
            radioNonOri.TabIndex = 0;
            radioNonOri.Text = "Non-Ori";
            radioNonOri.UseVisualStyleBackColor = true;
            // 
            // radioAll
            // 
            radioAll.AutoSize = true;
            radioAll.Checked = true;
            radioAll.Enabled = false;
            radioAll.Location = new Point(3, 11);
            radioAll.Margin = new Padding(3, 4, 3, 4);
            radioAll.Name = "radioAll";
            radioAll.Size = new Size(48, 24);
            radioAll.TabIndex = 0;
            radioAll.TabStop = true;
            radioAll.Text = "All";
            radioAll.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 275);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 8;
            label5.Text = "Original Status";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 41);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "Source";
            // 
            // txtScanPath
            // 
            txtScanPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtScanPath.Location = new Point(134, 31);
            txtScanPath.Margin = new Padding(3, 4, 3, 4);
            txtScanPath.Name = "txtScanPath";
            txtScanPath.Size = new Size(302, 27);
            txtScanPath.TabIndex = 1;
            txtScanPath.TextChanged += txtScanPath_TextChanged;
            // 
            // btnCancelScan
            // 
            btnCancelScan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelScan.BackColor = Color.Red;
            btnCancelScan.Enabled = false;
            btnCancelScan.Location = new Point(447, 176);
            btnCancelScan.Margin = new Padding(3, 4, 3, 4);
            btnCancelScan.Name = "btnCancelScan";
            btnCancelScan.Size = new Size(106, 89);
            btnCancelScan.TabIndex = 7;
            btnCancelScan.Text = "Stop";
            btnCancelScan.UseVisualStyleBackColor = false;
            btnCancelScan.Click += btnCancelScan_Click;
            // 
            // txtExtVideo
            // 
            txtExtVideo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtExtVideo.Enabled = false;
            txtExtVideo.Location = new Point(134, 109);
            txtExtVideo.Margin = new Padding(3, 4, 3, 4);
            txtExtVideo.Name = "txtExtVideo";
            txtExtVideo.Size = new Size(302, 27);
            txtExtVideo.TabIndex = 1;
            txtExtVideo.Text = "MP4, MOV, AVI, MKV, FLV, WMV, M4V, WEBM, MPG, MPEG, 3GP, MTS, M2TS, TS, OGV";
            // 
            // btnScan
            // 
            btnScan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScan.BackColor = Color.LawnGreen;
            btnScan.Enabled = false;
            btnScan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnScan.Location = new Point(447, 79);
            btnScan.Margin = new Padding(3, 4, 3, 4);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(106, 89);
            btnScan.TabIndex = 7;
            btnScan.Text = "Scan";
            btnScan.UseVisualStyleBackColor = false;
            btnScan.Click += btnScan_Click;
            // 
            // txtExtImage
            // 
            txtExtImage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtExtImage.Enabled = false;
            txtExtImage.Location = new Point(134, 71);
            txtExtImage.Margin = new Padding(3, 4, 3, 4);
            txtExtImage.Name = "txtExtImage";
            txtExtImage.Size = new Size(302, 27);
            txtExtImage.TabIndex = 1;
            txtExtImage.Text = "JPG, JPEG, PNG, GIF, BMP, TIFF, TIF, WEBP, HEIC, HEIF, RAW, CR2, NEF, ORF, SR2, ARW, DNG, PSD, ICO, SVG";
            // 
            // chkKeyExcl
            // 
            chkKeyExcl.AutoSize = true;
            chkKeyExcl.Enabled = false;
            chkKeyExcl.Location = new Point(17, 231);
            chkKeyExcl.Margin = new Padding(3, 4, 3, 4);
            chkKeyExcl.Name = "chkKeyExcl";
            chkKeyExcl.Size = new Size(110, 24);
            chkKeyExcl.TabIndex = 6;
            chkKeyExcl.Text = "Key Exclude";
            chkKeyExcl.UseVisualStyleBackColor = true;
            chkKeyExcl.CheckedChanged += chkKeyExcl_CheckedChanged;
            // 
            // txtExtDocument
            // 
            txtExtDocument.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtExtDocument.Enabled = false;
            txtExtDocument.Location = new Point(134, 148);
            txtExtDocument.Margin = new Padding(3, 4, 3, 4);
            txtExtDocument.Name = "txtExtDocument";
            txtExtDocument.Size = new Size(302, 27);
            txtExtDocument.TabIndex = 1;
            txtExtDocument.Text = "DOC, DOCX, PDF, XLS, XLSX, PPT, PPTX, TXT, RTF, ODT, ODS, ODP, CSV, XML, HTML, HTM, JSON, MD, LOG";
            // 
            // chkKeyIncl
            // 
            chkKeyIncl.AutoSize = true;
            chkKeyIncl.Enabled = false;
            chkKeyIncl.Location = new Point(18, 192);
            chkKeyIncl.Margin = new Padding(3, 4, 3, 4);
            chkKeyIncl.Name = "chkKeyIncl";
            chkKeyIncl.Size = new Size(107, 24);
            chkKeyIncl.TabIndex = 6;
            chkKeyIncl.Text = "Key Include";
            chkKeyIncl.UseVisualStyleBackColor = true;
            chkKeyIncl.CheckedChanged += chkKeyIncl_CheckedChanged;
            // 
            // txtKeyIncl
            // 
            txtKeyIncl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKeyIncl.Enabled = false;
            txtKeyIncl.Location = new Point(134, 187);
            txtKeyIncl.Margin = new Padding(3, 4, 3, 4);
            txtKeyIncl.Name = "txtKeyIncl";
            txtKeyIncl.Size = new Size(302, 27);
            txtKeyIncl.TabIndex = 1;
            txtKeyIncl.Text = "IMG_, VID_, MOV_, DSC, PXL, JPEG, PHOTO, SAMSUNG, ANDROID, DCIM, CAM, CAMERA, DCM, PIC, MV, IMG_E";
            // 
            // chkDocument
            // 
            chkDocument.AutoSize = true;
            chkDocument.Enabled = false;
            chkDocument.Location = new Point(18, 153);
            chkDocument.Margin = new Padding(3, 4, 3, 4);
            chkDocument.Name = "chkDocument";
            chkDocument.Size = new Size(100, 24);
            chkDocument.TabIndex = 5;
            chkDocument.Text = "Document";
            chkDocument.UseVisualStyleBackColor = true;
            chkDocument.CheckedChanged += chkDocument_CheckedChanged;
            // 
            // txtKeyExcl
            // 
            txtKeyExcl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKeyExcl.Enabled = false;
            txtKeyExcl.Location = new Point(134, 225);
            txtKeyExcl.Margin = new Padding(3, 4, 3, 4);
            txtKeyExcl.Name = "txtKeyExcl";
            txtKeyExcl.Size = new Size(302, 27);
            txtKeyExcl.TabIndex = 1;
            txtKeyExcl.Text = ".IMG, .VID, .MOV, SCREENSHOT";
            // 
            // chkVideo
            // 
            chkVideo.AutoSize = true;
            chkVideo.Enabled = false;
            chkVideo.Location = new Point(18, 115);
            chkVideo.Margin = new Padding(3, 4, 3, 4);
            chkVideo.Name = "chkVideo";
            chkVideo.Size = new Size(70, 24);
            chkVideo.TabIndex = 4;
            chkVideo.Text = "Video";
            chkVideo.UseVisualStyleBackColor = true;
            chkVideo.CheckedChanged += chkVideo_CheckedChanged;
            // 
            // btnScanBrowse
            // 
            btnScanBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScanBrowse.Location = new Point(447, 29);
            btnScanBrowse.Margin = new Padding(3, 4, 3, 4);
            btnScanBrowse.Name = "btnScanBrowse";
            btnScanBrowse.Size = new Size(106, 31);
            btnScanBrowse.TabIndex = 2;
            btnScanBrowse.Text = "Browse";
            btnScanBrowse.UseVisualStyleBackColor = true;
            btnScanBrowse.Click += btnScanBrowse_Click;
            // 
            // chkImage
            // 
            chkImage.AutoSize = true;
            chkImage.Enabled = false;
            chkImage.Location = new Point(18, 76);
            chkImage.Margin = new Padding(3, 4, 3, 4);
            chkImage.Name = "chkImage";
            chkImage.Size = new Size(73, 24);
            chkImage.TabIndex = 3;
            chkImage.Text = "Image";
            chkImage.UseVisualStyleBackColor = true;
            chkImage.CheckedChanged += chkImage_CheckedChanged;
            // 
            // tabPagePrefixFound
            // 
            tabPagePrefixFound.Controls.Add(richTextBoxPrefixFound);
            tabPagePrefixFound.Controls.Add(label6);
            tabPagePrefixFound.Location = new Point(4, 29);
            tabPagePrefixFound.Margin = new Padding(3, 4, 3, 4);
            tabPagePrefixFound.Name = "tabPagePrefixFound";
            tabPagePrefixFound.Padding = new Padding(3, 4, 3, 4);
            tabPagePrefixFound.Size = new Size(1146, 359);
            tabPagePrefixFound.TabIndex = 4;
            tabPagePrefixFound.Text = "Prefix Found";
            tabPagePrefixFound.UseVisualStyleBackColor = true;
            // 
            // richTextBoxPrefixFound
            // 
            richTextBoxPrefixFound.Dock = DockStyle.Fill;
            richTextBoxPrefixFound.Location = new Point(3, 4);
            richTextBoxPrefixFound.Margin = new Padding(3, 4, 3, 4);
            richTextBoxPrefixFound.Name = "richTextBoxPrefixFound";
            richTextBoxPrefixFound.Size = new Size(1140, 351);
            richTextBoxPrefixFound.TabIndex = 2;
            richTextBoxPrefixFound.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 13);
            label6.Name = "label6";
            label6.Size = new Size(94, 20);
            label6.TabIndex = 1;
            label6.Text = "Prefix Found:";
            // 
            // tabPageProcess
            // 
            tabPageProcess.Controls.Add(tableLayoutPanel2);
            tabPageProcess.Location = new Point(4, 29);
            tabPageProcess.Margin = new Padding(3, 4, 3, 4);
            tabPageProcess.Name = "tabPageProcess";
            tabPageProcess.Padding = new Padding(3, 4, 3, 4);
            tabPageProcess.Size = new Size(1146, 359);
            tabPageProcess.TabIndex = 1;
            tabPageProcess.Text = "Copy/Move";
            tabPageProcess.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.8536568F));
            tableLayoutPanel2.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 4);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1140, 351);
            tableLayoutPanel2.TabIndex = 12;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(panel4);
            groupBox3.Controls.Add(buttonProcess);
            groupBox3.Controls.Add(gBoxCopyImages);
            groupBox3.Controls.Add(gBoxCopyVideos);
            groupBox3.Controls.Add(checkBoxCopyImages);
            groupBox3.Controls.Add(checkBoxCopyVideos);
            groupBox3.Controls.Add(checkBoxCopyDocs);
            groupBox3.Controls.Add(comboBoxCopySubFolder);
            groupBox3.Controls.Add(lblCopyPathFinalPreview);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(txtCopyPath);
            groupBox3.Controls.Add(btnCopyStop);
            groupBox3.Controls.Add(btnCopyBrowse);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 4);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(1134, 343);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Parameter";
            // 
            // panel4
            // 
            panel4.Controls.Add(checkBoxMoveDeleteFiles);
            panel4.Controls.Add(radioButtonProcessMove);
            panel4.Controls.Add(radioButtonProcessCopy);
            panel4.Location = new Point(134, 139);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(378, 47);
            panel4.TabIndex = 16;
            // 
            // checkBoxMoveDeleteFiles
            // 
            checkBoxMoveDeleteFiles.AutoSize = true;
            checkBoxMoveDeleteFiles.Enabled = false;
            checkBoxMoveDeleteFiles.Location = new Point(190, 13);
            checkBoxMoveDeleteFiles.Margin = new Padding(3, 4, 3, 4);
            checkBoxMoveDeleteFiles.Name = "checkBoxMoveDeleteFiles";
            checkBoxMoveDeleteFiles.Size = new Size(143, 24);
            checkBoxMoveDeleteFiles.TabIndex = 1;
            checkBoxMoveDeleteFiles.Text = "Delete Old FIles?";
            checkBoxMoveDeleteFiles.UseVisualStyleBackColor = true;
            // 
            // radioButtonProcessMove
            // 
            radioButtonProcessMove.AutoSize = true;
            radioButtonProcessMove.Enabled = false;
            radioButtonProcessMove.Location = new Point(102, 11);
            radioButtonProcessMove.Margin = new Padding(3, 4, 3, 4);
            radioButtonProcessMove.Name = "radioButtonProcessMove";
            radioButtonProcessMove.Size = new Size(67, 24);
            radioButtonProcessMove.TabIndex = 0;
            radioButtonProcessMove.Text = "Move";
            radioButtonProcessMove.UseVisualStyleBackColor = true;
            // 
            // radioButtonProcessCopy
            // 
            radioButtonProcessCopy.AutoSize = true;
            radioButtonProcessCopy.Checked = true;
            radioButtonProcessCopy.Enabled = false;
            radioButtonProcessCopy.Location = new Point(16, 11);
            radioButtonProcessCopy.Margin = new Padding(3, 4, 3, 4);
            radioButtonProcessCopy.Name = "radioButtonProcessCopy";
            radioButtonProcessCopy.Size = new Size(64, 24);
            radioButtonProcessCopy.TabIndex = 0;
            radioButtonProcessCopy.TabStop = true;
            radioButtonProcessCopy.Text = "Copy";
            radioButtonProcessCopy.UseVisualStyleBackColor = true;
            radioButtonProcessCopy.CheckedChanged += radioButtonProcessCopy_CheckedChanged;
            // 
            // buttonProcess
            // 
            buttonProcess.BackColor = Color.LawnGreen;
            buttonProcess.Enabled = false;
            buttonProcess.FlatStyle = FlatStyle.Popup;
            buttonProcess.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonProcess.Location = new Point(544, 139);
            buttonProcess.Margin = new Padding(3, 4, 3, 4);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(136, 153);
            buttonProcess.TabIndex = 15;
            buttonProcess.Text = "Process";
            buttonProcess.UseVisualStyleBackColor = false;
            buttonProcess.Click += buttonProcess_Click;
            // 
            // gBoxCopyImages
            // 
            gBoxCopyImages.Controls.Add(radioProcessImageAll);
            gBoxCopyImages.Controls.Add(radioProcessImageOri);
            gBoxCopyImages.Controls.Add(radioProcessImageNonOri);
            gBoxCopyImages.Location = new Point(214, 193);
            gBoxCopyImages.Margin = new Padding(3, 4, 3, 4);
            gBoxCopyImages.Name = "gBoxCopyImages";
            gBoxCopyImages.Padding = new Padding(3, 4, 3, 4);
            gBoxCopyImages.Size = new Size(295, 55);
            gBoxCopyImages.TabIndex = 13;
            gBoxCopyImages.TabStop = false;
            // 
            // radioProcessImageAll
            // 
            radioProcessImageAll.AutoSize = true;
            radioProcessImageAll.Checked = true;
            radioProcessImageAll.Enabled = false;
            radioProcessImageAll.Location = new Point(7, 19);
            radioProcessImageAll.Margin = new Padding(3, 4, 3, 4);
            radioProcessImageAll.Name = "radioProcessImageAll";
            radioProcessImageAll.Size = new Size(48, 24);
            radioProcessImageAll.TabIndex = 10;
            radioProcessImageAll.TabStop = true;
            radioProcessImageAll.Text = "All";
            radioProcessImageAll.UseVisualStyleBackColor = true;
            // 
            // radioProcessImageOri
            // 
            radioProcessImageOri.AutoSize = true;
            radioProcessImageOri.Enabled = false;
            radioProcessImageOri.Location = new Point(70, 19);
            radioProcessImageOri.Margin = new Padding(3, 4, 3, 4);
            radioProcessImageOri.Name = "radioProcessImageOri";
            radioProcessImageOri.Size = new Size(50, 24);
            radioProcessImageOri.TabIndex = 10;
            radioProcessImageOri.Text = "Ori";
            radioProcessImageOri.UseVisualStyleBackColor = true;
            // 
            // radioProcessImageNonOri
            // 
            radioProcessImageNonOri.AutoSize = true;
            radioProcessImageNonOri.Enabled = false;
            radioProcessImageNonOri.Location = new Point(129, 19);
            radioProcessImageNonOri.Margin = new Padding(3, 4, 3, 4);
            radioProcessImageNonOri.Name = "radioProcessImageNonOri";
            radioProcessImageNonOri.Size = new Size(82, 24);
            radioProcessImageNonOri.TabIndex = 10;
            radioProcessImageNonOri.Text = "Non Ori";
            radioProcessImageNonOri.UseVisualStyleBackColor = true;
            // 
            // gBoxCopyVideos
            // 
            gBoxCopyVideos.Controls.Add(radioProcessVideoAll);
            gBoxCopyVideos.Controls.Add(radioProcessVideoOri);
            gBoxCopyVideos.Controls.Add(radioProcessVideoNonOri);
            gBoxCopyVideos.Location = new Point(214, 237);
            gBoxCopyVideos.Margin = new Padding(3, 4, 3, 4);
            gBoxCopyVideos.Name = "gBoxCopyVideos";
            gBoxCopyVideos.Padding = new Padding(3, 4, 3, 4);
            gBoxCopyVideos.Size = new Size(295, 55);
            gBoxCopyVideos.TabIndex = 12;
            gBoxCopyVideos.TabStop = false;
            // 
            // radioProcessVideoAll
            // 
            radioProcessVideoAll.AutoSize = true;
            radioProcessVideoAll.Checked = true;
            radioProcessVideoAll.Enabled = false;
            radioProcessVideoAll.Location = new Point(7, 19);
            radioProcessVideoAll.Margin = new Padding(3, 4, 3, 4);
            radioProcessVideoAll.Name = "radioProcessVideoAll";
            radioProcessVideoAll.Size = new Size(48, 24);
            radioProcessVideoAll.TabIndex = 10;
            radioProcessVideoAll.TabStop = true;
            radioProcessVideoAll.Text = "All";
            radioProcessVideoAll.UseVisualStyleBackColor = true;
            // 
            // radioProcessVideoOri
            // 
            radioProcessVideoOri.AutoSize = true;
            radioProcessVideoOri.Enabled = false;
            radioProcessVideoOri.Location = new Point(70, 19);
            radioProcessVideoOri.Margin = new Padding(3, 4, 3, 4);
            radioProcessVideoOri.Name = "radioProcessVideoOri";
            radioProcessVideoOri.Size = new Size(50, 24);
            radioProcessVideoOri.TabIndex = 10;
            radioProcessVideoOri.Text = "Ori";
            radioProcessVideoOri.UseVisualStyleBackColor = true;
            // 
            // radioProcessVideoNonOri
            // 
            radioProcessVideoNonOri.AutoSize = true;
            radioProcessVideoNonOri.Enabled = false;
            radioProcessVideoNonOri.Location = new Point(129, 19);
            radioProcessVideoNonOri.Margin = new Padding(3, 4, 3, 4);
            radioProcessVideoNonOri.Name = "radioProcessVideoNonOri";
            radioProcessVideoNonOri.Size = new Size(82, 24);
            radioProcessVideoNonOri.TabIndex = 10;
            radioProcessVideoNonOri.Text = "Non Ori";
            radioProcessVideoNonOri.UseVisualStyleBackColor = true;
            // 
            // checkBoxCopyImages
            // 
            checkBoxCopyImages.AutoSize = true;
            checkBoxCopyImages.Enabled = false;
            checkBoxCopyImages.Location = new Point(134, 212);
            checkBoxCopyImages.Margin = new Padding(3, 4, 3, 4);
            checkBoxCopyImages.Name = "checkBoxCopyImages";
            checkBoxCopyImages.Size = new Size(79, 24);
            checkBoxCopyImages.TabIndex = 9;
            checkBoxCopyImages.Text = "Images";
            checkBoxCopyImages.UseVisualStyleBackColor = true;
            checkBoxCopyImages.CheckedChanged += checkBoxCopyImages_CheckedChanged;
            // 
            // checkBoxCopyVideos
            // 
            checkBoxCopyVideos.AutoSize = true;
            checkBoxCopyVideos.Enabled = false;
            checkBoxCopyVideos.Location = new Point(134, 257);
            checkBoxCopyVideos.Margin = new Padding(3, 4, 3, 4);
            checkBoxCopyVideos.Name = "checkBoxCopyVideos";
            checkBoxCopyVideos.Size = new Size(76, 24);
            checkBoxCopyVideos.TabIndex = 9;
            checkBoxCopyVideos.Text = "Videos";
            checkBoxCopyVideos.UseVisualStyleBackColor = true;
            checkBoxCopyVideos.CheckedChanged += checkBoxCopyVideos_CheckedChanged;
            // 
            // checkBoxCopyDocs
            // 
            checkBoxCopyDocs.AutoSize = true;
            checkBoxCopyDocs.Enabled = false;
            checkBoxCopyDocs.Location = new Point(134, 300);
            checkBoxCopyDocs.Margin = new Padding(3, 4, 3, 4);
            checkBoxCopyDocs.Name = "checkBoxCopyDocs";
            checkBoxCopyDocs.Size = new Size(106, 24);
            checkBoxCopyDocs.TabIndex = 9;
            checkBoxCopyDocs.Text = "Documents";
            checkBoxCopyDocs.UseVisualStyleBackColor = true;
            // 
            // comboBoxCopySubFolder
            // 
            comboBoxCopySubFolder.AllowDrop = true;
            comboBoxCopySubFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCopySubFolder.FormattingEnabled = true;
            comboBoxCopySubFolder.Items.AddRange(new object[] { "/YYYY", "/YYYY/MM", "/YYYYMM", "/YYYY-MM", "/YYYY/YYYYMM", "/YYYY/YYYY-MM", "/YYYY/MM/DD" });
            comboBoxCopySubFolder.Location = new Point(134, 72);
            comboBoxCopySubFolder.Margin = new Padding(3, 4, 3, 4);
            comboBoxCopySubFolder.Name = "comboBoxCopySubFolder";
            comboBoxCopySubFolder.Size = new Size(872, 28);
            comboBoxCopySubFolder.TabIndex = 8;
            comboBoxCopySubFolder.SelectedIndexChanged += comboBoxCopySubFolder_SelectedIndexChanged;
            // 
            // lblCopyPathFinalPreview
            // 
            lblCopyPathFinalPreview.AutoSize = true;
            lblCopyPathFinalPreview.Location = new Point(134, 107);
            lblCopyPathFinalPreview.Name = "lblCopyPathFinalPreview";
            lblCopyPathFinalPreview.Size = new Size(18, 20);
            lblCopyPathFinalPreview.TabIndex = 0;
            lblCopyPathFinalPreview.Text = "...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 76);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 0;
            label3.Text = "Sub Folder";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 215);
            label8.Name = "label8";
            label8.Size = new Size(111, 20);
            label8.TabIndex = 0;
            label8.Text = "Files Extensions";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 153);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 0;
            label4.Text = "Process?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 41);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 0;
            label2.Text = "Destination";
            // 
            // txtCopyPath
            // 
            txtCopyPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCopyPath.Location = new Point(134, 31);
            txtCopyPath.Margin = new Padding(3, 4, 3, 4);
            txtCopyPath.Name = "txtCopyPath";
            txtCopyPath.Size = new Size(874, 27);
            txtCopyPath.TabIndex = 1;
            txtCopyPath.TextChanged += txtCopyPath_TextChanged;
            // 
            // btnCopyStop
            // 
            btnCopyStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyStop.BackColor = Color.Red;
            btnCopyStop.Enabled = false;
            btnCopyStop.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCopyStop.Location = new Point(730, 139);
            btnCopyStop.Margin = new Padding(3, 4, 3, 4);
            btnCopyStop.Name = "btnCopyStop";
            btnCopyStop.Size = new Size(106, 153);
            btnCopyStop.TabIndex = 7;
            btnCopyStop.Text = "Stop";
            btnCopyStop.UseVisualStyleBackColor = false;
            btnCopyStop.Click += btnCopyStop_Click;
            // 
            // btnCopyBrowse
            // 
            btnCopyBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyBrowse.Location = new Point(1019, 29);
            btnCopyBrowse.Margin = new Padding(3, 4, 3, 4);
            btnCopyBrowse.Name = "btnCopyBrowse";
            btnCopyBrowse.Size = new Size(106, 31);
            btnCopyBrowse.TabIndex = 2;
            btnCopyBrowse.Text = "Browse";
            btnCopyBrowse.UseVisualStyleBackColor = true;
            btnCopyBrowse.Click += btnCopyBrowse_Click;
            // 
            // tabPageValidasi
            // 
            tabPageValidasi.Controls.Add(panel5);
            tabPageValidasi.Location = new Point(4, 29);
            tabPageValidasi.Margin = new Padding(3, 4, 3, 4);
            tabPageValidasi.Name = "tabPageValidasi";
            tabPageValidasi.Padding = new Padding(3, 4, 3, 4);
            tabPageValidasi.Size = new Size(1146, 359);
            tabPageValidasi.TabIndex = 5;
            tabPageValidasi.Text = "Validasi";
            tabPageValidasi.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(groupBox4);
            panel5.Controls.Add(groupBox2);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 4);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(1140, 351);
            panel5.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Location = new Point(582, 4);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(555, 337);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "groupBox4";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.Controls.Add(panel6);
            groupBox2.Controls.Add(groupBox5);
            groupBox2.Controls.Add(groupBox6);
            groupBox2.Controls.Add(checkBox2);
            groupBox2.Controls.Add(checkBox3);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(3, 4);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(571, 337);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Check Meta";
            // 
            // panel6
            // 
            panel6.Controls.Add(checkBox1);
            panel6.Controls.Add(radioButton1);
            panel6.Controls.Add(radioButton2);
            panel6.Location = new Point(133, 29);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(378, 47);
            panel6.TabIndex = 23;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Location = new Point(190, 13);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(143, 24);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Delete Old FIles?";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Enabled = false;
            radioButton1.Location = new Point(102, 11);
            radioButton1.Margin = new Padding(3, 4, 3, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(67, 24);
            radioButton1.TabIndex = 0;
            radioButton1.Text = "Move";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Enabled = false;
            radioButton2.Location = new Point(16, 11);
            radioButton2.Margin = new Padding(3, 4, 3, 4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(64, 24);
            radioButton2.TabIndex = 0;
            radioButton2.TabStop = true;
            radioButton2.Text = "Copy";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(radioButton3);
            groupBox5.Controls.Add(radioButton4);
            groupBox5.Controls.Add(radioButton5);
            groupBox5.Location = new Point(213, 84);
            groupBox5.Margin = new Padding(3, 4, 3, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 4, 3, 4);
            groupBox5.Size = new Size(295, 55);
            groupBox5.TabIndex = 22;
            groupBox5.TabStop = false;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Checked = true;
            radioButton3.Enabled = false;
            radioButton3.Location = new Point(7, 19);
            radioButton3.Margin = new Padding(3, 4, 3, 4);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(48, 24);
            radioButton3.TabIndex = 10;
            radioButton3.TabStop = true;
            radioButton3.Text = "All";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Enabled = false;
            radioButton4.Location = new Point(70, 19);
            radioButton4.Margin = new Padding(3, 4, 3, 4);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(50, 24);
            radioButton4.TabIndex = 10;
            radioButton4.Text = "Ori";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Enabled = false;
            radioButton5.Location = new Point(129, 19);
            radioButton5.Margin = new Padding(3, 4, 3, 4);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(82, 24);
            radioButton5.TabIndex = 10;
            radioButton5.Text = "Non Ori";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(radioButton6);
            groupBox6.Controls.Add(radioButton7);
            groupBox6.Controls.Add(radioButton8);
            groupBox6.Location = new Point(213, 128);
            groupBox6.Margin = new Padding(3, 4, 3, 4);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(3, 4, 3, 4);
            groupBox6.Size = new Size(295, 55);
            groupBox6.TabIndex = 21;
            groupBox6.TabStop = false;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Checked = true;
            radioButton6.Enabled = false;
            radioButton6.Location = new Point(7, 19);
            radioButton6.Margin = new Padding(3, 4, 3, 4);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(48, 24);
            radioButton6.TabIndex = 10;
            radioButton6.TabStop = true;
            radioButton6.Text = "All";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Enabled = false;
            radioButton7.Location = new Point(70, 19);
            radioButton7.Margin = new Padding(3, 4, 3, 4);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(50, 24);
            radioButton7.TabIndex = 10;
            radioButton7.Text = "Ori";
            radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            radioButton8.AutoSize = true;
            radioButton8.Enabled = false;
            radioButton8.Location = new Point(129, 19);
            radioButton8.Margin = new Padding(3, 4, 3, 4);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new Size(82, 24);
            radioButton8.TabIndex = 10;
            radioButton8.Text = "Non Ori";
            radioButton8.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Enabled = false;
            checkBox2.Location = new Point(133, 103);
            checkBox2.Margin = new Padding(3, 4, 3, 4);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(79, 24);
            checkBox2.TabIndex = 19;
            checkBox2.Text = "Images";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Enabled = false;
            checkBox3.Location = new Point(133, 148);
            checkBox3.Margin = new Padding(3, 4, 3, 4);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(76, 24);
            checkBox3.TabIndex = 20;
            checkBox3.Text = "Videos";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 105);
            label7.Name = "label7";
            label7.Size = new Size(111, 20);
            label7.TabIndex = 17;
            label7.Text = "Files Extensions";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 44);
            label9.Name = "label9";
            label9.Size = new Size(65, 20);
            label9.TabIndex = 18;
            label9.Text = "Process?";
            // 
            // tabPageLog
            // 
            tabPageLog.Controls.Add(tableLayoutPanel3);
            tabPageLog.Location = new Point(4, 29);
            tabPageLog.Margin = new Padding(3, 4, 3, 4);
            tabPageLog.Name = "tabPageLog";
            tabPageLog.Size = new Size(1146, 359);
            tabPageLog.TabIndex = 3;
            tabPageLog.Text = "Log";
            tabPageLog.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(rtBoxLog, 1, 0);
            tableLayoutPanel3.Controls.Add(lstBoxLog, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(1146, 359);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // rtBoxLog
            // 
            rtBoxLog.Dock = DockStyle.Fill;
            rtBoxLog.Location = new Point(576, 4);
            rtBoxLog.Margin = new Padding(3, 4, 3, 4);
            rtBoxLog.Name = "rtBoxLog";
            rtBoxLog.Size = new Size(567, 351);
            rtBoxLog.TabIndex = 1;
            rtBoxLog.Text = "";
            // 
            // lstBoxLog
            // 
            lstBoxLog.Dock = DockStyle.Fill;
            lstBoxLog.FormattingEnabled = true;
            lstBoxLog.ImeMode = ImeMode.NoControl;
            lstBoxLog.Location = new Point(3, 4);
            lstBoxLog.Margin = new Padding(3, 4, 3, 4);
            lstBoxLog.Name = "lstBoxLog";
            lstBoxLog.Size = new Size(567, 351);
            lstBoxLog.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { progressBarGlobal, labelProgress, progressBarPerFile });
            statusStrip1.Location = new Point(0, 743);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1181, 32);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "-";
            // 
            // progressBarGlobal
            // 
            progressBarGlobal.Alignment = ToolStripItemAlignment.Right;
            progressBarGlobal.Name = "progressBarGlobal";
            progressBarGlobal.Size = new Size(229, 24);
            // 
            // labelProgress
            // 
            labelProgress.ForeColor = SystemColors.ControlText;
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(15, 26);
            labelProgress.Text = "-";
            // 
            // progressBarPerFile
            // 
            progressBarPerFile.Name = "progressBarPerFile";
            progressBarPerFile.Size = new Size(114, 24);
            progressBarPerFile.Visible = false;
            // 
            // folderBrowserScan
            // 
            folderBrowserScan.RootFolder = Environment.SpecialFolder.MyComputer;
            // 
            // bgWorkerScan
            // 
            bgWorkerScan.WorkerReportsProgress = true;
            bgWorkerScan.WorkerSupportsCancellation = true;
            bgWorkerScan.DoWork += bgWorkerScan_DoWork;
            bgWorkerScan.ProgressChanged += bgWorkerScan_ProgressChanged;
            bgWorkerScan.RunWorkerCompleted += bgWorkerScan_RunWorkerCompleted;
            // 
            // bgWorkerCopy
            // 
            bgWorkerCopy.WorkerReportsProgress = true;
            bgWorkerCopy.WorkerSupportsCancellation = true;
            bgWorkerCopy.DoWork += bgWorkerCopy_DoWork;
            bgWorkerCopy.ProgressChanged += bgWorkerCopy_ProgressChanged;
            bgWorkerCopy.RunWorkerCompleted += bgWorkerCopy_RunWorkerCompleted;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1181, 775);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Foto & Video Sorter V2";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvScan).EndInit();
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageScan.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            gbPicturePreview.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            gbScanParams.ResumeLayout(false);
            gbScanParams.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabPagePrefixFound.ResumeLayout(false);
            tabPagePrefixFound.PerformLayout();
            tabPageProcess.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            gBoxCopyImages.ResumeLayout(false);
            gBoxCopyImages.PerformLayout();
            gBoxCopyVideos.ResumeLayout(false);
            gBoxCopyVideos.PerformLayout();
            tabPageValidasi.ResumeLayout(false);
            panel5.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            tabPageLog.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private StatusStrip statusStrip1;
        private TabControl tabControl1;
        private TabPage tabPageScan;
        private DataGridView dgvScan;
        private TabPage tabPageLog;
        private CheckBox chkKeyIncl;
        private CheckBox chkDocument;
        private CheckBox chkVideo;
        private CheckBox chkImage;
        private Button btnScanBrowse;
        private TextBox txtScanPath;
        private Label label1;
        private CheckBox chkKeyExcl;
        private TextBox txtExtDocument;
        private TextBox txtExtImage;
        private TextBox txtExtVideo;
        private TextBox txtKeyIncl;
        private TextBox txtKeyExcl;
        private Button btnScan;
        private ToolStripProgressBar progressBarGlobal;
        private ToolStripStatusLabel labelProgress;
        private FolderBrowserDialog folderBrowserScan;
        private Panel panel2;
        private System.ComponentModel.BackgroundWorker bgWorkerScan;
        private Button btnCancelScan;
        private GroupBox gbScanParams;
        private GroupBox gbPicturePreview;
        private PictureBox picBox;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TabPage tabPageProcess;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox3;
        private Label label2;
        private TextBox txtCopyPath;
        private Button btnCopyStop;
        private Button btnCopyBrowse;
        private ComboBox comboBoxCopySubFolder;
        private Label label3;
        private System.ComponentModel.BackgroundWorker bgWorkerCopy;
        private TabPage tabPagePrefixFound;
        private CheckBox checkBoxCopyImages;
        private CheckBox checkBoxCopyDocs;
        private CheckBox checkBoxCopyVideos;
        private Label label4;
        private RadioButton radioProcessVideoNonOri;
        private RadioButton radioProcessVideoOri;
        private RadioButton radioProcessVideoAll;
        private GroupBox gBoxCopyVideos;
        private GroupBox gBoxCopyImages;
        private RadioButton radioProcessImageAll;
        private RadioButton radioProcessImageOri;
        private RadioButton radioProcessImageNonOri;
        private ToolStripProgressBar progressBarPerFile;
        private Splitter splitter1;
        private Label lblCopyPathFinalPreview;
        private Label label5;
        private Label label6;
        private FolderBrowserDialog folderBrowserCopy;
        private ListBox lstBoxLog;
        private RichTextBox rtBoxLog;
        private RichTextBox richTextBoxPrefixFound;
        private Panel panel3;
        private RadioButton radioOri;
        private RadioButton radioNonOri;
        private RadioButton radioAll;
        private Button buttonProcess;
        private Panel panel4;
        private RadioButton radioButtonProcessCopy;
        private RadioButton radioButtonProcessMove;
        private CheckBox checkBoxMoveDeleteFiles;
        private Label label8;
        private TableLayoutPanel tableLayoutPanel3;
        private RichTextBox rtBoxMetaFiles;
        private TableLayoutPanel tableLayoutPanel4;
        private TabPage tabPageValidasi;
        private Panel panel5;
        private GroupBox groupBox4;
        private GroupBox groupBox2;
        private Panel panel6;
        private CheckBox checkBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private GroupBox groupBox5;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private GroupBox groupBox6;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private Label label7;
        private Label label9;
        private DataGridViewCheckBoxColumn checkBox;
        private DataGridViewTextBoxColumn no;
        private DataGridViewTextBoxColumn dirPath;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn size;
        private DataGridViewTextBoxColumn originalStatus;
        private DataGridViewTextBoxColumn dateTaken;
        private DataGridViewTextBoxColumn mediaCreated;
        private DataGridViewTextBoxColumn dateCreated;
        private DataGridViewTextBoxColumn fileStatus;
        private DataGridViewTextBoxColumn copyStatus;
    }
}
