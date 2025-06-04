using Microsoft.VisualBasic;
using File_Management_v1.Helper;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace File_Management_v1
{
    public partial class Main : Form
    {
        private string[] extImages = Array.Empty<string>();
        private string[] extVideos = Array.Empty<string>();
        private string[] extDocuments = Array.Empty<string>();
        private string[] extAll = Array.Empty<string>();
        private string[] prefixIncl = Array.Empty<string>();
        private string[] prefixExcl = Array.Empty<string>();
        private string[] resFiles = Array.Empty<string>();
        List<string> tempResFiles = new List<string> { };

        private Dictionary<string, int> _prefixDict = new Dictionary<string, int>(); // Untuk menyimpan prefix yang sudah ditemukan beserta jumlahnya

        private string currentAction; // Variabel untuk menyimpan jenis proses yang sedang dilakukan (Scan, Copy, Move)

        private string currentState; // Variabel untuk menyimpan status proses saat ini

        private DataGridColumnIndexer indexer; // Untuk menyimpan indeks kolom berdasarkan nama kolom

        private int totalScannedDatas = 0; // Total data yang akan di-scan, bisa digunakan untuk progress bar

        private int totalDataToCopy = 0; // Total data yang akan di-copy, bisa digunakan untuk progress bar

        private bool moveAndDelete = false; // Untuk menentukan apakah akan memindahkan file dan menghapus yang lama

        private string _lastPreviewFilePath = "";

        ImagePreview ImgPrev = new ImagePreview();

        public Main()
        {
            InitializeComponent();
            currentAction = Status.Action.None;
            currentState = Status.Process.None;
            totalScannedDatas = 0;
            totalDataToCopy = 0;
            _prefixDict.Clear();

            indexer = new DataGridColumnIndexer(dgvScan); // Inisialisasi indeks kolom berdasarkan DataGridView
        }

        #region SCAN FILES

        private void btnScanBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserScan.ShowDialog() == DialogResult.OK)
            {
                txtScanPath.Text = folderBrowserScan.SelectedPath;
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (!bgWorkerScan.IsBusy)
            {
                currentAction = Status.Action.Scan;
                currentState = Status.Process.Initiating;
                addLog();

                _prefixDict.Clear();
                totalScannedDatas = 0; // Reset total data scan sebelum memulai scan baru
                toolStripProgressBarPerFile.Visible = false; // Sembunyikan progress bar per file

                // Disable tombol scan dan aktifkan tombol stop
                btnScan.Enabled = false;
                btnScanStop.Enabled = true;

                // Reset DataGridView
                dgvScan.Rows.Clear();

                // Reset progress bar
                toolStripProgressBarGlobal.Value = 0;
                toolStripProgressBarGlobal.Maximum = 100;
                toolStripLabelProgress.Text = $"Memulai {currentState}...";

                extAll = Array.Empty<string>();

                //Application.DoEvents(); // Ini penting agar tombol tetap bisa diklik
                Cursor.Current = Cursors.WaitCursor;

                // jalankan bgWorkerScan_DoWork
                bgWorkerScan.RunWorkerAsync(txtScanPath.Text); // kirim path jika perlu
            }
        }

        private void btnScanStop_Click(object sender, EventArgs e)
        {
            if (bgWorkerScan.IsBusy && bgWorkerScan.WorkerSupportsCancellation)
            {
                currentAction = Status.Action.Stop;
                currentState = Status.Process.Stopping; // Set state ke Stopping
                btnScan.Enabled = true;
                btnScanStop.Enabled = false;
                bgWorkerScan.CancelAsync();
                toolStripLabelProgress.Text = $"Membatalkan {currentState}...";
                addLog();
            }
        }

        private void bgWorkerScan_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Application.DoEvents(); // pastikan event berjalan
            var prefixDict = new Dictionary<string, int>();
            string path = e.Argument as string;
            doScanFiles(path, sender as BackgroundWorker, e);

            e.Result = prefixDict;

            currentState = Status.Process.Scanning;
            addLog();
        }

        private void bgWorkerScan_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripProgressBarGlobal.Value = Math.Min(e.ProgressPercentage, 100);

            var data = e.UserState as dynamic;
            doScanAddDGV(data);

            toolStripLabelProgress.Text = $"{currentState}: {data.Index}/{totalScannedDatas} data {data.FileLocation}";
        }

        private void bgWorkerScan_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnScan.Enabled = true;
            btnScanStop.Enabled = false;
            if (e.Cancelled)
            {
                toolStripLabelProgress.Text = $"{currentState} dibatalkan.";
            }
            else if (e.Error != null)
            {
                toolStripLabelProgress.Text = "Terjadi error saat scan.";
            }
            else
            {
                // Sortir prefix berdasarkan jumlah terbesar
                var prefixSummaryList = _prefixDict
                    .OrderByDescending(kvp => kvp.Value)
                    .Select(kvp => $"{kvp.Key} {kvp.Value}")
                    .ToList();

                // Update ListBox dari thread UI
                if (richTextBoxPrefixFound.InvokeRequired)
                {
                    richTextBoxPrefixFound.Invoke(new MethodInvoker(() =>
                    {
                        richTextBoxPrefixFound.Clear();
                        //lstBoxScanPrefix.Items.Add("Prefix Found:");
                        foreach (var item in prefixSummaryList)
                        {
                            richTextBoxPrefixFound.Text = item + Environment.NewLine + richTextBoxPrefixFound.Text;
                        }
                    }));
                }
                else
                {
                    richTextBoxPrefixFound.Clear();
                    foreach (var item in prefixSummaryList)
                    {
                        richTextBoxPrefixFound.Text = item + Environment.NewLine + richTextBoxPrefixFound.Text;
                    }
                }

                toolStripProgressBarGlobal.Value = 100;
                toolStripLabelProgress.Text = $"{currentState}: {totalScannedDatas}/{totalScannedDatas} data selesai.";
            }
            Cursor.Current = Cursors.Default;

            currentState = Status.Process.Done; // Reset state setelah selesai
            addLog();
            currentState.Normalize(); // Reset currentState ke None setelah selesai
            currentAction.Normalize(); // Reset currentAction ke None setelah selesai
        }

        private void doScanFiles(string sourcePath, BackgroundWorker worker, DoWorkEventArgs e)
        {
            addLog($"Sedang memindai direktory {sourcePath}");

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
            var resFiles = FileScanner.GetAllFiles(sourcePath, extAll)
                          .Select(f => new FileInfo(f))
                          .ToArray();

            // Filter berdasarkan prefix
            List<FileInfo> filteredFiles = new List<FileInfo>(resFiles);

            // Prefix yang **harus ada** di nama file
            if (chkPrefixIncl.Checked && !string.IsNullOrWhiteSpace(txtPrefixIncl.Text))
            {
                var inclPrefixes = txtPrefixIncl.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                     .Select(p => p.Trim().ToLower());

                filteredFiles = filteredFiles.Where(f => inclPrefixes.Any(p => f.Name.ToLower().Contains(p)))
                                             .ToList();
            }

            // Prefix yang **harus dihindari**
            if (chkPrefixExcl.Checked && !string.IsNullOrWhiteSpace(txtPrefixExcl.Text))
            {
                var exclPrefixes = txtPrefixExcl.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                     .Select(p => p.Trim().ToLower());

                filteredFiles = filteredFiles.Where(f => !exclPrefixes.Any(p => f.Name.ToLower().Contains(p)))
                                             .ToList();
            }


            // Simpan hasil akhir
            resFiles = filteredFiles.ToArray();
            totalScannedDatas = resFiles.Length;

            addLog($"Sedang memindai {totalScannedDatas} file");

            for (int i = 0; i < resFiles.Length; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                FileInfo file = resFiles[i];

                int progress = (int)((i + 1) * 100.0 / resFiles.Length);
                // Ambil prefix + jumlahnya
                var (prefix, count) = ExtractSmartPrefix(file.Name);

                string dateTaken = FileProperty.GetProperty(file.FullName, "Date taken");
                string mediaCreated = FileProperty.GetProperty(file.FullName, "Media created");
                string statusOri = (!string.IsNullOrEmpty(dateTaken) || !string.IsNullOrEmpty(mediaCreated)) ? Status.File.Ori : Status.File.NonOri;

                string statusFile = Status.Scan.Display;
                if (!file.Exists) statusFile = Status.Scan.NotFound;
                else if (file.Length == 0) statusFile = Status.Scan.Error;

                worker?.ReportProgress(progress, new
                {
                    Index = i + 1,
                    FileLocation = file.DirectoryName,
                    Name = file.Name,
                    Type = file.Extension,
                    SizeBytes = Format.GetFileSizeBytes(file.FullName),
                    StatusOri = statusOri,
                    DateTaken = dateTaken,
                    MediaCreated = mediaCreated,
                    DateCreated = FileProperty.GetProperty(file.FullName, "Date created"),
                    StatusFile = statusFile,
                    statusCopy = ""
                });
            }
        }

        private (string prefix, int count) ExtractSmartPrefix(string fileName)
        {
            string nameOnly = Path.GetFileNameWithoutExtension(fileName);

            // Ganti semua angka (grup) dengan ...
            string prefix = Regex.Replace(nameOnly, @"\d+", "...");

            // Jika hasilnya jadi berulang titik (misal ......), sederhanakan jadi ...
            prefix = Regex.Replace(prefix, @"\.{2,}", "...");

            // Simpan prefix ke dictionary
            if (_prefixDict.ContainsKey(prefix))
                _prefixDict[prefix]++;
            else
                _prefixDict[prefix] = 1;

            return (prefix, _prefixDict[prefix]);
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
            _lastPreviewFilePath = "";

        }

        #endregion SCAN FILES


        #region COPY FILES
        private void btnCopyBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserCopy.ShowDialog() == DialogResult.OK)
            {
                txtCopyPath.Text = folderBrowserCopy.SelectedPath;
                btnMove.Enabled = true;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // Set currentAction untuk proses Copy
            currentAction = Status.Action.Copy;
            // Set currentAction dan currentState untuk proses Copy
            DoCopyOrMoveInitialing();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            // Set currentAction dan currentState untuk proses Move
            currentAction = Status.Action.Move;
            moveAndDelete = chkMoveAndDelete.Checked; // Ambil nilai dari checkbox
                                                      // Set currentAction dan currentState untuk proses Move
            DoCopyOrMoveInitialing();
        }

        private bool validateFormCopy()
        {
            if (string.IsNullOrEmpty(txtCopyPath.Text))
            {
                MessageBox.Show("Silakan pilih folder tujuan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!Directory.Exists(txtCopyPath.Text))
            {
                MessageBox.Show("Folder tujuan tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(cbBoxCopySubFolder.Text))
            {
                MessageBox.Show("Silakan pilih struktur folder tujuan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void DoCopyOrMoveInitialing()
        {
            if (!bgWorkerCopy.IsBusy)
            {
                currentState = Status.Process.Initiating;

                toolStripProgressBarPerFile.Visible = true;

                // Validasi form sebelum melanjutkan
                if (!validateFormCopy())
                {
                    currentState = Status.Process.Error; // Set state ke Error jika validasi gagal
                    addLog();
                    return;
                }
                else
                {
                    addLog();
                    totalDataToCopy = 0; // Reset total data copy sebelum memulai copy baru

                    // Disable tombol copy dan move, aktifkan tombol stop
                    btnCopy.Enabled = false;
                    btnMove.Enabled = false;
                    btnCopyStop.Enabled = true;

                    // Reset progress bar
                    toolStripProgressBarGlobal.Value = 0;
                    toolStripProgressBarGlobal.Maximum = 100;
                    toolStripProgressBarPerFile.Value = 0;
                    toolStripProgressBarPerFile.Maximum = 100;
                    toolStripLabelProgress.Text = $"Memulai {currentAction.ToString()}...";

                    extAll = Array.Empty<string>();

                    ResetCopiedStatus(); // Reset status "Copied" sebelum mulai copy ulang

                    Cursor.Current = Cursors.WaitCursor;

                    // Kirim dua nilai sebagai tuple
                    var args = Tuple.Create(txtCopyPath.Text, cbBoxCopySubFolder.Text);
                    bgWorkerCopy.RunWorkerAsync(args); // hanya bisa mengirim satu argumen, jadi kita gunakan Tuple
                }
            }
            else
            {
                MessageBox.Show($"Proses {currentState.ToString()} masih berjalan. Harap tunggu hingga selesai atau klik Stop.");
            }
        }

        private void btnCopyStop_Click(object sender, EventArgs e)
        {
            if (bgWorkerCopy.IsBusy && bgWorkerCopy.WorkerSupportsCancellation)
            {
                currentAction = Status.Action.Stop;
                bgWorkerCopy.CancelAsync();
                toolStripLabelProgress.Text = $"Membatalkan proses {currentState}...";

                if (currentAction == Status.Action.Copy)
                {
                    btnCopy.Enabled = true;
                    btnCopyStop.Enabled = false;
                }
                if (currentAction == Status.Action.Move)
                {
                    btnMove.Enabled = true;
                    btnCopyStop.Enabled = false;
                }
            }
            toolStripProgressBarPerFile.Visible = false;
        }

        private void bgWorkerCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            Application.DoEvents(); // pastikan event berjalan
            currentState = currentAction == Status.Action.Copy ? Status.Process.Copying : Status.Process.Moving; // Set state sesuai action
            addLog();

            var args = e.Argument as Tuple<string, string>;
            DoCopyFiles(args.Item1, args.Item2, sender as BackgroundWorker, e);
        }

        private void bgWorkerCopy_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBarGlobal.Value = Math.Min(e.ProgressPercentage, 100);
            var data = e.UserState as dynamic;
            toolStripLabelProgress.Text = $"{currentState}: {data.Index + 1}/{data.Total} to {data.DestFile}";
        }

        private void bgWorkerCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCopy.Enabled = true;
            btnMove.Enabled = true;
            btnCopyStop.Enabled = false;
            toolStripProgressBarPerFile.Visible = false;

            if (e.Cancelled)
            {
                currentState = Status.Process.Stopping; // Set state ke Stopping
                toolStripLabelProgress.Text = $"Proses {currentAction} dibatalkan.";
            }
            else if (e.Error != null)
            {
                toolStripLabelProgress.Text = $"Terjadi {Status.Process.Error} saat {currentState}.";
            }
            else
            {
                toolStripProgressBarGlobal.Value = 100;
                toolStripProgressBarPerFile.Value = 100;

                toolStripLabelProgress.GetCurrentParent()?.Refresh();

                toolStripLabelProgress.Text = $"{currentState}: {totalDataToCopy}/{totalDataToCopy} data selesai.";
            }
            Cursor.Current = Cursors.Default;

            int copied = dgvScan.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[indexer["copyStatus"]].Value.ToString().Contains(Status.Copy.Success));
            int failed = dgvScan.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[indexer["copyStatus"]].Value?.ToString() == Status.Copy.Failed
            || r.Cells[indexer["copyStatus"]].Value?.ToString() == Status.Copy.Error);
            int total = dgvScan.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[indexer["copyStatus"]].Value?.ToString() != null);
            MessageBox.Show($"{currentAction} selesai:\nTotal: {totalDataToCopy}\nSukses: {(copied > totalDataToCopy ? 0 : copied)}\nGagal: {failed}", "Hasil {currentState}");
            //MessageBox.Show($"Copy selesai:\nSukses: {copied}\nGagal: {failed}", "Hasil Copy");


            addLog($"Total: {totalDataToCopy}");
            addLog($"Sukses: {(copied > totalDataToCopy ? 0 : copied)}");
            addLog($"Gagal: {failed} Hasil {currentState}");
            currentState = Status.Process.Done; // Reset state setelah selesai
            addLog();
            currentState.Normalize(); // Reset currentState ke None setelah selesai
            currentAction.Normalize(); // Reset currentAction ke None setelah selesai
        }

        private void DoCopyFiles(string mainPath, string subPath, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true; // <- ini perlu ditambahkan
                return;
            }
            string copySubFolderFormat = "";
            cbBoxCopySubFolder.Invoke((MethodInvoker)(() =>
            {
                copySubFolderFormat = cbBoxCopySubFolder.Text;
            }));

            totalDataToCopy = dgvScan.InvokeRequired ? (int)dgvScan.Invoke(() => dgvScan.RowCount) : dgvScan.RowCount;
            if (totalDataToCopy == 0)
            {
                dgvScan.Invoke((MethodInvoker)(() =>
                {
                    toolStripLabelProgress.Text = $"Tidak ada file yang akan di-{currentAction.ToLower()}.";
                }));
                return;
            }
            int current = 0;
            int processed = 0;
            for (int i = 0; i < totalDataToCopy; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                DataGridViewRow row = null;
                dgvScan.Invoke((MethodInvoker)(() => { row = dgvScan.Rows[i]; }));

                DateTime myDate = GetTargetDate(row);
                string finalPath = BuildFinalPath(mainPath, myDate, copySubFolderFormat);

                string sourceFile = Path.Combine(row.Cells[indexer["path"]].Value.ToString(), row.Cells[indexer["name"]].Value.ToString());
                string destFile = Path.Combine(finalPath, Path.GetFileName(sourceFile));

                List<string> status = new List<string>();

                if (ShouldCopyRow(row)) // Cek apakah baris ini perlu disalin
                {
                    if (isFileDuplicateSize(sourceFile, destFile))
                    {
                        if (currentAction == Status.Action.Copy || currentAction == Status.Action.Move)
                            status.Add(Status.Copy.Exist);
                    }
                    else if (isFileDuplicateName(sourceFile, destFile))
                    {
                        destFile = GetUniqueFileName(finalPath, Path.GetFileName(sourceFile));
                        status.Add(Status.Copy.Rename);
                    }

                    try
                    {
                        if (!Directory.Exists(finalPath))
                            Directory.CreateDirectory(finalPath);

                        bool success = CopyAndVerifyWithProgressOrMove(sourceFile, destFile, worker);
                        status.Add(success ? Status.Copy.Success : Status.Copy.Failed);
                    }
                    catch (Exception)
                    {
                        status.Add(Status.Copy.Error);
                    }
                }
                else
                {
                    status.Add(Status.Copy.Skip);
                }

                // Update ke UI: status dan progress
                string finalStatus = string.Join(" ", status);
                dgvScan.Invoke((MethodInvoker)(() =>
                {
                    row.Cells[indexer["copyStatus"]].Value = finalStatus;
                }));

                current++;
                processed++;

                int progress = (int)((current / (double)totalDataToCopy) * 100);
                bgWorkerCopy?.ReportProgress(progress, new
                {
                    Index = processed,
                    Total = totalDataToCopy,
                    DestFile = destFile
                });
            }
        }


        private string GetUniqueFileName(string destFolder, string originalFileName)
        {
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(originalFileName);
            string ext = Path.GetExtension(originalFileName);
            string newFileName = originalFileName;
            int counter = 1;

            while (File.Exists(Path.Combine(destFolder, newFileName)))
            {
                newFileName = $"{fileNameWithoutExt}_{counter}{ext}";
                counter++;
            }

            return Path.Combine(destFolder, newFileName);
        }

        private bool ShouldCopyRow(DataGridViewRow row)
        {
            string ext = Path.GetExtension(row.Cells[indexer["name"]].Value?.ToString() ?? "").ToLower();
            string type = row.Cells[indexer["type"]].Value?.ToString().ToLower(); // Type
            string status = row.Cells[indexer["fileStatus"]].Value?.ToString();
            string statusCopy = row.Cells[indexer["copyStatus"]].Value?.ToString();

            if (status != Status.Scan.Display && statusCopy == Status.Copy.Failed) return false;

            bool isImage = extImages != null && extImages.Contains(ext);
            bool isVideo = extVideos != null && extVideos.Contains(ext);
            bool isDocument = extDocuments != null && extDocuments.Contains(ext);

            bool dateTaken = !string.IsNullOrEmpty(row.Cells[indexer["dateTaken"]].Value?.ToString());
            bool mediaCreated = !string.IsNullOrEmpty(row.Cells[indexer["mediaCreated"]].Value?.ToString());

            bool isAsli = row.Cells[indexer["originalStatus"]].Value?.ToString() == "Ori";
            bool isCopied = statusCopy == Status.Copy.Success;

            if (chkBoxCopyImages.Checked && isImage && !isCopied)
            {
                if (rbtnImageAll.Checked) return true;
                if (rbtnImageOri.Checked) return dateTaken && isAsli;
                if (rbtnImageNonOri.Checked) return !dateTaken && !isAsli;
            }

            if (chkBoxCopyVideos.Checked && isVideo && !isCopied)
            {
                if (rbtnVideoAll.Checked) return true;
                if (rbtnVideoOri.Checked) return mediaCreated && isAsli;
                if (rbtnVideoNonOri.Checked) return !mediaCreated && !isAsli;
            }

            if (chkBoxCopyDocuments.Checked && isDocument && !isCopied)
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

        private string BuildFinalPath(string mainPath, DateTime date, string subPathFormat)
        {
            // Misalnya: subPathFormat = "/yyyy/yyyy_MM/yyyy_MM_dd"

            if (string.IsNullOrWhiteSpace(subPathFormat))
                return mainPath;

            // Format sesuai DateTime, hapus / di awal dan akhir agar aman saat split
            string formattedSubPath = date.ToString(subPathFormat.Trim('/'));

            // Pisahkan bagian folder berdasarkan separator /
            string[] subDirs = formattedSubPath.Split('/');

            // Gabungkan semuanya ke dalam path final
            return Path.Combine(new[] { mainPath }.Concat(subDirs).ToArray());
        }

        private bool isFileDuplicateSize(string firstFile, string secondFile)
        {
            if (File.Exists(secondFile))
            {
                long firstSize = new FileInfo(firstFile).Length;
                long secondSize = new FileInfo(secondFile).Length;
                string DateTakenFirst = FileProperty.GetProperty(firstFile, "Date taken");
                string DateTakenSecond = FileProperty.GetProperty(secondFile, "Date taken");
                string MediaCreatedFirst = FileProperty.GetProperty(firstFile, "Media created");
                string MediaCreatedSecond = FileProperty.GetProperty(secondFile, "Media created");

                bool isFirstFileEmpty = string.IsNullOrEmpty(firstFile) || firstSize == 0;
                bool isSecondFileEmpty = string.IsNullOrEmpty(secondFile) || secondSize == 0;

                // Jika salah satu file tidak ada atau kosong, tidak dianggap duplikat
                bool dateTaken = !string.IsNullOrEmpty(DateTakenFirst) == !string.IsNullOrEmpty(DateTakenSecond);
                bool mediaCreated = !string.IsNullOrEmpty(MediaCreatedFirst) == !string.IsNullOrEmpty(MediaCreatedSecond);
                bool sizeMatch = firstSize == secondSize;

                return dateTaken && mediaCreated && sizeMatch; // Jika kedua file memiliki Date Taken dan Media Created yang sama, serta ukuran file sama, anggap duplikat
            }
            return false;
        }

        private bool isFileDuplicateName(string firstFile, string secondFile)
        {
            if (File.Exists(secondFile))
            {
                return true; // Jika file dengan nama yang sama sudah ada, anggap duplikat
            }
            return false;
        }

        private bool CopyAndVerifyWithProgressOrMove(string sourceFile, string destFile, BackgroundWorker worker)
        {
            try
            {
                // Jika mode MOVE dan file tujuan belum ada, gunakan File.Move()
                if (currentState == Status.Process.Moving)
                {
                    if(!File.Exists(destFile))
                        File.Move(sourceFile, destFile);

                    if (moveAndDelete && File.Exists(destFile) && isFileDuplicateSize(sourceFile, destFile)) // Jika file sudah ada di tujuan dan ukurannya sama, hapus file sumber
                        File.Delete(sourceFile);
                    return true;
                }

                // Default: Copy with progress
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

                        destStream.Write(buffer, 0, bytesRead);
                        totalCopied += bytesRead;

                        int percent = (int)(totalCopied * 100 / totalBytes);
                        toolStripProgressBarPerFile.GetCurrentParent().Invoke((MethodInvoker)(() =>
                        {
                            toolStripProgressBarPerFile.Value = percent;
                        }));
                    }
                }

                return isFileDuplicateSize(sourceFile, destFile); // Kembalikan true jika file berhasil disalin dan ukurannya cocok
            }
            catch (IOException ioex)
            {
                // Optional: Log khusus IO error
                Console.WriteLine("IO error: " + ioex.Message);
                return false;
            }
            catch (Exception ex)
            {
                // Optional: Log general error
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
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
                    if (row.Cells[indexer["copyStatus"]].Value?.ToString() == Status.Copy.Copied
                    || row.Cells[indexer["copyStatus"]].Value?.ToString() == Status.Copy.Failed
                    || row.Cells[indexer["copyStatus"]].Value?.ToString() == Status.Copy.Error)
                    {
                        row.Cells[indexer["copyStatus"]].Value = Status.Copy.Error;
                    }
                }
            }));
        }

        #endregion COPY FILES


        private void chkBoxCopyImages_CheckedChanged(object sender, EventArgs e)
        {
            gBoxCopyImages.Enabled = chkBoxCopyImages.Checked;
            rbtnImageAll.Enabled = chkBoxCopyImages.Checked;
            rbtnImageOri.Enabled = chkBoxCopyImages.Checked;
            rbtnImageNonOri.Enabled = chkBoxCopyImages.Checked;
        }

        private void chkBoxCopyVideos_CheckedChanged(object sender, EventArgs e)
        {
            gBoxCopyVideos.Enabled = chkBoxCopyVideos.Checked;
            rbtnVideoAll.Enabled = chkBoxCopyVideos.Checked;
            rbtnVideoOri.Enabled = chkBoxCopyVideos.Checked;
            rbtnVideoNonOri.Enabled = chkBoxCopyVideos.Checked;
        }

        private void cbBoxCopySubFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mainPath = txtCopyPath.Text; // Misalnya textbox folder utama
            DateTime currentDateTime = DateTime.Now;     // Atau contoh tanggal dari metadata
            string format = cbBoxCopySubFolder.Text;

            string preview = BuildFinalPath(mainPath, currentDateTime, format);
            lblCopyPathFinalPreview.Text = preview;
        }

        private void txtCopyPath_TextChanged(object sender, EventArgs e)
        {
            cbBoxCopySubFolder_SelectedIndexChanged(sender, e);
        }

        private void dgvScan_SelectionChanged(object sender, EventArgs e)
        {
            if (currentState == Status.Process.Done)
                dgvScan.SelectionChanged += (s, e) => ShowPreview();
        }


        #region LOGGING
        private void addLog(string message = null)
        {
            // Tangkap nilai final message dulu (hindari perubahan di thread lain)
            if (string.IsNullOrWhiteSpace(message))
            {
                switch (currentState)
                {
                    case Status.Process.Initiating:
                    case Status.Process.Done:
                        message = $"Proses {currentAction.ToLower()} {(currentState == Status.Process.Initiating ? "dimulai" : "selesai")}.";
                        break;

                    case Status.Process.Scanning:
                        message = "Memindai file...";
                        break;

                    case Status.Process.Copying:
                        message = "Menyalin file...";
                        break;

                    case Status.Process.Moving:
                        message = "Memindahkan file...";
                        break;

                    case Status.Process.Stopping:
                        message = "Proses dihentikan oleh pengguna.";
                        break;

                    case Status.Process.Error:
                        message = "Terjadi kesalahan selama proses.";
                        break;

                    default:
                        message = $"Status proses saat ini: {currentState}";
                        break;
                }
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logMessage = $"[{timestamp}] {message}";

            // Pastikan hanya UI update di Invoke
            if (lstBoxLog.InvokeRequired)
            {
                lstBoxLog.Invoke(new MethodInvoker(() =>
                {
                    lstBoxLog.Items.Insert(0, logMessage);
                    rtBoxLog.Text = logMessage + Environment.NewLine + rtBoxLog.Text;

                    if (lstBoxLog.Items.Count > 500)
                        lstBoxLog.Items.RemoveAt(lstBoxLog.Items.Count - 1);
                }));
            }
            else
            {
                lstBoxLog.Items.Insert(0, logMessage);
                rtBoxLog.Text = logMessage + Environment.NewLine + rtBoxLog.Text;

                if (lstBoxLog.Items.Count > 500)
                    lstBoxLog.Items.RemoveAt(lstBoxLog.Items.Count - 1);
            }
        }

        #endregion LOGGING

        private void ShowPreview()
        {
            try
            {
                ImgPrev.Dispose();
                ImgPrev.Hide();
                if (dgvScan.CurrentCell == null || dgvScan.CurrentCell.RowIndex == dgvScan.NewRowIndex)
                    return;

                int rowIndex = dgvScan.CurrentCell.RowIndex;
                DataGridViewRow row = dgvScan.Rows[rowIndex];

                string filePath = Path.Combine(
                    row.Cells[indexer["path"]].Value?.ToString() ?? "",
                    row.Cells[indexer["name"]].Value?.ToString() ?? ""
                );

                if (!File.Exists(filePath)) return;

                if (filePath == _lastPreviewFilePath) return;
                _lastPreviewFilePath = filePath;

                string ext = Path.GetExtension(filePath).ToLower();
                bool isImage = extImages.Contains(ext);

                if (isImage)
                {
                    // Load preview form jika belum ada
                    //if (ImgPrev == null || ImgPrev.IsDisposed)
                    //{
                        ImgPrev = new ImagePreview();
                        ImgPrev.StartPosition = FormStartPosition.Manual;
                        //ImgPrev.Location = new Point(this.Right + 10, this.Top);
                    //}

                    // Hapus gambar lama
                    //ImgPrev.picBoxImagePreview.Image?.Dispose();
                    picBox.Image?.Dispose();

                    // Load gambar baru
                    //Image previewImg = LoadImageSafe(filePath);

                    //ImgPrev.picBoxImagePreview.Image = previewImg;
                    //ImgPrev.picBoxImagePreview.SizeMode = PictureBoxSizeMode.Zoom;

                    picBox.Image = LoadImageSafe(filePath); // Boleh dipisah untuk duplikat
                    picBox.SizeMode = PictureBoxSizeMode.Zoom;

                    //ImgPrev.Text = Path.GetFileName(filePath);
                    //ImgPrev.Show();
                }
                else
                {
                    // Jika bukan image
                    picBox.Image?.Dispose();
                    picBox.Image = null;

                    if (ImgPrev != null && !ImgPrev.IsDisposed)
                        ImgPrev.Hide();
                }
            }
            catch (Exception ex)
            {
                // Optional: Log
                // Console.WriteLine("ShowPreview Error: " + ex.Message);
            }
        }

        private Image LoadImageSafe(string path)
        {
            byte[] imageBytes = File.ReadAllBytes(path);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms); // Image tetap valid setelah ms dibuang
            }
        }
    }
}
