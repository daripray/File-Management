using Simpler.Helper;
using System.ComponentModel;


namespace Simpler
{
    public partial class Form1 : Form
    {
        private String[] extImages;
        private String[] extVideos;
        private String[] extDocuments;
        private String[] extAll = Array.Empty<string>();
        private String[] prefixIncl;
        private String[] prefixExcl;
        private String[] resFiles;
        List<String> tempResFiles = new List<String> { };

        private int totalDataScan = 0; // Total data yang akan di-scan, bisa digunakan untuk progress bar

        public Form1()
        {
            InitializeComponent();
        }

        #region SCAN FILES
        private void btnScanBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtScanPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (!bgWorkerScan.IsBusy)
            {
                btnScan.Enabled = false;
                btnScanStop.Enabled = true;
                dgvScan.Rows.Clear();

                // Reset progress bar
                toolStripProgressBarGlobal.Value = 0;
                toolStripProgressBarGlobal.Maximum = 100;
                toolStripLabelProgress.Text = "Memulai scan...";

                extAll = Array.Empty<string>();

                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents(); // Ini penting agar tombol tetap bisa diklik

                // jalankan bgWorkerScan_DoWork
                bgWorkerScan.RunWorkerAsync(txtScanPath.Text); // kirim path jika perlu
            }
        }

        private void btnScanStop_Click(object sender, EventArgs e)
        {
            if (bgWorkerScan.IsBusy && bgWorkerScan.WorkerSupportsCancellation)
            {
                //btnScan.Enabled = true;
                //btnScanStop.Enabled = false;

                bgWorkerScan.CancelAsync();
                toolStripLabelProgress.Text = "Membatalkan scan...";
            }
        }

