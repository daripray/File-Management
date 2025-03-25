using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Windows.Input;
using System.Threading;

namespace File_Management
{
    public partial class Form1 : Form
    {
        private List<Array> dataList = new List<Array>();
        private ArrayList arrayList = new ArrayList();
        private String[,] datas = new String[0, 0];

        private String final_dest_path;

        private String[] extImages;
        private String[] extVideos;
        private String[] extDocuments;
        private String[] extOptional;
        private String[] extAll;
        private String[] optPrefix;
        private String[] optException;

        private String[] resFiles;
        List<String> tempResFiles = new List<String> { };

        private String[] arrStatus;

        BackgroundWorker worker = new BackgroundWorker();
        FormDetail fd = new FormDetail();

        //private BackgroundWorker bgWorker;
        private CancellationTokenSource cancellationTokenSource;
        private bool isPaused = false;


        public Form1()
        {
            InitializeComponent();

            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;

            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_ProgressCompleted;

            //bgWorker = new BackgroundWorker();
            //bgWorker.WorkerReportsProgress = true;
            //bgWorker.WorkerSupportsCancellation = true;

            //bgWorker.DoWork += BgWorker_DoWork;
            //bgWorker.ProgressChanged += BgWorker_ProgressChanged;
            //bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;

            //toolTip2 = new ToolTip();

            toolTip1.SetToolTip(txt_source_path, "Type Directory URL of source here");
            toolTip1.SetToolTip(txt_dest_path, "Type Directory URL of target here");
            toolTip1.SetToolTip(txt_format_images, "Type Images extension here");
            toolTip1.SetToolTip(txt_format_videos, "Type Videos extension here");
            toolTip1.SetToolTip(txt_format_documents, "Type Documents extension here");
            toolTip1.SetToolTip(txt_format_optional, "Type Optional by extension or prefix files here");
            toolTip1.SetToolTip(txt_format_exception, "Type Exception by extension or prefix files here");
        }


