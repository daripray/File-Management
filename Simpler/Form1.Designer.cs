namespace Simpler
{
    partial class Form1
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
            groupBox1 = new GroupBox();
            dgvScan = new DataGridView();
            no = new DataGridViewTextBoxColumn();
            path = new DataGridViewTextBoxColumn();
            nama = new DataGridViewTextBoxColumn();
            type = new DataGridViewTextBoxColumn();
            size = new DataGridViewTextBoxColumn();
            dateTaken = new DataGridViewTextBoxColumn();
            mediaCreated = new DataGridViewTextBoxColumn();
            statusOri = new DataGridViewTextBoxColumn();
            dateCreated = new DataGridViewTextBoxColumn();
            proses = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            gbPicturePreview = new GroupBox();
            picBox = new PictureBox();
            gbScanParams = new GroupBox();
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
            tabPage2 = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            pictureBox1 = new PictureBox();
            groupBox3 = new GroupBox();
            gBoxCopyImages = new GroupBox();
            rbtnImageAll = new RadioButton();
            rbtnImageOri = new RadioButton();
            rbtnImageNonOri = new RadioButton();
            gBoxCopyVideos = new GroupBox();
            rbtnVideoAll = new RadioButton();
            rbtnVideoOri = new RadioButton();
            rbtnVideoNonOri = new RadioButton();
            cbxCopyImages = new CheckBox();
            cbxCopyVideos = new CheckBox();
            cbxCopyDocuments = new CheckBox();
            cbxCopySubFolder = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            txtCopyPath = new TextBox();
            btnCopyStop = new Button();
            btnCopy = new Button();
            btnCopyBrowse = new Button();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            statusStrip1 = new StatusStrip();
            toolStripProgressBarGlobal = new ToolStripProgressBar();
            toolStripLabelProgress = new ToolStripStatusLabel();
            folderBrowserDialog1 = new FolderBrowserDialog();
            bgWorkerScan = new System.ComponentModel.BackgroundWorker();
            bgWorkerCopy = new System.ComponentModel.BackgroundWorker();
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
            tabPage2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox3.SuspendLayout();
            gBoxCopyImages.SuspendLayout();
            gBoxCopyVideos.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(statusStrip1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1062, 555);
            panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(dgvScan);
            groupBox1.Location = new Point(16, 308);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1030, 222);
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
            dgvScan.Columns.AddRange(new DataGridViewColumn[] { no, path, nama, type, size, dateTaken, mediaCreated, statusOri, dateCreated, proses });
            dgvScan.Dock = DockStyle.Fill;
            dgvScan.Location = new Point(3, 19);
            dgvScan.Name = "dgvScan";
            dgvScan.Size = new Size(1024, 200);
            dgvScan.TabIndex = 3;
            dgvScan.CellClick += dgvScan_CellClick;
            // 
            // no
            // 
            no.HeaderText = "No";
            no.Name = "no";
            no.Width = 50;
            // 
            // path
            // 
            path.HeaderText = "Path";
            path.Name = "path";
            path.Width = 150;
            // 
            // nama
            // 
            nama.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nama.HeaderText = "Nama";
            nama.Name = "nama";
            // 
            // type
            // 
            type.HeaderText = "Type";
            type.Name = "type";
            type.Width = 70;
            // 
            // size
            // 
            size.HeaderText = "Size (B)";
            size.Name = "size";
            size.Width = 70;
            // 
            // dateTaken
            // 
            dateTaken.HeaderText = "Date Taken";
            dateTaken.Name = "dateTaken";
            dateTaken.Width = 120;
            // 
            // mediaCreated
            // 
            mediaCreated.HeaderText = "Media Created";
            mediaCreated.Name = "mediaCreated";
            mediaCreated.Width = 120;
            // 
            // statusOri
            // 
            statusOri.HeaderText = "Keaslian";
            statusOri.Name = "statusOri";
            statusOri.Width = 70;
            // 
            // dateCreated
            // 
            dateCreated.HeaderText = "Date Created";
            dateCreated.Name = "dateCreated";
            dateCreated.Width = 120;
            // 
            // proses
            // 
            proses.HeaderText = "Proses";
            proses.Name = "proses";
            proses.Width = 70;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(tabControl1);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(1039, 294);
            panel2.TabIndex = 5;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1039, 294);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1031, 266);
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
            tableLayoutPanel1.Size = new Size(1025, 260);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // gbPicturePreview
            // 
            gbPicturePreview.Controls.Add(picBox);
            gbPicturePreview.Dock = DockStyle.Fill;
            gbPicturePreview.Location = new Point(515, 3);
            gbPicturePreview.Name = "gbPicturePreview";
            gbPicturePreview.Size = new Size(507, 254);
            gbPicturePreview.TabIndex = 10;
            gbPicturePreview.TabStop = false;
            gbPicturePreview.Text = "Preview";
            // 
            // picBox
            // 
            picBox.Dock = DockStyle.Fill;
            picBox.Location = new Point(3, 19);
            picBox.Name = "picBox";
            picBox.Size = new Size(501, 232);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.TabIndex = 0;
            picBox.TabStop = false;
            // 
            // gbScanParams
            // 
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
            gbScanParams.Size = new Size(506, 254);
            gbScanParams.TabIndex = 9;
            gbScanParams.TabStop = false;
            gbScanParams.Text = "Parameter";
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
            txtScanPath.Size = new Size(279, 23);
            txtScanPath.TabIndex = 1;
            txtScanPath.Text = "H:\\BACKU FIX 1\\SAMPLE";
            // 
            // btnScanStop
            // 
            btnScanStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScanStop.BackColor = Color.Red;
            btnScanStop.Enabled = false;
            btnScanStop.Location = new Point(405, 132);
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
            txtExtVideos.Size = new Size(279, 23);
            txtExtVideos.TabIndex = 1;
            txtExtVideos.Text = "mp4 mov avi mkv flv wmv m4v webm mpg mpeg 3gp mts m2ts ts ogv";
            // 
            // btnScan
            // 
            btnScan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScan.BackColor = Color.LawnGreen;
            btnScan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnScan.Location = new Point(405, 59);
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
            txtExtImage.Size = new Size(279, 23);
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
            txtExtDocuments.Size = new Size(279, 23);
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
            txtPrefixIncl.Size = new Size(279, 23);
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
            txtPrefixExcl.Size = new Size(279, 23);
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
            btnScanBrowse.Location = new Point(405, 22);
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
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1031, 266);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Scan Video";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tableLayoutPanel2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1031, 266);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Copy";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(groupBox2, 1, 0);
            tableLayoutPanel2.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1025, 260);
            tableLayoutPanel2.TabIndex = 12;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(515, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(507, 254);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Preview";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(501, 232);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(gBoxCopyImages);
            groupBox3.Controls.Add(gBoxCopyVideos);
            groupBox3.Controls.Add(cbxCopyImages);
            groupBox3.Controls.Add(cbxCopyVideos);
            groupBox3.Controls.Add(cbxCopyDocuments);
            groupBox3.Controls.Add(cbxCopySubFolder);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(txtCopyPath);
            groupBox3.Controls.Add(btnCopyStop);
            groupBox3.Controls.Add(btnCopy);
            groupBox3.Controls.Add(btnCopyBrowse);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(506, 254);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Parameter";
            // 
            // gBoxCopyImages
            // 
            gBoxCopyImages.Controls.Add(rbtnImageAll);
            gBoxCopyImages.Controls.Add(rbtnImageOri);
            gBoxCopyImages.Controls.Add(rbtnImageNonOri);
            gBoxCopyImages.Enabled = false;
            gBoxCopyImages.Location = new Point(136, 98);
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
            gBoxCopyVideos.Location = new Point(136, 158);
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
            // cbxCopyImages
            // 
            cbxCopyImages.AutoSize = true;
            cbxCopyImages.Location = new Point(117, 84);
            cbxCopyImages.Name = "cbxCopyImages";
            cbxCopyImages.Size = new Size(64, 19);
            cbxCopyImages.TabIndex = 9;
            cbxCopyImages.Text = "Images";
            cbxCopyImages.UseVisualStyleBackColor = true;
            cbxCopyImages.CheckedChanged += cbxCopyImages_CheckedChanged;
            // 
            // cbxCopyVideos
            // 
            cbxCopyVideos.AutoSize = true;
            cbxCopyVideos.Location = new Point(117, 145);
            cbxCopyVideos.Name = "cbxCopyVideos";
            cbxCopyVideos.Size = new Size(61, 19);
            cbxCopyVideos.TabIndex = 9;
            cbxCopyVideos.Text = "Videos";
            cbxCopyVideos.UseVisualStyleBackColor = true;
            cbxCopyVideos.CheckedChanged += cbxCopyVideos_CheckedChanged;
            // 
            // cbxCopyDocuments
            // 
            cbxCopyDocuments.AutoSize = true;
            cbxCopyDocuments.Location = new Point(117, 205);
            cbxCopyDocuments.Name = "cbxCopyDocuments";
            cbxCopyDocuments.Size = new Size(87, 19);
            cbxCopyDocuments.TabIndex = 9;
            cbxCopyDocuments.Text = "Documents";
            cbxCopyDocuments.UseVisualStyleBackColor = true;
            // 
            // cbxCopySubFolder
            // 
            cbxCopySubFolder.AllowDrop = true;
            cbxCopySubFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbxCopySubFolder.FormattingEnabled = true;
            cbxCopySubFolder.Items.AddRange(new object[] { "/yyyy", "/yyyy/MM", "/yyyy/MM/dd" });
            cbxCopySubFolder.Location = new Point(117, 54);
            cbxCopySubFolder.Name = "cbxCopySubFolder";
            cbxCopySubFolder.Size = new Size(277, 23);
            cbxCopySubFolder.TabIndex = 8;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 83);
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
            txtCopyPath.Size = new Size(279, 23);
            txtCopyPath.TabIndex = 1;
            txtCopyPath.Text = "H:\\BACKU FIX 1\\HASIL";
            // 
            // btnCopyStop
            // 
            btnCopyStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyStop.BackColor = Color.Red;
            btnCopyStop.Enabled = false;
            btnCopyStop.Location = new Point(405, 132);
            btnCopyStop.Name = "btnCopyStop";
            btnCopyStop.Size = new Size(93, 67);
            btnCopyStop.TabIndex = 7;
            btnCopyStop.Text = "Stop";
            btnCopyStop.UseVisualStyleBackColor = false;
            btnCopyStop.Click += btnCopyStop_Click;
            // 
            // btnCopy
            // 
            btnCopy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopy.BackColor = Color.LawnGreen;
            btnCopy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCopy.Location = new Point(405, 59);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(93, 67);
            btnCopy.TabIndex = 7;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = false;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnCopyBrowse
            // 
            btnCopyBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyBrowse.Location = new Point(405, 22);
            btnCopyBrowse.Name = "btnCopyBrowse";
            btnCopyBrowse.Size = new Size(93, 23);
            btnCopyBrowse.TabIndex = 2;
            btnCopyBrowse.Text = "Browse";
            btnCopyBrowse.UseVisualStyleBackColor = true;
            btnCopyBrowse.Click += btnCopyBrowse_Click;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1031, 266);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Move";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1031, 266);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Log";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBarGlobal, toolStripLabelProgress });
            statusStrip1.Location = new Point(0, 533);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1062, 22);
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
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 555);
            Controls.Add(panel1);
            Name = "Form1";
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
            tabPage2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            gBoxCopyImages.ResumeLayout(false);
            gBoxCopyImages.PerformLayout();
            gBoxCopyVideos.ResumeLayout(false);
            gBoxCopyVideos.PerformLayout();
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
        private TabPage tabPage3;
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
        private FolderBrowserDialog folderBrowserDialog1;
        private Panel panel2;
        private System.ComponentModel.BackgroundWorker bgWorkerScan;
        private Button btnScanStop;
        private GroupBox gbScanParams;
        private GroupBox gbPicturePreview;
        private PictureBox picBox;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridViewTextBoxColumn no;
        private DataGridViewTextBoxColumn path;
        private DataGridViewTextBoxColumn nama;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn size;
        private DataGridViewTextBoxColumn dateTaken;
        private DataGridViewTextBoxColumn mediaCreated;
        private DataGridViewTextBoxColumn statusOri;
        private DataGridViewTextBoxColumn dateCreated;
        private DataGridViewTextBoxColumn proses;
        private TabPage tabPage2;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox2;
        private PictureBox pictureBox1;
        private GroupBox groupBox3;
        private Label label2;
        private TextBox txtCopyPath;
        private Button btnCopyStop;
        private Button btnCopy;
        private Button btnCopyBrowse;
        private ComboBox cbxCopySubFolder;
        private Label label3;
        private System.ComponentModel.BackgroundWorker bgWorkerCopy;
        private TabPage tabPage5;
        private CheckBox cbxCopyImages;
        private CheckBox cbxCopyDocuments;
        private CheckBox cbxCopyVideos;
        private Label label4;
        private RadioButton rbtnVideoNonOri;
        private RadioButton rbtnVideoOri;
        private RadioButton rbtnVideoAll;
        private GroupBox gBoxCopyVideos;
        private GroupBox gBoxCopyImages;
        private RadioButton rbtnImageAll;
        private RadioButton rbtnImageOri;
        private RadioButton rbtnImageNonOri;
    }
}
