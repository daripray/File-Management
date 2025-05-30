using Simpler.Helper;
using System.ComponentModel;
using System.Diagnostics;


namespace Simpler
{
    public partial class Form1 : Form
    {
        private string[] extImages = Array.Empty<string>();
        private string[] extVideos = Array.Empty<string>();
        private string[] extDocuments = Array.Empty<string>();
        private string[] extAll = Array.Empty<string>();
        private string[] prefixIncl = Array.Empty<string>();
        private string[] prefixExcl = Array.Empty<string>();
        private string[] resFiles = Array.Empty<string>();
        List<string> tempResFiles = new List<string> { };

        private enum ProcessState { None, Scanning, Copying, Completed, Error };
        private ProcessState currentState = ProcessState.None;

        private DataGridColumnIndexer indexer; // Untuk menyimpan indeks kolom berdasarkan nama kolom

        private int totalScannedDatas = 0; // Total data yang akan di-scan, bisa digunakan untuk progress bar
        private int totalDataToCopy = 0; // Total data yang akan di-copy, bisa digunakan untuk progress bar

        public Form1()
        {
            InitializeComponent();
            currentState = ProcessState.None;
            totalScannedDatas = 0;
            totalDataToCopy = 0;

            indexer = new DataGridColumnIndexer(dgvScan); // Inisialisasi indeks kolom berdasarkan DataGridView
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
                totalScannedDatas= 0; // Reset total data scan sebelum memulai scan baru
                toolStripProgressBarPerFile.Visible = false; // Sembunyikan progress bar per file

                // Disable tombol scan dan aktifkan tombol stop
                btnScan.Enabled = false;
                btnScanStop.Enabled = true;

                // Reset DataGridView
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

            toolStripLabelProgress.Text = $"Scanning: {data.Index}/{totalScannedDatas} data {data.FileLocation}";
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
                toolStripLabelProgress.Text = $"Scanning: {totalScannedDatas}/{totalScannedDatas} data selesai.";
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
            totalScannedDatas = resFiles.Length; // Simpan total data yang akan di-scan

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
                string statusOri = !string.IsNullOrEmpty(FileProperty.GetProperty(file, "Date taken")) || !string.IsNullOrEmpty(FileProperty.GetProperty(file, "Media created")) ? "Ori" : "Non-Ori";
                string statusFile = File.Exists(Path.Combine(file)) ? "Display" : "Not Found";
                if(new FileInfo(file).Length == 0) statusFile = "Empty";

                worker?.ReportProgress(progress, new
                {
                    Index = i+1,
                    FileLocation = FileProperty.GetProperty(file, "File location"),
                    Name = FileProperty.GetProperty(file, "name"),
                    Type = FileProperty.GetProperty(file, "Type"),
                    SizeBytes = Format.GetFileSizeBytes(file),
                    StatusOri = statusOri,
                    DateTaken = FileProperty.GetProperty(file, "Date taken"),
                    MediaCreated = FileProperty.GetProperty(file, "Media created"),
                    DateCreated = FileProperty.GetProperty(file, "Date created"),
                    //DateModified = FileProperty.GetProperty(file, "Date modified"),
                    StatusFile = statusFile,
                    statusCopy = ""
                });
            }
        }