        private void bgWorkerScan_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Application.DoEvents(); // pastikan event berjalan
            string path = e.Argument as string;
            doScanFiles(path, sender as BackgroundWorker, e);
        }

        private void bgWorkerScan_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripProgressBarGlobal.Value = Math.Min(e.ProgressPercentage, 100);

            var data = e.UserState as dynamic;
            doScanAddDGV(data);

            toolStripLabelProgress.Text = $"Scanning: {data.Index + 1}/{totalDataScan} data {data.FileLocation}";
            //toolStripLabelProgress.GetCurrentParent()?.Refresh();
        }

        private void bgWorkerScan_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnScan.Enabled = true;
            btnScanStop.Enabled = false;
            if (e.Cancelled)
            {
                toolStripLabelProgress.Text = "Scan dibatalkan.";
            }
            else if (e.Error != null)
            {
                toolStripLabelProgress.Text = "Terjadi error saat scan.";
            }
            else
            {
                toolStripProgressBarGlobal.Value = 100;
                toolStripLabelProgress.Text = $"Scanning: {totalDataScan}/{totalDataScan} data selesai.";
            }
            Cursor.Current = Cursors.Default;
        }

        private void doScanFiles(string sourcePath, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (!Directory.Exists(sourcePath)) return;

            // Kumpulkan ekstensi dari checkbox yang dicentang
            if (chkExtImages.Checked)
            {
                extImages = txtExtImage.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => "." + e.Trim()).ToArray();
                extAll = extAll.Concat(extImages).ToArray();
            }

            if (chkExtVideos.Checked)
            {
                extVideos = txtExtVideos.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => "." + e.Trim()).ToArray();
                extAll = extAll.Concat(extVideos).ToArray();
            }

            if (chkExtDocuments.Checked)
            {
                extDocuments = txtExtDocuments.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => "." + e.Trim()).ToArray();
                extAll = extAll.Concat(extDocuments).ToArray();
            }

            // Ambil semua file berdasarkan ekstensi
            resFiles = FileScanner.GetAllFiles(sourcePath, extAll).ToArray();

            // Filter berdasarkan prefix
            List<string> filteredFiles = new List<string>(resFiles);

            // Prefix yang **harus ada** di nama file
            if (chkPrefixIncl.Checked && !string.IsNullOrWhiteSpace(txtPrefixIncl.Text))
            {
                var inclPrefixes = txtPrefixIncl.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                     .Select(p => p.Trim().ToLower());

                filteredFiles = filteredFiles.Where(f => inclPrefixes.Any(p => Path.GetFileName(f).ToLower().StartsWith(p)))
                                             .ToList();
            }

            // Prefix yang **harus dihindari**
            if (chkPrefixExcl.Checked && !string.IsNullOrWhiteSpace(txtPrefixExcl.Text))
            {
                var exclPrefixes = txtPrefixExcl.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                     .Select(p => p.Trim().ToLower());

                filteredFiles = filteredFiles.Where(f => !exclPrefixes.Any(p => Path.GetFileName(f).ToLower().StartsWith(p)))
                                             .ToList();
            }

            // Simpan hasil akhir
            resFiles = filteredFiles.ToArray();
            totalDataScan = resFiles.Length; // Simpan total data yang akan di-scan
            for (int i = 0; i < resFiles.Length; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;  // keluar dari scan
                }

                // Simpan sementara untuk menampilkan di DataGridView
                string file = resFiles[i];
                int progress = (int)((i + 1) * 100.0 / resFiles.Length);
                // jalankan bgworker_onProgressChanged
                //worker?.ReportProgress(progress, new { Index = i, File = file });
                worker?.ReportProgress(progress, new
                {
                    Index = i,
                    File = file,
                    FileLocation = FileProperty.GetProperty(file, "File location"),
                    Name = FileProperty.GetProperty(file, "Name"),
                    DateTaken = FileProperty.GetProperty(file, "Date taken"),
                    MediaCreated = FileProperty.GetProperty(file, "Media created"),
                    DateCreated = FileProperty.GetProperty(file, "Date created"),
                    DateModified = FileProperty.GetProperty(file, "Date modified"),
                    Type = FileProperty.GetProperty(file, "Type"),
                    SizeBytes = Format.GetFileSizeBytes(file)
                });
            }
        }

        private void doScanAddDGV(dynamic data)
        {
            try
            {
                dgvScan.Rows.Add(
                    data.Index + 1,
                    data.FileLocation,
                    data.Name,
                    data.Type,
                    data.SizeBytes,
                    data.DateTaken,
                    data.MediaCreated,
                    !String.IsNullOrEmpty(data.DateTaken) || !String.IsNullOrEmpty(data.MediaCreated) ? "Asli" : "",
                    data.DateCreated,
                    "Display"
                );
                //dgvScan.Refresh();
            }
            catch (Exception ex)
            {
                // Log error jika diperlukan
            }

            // Jangan ubah cursor di sini, bukan tempatnya
        }

        private void dgvScan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //fd.Hide();

                if (e.RowIndex != this.dgvScan.NewRowIndex)
                {
                    //DataGridView row
                    //DataGridViewRow row = dgvListFiles.Rows[e.RowIndex];
                    //row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                }
                if (e.RowIndex != this.dgvScan.NewRowIndex)
                {
                    DataGridViewRow row = dgvScan.Rows[e.RowIndex];
                    string filePath = row.Cells[1].Value.ToString() + "/" + row.Cells[2].Value.ToString();

                    if (File.Exists(filePath) && extImages.Contains(Path.GetExtension(filePath)))
                    {
                        picBox.Image = Image.FromFile(filePath);
                        picBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        picBox.Image = null; // Kosongkan PictureBox
                    }


                }
            }
            catch (System.Exception ex)
            {
                //listLog.Items.Add("MouseEnter Unknown error : " + ex);
            }
        }

        #endregion SCAN FILES



        #region COPY FILES
        private void btnCopyBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtCopyPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!bgWorkerCopy.IsBusy)
            {
                // jalankan bgWorkerCopy_DoWork
                if (string.IsNullOrEmpty(txtCopyPath.Text))
                {
                    MessageBox.Show("Silakan pilih folder tujuan untuk copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (!Directory.Exists(txtCopyPath.Text))
                {
                    MessageBox.Show("Folder tujuan tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (string.IsNullOrEmpty(cbxCopySubFolder.Text))
                {
                    MessageBox.Show("Silakan pilih struktur folder untuk copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    btnCopy.Enabled = false;
                    btnCopyStop.Enabled = true;

                    // Reset progress bar
                    toolStripProgressBarGlobal.Value = 0;
                    toolStripProgressBarGlobal.Maximum = 100;
                    toolStripLabelProgress.Text = "Memulai copy...";

                    extAll = Array.Empty<string>();

                    Cursor.Current = Cursors.WaitCursor;
                    Application.DoEvents(); // Ini penting agar tombol tetap bisa diklik

                    // Kirim dua nilai sebagai tuple
                    var args = Tuple.Create(txtCopyPath.Text, cbxCopySubFolder.Text);
                    bgWorkerCopy.RunWorkerAsync(args); // hanya bisa mengirim satu argumen, jadi kita gunakan Tuple
                }
            }
        }

        private void btnCopyStop_Click(object sender, EventArgs e)
        {
            if (bgWorkerCopy.IsBusy && bgWorkerCopy.WorkerSupportsCancellation)
            {
                bgWorkerCopy.CancelAsync();
                toolStripLabelProgress.Text = "Membatalkan copy...";
                btnCopy.Enabled = true;
                btnCopyStop.Enabled = false;
            }
        }

        private void bgWorkerCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            Application.DoEvents(); // pastikan event berjalan
            var args = e.Argument as Tuple<string, string>;

            DoCopyFiles(args.Item1, args.Item2, sender as BackgroundWorker, e);
        }

        private void bgWorkerCopy_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBarGlobal.Value = Math.Min(e.ProgressPercentage, 100);
            var data = e.UserState as dynamic;
            toolStripLabelProgress.Text = $"Copying: {data.Index + 1}/{data.Total} to {data.DestFile}";
        }

        private void bgWorkerCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCopy.Enabled = true;
            btnCopyStop.Enabled = false;
            if (e.Cancelled)
            {
                toolStripLabelProgress.Text = "Copy dibatalkan.";
            }
            else if (e.Error != null)
            {
                toolStripLabelProgress.Text = "Terjadi error saat scan.";
            }
            else
            {
                toolStripProgressBarGlobal.Value = 100;
                toolStripLabelProgress.Text = $"Copy: {totalDataScan}/{totalDataScan} data selesai.";
            }
            Cursor.Current = Cursors.Default;
        }

        private void DoCopyFiles(string mainPath, string subPath, BackgroundWorker worker, DoWorkEventArgs e)
        {
            string[] arrSubPath = subPath.Split('/', StringSplitOptions.RemoveEmptyEntries);

            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            dgvScan.Invoke((MethodInvoker)(() =>
            {
                foreach (DataGridViewRow row in dgvScan.Rows)
                {
                    if (!row.IsNewRow)
                        rows.Add(row);
                }
            }));

            int total = rows.Count;
            int current = 0;

            int processed = 0;
            foreach (DataGridViewRow row in rows)
            {
                if (!ShouldCopyRow(row)) continue;

                DateTime myDate = GetTargetDate(row);
                string finalPath = BuildFinalPath(mainPath, myDate, arrSubPath);

                if (!Directory.Exists(finalPath))
                    Directory.CreateDirectory(finalPath);

                string sourceFile = Path.Combine(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());
                string destFile = Path.Combine(finalPath, Path.GetFileName(sourceFile));

                try
                {
                    bool success = CopyAndVerify(sourceFile, destFile);

                    dgvScan.Invoke((MethodInvoker)(() =>
                    {
                        row.Cells[9].Value = success ? "Copied" : "Copy Failed";
                    }));
                }
                catch (Exception)
                {
                    dgvScan.Invoke((MethodInvoker)(() =>
                    {
                        row.Cells[9].Value = "Error";
                    }));
                }
                processed++;

                current++;
                int progress = (int)((current / (double)total) * 100);
                bgWorkerCopy?.ReportProgress(progress, new { Index = processed, Total = total, DestFile = destFile });
            }
        }

        private bool ShouldCopyRow(DataGridViewRow row)
        {
            string ext = Path.GetExtension(row.Cells[2].Value?.ToString() ?? "").ToLower();
            string type = row.Cells[3].Value?.ToString().ToLower(); // Type
            string status = row.Cells[9].Value?.ToString();

            if (status != "Display") return false;

            bool isImage = extImages != null && extImages.Contains(ext);
            bool isVideo = extVideos != null && extVideos.Contains(ext);
            bool isDocument = extDocuments != null && extDocuments.Contains(ext);

            bool dateTaken = !string.IsNullOrEmpty(row.Cells[5].Value?.ToString());
            bool mediaCreated = !string.IsNullOrEmpty(row.Cells[6].Value?.ToString());

            bool isAsli = row.Cells[7].Value?.ToString()?.ToLower() == "Asli";

            if (isImage && cbxCopyImages.Checked)
            {
                if (rbtnImageAll.Checked) return true;
                if (rbtnImageOri.Checked) return dateTaken && isAsli;
                if (rbtnImageNonOri.Checked) return !dateTaken && !isAsli;
            }

            if (isVideo && cbxCopyVideos.Checked)
            {
                if (rbtnVideoAll.Checked) return true;
                if (rbtnVideoAll.Checked) return mediaCreated && isAsli;
                if (rbtnVideoAll.Checked) return !mediaCreated && !isAsli;
            }

            if (isDocument && cbxCopyDocuments.Checked)
            {
                return true;
            }

            return false;
        }

        private DateTime GetTargetDate(DataGridViewRow row)
        {
            string dateTaken = row.Cells[5].Value?.ToString();
            string mediaCreated = row.Cells[6].Value?.ToString();

            if (!string.IsNullOrEmpty(dateTaken) && DateTime.TryParse(dateTaken, out DateTime dtTaken))
                return dtTaken;
            if (!string.IsNullOrEmpty(mediaCreated) && DateTime.TryParse(mediaCreated, out DateTime dtCreated))
                return dtCreated;

            return DateTime.Now;
        }

        private string BuildFinalPath(string mainPath, DateTime date, string[] arrSubPath)
        {
            string year = arrSubPath.Length > 0 ? date.ToString("yyyy") : "";
            string month = arrSubPath.Length > 1 ? date.ToString("MM") : "";
            string day = arrSubPath.Length > 2 ? date.ToString("dd") : "";

            return Path.Combine(mainPath, year, month, day);
        }

        private bool CopyAndVerify(string sourceFile, string destFile)
        {
            File.Copy(sourceFile, destFile, overwrite: false);

            long srcSize = new FileInfo(sourceFile).Length;
            long dstSize = new FileInfo(destFile).Length;

            return srcSize == dstSize;
        }


        private void DoCopyUpdateDGV(dynamic data)
        {
            try
            {
                dgvScan.Rows.Add(
                    data.Index + 1,
                    data.FileLocation,
                    data.Name,
                    data.Type,
                    data.SizeBytes,
                    data.DateTaken,
                    data.MediaCreated,
                    !String.IsNullOrEmpty(data.DateTaken) || !String.IsNullOrEmpty(data.MediaCreated) ? "Asli" : "",
                    data.DateCreated,
                    "Display"
                );
                //dgvScan.Refresh();
            }
            catch (Exception ex)
            {
                // Log error jika diperlukan
            }

            // Jangan ubah cursor di sini, bukan tempatnya
        }
        #endregion COPY FILES


        private void cbxCopyImages_CheckedChanged(object sender, EventArgs e)
        {
            gBoxCopyImages.Enabled = cbxCopyImages.Checked;
            rbtnImageAll.Enabled = cbxCopyImages.Checked;
            rbtnImageOri.Enabled = cbxCopyImages.Checked;
            rbtnImageNonOri.Enabled = cbxCopyImages.Checked;
        }

        private void cbxCopyVideos_CheckedChanged(object sender, EventArgs e)
        {
            gBoxCopyVideos.Enabled = cbxCopyVideos.Checked;
            rbtnVideoAll.Enabled = cbxCopyVideos.Checked;
            rbtnVideoOri.Enabled = cbxCopyVideos.Checked;
            rbtnVideoNonOri.Enabled = cbxCopyVideos.Checked;
        }
    }
}
