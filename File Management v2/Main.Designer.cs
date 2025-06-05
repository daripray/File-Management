namespace File_Management_v2
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
            no = new DataGridViewTextBoxColumn();
            directory = new DataGridViewTextBoxColumn();
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
            tabPage1 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            gbPicturePreview = new GroupBox();
            picBox = new PictureBox();
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
            tabPage5 = new TabPage();
            richTextBoxPrefixFound = new RichTextBox();
            label6 = new Label();
            tabPage2 = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox3 = new GroupBox();
            panel4 = new Panel();
            checkBoxMoveDeleteFiles = new CheckBox();
            radioButtonProcessMove = new RadioButton();
            radioButtonProcessCopy = new RadioButton();
            btnProcess = new Button();
            checkBoxMoveDeleteFile = new CheckBox();
            gBoxCopyImages = new GroupBox();
            rbtnImageAll = new RadioButton();
            rbtnImageOri = new RadioButton();
            rbtnImageNonOri = new RadioButton();
            gBoxCopyVideos = new GroupBox();
            rbtnVideoAll = new RadioButton();
            rbtnVideoOri = new RadioButton();
            rbtnVideoNonOri = new RadioButton();
            chkBoxCopyImages = new CheckBox();
            chkBoxCopyVideos = new CheckBox();
            chkBoxCopyDocuments = new CheckBox();
            comboBoxCopySubFolder = new ComboBox();
            lblCopyPathFinalPreview = new Label();
            label3 = new Label();
            label8 = new Label();
            label4 = new Label();
            label2 = new Label();
            txtCopyPath = new TextBox();
            btnMove = new Button();
            btnCopyStop = new Button();
            btnCopy = new Button();
            btnCopyBrowse = new Button();
            tabPage4 = new TabPage();
            rtBoxLog = new RichTextBox();
            lstBoxLog = new ListBox();
            statusStrip1 = new StatusStrip();
            progressBarScan = new ToolStripProgressBar();
            toolStripLabelProgress = new ToolStripStatusLabel();
            toolStripProgressBarPerFile = new ToolStripProgressBar();
            folderBrowserScan = new FolderBrowserDialog();
            bgWorkerScan = new System.ComponentModel.BackgroundWorker();
            bgWorkerCopy = new System.ComponentModel.BackgroundWorker();
            folderBrowserCopy = new FolderBrowserDialog();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScan).BeginInit();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            gbPicturePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            gbScanParams.SuspendLayout();
            panel3.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox3.SuspendLayout();
            panel4.SuspendLayout();
            gBoxCopyImages.SuspendLayout();
            gBoxCopyVideos.SuspendLayout();
            tabPage4.SuspendLayout();
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
            panel1.Name = "panel1";
            panel1.Size = new Size(1204, 581);
            panel1.TabIndex = 0;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 559);
            splitter1.TabIndex = 7;
            splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(dgvScan);
            groupBox1.Location = new Point(16, 308);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1172, 248);
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
            dgvScan.Columns.AddRange(new DataGridViewColumn[] { no, directory, name, type, size, originalStatus, dateTaken, mediaCreated, dateCreated, fileStatus, copyStatus });
            dgvScan.Dock = DockStyle.Fill;
            dgvScan.Location = new Point(3, 19);
            dgvScan.Name = "dgvScan";
            dgvScan.ReadOnly = true;
            dgvScan.Size = new Size(1166, 226);
            dgvScan.TabIndex = 3;
            dgvScan.SelectionChanged += dgvScan_SelectionChanged;
            // 
            // no
            // 
            no.HeaderText = "No";
            no.Name = "no";
            no.ReadOnly = true;
            no.Width = 50;
            // 
            // directory
            // 
            directory.HeaderText = "Directory";
            directory.Name = "directory";
            directory.ReadOnly = true;
            directory.Width = 150;
            // 
            // name
            // 
            name.HeaderText = "Name";
            name.Name = "name";
            name.ReadOnly = true;
            // 
            // type
            // 
            type.HeaderText = "Type";
            type.Name = "type";
            type.ReadOnly = true;
            type.Width = 70;
            // 
            // size
            // 
            size.HeaderText = "Size (B)";
            size.Name = "size";
            size.ReadOnly = true;
            size.Width = 70;
            // 
            // originalStatus
            // 
            originalStatus.HeaderText = "Original Status";
            originalStatus.Name = "originalStatus";
            originalStatus.ReadOnly = true;
            originalStatus.Width = 70;
            // 
            // dateTaken
            // 
            dateTaken.HeaderText = "Date Taken";
            dateTaken.Name = "dateTaken";
            dateTaken.ReadOnly = true;
            dateTaken.Width = 120;
            // 
            // mediaCreated
            // 
            mediaCreated.HeaderText = "Media Created";
            mediaCreated.Name = "mediaCreated";
            mediaCreated.ReadOnly = true;
            mediaCreated.Width = 120;
            // 
            // dateCreated
            // 
            dateCreated.HeaderText = "Date Created";
            dateCreated.Name = "dateCreated";
            dateCreated.ReadOnly = true;
            dateCreated.Width = 120;
            // 
            // fileStatus
            // 
            fileStatus.HeaderText = "Quality Status";
            fileStatus.Name = "fileStatus";
            fileStatus.ReadOnly = true;
            // 
            // copyStatus
            // 
            copyStatus.HeaderText = "Process Status";
            copyStatus.Name = "copyStatus";
            copyStatus.ReadOnly = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(tabControl1);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(1181, 294);
            panel2.TabIndex = 5;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1181, 294);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1173, 266);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Scan Images";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57.2446556F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.7553444F));
            tableLayoutPanel1.Controls.Add(gbPicturePreview, 1, 0);
            tableLayoutPanel1.Controls.Add(gbScanParams, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1167, 260);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // gbPicturePreview
            // 
            gbPicturePreview.Controls.Add(picBox);
            gbPicturePreview.Dock = DockStyle.Fill;
            gbPicturePreview.Location = new Point(671, 3);
            gbPicturePreview.Name = "gbPicturePreview";
            gbPicturePreview.Size = new Size(493, 254);
            gbPicturePreview.TabIndex = 10;
            gbPicturePreview.TabStop = false;
            gbPicturePreview.Text = "Preview";
            // 
            // picBox
            // 
            picBox.Dock = DockStyle.Fill;
            picBox.Location = new Point(3, 19);
            picBox.Name = "picBox";
            picBox.Size = new Size(487, 232);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.TabIndex = 0;
            picBox.TabStop = false;
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
            gbScanParams.Location = new Point(3, 3);
            gbScanParams.Name = "gbScanParams";
            gbScanParams.Size = new Size(662, 254);
            gbScanParams.TabIndex = 9;
            gbScanParams.TabStop = false;
            gbScanParams.Text = "Parameter";
            // 
            // panel3
            // 
            panel3.Controls.Add(radioOri);
            panel3.Controls.Add(radioNonOri);
            panel3.Controls.Add(radioAll);
            panel3.Location = new Point(120, 203);
            panel3.Name = "panel3";
            panel3.Size = new Size(430, 33);
            panel3.TabIndex = 9;
            // 
            // radioOri
            // 
            radioOri.AutoSize = true;
            radioOri.Enabled = false;
            radioOri.Location = new Point(64, 8);
            radioOri.Name = "radioOri";
            radioOri.Size = new Size(41, 19);
            radioOri.TabIndex = 0;
            radioOri.Text = "Ori";
            radioOri.UseVisualStyleBackColor = true;
            // 
            // radioNonOri
            // 
            radioNonOri.AutoSize = true;
            radioNonOri.Enabled = false;
            radioNonOri.Location = new Point(127, 8);
            radioNonOri.Name = "radioNonOri";
            radioNonOri.Size = new Size(69, 19);
            radioNonOri.TabIndex = 0;
            radioNonOri.Text = "Non-Ori";
            radioNonOri.UseVisualStyleBackColor = true;
            // 
            // radioAll
            // 
            radioAll.AutoSize = true;
            radioAll.Checked = true;
            radioAll.Enabled = false;
            radioAll.Location = new Point(3, 8);
            radioAll.Name = "radioAll";
            radioAll.Size = new Size(39, 19);
            radioAll.TabIndex = 0;
            radioAll.TabStop = true;
            radioAll.Text = "All";
            radioAll.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 206);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 8;
            label5.Text = "Original Status";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 31);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Source";
            // 
            // txtScanPath
            // 
            txtScanPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtScanPath.Location = new Point(117, 23);
            txtScanPath.Name = "txtScanPath";
            txtScanPath.Size = new Size(433, 23);
            txtScanPath.TabIndex = 1;
            txtScanPath.TextChanged += txtScanPath_TextChanged;
            // 
            // btnCancelScan
            // 
            btnCancelScan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelScan.BackColor = Color.Red;
            btnCancelScan.Enabled = false;
            btnCancelScan.Location = new Point(559, 132);
            btnCancelScan.Name = "btnCancelScan";
            btnCancelScan.Size = new Size(93, 67);
            btnCancelScan.TabIndex = 7;
            btnCancelScan.Text = "Stop";
            btnCancelScan.UseVisualStyleBackColor = false;
            btnCancelScan.Click += btnCancelScan_Click;
            // 
            // txtExtVideo
            // 
            txtExtVideo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtExtVideo.Enabled = false;
            txtExtVideo.Location = new Point(117, 82);
            txtExtVideo.Name = "txtExtVideo";
            txtExtVideo.Size = new Size(433, 23);
            txtExtVideo.TabIndex = 1;
            txtExtVideo.Text = "MP4, MOV, AVI, MKV, FLV, WMV, M4V, WEBM, MPG, MPEG, 3GP, MTS, M2TS, TS, OGV";
            // 
            // btnScan
            // 
            btnScan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScan.BackColor = Color.LawnGreen;
            btnScan.Enabled = false;
            btnScan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnScan.Location = new Point(559, 59);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(93, 67);
            btnScan.TabIndex = 7;
            btnScan.Text = "Scan";
            btnScan.UseVisualStyleBackColor = false;
            btnScan.Click += btnScan_Click;
            // 
            // txtExtImage
            // 
            txtExtImage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtExtImage.Enabled = false;
            txtExtImage.Location = new Point(117, 53);
            txtExtImage.Name = "txtExtImage";
            txtExtImage.Size = new Size(433, 23);
            txtExtImage.TabIndex = 1;
            txtExtImage.Text = "JPG, JPEG, PNG, GIF, BMP, TIFF, TIF, WEBP, HEIC, HEIF, RAW, CR2, NEF, ORF, SR2, ARW, DNG, PSD, ICO, SVG";
            // 
            // chkKeyExcl
            // 
            chkKeyExcl.AutoSize = true;
            chkKeyExcl.Enabled = false;
            chkKeyExcl.Location = new Point(15, 173);
            chkKeyExcl.Name = "chkKeyExcl";
            chkKeyExcl.Size = new Size(88, 19);
            chkKeyExcl.TabIndex = 6;
            chkKeyExcl.Text = "Key Exclude";
            chkKeyExcl.UseVisualStyleBackColor = true;
            chkKeyExcl.CheckedChanged += chkKeyExcl_CheckedChanged;
            // 
            // txtExtDocument
            // 
            txtExtDocument.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtExtDocument.Enabled = false;
            txtExtDocument.Location = new Point(117, 111);
            txtExtDocument.Name = "txtExtDocument";
            txtExtDocument.Size = new Size(433, 23);
            txtExtDocument.TabIndex = 1;
            txtExtDocument.Text = "DOC, DOCX, PDF, XLS, XLSX, PPT, PPTX, TXT, RTF, ODT, ODS, ODP, CSV, XML, HTML, HTM, JSON, MD, LOG";
            // 
            // chkKeyIncl
            // 
            chkKeyIncl.AutoSize = true;
            chkKeyIncl.Enabled = false;
            chkKeyIncl.Location = new Point(16, 144);
            chkKeyIncl.Name = "chkKeyIncl";
            chkKeyIncl.Size = new Size(87, 19);
            chkKeyIncl.TabIndex = 6;
            chkKeyIncl.Text = "Key Include";
            chkKeyIncl.UseVisualStyleBackColor = true;
            chkKeyIncl.CheckedChanged += chkKeyIncl_CheckedChanged;
            // 
            // txtKeyIncl
            // 
            txtKeyIncl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKeyIncl.Enabled = false;
            txtKeyIncl.Location = new Point(117, 140);
            txtKeyIncl.Name = "txtKeyIncl";
            txtKeyIncl.Size = new Size(433, 23);
            txtKeyIncl.TabIndex = 1;
            txtKeyIncl.Text = "IMG, DSC, PXL, JPEG, PHOTO, SAMSUNG, ANDROID, DCIM, CAM, CAMERA, DCM, PIC, MV, IMG_E";
            // 
            // chkDocument
            // 
            chkDocument.AutoSize = true;
            chkDocument.Enabled = false;
            chkDocument.Location = new Point(16, 115);
            chkDocument.Name = "chkDocument";
            chkDocument.Size = new Size(82, 19);
            chkDocument.TabIndex = 5;
            chkDocument.Text = "Document";
            chkDocument.UseVisualStyleBackColor = true;
            chkDocument.CheckedChanged += chkDocument_CheckedChanged;
            // 
            // txtKeyExcl
            // 
            txtKeyExcl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKeyExcl.Enabled = false;
            txtKeyExcl.Location = new Point(117, 169);
            txtKeyExcl.Name = "txtKeyExcl";
            txtKeyExcl.Size = new Size(433, 23);
            txtKeyExcl.TabIndex = 1;
            txtKeyExcl.Text = ".IMG, .VID, .MOV, SCREENSHOT";
            // 
            // chkVideo
            // 
            chkVideo.AutoSize = true;
            chkVideo.Enabled = false;
            chkVideo.Location = new Point(16, 86);
            chkVideo.Name = "chkVideo";
            chkVideo.Size = new Size(56, 19);
            chkVideo.TabIndex = 4;
            chkVideo.Text = "Video";
            chkVideo.UseVisualStyleBackColor = true;
            chkVideo.CheckedChanged += chkVideo_CheckedChanged;
            // 
            // btnScanBrowse
            // 
            btnScanBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScanBrowse.Location = new Point(559, 22);
            btnScanBrowse.Name = "btnScanBrowse";
            btnScanBrowse.Size = new Size(93, 23);
            btnScanBrowse.TabIndex = 2;
            btnScanBrowse.Text = "Browse";
            btnScanBrowse.UseVisualStyleBackColor = true;
            btnScanBrowse.Click += btnScanBrowse_Click;
            // 
            // chkImage
            // 
            chkImage.AutoSize = true;
            chkImage.Enabled = false;
            chkImage.Location = new Point(16, 57);
            chkImage.Name = "chkImage";
            chkImage.Size = new Size(59, 19);
            chkImage.TabIndex = 3;
            chkImage.Text = "Image";
            chkImage.UseVisualStyleBackColor = true;
            chkImage.CheckedChanged += chkImage_CheckedChanged;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(richTextBoxPrefixFound);
            tabPage5.Controls.Add(label6);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1173, 266);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Prefix Found";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // richTextBoxPrefixFound
            // 
            richTextBoxPrefixFound.Dock = DockStyle.Fill;
            richTextBoxPrefixFound.Location = new Point(3, 3);
            richTextBoxPrefixFound.Name = "richTextBoxPrefixFound";
            richTextBoxPrefixFound.Size = new Size(1167, 260);
            richTextBoxPrefixFound.TabIndex = 2;
            richTextBoxPrefixFound.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 10);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 1;
            label6.Text = "Prefix Found:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tableLayoutPanel2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1173, 266);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Copy/Move";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.8536568F));
            tableLayoutPanel2.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1167, 260);
            tableLayoutPanel2.TabIndex = 12;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(panel4);
            groupBox3.Controls.Add(btnProcess);
            groupBox3.Controls.Add(checkBoxMoveDeleteFile);
            groupBox3.Controls.Add(gBoxCopyImages);
            groupBox3.Controls.Add(gBoxCopyVideos);
            groupBox3.Controls.Add(chkBoxCopyImages);
            groupBox3.Controls.Add(chkBoxCopyVideos);
            groupBox3.Controls.Add(chkBoxCopyDocuments);
            groupBox3.Controls.Add(comboBoxCopySubFolder);
            groupBox3.Controls.Add(lblCopyPathFinalPreview);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(txtCopyPath);
            groupBox3.Controls.Add(btnMove);
            groupBox3.Controls.Add(btnCopyStop);
            groupBox3.Controls.Add(btnCopy);
            groupBox3.Controls.Add(btnCopyBrowse);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1161, 254);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Parameter";
            // 
            // panel4
            // 
            panel4.Controls.Add(checkBoxMoveDeleteFiles);
            panel4.Controls.Add(radioButtonProcessMove);
            panel4.Controls.Add(radioButtonProcessCopy);
            panel4.Location = new Point(117, 104);
            panel4.Name = "panel4";
            panel4.Size = new Size(331, 35);
            panel4.TabIndex = 16;
            // 
            // checkBoxMoveDeleteFiles
            // 
            checkBoxMoveDeleteFiles.AutoSize = true;
            checkBoxMoveDeleteFiles.Enabled = false;
            checkBoxMoveDeleteFiles.Location = new Point(166, 10);
            checkBoxMoveDeleteFiles.Name = "checkBoxMoveDeleteFiles";
            checkBoxMoveDeleteFiles.Size = new Size(112, 19);
            checkBoxMoveDeleteFiles.TabIndex = 1;
            checkBoxMoveDeleteFiles.Text = "Delete Old FIles?";
            checkBoxMoveDeleteFiles.UseVisualStyleBackColor = true;
            // 
            // radioButtonProcessMove
            // 
            radioButtonProcessMove.AutoSize = true;
            radioButtonProcessMove.Enabled = false;
            radioButtonProcessMove.Location = new Point(89, 8);
            radioButtonProcessMove.Name = "radioButtonProcessMove";
            radioButtonProcessMove.Size = new Size(55, 19);
            radioButtonProcessMove.TabIndex = 0;
            radioButtonProcessMove.Text = "Move";
            radioButtonProcessMove.UseVisualStyleBackColor = true;
            // 
            // radioButtonProcessCopy
            // 
            radioButtonProcessCopy.AutoSize = true;
            radioButtonProcessCopy.Checked = true;
            radioButtonProcessCopy.Enabled = false;
            radioButtonProcessCopy.Location = new Point(14, 8);
            radioButtonProcessCopy.Name = "radioButtonProcessCopy";
            radioButtonProcessCopy.Size = new Size(53, 19);
            radioButtonProcessCopy.TabIndex = 0;
            radioButtonProcessCopy.TabStop = true;
            radioButtonProcessCopy.Text = "Copy";
            radioButtonProcessCopy.UseVisualStyleBackColor = true;
            radioButtonProcessCopy.CheckedChanged += radioButtonProcessCopy_CheckedChanged;
            // 
            // btnProcess
            // 
            btnProcess.Location = new Point(553, 112);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(119, 99);
            btnProcess.TabIndex = 15;
            btnProcess.Text = "Copy";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // checkBoxMoveDeleteFile
            // 
            checkBoxMoveDeleteFile.AutoSize = true;
            checkBoxMoveDeleteFile.Location = new Point(903, 137);
            checkBoxMoveDeleteFile.Name = "checkBoxMoveDeleteFile";
            checkBoxMoveDeleteFile.Size = new Size(15, 14);
            checkBoxMoveDeleteFile.TabIndex = 14;
            checkBoxMoveDeleteFile.UseVisualStyleBackColor = true;
            // 
            // gBoxCopyImages
            // 
            gBoxCopyImages.Controls.Add(rbtnImageAll);
            gBoxCopyImages.Controls.Add(rbtnImageOri);
            gBoxCopyImages.Controls.Add(rbtnImageNonOri);
            gBoxCopyImages.Location = new Point(187, 145);
            gBoxCopyImages.Name = "gBoxCopyImages";
            gBoxCopyImages.Size = new Size(258, 41);
            gBoxCopyImages.TabIndex = 13;
            gBoxCopyImages.TabStop = false;
            // 
            // rbtnImageAll
            // 
            rbtnImageAll.AutoSize = true;
            rbtnImageAll.Checked = true;
            rbtnImageAll.Enabled = false;
            rbtnImageAll.Location = new Point(6, 14);
            rbtnImageAll.Name = "rbtnImageAll";
            rbtnImageAll.Size = new Size(39, 19);
            rbtnImageAll.TabIndex = 10;
            rbtnImageAll.TabStop = true;
            rbtnImageAll.Text = "All";
            rbtnImageAll.UseVisualStyleBackColor = true;
            // 
            // rbtnImageOri
            // 
            rbtnImageOri.AutoSize = true;
            rbtnImageOri.Enabled = false;
            rbtnImageOri.Location = new Point(61, 14);
            rbtnImageOri.Name = "rbtnImageOri";
            rbtnImageOri.Size = new Size(41, 19);
            rbtnImageOri.TabIndex = 10;
            rbtnImageOri.Text = "Ori";
            rbtnImageOri.UseVisualStyleBackColor = true;
            // 
            // rbtnImageNonOri
            // 
            rbtnImageNonOri.AutoSize = true;
            rbtnImageNonOri.Enabled = false;
            rbtnImageNonOri.Location = new Point(113, 14);
            rbtnImageNonOri.Name = "rbtnImageNonOri";
            rbtnImageNonOri.Size = new Size(67, 19);
            rbtnImageNonOri.TabIndex = 10;
            rbtnImageNonOri.Text = "Non Ori";
            rbtnImageNonOri.UseVisualStyleBackColor = true;
            // 
            // gBoxCopyVideos
            // 
            gBoxCopyVideos.Controls.Add(rbtnVideoAll);
            gBoxCopyVideos.Controls.Add(rbtnVideoOri);
            gBoxCopyVideos.Controls.Add(rbtnVideoNonOri);
            gBoxCopyVideos.Location = new Point(187, 178);
            gBoxCopyVideos.Name = "gBoxCopyVideos";
            gBoxCopyVideos.Size = new Size(258, 41);
            gBoxCopyVideos.TabIndex = 12;
            gBoxCopyVideos.TabStop = false;
            // 
            // rbtnVideoAll
            // 
            rbtnVideoAll.AutoSize = true;
            rbtnVideoAll.Checked = true;
            rbtnVideoAll.Enabled = false;
            rbtnVideoAll.Location = new Point(6, 14);
            rbtnVideoAll.Name = "rbtnVideoAll";
            rbtnVideoAll.Size = new Size(39, 19);
            rbtnVideoAll.TabIndex = 10;
            rbtnVideoAll.TabStop = true;
            rbtnVideoAll.Text = "All";
            rbtnVideoAll.UseVisualStyleBackColor = true;
            // 
            // rbtnVideoOri
            // 
            rbtnVideoOri.AutoSize = true;
            rbtnVideoOri.Enabled = false;
            rbtnVideoOri.Location = new Point(61, 14);
            rbtnVideoOri.Name = "rbtnVideoOri";
            rbtnVideoOri.Size = new Size(41, 19);
            rbtnVideoOri.TabIndex = 10;
            rbtnVideoOri.Text = "Ori";
            rbtnVideoOri.UseVisualStyleBackColor = true;
            // 
            // rbtnVideoNonOri
            // 
            rbtnVideoNonOri.AutoSize = true;
            rbtnVideoNonOri.Enabled = false;
            rbtnVideoNonOri.Location = new Point(113, 14);
            rbtnVideoNonOri.Name = "rbtnVideoNonOri";
            rbtnVideoNonOri.Size = new Size(67, 19);
            rbtnVideoNonOri.TabIndex = 10;
            rbtnVideoNonOri.Text = "Non Ori";
            rbtnVideoNonOri.UseVisualStyleBackColor = true;
            // 
            // chkBoxCopyImages
            // 
            chkBoxCopyImages.AutoSize = true;
            chkBoxCopyImages.Enabled = false;
            chkBoxCopyImages.Location = new Point(117, 159);
            chkBoxCopyImages.Name = "chkBoxCopyImages";
            chkBoxCopyImages.Size = new Size(64, 19);
            chkBoxCopyImages.TabIndex = 9;
            chkBoxCopyImages.Text = "Images";
            chkBoxCopyImages.UseVisualStyleBackColor = true;
            chkBoxCopyImages.CheckedChanged += chkBoxCopyImages_CheckedChanged;
            // 
            // chkBoxCopyVideos
            // 
            chkBoxCopyVideos.AutoSize = true;
            chkBoxCopyVideos.Enabled = false;
            chkBoxCopyVideos.Location = new Point(117, 193);
            chkBoxCopyVideos.Name = "chkBoxCopyVideos";
            chkBoxCopyVideos.Size = new Size(61, 19);
            chkBoxCopyVideos.TabIndex = 9;
            chkBoxCopyVideos.Text = "Videos";
            chkBoxCopyVideos.UseVisualStyleBackColor = true;
            chkBoxCopyVideos.CheckedChanged += chkBoxCopyVideos_CheckedChanged;
            // 
            // chkBoxCopyDocuments
            // 
            chkBoxCopyDocuments.AutoSize = true;
            chkBoxCopyDocuments.Enabled = false;
            chkBoxCopyDocuments.Location = new Point(117, 225);
            chkBoxCopyDocuments.Name = "chkBoxCopyDocuments";
            chkBoxCopyDocuments.Size = new Size(87, 19);
            chkBoxCopyDocuments.TabIndex = 9;
            chkBoxCopyDocuments.Text = "Documents";
            chkBoxCopyDocuments.UseVisualStyleBackColor = true;
            // 
            // comboBoxCopySubFolder
            // 
            comboBoxCopySubFolder.AllowDrop = true;
            comboBoxCopySubFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCopySubFolder.FormattingEnabled = true;
            comboBoxCopySubFolder.Items.AddRange(new object[] { "/yyyy", "/yyyy/MM", "/yyyy/yyyyMM/", "/yyyy/yyyy_MM/", "/yyyy/MM/dd", "/yyyy/yyyyMM/yyyyMMdd", "/yyyy/yyyy_MM/yyyy_MM_dd" });
            comboBoxCopySubFolder.Location = new Point(117, 54);
            comboBoxCopySubFolder.Name = "comboBoxCopySubFolder";
            comboBoxCopySubFolder.Size = new Size(932, 23);
            comboBoxCopySubFolder.TabIndex = 8;
            comboBoxCopySubFolder.SelectedIndexChanged += comboBoxCopySubFolder_SelectedIndexChanged;
            // 
            // lblCopyPathFinalPreview
            // 
            lblCopyPathFinalPreview.AutoSize = true;
            lblCopyPathFinalPreview.Location = new Point(117, 80);
            lblCopyPathFinalPreview.Name = "lblCopyPathFinalPreview";
            lblCopyPathFinalPreview.Size = new Size(16, 15);
            lblCopyPathFinalPreview.TabIndex = 0;
            lblCopyPathFinalPreview.Text = "...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 57);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 0;
            label3.Text = "Sub Folder";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 161);
            label8.Name = "label8";
            label8.Size = new Size(88, 15);
            label8.TabIndex = 0;
            label8.Text = "Files Extensions";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 115);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 0;
            label4.Text = "Process?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 31);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 0;
            label2.Text = "Destination";
            // 
            // txtCopyPath
            // 
            txtCopyPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCopyPath.Location = new Point(117, 23);
            txtCopyPath.Name = "txtCopyPath";
            txtCopyPath.Size = new Size(934, 23);
            txtCopyPath.TabIndex = 1;
            txtCopyPath.TextChanged += txtCopyPath_TextChanged;
            // 
            // btnMove
            // 
            btnMove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMove.BackColor = Color.DodgerBlue;
            btnMove.Enabled = false;
            btnMove.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMove.Location = new Point(1060, 124);
            btnMove.Name = "btnMove";
            btnMove.Size = new Size(93, 54);
            btnMove.TabIndex = 7;
            btnMove.Text = "Move";
            btnMove.UseVisualStyleBackColor = false;
            btnMove.Click += btnMove_Click;
            // 
            // btnCopyStop
            // 
            btnCopyStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyStop.BackColor = Color.Red;
            btnCopyStop.Enabled = false;
            btnCopyStop.Location = new Point(736, 142);
            btnCopyStop.Name = "btnCopyStop";
            btnCopyStop.Size = new Size(93, 54);
            btnCopyStop.TabIndex = 7;
            btnCopyStop.Text = "Stop";
            btnCopyStop.UseVisualStyleBackColor = false;
            btnCopyStop.Click += btnCopyStop_Click;
            // 
            // btnCopy
            // 
            btnCopy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopy.BackColor = Color.LawnGreen;
            btnCopy.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnCopy.Location = new Point(1060, 59);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(93, 59);
            btnCopy.TabIndex = 7;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = false;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnCopyBrowse
            // 
            btnCopyBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyBrowse.Location = new Point(1060, 22);
            btnCopyBrowse.Name = "btnCopyBrowse";
            btnCopyBrowse.Size = new Size(93, 23);
            btnCopyBrowse.TabIndex = 2;
            btnCopyBrowse.Text = "Browse";
            btnCopyBrowse.UseVisualStyleBackColor = true;
            btnCopyBrowse.Click += btnCopyBrowse_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(rtBoxLog);
            tabPage4.Controls.Add(lstBoxLog);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1173, 266);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Log";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // rtBoxLog
            // 
            rtBoxLog.Location = new Point(472, 0);
            rtBoxLog.Name = "rtBoxLog";
            rtBoxLog.Size = new Size(470, 259);
            rtBoxLog.TabIndex = 1;
            rtBoxLog.Text = "";
            // 
            // lstBoxLog
            // 
            lstBoxLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstBoxLog.FormattingEnabled = true;
            lstBoxLog.ImeMode = ImeMode.NoControl;
            lstBoxLog.ItemHeight = 15;
            lstBoxLog.Location = new Point(0, 0);
            lstBoxLog.Name = "lstBoxLog";
            lstBoxLog.Size = new Size(466, 259);
            lstBoxLog.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { progressBarScan, toolStripLabelProgress, toolStripProgressBarPerFile });
            statusStrip1.Location = new Point(0, 559);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1204, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "-";
            // 
            // progressBarScan
            // 
            progressBarScan.Alignment = ToolStripItemAlignment.Right;
            progressBarScan.Name = "progressBarScan";
            progressBarScan.Size = new Size(200, 16);
            // 
            // toolStripLabelProgress
            // 
            toolStripLabelProgress.ForeColor = SystemColors.ControlText;
            toolStripLabelProgress.Name = "toolStripLabelProgress";
            toolStripLabelProgress.Size = new Size(12, 17);
            toolStripLabelProgress.Text = "-";
            // 
            // toolStripProgressBarPerFile
            // 
            toolStripProgressBarPerFile.Name = "toolStripProgressBarPerFile";
            toolStripProgressBarPerFile.Size = new Size(100, 16);
            toolStripProgressBarPerFile.Visible = false;
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 581);
            Controls.Add(panel1);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Foto & Video Sorter V2";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvScan).EndInit();
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            gbPicturePreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            gbScanParams.ResumeLayout(false);
            gbScanParams.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabPage2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            gBoxCopyImages.ResumeLayout(false);
            gBoxCopyImages.PerformLayout();
            gBoxCopyVideos.ResumeLayout(false);
            gBoxCopyVideos.PerformLayout();
            tabPage4.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private StatusStrip statusStrip1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dgvScan;
        private TabPage tabPage4;
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
        private ToolStripProgressBar progressBarScan;
        private ToolStripStatusLabel toolStripLabelProgress;
        private FolderBrowserDialog folderBrowserScan;
        private Panel panel2;
        private System.ComponentModel.BackgroundWorker bgWorkerScan;
        private Button btnCancelScan;
        private GroupBox gbScanParams;
        private GroupBox gbPicturePreview;
        private PictureBox picBox;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TabPage tabPage2;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox3;
        private Label label2;
        private TextBox txtCopyPath;
        private Button btnCopyStop;
        private Button btnCopy;
        private Button btnCopyBrowse;
        private ComboBox comboBoxCopySubFolder;
        private Label label3;
        private System.ComponentModel.BackgroundWorker bgWorkerCopy;
        private TabPage tabPage5;
        private CheckBox chkBoxCopyImages;
        private CheckBox chkBoxCopyDocuments;
        private CheckBox chkBoxCopyVideos;
        private Label label4;
        private RadioButton rbtnVideoNonOri;
        private RadioButton rbtnVideoOri;
        private RadioButton rbtnVideoAll;
        private GroupBox gBoxCopyVideos;
        private GroupBox gBoxCopyImages;
        private RadioButton rbtnImageAll;
        private RadioButton rbtnImageOri;
        private RadioButton rbtnImageNonOri;
        private ToolStripProgressBar toolStripProgressBarPerFile;
        private Splitter splitter1;
        private Label lblCopyPathFinalPreview;
        private Label label5;
        private Label label6;
        private Button btnMove;
        private FolderBrowserDialog folderBrowserCopy;
        private CheckBox checkBoxMoveDeleteFile;
        private ListBox lstBoxLog;
        private RichTextBox rtBoxLog;
        private RichTextBox richTextBoxPrefixFound;
        private Panel panel3;
        private RadioButton radioOri;
        private RadioButton radioNonOri;
        private RadioButton radioAll;
        private Button btnProcess;
        private Panel panel4;
        private RadioButton radioButtonProcessCopy;
        private RadioButton radioButtonProcessMove;
        private CheckBox checkBoxMoveDeleteFiles;
        private Label label8;
        private DataGridViewTextBoxColumn no;
        private DataGridViewTextBoxColumn directory;
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