        private void doScanAddDGV(dynamic data)
        {
            try
            {
                dgvScan.Rows.Add(
                    data.Index,
                    data.FileLocation,
                    data.Name,
                    data.Type,
                    data.SizeBytes,
                    data.StatusOri,
                    data.DateTaken,
                    data.MediaCreated,
                    data.DateCreated,
                    data.StatusFile,
                    data.statusCopy
            );
            }
            catch (Exception ex) { }
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
                    string filePath = row.Cells[indexer["path"]].Value.ToString() + "/" + row.Cells[indexer["name"]].Value.ToString();

                    bool exist = File.Exists(filePath);
                    string ext = Path.GetExtension(filePath).ToLower();
                    bool contain = extImages.Contains(ext);
                    if (exist && contain)
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
                toolStripProgressBarPerFile.Visible = true;
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
                    totalDataToCopy = 0; // Reset total data copy sebelum memulai copy baru

                    // Disable tombol copy dan aktifkan tombol stop
                    btnCopy.Enabled = false;
                    btnCopyStop.Enabled = true;

                    // Reset progress bar
                    toolStripProgressBarGlobal.Value = 0;
                    toolStripProgressBarGlobal.Maximum = 100;
                    toolStripProgressBarPerFile.Value = 0;
                    toolStripProgressBarPerFile.Maximum = 100;
                    toolStripLabelProgress.Text = "Memulai copy...";

                    extAll = Array.Empty<string>();

                    ResetCopiedStatus(); // Reset status "Copied" sebelum mulai copy ulang

                    Cursor.Current = Cursors.WaitCursor;
                    Application.DoEvents(); // Ini penting agar tombol tetap bisa diklik

                    // Kirim dua nilai sebagai tuple
                    string mainPath = txtCopyPath.Text;
                    string subPath = cbxCopySubFolder.Text;
                    var args = Tuple.Create(txtCopyPath.Text, cbxCopySubFolder.Text);
                    bgWorkerCopy.RunWorkerAsync(args); // hanya bisa mengirim satu argumen, jadi kita gunakan Tuple
                }
            }
            else
            {
                MessageBox.Show("Proses copy masih berjalan. Harap tunggu hingga selesai atau klik Stop.");
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
            toolStripProgressBarPerFile.Visible = false;
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
                toolStripLabelProgress.Text = "Terjadi error saat copy.";
            }
            else
            {
                toolStripProgressBarGlobal.Value = 100;
                toolStripProgressBarPerFile.Value = 100;

                toolStripLabelProgress.GetCurrentParent()?.Refresh();

                toolStripLabelProgress.Text = $"Copy: {totalDataToCopy}/{totalDataToCopy} data selesai.";
            }
            toolStripProgressBarPerFile.Visible = false;
            Cursor.Current = Cursors.Default;

            int copied = dgvScan.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[indexer["copyStatus"]].Value?.ToString() == "Success");
            int failed = dgvScan.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[indexer["copyStatus"]].Value?.ToString() == "Failed" 
            || r.Cells[indexer["copyStatus"]].Value?.ToString() == "Error");
            int total = dgvScan.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[indexer["copyStatus"]].Value?.ToString() != null);
            MessageBox.Show($"Copy selesai:\nTotal: {totalDataToCopy}\nSukses: {(copied>totalDataToCopy?0:copied)}\nGagal: {failed}", "Hasil Copy");
            //MessageBox.Show($"Copy selesai:\nSukses: {copied}\nGagal: {failed}", "Hasil Copy");
        }

        private void DoCopyFiles(string mainPath, string subPath, BackgroundWorker worker, DoWorkEventArgs e)
        {

            if (worker.CancellationPending)
            {
                e.Cancel = true; // <- ini perlu ditambahkan
                return;
            }

            string[] arrSubPath = subPath.Split('/', StringSplitOptions.RemoveEmptyEntries);

            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            dgvScan.Invoke((MethodInvoker)(() =>
            {
                foreach (DataGridViewRow row in dgvScan.Rows)
                {
                    if (!ShouldCopyRow(row))
                        continue;

                    if (!row.IsNewRow)
                        rows.Add(row);
                }
            }));

            totalDataToCopy = rows.Count;
            if (totalDataToCopy == 0)
            {
                dgvScan.Invoke((MethodInvoker)(() =>
                {
                    toolStripLabelProgress.Text = "Tidak ada file yang akan di-copy.";
                }));
                return;
            }
            int current = 0;
            int processed = 0;
            foreach (DataGridViewRow row in rows)
            {
                //if (!ShouldCopyRow(row)) continue;

                DateTime myDate = GetTargetDate(row);
                string finalPath = BuildFinalPath(mainPath, myDate, arrSubPath);

                if (!Directory.Exists(finalPath))
                    Directory.CreateDirectory(finalPath);

                string sourceFile = Path.Combine(row.Cells[indexer["path"]].Value.ToString(), row.Cells[indexer["name"]].Value.ToString());
                string destFile = Path.Combine(finalPath, Path.GetFileName(sourceFile));
                
                long sourceSize = new FileInfo(sourceFile).Length;
                if (File.Exists(destFile))
                {
                    long finalSize = new FileInfo(destFile).Length;
                    if (sourceSize == finalSize)
                    {
                        row.Cells[indexer["copyStatus"]].Value = "Exist";
                        continue;
                    }
                }
                    try
                    {
                        bool success = CopyAndVerifyWithProgress(sourceFile, destFile, worker);

                        dgvScan.Invoke((MethodInvoker)(() =>
                        {
                            row.Cells[indexer["copyStatus"]].Value = success ? "Success" : "Failed";
                        }));
                    }
                    catch (Exception)
                    {
                        dgvScan.Invoke((MethodInvoker)(() =>
                        {
                            row.Cells[indexer["copyStatus"]].Value = "Error";
                        }));
                    }
                processed++;

                current++;
                int progress = (int)((current / (double)totalDataToCopy) * 100);
                bgWorkerCopy?.ReportProgress(progress, new { Index = processed, Total = totalDataToCopy, DestFile = destFile });
            }
        }

        private bool ShouldCopyRow(DataGridViewRow row)
        {
            string ext = Path.GetExtension(row.Cells[indexer["name"]].Value?.ToString() ?? "").ToLower();
            string type = row.Cells[indexer["type"]].Value?.ToString().ToLower(); // Type
            string status = row.Cells[indexer["fileStatus"]].Value?.ToString();
            string statusCopy = row.Cells[indexer["copyStatus"]].Value?.ToString();

            if (status != "Display" && statusCopy == "Failed") return false;

           bool isImage = extImages != null && extImages.Contains(ext);
            bool isVideo = extVideos != null && extVideos.Contains(ext);
            bool isDocument = extDocuments != null && extDocuments.Contains(ext);

            bool dateTaken = !string.IsNullOrEmpty(row.Cells[indexer["dateTaken"]].Value?.ToString());
            bool mediaCreated = !string.IsNullOrEmpty(row.Cells[indexer["mediaCreated"]].Value?.ToString());

            bool isAsli = row.Cells[indexer["originalStatus"]].Value?.ToString() == "Ori";
            bool isCopied = statusCopy == "Success";

            if (cbxCopyImages.Checked && isImage && !isCopied)
            {
                if (rbtnImageAll.Checked) return true;
                if (rbtnImageOri.Checked) return dateTaken && isAsli;
                if (rbtnImageNonOri.Checked) return !dateTaken && !isAsli;
            }

            if (cbxCopyVideos.Checked && isVideo && !isCopied)
            {
                if (rbtnVideoAll.Checked) return true;
                if (rbtnVideoOri.Checked) return mediaCreated && isAsli;
                if (rbtnVideoNonOri.Checked) return !mediaCreated && !isAsli;
            }

            if (cbxCopyDocuments.Checked && isDocument && !isCopied)
            {
                return true;
            }

            return false;
        }

        private DateTime GetTargetDate(DataGridViewRow row)
        {
            string dateTaken = row.Cells[indexer["dateTaken"]].Value?.ToString();
            string mediaCreated = row.Cells[indexer["mediaCreated"]].Value?.ToString();

            if (!string.IsNullOrEmpty(dateTaken) && DateTime.TryParse(dateTaken, out DateTime dtTaken)) // Coba parse Date Taken > Foto
                return dtTaken;
            if (!string.IsNullOrEmpty(mediaCreated) && DateTime.TryParse(mediaCreated, out DateTime dtCreated)) // Coba parse Media Created > Video
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

        private bool CopyAndVerifyWithProgress(string sourceFile, string destFile, BackgroundWorker worker)
        {
            const int bufferSize = 1024 * 1024; // 1MB
            byte[] buffer = new byte[bufferSize];

            long totalBytes = new FileInfo(sourceFile).Length;
            long totalCopied = 0;

            toolStripProgressBarPerFile.GetCurrentParent().Invoke((MethodInvoker)(() =>
            {
                toolStripProgressBarPerFile.Minimum = 0;
                toolStripProgressBarPerFile.Maximum = 100;
                toolStripProgressBarPerFile.Value = 0;
            }));

            using (var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (var destStream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
            {
                int bytesRead;
                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (worker.CancellationPending)
                    {
                        return false;
                    }

                    //if (File.Exists(destFile)) continue;
                    destStream.Write(buffer, 0, bytesRead);
                    totalCopied += bytesRead;

                    int percent = (int)(totalCopied * 100 / totalBytes);

                    toolStripProgressBarPerFile.GetCurrentParent().Invoke((MethodInvoker)(() =>
                    {
                        toolStripProgressBarPerFile.Value = percent;
                    }));
                }
            }

            // Final verifikasi ukuran
            long finalSize = new FileInfo(destFile).Length;
            return totalBytes == finalSize;
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error update DGV: {ex.Message}");
            }
        }


        private void ResetCopiedStatus() //copy ulang file yang sudah "Copied"
        {
            totalDataToCopy = 0;
            dgvScan.Invoke((MethodInvoker)(() =>
            {
                foreach (DataGridViewRow row in dgvScan.Rows)
                {
                    if (row.Cells[indexer["copyStatus"]].Value?.ToString() == "Copied" 
                    || row.Cells[indexer["copyStatus"]].Value?.ToString() == "Copy Failed" 
                    || row.Cells[indexer["copyStatus"]].Value?.ToString() == "Error")
                    {
                        row.Cells[indexer["copyStatus"]].Value = "Display";
                    }
                }
            }));
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
