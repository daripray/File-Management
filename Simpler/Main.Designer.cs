namespace File_Management_v1
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
            path = new DataGridViewTextBoxColumn();
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
            label5 = new Label();
            lblScanPrefixFound = new Label();
            label1 = new Label();
            txtScanPath = new TextBox();
            btnScanStop = new Button();
            txtExtVideos = new TextBox();
            btnScan = new Button();
            txtExtImage = new TextBox();
            chkPrefixExcl = new CheckBox();
            txtExtDocuments = new TextBox();
            chkPrefixIncl = new CheckBox();
            txtPrefixIncl = new TextBox();
            chkExtDocuments = new CheckBox();
            txtPrefixExcl = new TextBox();
            chkExtVideos = new CheckBox();
            btnScanBrowse = new Button();
            chkExtImages = new CheckBox();
            tabPage5 = new TabPage();
            richTextBoxPrefixFound = new RichTextBox();
            label6 = new Label();
            tabPage2 = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox3 = new GroupBox();
            chkMoveAndDelete = new CheckBox();
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
            cbBoxCopySubFolder = new ComboBox();
            lblCopyPathFinalPreview = new Label();
            label3 = new Label();
            label7 = new Label();
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
            toolStripProgressBarGlobal = new ToolStripProgressBar();
            toolStripLabelProgress = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
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
            tabPage5.SuspendLayout();
            tabPage2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox3.SuspendLayout();
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
            panel1.Size = new Size(1300, 581);
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
            groupBox1.Size = new Size(1268, 248);
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
            dgvScan.Columns.AddRange(new DataGridViewColumn[] { no, path, name, type, size, originalStatus, dateTaken, mediaCreated, dateCreated, fileStatus, copyStatus });
            dgvScan.Dock = DockStyle.Fill;
            dgvScan.Location = new Point(3, 19);
            dgvScan.Name = "dgvScan";
            dgvScan.ReadOnly = true;
            dgvScan.Size = new Size(1262, 226);
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
            // path
            // 
            path.HeaderText = "Path";
            path.Name = "path";
            path.ReadOnly = true;
            path.Width = 150;
            // 
            // name
            // 
            name.HeaderText = "Nama";
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
            originalStatus.HeaderText = "Original?";
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
            fileStatus.HeaderText = "Status File";
            fileStatus.Name = "fileStatus";
            fileStatus.ReadOnly = true;
            // 
            // copyStatus
            // 
            copyStatus.HeaderText = "Status Copy";
            copyStatus.Name = "copyStatus";
            copyStatus.ReadOnly = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(tabControl1);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(1277, 294);
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
            tabControl1.Size = new Size(1277, 294);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1269, 266);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Scan Images";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(gbPicturePreview, 1, 0);
            tableLayoutPanel1.Controls.Add(gbScanParams, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1263, 260);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // gbPicturePreview
            // 
            gbPicturePreview.Controls.Add(picBox);
            gbPicturePreview.Dock = DockStyle.Fill;
            gbPicturePreview.Location = new Point(634, 3);
            gbPicturePreview.Name = "gbPicturePreview";
            gbPicturePreview.Size = new Size(626, 254);
            gbPicturePreview.TabIndex = 10;
            gbPicturePreview.TabStop = false;
            gbPicturePreview.Text = "Preview";
            // 
            // picBox
            // 
            picBox.Dock = DockStyle.Fill;
            picBox.Location = new Point(3, 19);
            picBox.Name = "picBox";
            picBox.Size = new Size(620, 232);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.TabIndex = 0;
            picBox.TabStop = false;
            // 
            // gbScanParams
            // 
            gbScanParams.Controls.Add(label5);
            gbScanParams.Controls.Add(lblScanPrefixFound);
            gbScanParams.Controls.Add(label1);
            gbScanParams.Controls.Add(txtScanPath);
            gbScanParams.Controls.Add(btnScanStop);
            gbScanParams.Controls.Add(txtExtVideos);
            gbScanParams.Controls.Add(btnScan);
            gbScanParams.Controls.Add(txtExtImage);
            gbScanParams.Controls.Add(chkPrefixExcl);
            gbScanParams.Controls.Add(txtExtDocuments);
            gbScanParams.Controls.Add(chkPrefixIncl);
            gbScanParams.Controls.Add(txtPrefixIncl);
            gbScanParams.Controls.Add(chkExtDocuments);
            gbScanParams.Controls.Add(txtPrefixExcl);
            gbScanParams.Controls.Add(chkExtVideos);
            gbScanParams.Controls.Add(btnScanBrowse);
            gbScanParams.Controls.Add(chkExtImages);
            gbScanParams.Dock = DockStyle.Fill;
            gbScanParams.Location = new Point(3, 3);
            gbScanParams.Name = "gbScanParams";
            gbScanParams.Size = new Size(625, 254);
            gbScanParams.TabIndex = 9;
            gbScanParams.TabStop = false;
            gbScanParams.Text = "Parameter";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 210);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 8;
            label5.Text = "Prefix Found";
            // 
            // lblScanPrefixFound
            // 
            lblScanPrefixFound.AutoSize = true;
            lblScanPrefixFound.Location = new Point(117, 210);
            lblScanPrefixFound.Name = "lblScanPrefixFound";
            lblScanPrefixFound.Size = new Size(12, 15);
            lblScanPrefixFound.TabIndex = 8;
            lblScanPrefixFound.Text = "-";
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
            txtScanPath.Size = new Size(396, 23);
            txtScanPath.TabIndex = 1;
            txtScanPath.Text = "D:\\";
            // 
            // btnScanStop
            // 
            btnScanStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScanStop.BackColor = Color.Red;
            btnScanStop.Enabled = false;
            btnScanStop.Location = new Point(522, 132);
            btnScanStop.Name = "btnScanStop";
            btnScanStop.Size = new Size(93, 67);
            btnScanStop.TabIndex = 7;
            btnScanStop.Text = "Stop";
            btnScanStop.UseVisualStyleBackColor = false;
            btnScanStop.Click += btnScanStop_Click;
            // 
            // txtExtVideos
            // 
            txtExtVideos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtExtVideos.Location = new Point(117, 82);
            txtExtVideos.Name = "txtExtVideos";
            txtExtVideos.Size = new Size(396, 23);
            txtExtVideos.TabIndex = 1;
            txtExtVideos.Text = "mp4 mov avi mkv flv wmv m4v webm mpg mpeg 3gp mts m2ts ts ogv";
            // 
            // btnScan
            // 
            btnScan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScan.BackColor = Color.LawnGreen;
            btnScan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnScan.Location = new Point(522, 59);
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
            txtExtImage.Location = new Point(117, 53);
            txtExtImage.Name = "txtExtImage";
            txtExtImage.Size = new Size(396, 23);
            txtExtImage.TabIndex = 1;
            txtExtImage.Text = "jpg jpeg png gif bmp tiff tif webp heic heif raw cr2 nef orf sr2 arw dng psd ico svg";
            // 
            // chkPrefixExcl
            // 
            chkPrefixExcl.AutoSize = true;
            chkPrefixExcl.Location = new Point(15, 173);
            chkPrefixExcl.Name = "chkPrefixExcl";
            chkPrefixExcl.Size = new Size(98, 19);
            chkPrefixExcl.TabIndex = 6;
            chkPrefixExcl.Text = "Prefix Exclude";
            chkPrefixExcl.UseVisualStyleBackColor = true;
            // 
            // txtExtDocuments
            // 
            txtExtDocuments.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtExtDocuments.Location = new Point(117, 111);
            txtExtDocuments.Name = "txtExtDocuments";
            txtExtDocuments.Size = new Size(396, 23);
            txtExtDocuments.TabIndex = 1;
            txtExtDocuments.Text = "DOC DOCX PDF XLS XLSX PPT PPTX TXT RTF ODT ODS ODP CSV XML HTML HTM JSON MD LOG";
            // 
            // chkPrefixIncl
            // 
            chkPrefixIncl.AutoSize = true;
            chkPrefixIncl.Location = new Point(16, 144);
            chkPrefixIncl.Name = "chkPrefixIncl";
            chkPrefixIncl.Size = new Size(97, 19);
            chkPrefixIncl.TabIndex = 6;
            chkPrefixIncl.Text = "Prefix Include";
            chkPrefixIncl.UseVisualStyleBackColor = true;
            // 
            // txtPrefixIncl
            // 
            txtPrefixIncl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPrefixIncl.Location = new Point(117, 140);
            txtPrefixIncl.Name = "txtPrefixIncl";
            txtPrefixIncl.Size = new Size(396, 23);
            txtPrefixIncl.TabIndex = 1;
            txtPrefixIncl.Text = "IMG DSC PXL JPEG PHOTO SAMSUNG ANDROID DCIM CAM CAMERA DCM PIC MV IMG_E Screenshot";
            // 
            // chkExtDocuments
            // 
            chkExtDocuments.AutoSize = true;
            chkExtDocuments.Location = new Point(16, 115);
            chkExtDocuments.Name = "chkExtDocuments";
            chkExtDocuments.Size = new Size(87, 19);
            chkExtDocuments.TabIndex = 5;
            chkExtDocuments.Text = "Documents";
            chkExtDocuments.UseVisualStyleBackColor = true;
            // 
            // txtPrefixExcl
            // 
            txtPrefixExcl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPrefixExcl.Location = new Point(117, 169);
            txtPrefixExcl.Name = "txtPrefixExcl";
            txtPrefixExcl.Size = new Size(396, 23);
            txtPrefixExcl.TabIndex = 1;
            txtPrefixExcl.Text = "VID MOV IMG PXL MVI GOPR GH CAM DJI SAMSUNG VIDEO ANDROID CLIP RECORD";
            // 
            // chkExtVideos
            // 
            chkExtVideos.AutoSize = true;
            chkExtVideos.Location = new Point(16, 86);
            chkExtVideos.Name = "chkExtVideos";
            chkExtVideos.Size = new Size(61, 19);
            chkExtVideos.TabIndex = 4;
            chkExtVideos.Text = "Videos";
            chkExtVideos.UseVisualStyleBackColor = true;
            // 
            // btnScanBrowse
            // 
            btnScanBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScanBrowse.Location = new Point(522, 22);
            btnScanBrowse.Name = "btnScanBrowse";
            btnScanBrowse.Size = new Size(93, 23);
            btnScanBrowse.TabIndex = 2;
            btnScanBrowse.Text = "Browse";
            btnScanBrowse.UseVisualStyleBackColor = true;
            btnScanBrowse.Click += btnScanBrowse_Click;
            // 
            // chkExtImages
            // 
            chkExtImages.AutoSize = true;
            chkExtImages.Location = new Point(16, 57);
            chkExtImages.Name = "chkExtImages";
            chkExtImages.Size = new Size(64, 19);
            chkExtImages.TabIndex = 3;
            chkExtImages.Text = "Images";
            chkExtImages.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(richTextBoxPrefixFound);
            tabPage5.Controls.Add(label6);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1269, 266);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Prefix Found";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // richTextBoxPrefixFound
            // 
            richTextBoxPrefixFound.Dock = DockStyle.Fill;
            richTextBoxPrefixFound.Location = new Point(3, 3);
            richTextBoxPrefixFound.Name = "richTextBoxPrefixFound";
            richTextBoxPrefixFound.Size = new Size(1263, 260);
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
            tabPage2.Size = new Size(1269, 266);
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
            tableLayoutPanel2.Size = new Size(1263, 260);
            tableLayoutPanel2.TabIndex = 12;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(chkMoveAndDelete);
            groupBox3.Controls.Add(gBoxCopyImages);
            groupBox3.Controls.Add(gBoxCopyVideos);
            groupBox3.Controls.Add(chkBoxCopyImages);
            groupBox3.Controls.Add(chkBoxCopyVideos);
            groupBox3.Controls.Add(chkBoxCopyDocuments);
            groupBox3.Controls.Add(cbBoxCopySubFolder);
            groupBox3.Controls.Add(lblCopyPathFinalPreview);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label7);
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
            groupBox3.Size = new Size(1257, 254);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Parameter";
            // 
            // chkMoveAndDelete
            // 
            chkMoveAndDelete.AutoSize = true;
            chkMoveAndDelete.Location = new Point(570, 106);
            chkMoveAndDelete.Name = "chkMoveAndDelete";
            chkMoveAndDelete.Size = new Size(15, 14);
            chkMoveAndDelete.TabIndex = 14;
            chkMoveAndDelete.UseVisualStyleBackColor = true;
            // 
            // gBoxCopyImages
            // 
            gBoxCopyImages.Controls.Add(rbtnImageAll);
            gBoxCopyImages.Controls.Add(rbtnImageOri);
            gBoxCopyImages.Controls.Add(rbtnImageNonOri);
            gBoxCopyImages.Enabled = false;
            gBoxCopyImages.Location = new Point(136, 118);
            gBoxCopyImages.Name = "gBoxCopyImages";
            gBoxCopyImages.Size = new Size(258, 41);
            gBoxCopyImages.TabIndex = 13;
            gBoxCopyImages.TabStop = false;
            // 
            // rbtnImageAll
            // 
            rbtnImageAll.AutoSize = true;
            rbtnImageAll.Checked = true;
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
            gBoxCopyVideos.Enabled = false;
            gBoxCopyVideos.Location = new Point(136, 178);
            gBoxCopyVideos.Name = "gBoxCopyVideos";
            gBoxCopyVideos.Size = new Size(258, 41);
            gBoxCopyVideos.TabIndex = 12;
            gBoxCopyVideos.TabStop = false;
            // 
            // rbtnVideoAll
            // 
            rbtnVideoAll.AutoSize = true;
            rbtnVideoAll.Checked = true;
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
            chkBoxCopyImages.Location = new Point(117, 104);
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
            chkBoxCopyVideos.Location = new Point(117, 165);
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
            chkBoxCopyDocuments.Location = new Point(117, 225);
            chkBoxCopyDocuments.Name = "chkBoxCopyDocuments";
            chkBoxCopyDocuments.Size = new Size(87, 19);
            chkBoxCopyDocuments.TabIndex = 9;
            chkBoxCopyDocuments.Text = "Documents";
            chkBoxCopyDocuments.UseVisualStyleBackColor = true;
            // 
            // cbBoxCopySubFolder
            // 
            cbBoxCopySubFolder.AllowDrop = true;
            cbBoxCopySubFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbBoxCopySubFolder.FormattingEnabled = true;
            cbBoxCopySubFolder.Items.AddRange(new object[] { "/yyyy", "/yyyy/MM", "/yyyy/yyyyMM/", "/yyyy/yyyy_MM/", "/yyyy/MM/dd", "/yyyy/yyyyMM/yyyyMMdd", "/yyyy/yyyy_MM/yyyy_MM_dd" });
            cbBoxCopySubFolder.Location = new Point(117, 54);
            cbBoxCopySubFolder.Name = "cbBoxCopySubFolder";
            cbBoxCopySubFolder.Size = new Size(1028, 23);
            cbBoxCopySubFolder.TabIndex = 8;
            cbBoxCopySubFolder.SelectedIndexChanged += cbBoxCopySubFolder_SelectedIndexChanged;
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
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(435, 103);
            label7.Name = "label7";
            label7.Size = new Size(129, 15);
            label7.TabIndex = 0;
            label7.Text = "Move & Delete Old Files?";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 103);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 0;
            label4.Text = "Ekstensi";
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
            txtCopyPath.Size = new Size(1030, 23);
            txtCopyPath.TabIndex = 1;
            txtCopyPath.Text = "D:\\";
            txtCopyPath.TextChanged += txtCopyPath_TextChanged;
            // 
            // btnMove
            // 
            btnMove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMove.BackColor = Color.DodgerBlue;
            btnMove.Enabled = false;
            btnMove.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMove.Location = new Point(1156, 124);
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
            btnCopyStop.Location = new Point(1156, 184);
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
            btnCopy.Location = new Point(1156, 59);
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
            btnCopyBrowse.Location = new Point(1156, 22);
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
            tabPage4.Size = new Size(1269, 266);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Log";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // rtBoxLog
            // 
            rtBoxLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
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
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBarGlobal, toolStripLabelProgress, toolStripStatusLabel1, toolStripProgressBarPerFile });
            statusStrip1.Location = new Point(0, 559);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1300, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBarGlobal
            // 
            toolStripProgressBarGlobal.Alignment = ToolStripItemAlignment.Right;
            toolStripProgressBarGlobal.Name = "toolStripProgressBarGlobal";
            toolStripProgressBarGlobal.Size = new Size(200, 16);
            // 
            // toolStripLabelProgress
            // 
            toolStripLabelProgress.ForeColor = SystemColors.ControlText;
            toolStripLabelProgress.Name = "toolStripLabelProgress";
            toolStripLabelProgress.Size = new Size(125, 17);
            toolStripLabelProgress.Text = "toolStripLabelProgress";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(10, 17);
            toolStripStatusLabel1.Text = "|";
            // 
            // toolStripProgressBarPerFile
            // 
            toolStripProgressBarPerFile.Name = "toolStripProgressBarPerFile";
            toolStripProgressBarPerFile.Size = new Size(100, 16);
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
            // Simpler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 581);
            Controls.Add(panel1);
            Name = "Simpler";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Foto & Video Sorter";
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
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabPage2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
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
        private CheckBox chkPrefixIncl;
        private CheckBox chkExtDocuments;
        private CheckBox chkExtVideos;
        private CheckBox chkExtImages;
        private Button btnScanBrowse;
        private TextBox txtScanPath;
        private Label label1;
        private CheckBox chkPrefixExcl;
        private TextBox txtExtDocuments;
        private TextBox txtExtImage;
        private TextBox txtExtVideos;
        private TextBox txtPrefixIncl;
        private TextBox txtPrefixExcl;
        private Button btnScan;
        private ToolStripProgressBar toolStripProgressBarGlobal;
        private ToolStripStatusLabel toolStripLabelProgress;
        private FolderBrowserDialog folderBrowserScan;
        private Panel panel2;
        private System.ComponentModel.BackgroundWorker bgWorkerScan;
        private Button btnScanStop;
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
        private ComboBox cbBoxCopySubFolder;
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
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label lblCopyPathFinalPreview;
        private Label lblScanPrefixFound;
        private Label label5;
        private Label label6;
        private DataGridViewTextBoxColumn no;
        private DataGridViewTextBoxColumn path;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn size;
        private DataGridViewTextBoxColumn originalStatus;
        private DataGridViewTextBoxColumn dateTaken;
        private DataGridViewTextBoxColumn mediaCreated;
        private DataGridViewTextBoxColumn dateCreated;
        private DataGridViewTextBoxColumn fileStatus;
        private DataGridViewTextBoxColumn copyStatus;
        private Button btnMove;
        private FolderBrowserDialog folderBrowserCopy;
        private CheckBox chkMoveAndDelete;
        private Label label7;
        private ListBox lstBoxLog;
        private RichTextBox rtBoxLog;
        private RichTextBox richTextBoxPrefixFound;
    }
}