        private async void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            var args = (dynamic)e.Argument;
            if (resFiles != null && resFiles.Length > 0)
            {
                try
                {
                    listLog.Invoke((Action)(() => listLog.Items.Add($"Processing {resFiles.Length} files begin...")));
                    DateTime myDate;
                    string year, month, day;
                    arrStatus = new string[resFiles.Length];

                    progressBar1.Invoke((Action)(() =>
                    {
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = resFiles.Length;
                    }));

                    for (int i = 0; i < resFiles.Length; i++)
                    {
                        if (worker.CancellationPending)
                        {
                            args.Cancel = true;
                            return;
                        }

                        // Pause logic
                        while (isPaused)
                        {
                            await Task.Delay(500);
                            if (worker.CancellationPending) return;
                        }

                        string f = resFiles[i];

                        final_dest_path = txt_dest_path.Text;
                        myDate = rd_process_by_date_modified.Checked ? File.GetLastWriteTime(f) : File.(f);


                        year = myDate.ToString("yyyy");
                        month = myDate.ToString("MM");
                        day = myDate.ToString("dd");

                        if (rd_then_path_year.Checked)
                            final_dest_path = Path.Combine(final_dest_path, year);
                        if (rd_then_path_year_month.Checked)
                            final_dest_path = Path.Combine(final_dest_path, year, month);
                        if (rd_then_path_year_month_day.Checked)
                            final_dest_path = Path.Combine(final_dest_path, year, month, day);
                        if (rd_then_path_year_month_2.Checked)
                            final_dest_path = Path.Combine(final_dest_path, year, $"{year}-{month}");
                        if (rd_then_path_year_month_day_2.Checked)
                            final_dest_path = Path.Combine(final_dest_path, year, $"{year}-{month}", $"{year}-{month}-{day}");

                        if (!Directory.Exists(final_dest_path))
                        {
                            Directory.CreateDirectory(final_dest_path);
                            listLog.Invoke((Action)(() => listLog.Items.Add("Create directory: " + final_dest_path)));
                        }

                        string final_dest = Path.Combine(final_dest_path, Path.GetFileName(f));

                        dgvListFiles.Invoke((Action)(() =>
                        {
                            dgvListFiles[2, i].Value = "In Progress";
                            dgvListFiles.Rows[i].Selected = true;
                            dgvListFiles.FirstDisplayedScrollingRowIndex = i;
                        }));

                        try
                        {
                            if (args.opt == 0)
                            {
                                File.Copy(f, final_dest, true);
                            }
                            else if (args.opt == 1)
                            {
                                File.Move(f, final_dest);
                            }
                            // Wait with timeout
                            await WaitForFileAsync(final_dest, TimeSpan.FromSeconds(5));
                            listLog.Items.Add($"Copied {f} to {final_dest} success");
                            dgvListFiles.Invoke((Action)(() => dgvListFiles[2, i].Value = "Copied"));

                            listLog.Invoke((Action)(() => listLog.Items.Add($"{(args.opt == 0 ? "Copy" : "Move")} {f} to {final_dest} success")));
                            dgvListFiles.Invoke((Action)(() => dgvListFiles[2, i].Value = args.opt == 0 ? "Copied" : "Moved"));
                        }
                        catch (Exception ex)
                        {
                            listLog.Invoke((Action)(() => listLog.Items.Add($"Error {(args.opt == 0 ? "Copy" : "Move")}: {f} to {final_dest}")));
                            listLog.Invoke((Action)(() => listLog.Items.Add($"Error Copying {f}: {ex.Message}")));
                            dgvListFiles.Invoke((Action)(() => dgvListFiles[2, i].Value = "Error"));
                        }
                        listLog.Invoke((Action)(() => listLog.Items.Add("----------")));
                        worker.ReportProgress((i + 1) * 100 / resFiles.Length);
                    }
                }
                catch (Exception ex)
                {
                    listLog.Invoke((Action)(() => listLog.Items.Add("Unknown Error: " + ex.Message)));
                }
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressBar1.CreateGraphics().DrawString($"{e.ProgressPercentage}%",
                new Font("Arial", 9, FontStyle.Regular),
                Brushes.Black,
                new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
        }

        private void worker_ProgressCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                listLog.Items.Add("Process stopped.");
            }
            else
            {
                listLog.Items.Add("Processing completed!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbImages_CheckedChanged(sender, e);
            cbVideos_CheckedChanged(sender, e);
            cbDocuments_CheckedChanged(sender, e);
            Reset_Source();
            Reset_Destination();
        }

        private void Load_Format_Images()
        {
            txt_format_images.Text = "jpg jpeg jpe jfif png bmp ico gif tif tiff heif hdr webp dib heic hif svg";
        }

        private void Load_Format_Videos()
        {
            txt_format_videos.Text = "3gp avi amv flv mkv mp4 wmp webm";
        }

        private void Load_Format_Documents()
        {
            txt_format_documents.Text = "txt rtf doc docx dot dotx htm html mht mhtml odt pdf xml";
        }

        private void Load_Format_Optional()
        {
            txt_format_optional.Text = "";
        }

        private void Load_Format_Exception()
        {
            txt_format_exception.Text = "wa|whatsap|scan|save|hair|pencil|cetak";
        }

        private void Reset_Source()
        {
            Load_Format_Images();
            Load_Format_Videos();
            Load_Format_Documents();
            Load_Format_Optional();
            Load_Format_Exception();
        }

        private void Reset_Option()
        {
            rd_process_by_date_created.Checked = true;
            rd_process_by_date_modified.Checked = false;

        }

        private void Reset_Destination()
        {
            rd_then_path_None.Checked = true;
        }

        private void btnSourceScan_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_source_path.Text))
                this.ScanFile();
        }

        private void ScanFile()
        {
            if (!String.IsNullOrEmpty(txt_source_path.Text))
            {
                listLog.Items.Add("Scan directory " + txt_source_path.Text + " begin...");
                Object[] obj = new Object[2000];
                try
                {
                    extImages = new String[0] { };
                    extVideos = new String[0] { };
                    extDocuments = new String[0] { };
                    extOptional = new String[0] { };
                    extAll = new String[0] { };
                    optPrefix = new String[0] { };
                    optException = new String[0] { };

                    resFiles = new String[] { };
                    arrStatus = new String[] { };

                    tempResFiles.Clear();
                    dgvListFiles.Rows.Clear();

                    if (cbImages.Checked)
                    {
                        extImages = ("." + txt_format_images.Text.Replace(" ", " .")).Split(' ');
                        extAll = extAll.Concat(extImages).ToArray();
                    }
                    if (cbVideos.Checked)
                    {
                        extVideos = ("." + txt_format_videos.Text.Replace(" ", " .")).Split(' ');
                        extAll = extAll.Concat(extVideos).ToArray();
                    }
                    if (cbDocuments.Checked)
                    {
                        extDocuments = ("." + txt_format_documents.Text.Replace(" ", " .")).Split(' ');
                        extAll = extAll.Concat(extDocuments).ToArray();
                    }
                    if (cbOptional.Checked)
                    {
                        extOptional = ("." + txt_format_optional.Text.Replace(" ", " .")).Split(' ');
                        extAll = extAll.Concat(extOptional).ToArray();

                        optPrefix = txt_format_optional.Text.Split('|');
                    }
                    if (cbException.Checked)
                    {
                        optException = txt_format_exception.Text.Split('|');
                    }

                    resFiles = Directory.GetFiles(txt_source_path.Text, "*.*", SearchOption.AllDirectories)
                      .Where(file => extAll
                      .Contains(Path.GetExtension(file)))
                      .ToList().ToArray<String>();

                    if (optPrefix.Length > 0)
                    {
                        foreach (String f in resFiles)
                        {
                            foreach (String p in optPrefix)
                            {
                                if (!string.IsNullOrWhiteSpace(p) && Path.GetFileName(f).ToLower().Contains(p.ToLower()))
                                {
                                    tempResFiles.Add(f);
                                }
                            }
                        }
                        if (tempResFiles.ToArray().Length > 0)
                            resFiles = tempResFiles.ToArray();
                    }
                    else
                    {
                        tempResFiles = resFiles.ToList();
                    }

                    if (optException.Length > 0)
                    {
                        foreach (String f in resFiles)
                        {
                            foreach (String p in optException)
                            {
                                if (!string.IsNullOrWhiteSpace(p) && Path.GetFileName(f).ToLower().Contains(p.ToLower()))
                                {
                                    tempResFiles.Remove(f);
                                }
                            }
                        }
                        resFiles = tempResFiles.ToArray();
                    }
                    else
                    {
                        tempResFiles = resFiles.ToList();
                    }
                    this.AddListToDGV();
                }
                catch (System.Exception ex)
                {
                    listLog.Items.Add("Unknown Error when scan directory : " + ex);
                }
                listLog.Items.Add("Scan result : " + resFiles.Length + " files found ...");
            }
        }

        private void AddListToDGV()
        {
            btnSourceScan.Enabled = false;

            dgvListFiles.UseWaitCursor = true;
            dgvListFiles.Enabled = false;
            try
            {
                int i = 0;
                dgvListFiles.Rows.Clear();
                foreach (String f in resFiles)
                {
                    string status = "Pending";
                    if (arrStatus.Length > 0)
                    {
                        status = arrStatus[i];
                    }

                    dgvListFiles.Rows.Add(f, i + 1, status, Path.GetFileName(f), File.GetCreationTime(f).ToString(), File.GetLastWriteTime(f).ToString(), "View");
                    i++;
                }
            }
            catch (System.Exception ex)
            {
                listLog.Items.Add("Unknown Error when list files : " + ex);
            }
            
            btnSourceScan.Enabled = true;

            dgvListFiles.UseWaitCursor = false;
            dgvListFiles.Enabled = true;
        }

        private void btnSourceAdd_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_source_path.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSourceClear_Click(object sender, EventArgs e)
        {
            txt_source_path.Clear();
            dgvListFiles.Rows.Clear();
        }

        private void btnDestAdd_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_dest_path.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void cbx_condition_files_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ScanFile();
        }

        private void btnDestClear_Click(object sender, EventArgs e)
        {
            txt_dest_path.Clear();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //this.Process(0);

            if (!worker.IsBusy)
            {
                var arguments = new
                {
                    opt = 0,
                };
                worker.RunWorkerAsync(arguments);
                //btnStart.Enabled = false;
                btnPause.Enabled = true;
                btnResume.Enabled = false;
                btnStop.Enabled = true;

            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            //this.Process(1);

            if (!worker.IsBusy)
            {
                var arguments = new
                {
                    opt = 1,
                };
                worker.RunWorkerAsync(arguments);
                //btnStart.Enabled = false;
                btnPause.Enabled = true;
                btnResume.Enabled = false;
                btnStop.Enabled = true;

            }
        }

        private async Task Process(int opt)
        {
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            if (!string.IsNullOrEmpty(txt_dest_path.Text.Trim()))
            {
                listLog.Items.Add($"Processing {resFiles.Length} files begin...");
                try
                {
                    DateTime myDate;
                    string year, month, day;
                    arrStatus = new string[resFiles.Length];
                    int i = 0;

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = resFiles.Length;

                    foreach (String f in resFiles)
                    {
                        if (token.IsCancellationRequested)
                        {
                            listLog.Items.Add("Process stopped.");
                            break;
                        }

                        while (isPaused)
                        {
                            await Task.Delay(500);
                        }

                        dgvListFiles[2, i].Value = "In Progress";
                        dgvListFiles.Rows[i].Selected = true;
                        dgvListFiles.FirstDisplayedScrollingRowIndex = i;
                        dgvListFiles.Refresh();

                        final_dest_path = txt_dest_path.Text;
                        myDate = rd_process_by_date_modified.Checked ? File.GetLastWriteTime(f) : File.GetCreationTime(f);

                        year = myDate.ToString("yyyy");
                        month = myDate.ToString("MM");
                        day = myDate.ToString("dd");

                        if (rd_then_path_year.Checked)
                            final_dest_path = Path.Combine(final_dest_path, year);
                        if (rd_then_path_year_month.Checked)
                            final_dest_path = Path.Combine(final_dest_path, year, month);
                        if (rd_then_path_year_month_day.Checked)
                            final_dest_path = Path.Combine(final_dest_path, year, month, day);
                        if (rd_then_path_year_month_2.Checked)
                            final_dest_path = Path.Combine(final_dest_path, year, $"{year}-{month}");
                        if (rd_then_path_year_month_day_2.Checked)
                            final_dest_path = Path.Combine(final_dest_path, year, $"{year}-{month}", $"{year}-{month}-{day}");

                        if (!Directory.Exists(final_dest_path))
                        {
                            Directory.CreateDirectory(final_dest_path);
                            listLog.Items.Add("Create directory: " + final_dest_path);
                        }

                        string target = Path.Combine(final_dest_path, Path.GetFileName(f));

                        try
                        {
                            if (opt == 0)
                            {
                                File.Copy(f, target, true);
                            }
                            else if (opt == 1)
                            {
                                File.Move(f, target);
                            }

                            // Wait with timeout
                            await WaitForFileAsync(target, TimeSpan.FromSeconds(5));

                            listLog.Items.Add($"{(opt == 0 ? "Copy" : "Move")} {f} to {target} success");
                            dgvListFiles[2, i].Value = opt == 0 ? "Copied" : "Moved";
                        }
                        catch (Exception err)
                        {
                            listLog.Items.Add($"Error {(opt == 0 ? "Copy" : "Move")}: {f} to {target}");
                            listLog.Items.Add(err.Message);
                            dgvListFiles[2, i].Value = "Error";
                        }

                        listLog.Items.Add("----------");
                        progressBar1.Value = i + 1;
                        int percent = (int)((double)progressBar1.Value / progressBar1.Maximum * 100);
                        progressBar1.Refresh();

                        progressBar1.CreateGraphics().DrawString($"{percent}%",
                            new Font("Arial", 9, FontStyle.Regular),
                            Brushes.Black,
                            new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));

                        dgvListFiles.Refresh();
                        dgvListFiles.ClearSelection();
                    }
                    i++;
                }
                catch (Exception ex)
                {
                    listLog.Items.Add("Unknown Error: " + ex.Message);
                }
            }
            listLog.Items.Add($"Processing {resFiles.Length} files completed...");
        }

        private async Task WaitForFileAsync(string filePath, TimeSpan timeout)
        {
            var startTime = DateTime.Now;
            while (!File.Exists(filePath))
            {
                if (DateTime.Now - startTime > timeout)
                {
                    throw new TimeoutException("File process timed out.");
                }
                await Task.Delay(100);
            }
        }

        private void cbImages_CheckedChanged(object sender, EventArgs e)
        {
            if (cbImages.Checked)
            {
                txt_format_images.Enabled = true;
                btnResetImages.Enabled = true;
            }
            else
            {
                txt_format_images.Enabled = false;
                btnResetImages.Enabled = false;
            }
        }

        private void cbVideos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVideos.Checked)
            {
                txt_format_videos.Enabled = true;
                btnResetVideos.Enabled = true;
            }
            else
            {
                txt_format_videos.Enabled = false;
                btnResetVideos.Enabled = false;
            }
        }

        private void cbDocuments_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDocuments.Checked)
            {
                txt_format_documents.Enabled = true;
                btnResetDocuments.Enabled = true;
            }
            else
            {
                txt_format_documents.Enabled = false;
                btnResetDocuments.Enabled = false;
            }
        }

        private void cbOptional_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOptional.Checked)
            {
                txt_format_optional.Enabled = true;
                btnResetOptional.Enabled = true;
            }
            else
            {
                txt_format_optional.Enabled = false;
                btnResetOptional.Enabled = false;
            }
        }

        private void cbException_CheckedChanged(object sender, EventArgs e)
        {
            if (cbException.Checked)
            {
                txt_format_exception.Enabled = true;
                btnResetException.Enabled = true;
            }
            else
            {
                txt_format_exception.Enabled = false;
                btnResetException.Enabled = false;
            }
        }

        private void btnResetImages_Click(object sender, EventArgs e)
        {
            Load_Format_Images();
        }

        private void btnResetVideos_Click(object sender, EventArgs e)
        {
            Load_Format_Videos();
        }

        private void btnResetDocuments_Click(object sender, EventArgs e)
        {
            Load_Format_Documents();
        }

        private void btnResetOptional_Click(object sender, EventArgs e)
        {
            Load_Format_Optional();
        }

        private void btnResetException_Click(object sender, EventArgs e)
        {
            Load_Format_Exception();
        }

        private void txt_source_path_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_source_path.Text))
            {
                btnSourceScan.BackColor = System.Drawing.Color.Transparent;
                btnSourceScan.Enabled = false;

                btnSourceClear.BackColor = System.Drawing.Color.Transparent;
                btnSourceClear.Enabled = false;

                groupBoxImages.Enabled = false;

                cbImages.Enabled = false;
                cbVideos.Enabled = false;
                cbDocuments.Enabled = false;
                cbOptional.Enabled = false;
                cbException.Enabled = false;

                txt_dest_path.Enabled = false;
                btnDestAdd.Enabled = false;

                rd_process_by_date_created.Enabled = false;
                rd_process_by_date_modified.Enabled = false;
            }
            else
            {
                //btnSourceScan.BackColor = System.Drawing.Color.CornflowerBlue;
                btnSourceScan.Enabled = true;

                //btnSourceClear.BackColor = System.Drawing.Color.CornflowerBlue;
                btnSourceClear.Enabled = true;

                groupBoxImages.Enabled = true;

                cbImages.Enabled = true;
                cbVideos.Enabled = true;
                cbDocuments.Enabled = true;
                cbOptional.Enabled = true;
                cbException.Enabled = true;

                txt_dest_path.Enabled = true;
                btnDestAdd.Enabled = true;

                rd_process_by_date_created.Enabled = true;
                rd_process_by_date_modified.Enabled = true;
            }
        }

        private void txt_dest_path_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_dest_path.Text))
            {
                btnDestClear.BackColor = System.Drawing.Color.Transparent;
                btnDestClear.Enabled = false;

                btnCopy.BackColor = System.Drawing.Color.Transparent;
                btnCopy.Enabled = false;

                btnMove.BackColor = System.Drawing.Color.Transparent;
                btnMove.Enabled = false;

                rd_then_path_None.Enabled = false;
                rd_then_path_year.Enabled = false;
                rd_then_path_year_month.Enabled = false;
                rd_then_path_year_month_2.Enabled = false;
                rd_then_path_year_month_day.Enabled = false;
                rd_then_path_year_month_day_2.Enabled = false;
            }
            else
            {
                //btnDestClear.BackColor = System.Drawing.Color.CornflowerBlue;
                btnDestClear.Enabled = true;

                //btnCopy.BackColor = System.Drawing.Color.CornflowerBlue;
                btnCopy.Enabled = true;

                //btnMove.BackColor = System.Drawing.Color.CornflowerBlue;
                btnMove.Enabled = true;

                rd_then_path_None.Enabled = true;
                rd_then_path_year.Enabled = true;
                rd_then_path_year_month.Enabled = true;
                rd_then_path_year_month_2.Enabled = true;
                rd_then_path_year_month_day.Enabled = true;
                rd_then_path_year_month_day_2.Enabled = true;
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            listLog.Items.Clear();
        }

        private void dgvListFiles_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != this.dgvListFiles.NewRowIndex)
                {
                    //DataGridView row
                    DataGridViewRow row = dgvListFiles.Rows[e.RowIndex];
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                }
                if (e.ColumnIndex == 5 && e.RowIndex != this.dgvListFiles.NewRowIndex)
                {
                    // Get the clicked row
                    DataGridViewRow row = dgvListFiles.Rows[e.RowIndex];
                    

                    // Get the data for the clicked row
                    fd.id = row.Cells[1].Value.ToString(); ;
                    fd.name = row.Cells[3].Value.ToString();
                    fd.path = row.Cells[0].Value.ToString();

                    fd.Text = row.Cells[3].Value.ToString();

                    fd.pbImages.Image = Image.FromFile(row.Cells[0].Value.ToString());
                    fd.pbImages.SizeMode = PictureBoxSizeMode.Zoom;

                    fd.Show();
                }
            }
            catch (System.Exception ex)
            {
                listLog.Items.Add("MouseEnter Unknown error : " + ex);
            }
        }

        private void dgvListFiles_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvListFiles.Rows[e.RowIndex];
                if (e.ColumnIndex == 5 && e.RowIndex != this.dgvListFiles.NewRowIndex)
                {
                    fd.Hide();
                }
                row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            }
            catch (System.Exception ex)
            {
                listLog.Items.Add("MouseLeave Unknown error : " + ex);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            isPaused = true;
            listLog.Items.Add("Process paused.");
            btnPause.Enabled = false;
            btnResume.Enabled = true;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            isPaused = false;
            listLog.Items.Add("Process resumed.");
            btnPause.Enabled = true;
            btnResume.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
            {
                //    cancellationTokenSource?.Cancel();
                //listLog.Items.Add("Stopping process...");
                //btnPause.Enabled = false;
                //btnResume.Enabled = false;

                if (cancellationTokenSource != null)
                {
                    cancellationTokenSource.Dispose();
                    cancellationTokenSource = null;

                    worker.CancelAsync();
                    listLog.Items.Add("Stopping process...");
                    btnPause.Enabled = false;
                    btnResume.Enabled = false;
                }
            }
        }
    }
}
