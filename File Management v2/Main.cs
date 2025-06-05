using File_Management_v2.Helper;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace File_Management_v2
{
    public partial class Main : Form
    {
        private List<string> imageExts = new List<string> { };
        private List<string> videoExts = new List<string> { };
        private List<string> docExts = new List<string> { };
        private List<string> allExt = new List<string> { };
        private List<string> excludeKeys = new List<string> { };
        private List<string> includeKeys = new List<string> { };

        private string currentAction; // Variabel untuk menyimpan jenis proses yang sedang dilakukan (Scan, Copy, Move)
        private string currentState; // Variabel untuk menyimpan status proses saat ini

        private Dictionary<string, int> _prefixDict = new Dictionary<string, int>(); // Untuk menyimpan prefix yang sudah ditemukan beserta jumlahnya
        private DataGridColumnIndexer indexer; // Untuk menyimpan indeks kolom berdasarkan nama kolom
        private int totalScannedDatas = 0; // Total data yang akan di-scan, bisa digunakan untuk progress bar
        private DateTime scanStartTime; // Waktu mulai scan
        private DateTime scanEndTime; // Waktu selesai scan

        private string _lastPreviewFilePath = "";

        private int totalDataToCopy = 0; // Total data yang akan di-copy, bisa digunakan untuk progress bar
        private bool moveAndDelete = false; // Untuk menentukan apakah akan memindahkan file dan menghapus yang lama

        public Main()
        {
            InitializeComponent();
            currentAction = Status.Action.None; // Inisialisasi currentAction
            currentState = Status.Process.None; // Inisialisasi currentState
            totalScannedDatas = 0;
            totalDataToCopy = 0;
            _prefixDict.Clear();

            indexer = new DataGridColumnIndexer(dgvScan); // Inisialisasi indeks kolom berdasarkan DataGridView
        }

        #region PARAMETER SCAN
        private void txtScanPath_TextChanged(object sender, EventArgs e)
        {
            // Aktifkan atau nonaktifkan kontrol berdasarkan apakah path scan valid
            bool isValidPath = !string.IsNullOrWhiteSpace(txtScanPath.Text) && Directory.Exists(txtScanPath.Text);
            chkImage.Enabled = isValidPath;
            chkVideo.Enabled = isValidPath;
            chkDocument.Enabled = isValidPath;
            chkKeyIncl.Enabled = isValidPath;
            chkKeyExcl.Enabled = isValidPath;
            radioAll.Enabled = isValidPath;
            radioOri.Enabled = isValidPath;
            radioNonOri.Enabled = isValidPath;
            btnScan.Enabled = isValidPath;
        }
        private void btnScanBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserScan.ShowDialog() == DialogResult.OK)
            {
                txtScanPath.Text = folderBrowserScan.SelectedPath;
            }
        }
        private void chkImage_CheckedChanged(object sender, EventArgs e)
        {
            // Aktifkan atau nonaktifkan kontrol terkait gambar berdasarkan checkbox
            txtExtImage.Enabled = chkImage.Checked;
            chkBoxCopyImages.Enabled = chkImage.Checked;
            rbtnImageAll.Enabled = chkImage.Checked;
            rbtnImageOri.Enabled = chkImage.Checked;
            rbtnImageNonOri.Enabled = chkImage.Checked;
        }
        private void chkVideo_CheckedChanged(object sender, EventArgs e)
        {
            // Aktifkan atau nonaktifkan kontrol terkait video berdasarkan checkbox
            txtExtVideo.Enabled = chkVideo.Checked;
            chkBoxCopyVideos.Enabled = chkVideo.Checked;
            rbtnVideoAll.Enabled = chkVideo.Checked;
            rbtnVideoOri.Enabled = chkVideo.Checked;
            rbtnVideoNonOri.Enabled = chkVideo.Checked;
        }
        private void chkDocument_CheckedChanged(object sender, EventArgs e)
        {
            // Aktifkan atau nonaktifkan kontrol terkait dokumen berdasarkan checkbox
            txtExtDocument.Enabled = chkDocument.Checked;
            chkBoxCopyDocuments.Enabled = chkDocument.Checked;
        }
        private void chkKeyIncl_CheckedChanged(object sender, EventArgs e)
        {
            txtKeyIncl.Enabled = chkKeyIncl.Checked;
        }
        private void chkKeyExcl_CheckedChanged(object sender, EventArgs e)
        {
            txtKeyExcl.Enabled = chkKeyExcl.Checked;
        }
        #endregion PARAMETER SCAN


        #region SCAN FILES
        private void btnScan_Click(object sender, EventArgs e)
        {
            scanStartTime = DateTime.Now;
            currentAction = Status.Action.Scan;
            currentState = Status.Process.Initiating;
            addLog(" ----------------------------------- ");
            addLog(); // akan log: "Proses SCAN dimulai."

            btnCancelScan.Enabled = true;

            if (string.IsNullOrWhiteSpace(txtScanPath.Text) || !Directory.Exists(txtScanPath.Text))
            {
                MessageBox.Show("Folder sumber wajib diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Kumpulkan ekstensi berdasarkan checkbox
            imageExts = chkImage.Checked ? txtExtImage.Text.Split(',').Select(e => e.Trim().ToUpper()).ToList() : new List<string>();
            videoExts = chkVideo.Checked ? txtExtVideo.Text.Split(',').Select(e => e.Trim().ToUpper()).ToList() : new List<string>();
            docExts = chkDocument.Checked ? txtExtDocument.Text.Split(',').Select(e => e.Trim().ToUpper()).ToList() : new List<string>();

            // 2. Keyword Include dan Exclude
            includeKeys = chkKeyIncl.Checked ? txtKeyIncl.Text.Split(',').Select(x => x.Trim().ToUpper()).ToList() : new List<string>();
            excludeKeys = chkKeyExcl.Checked ? txtKeyExcl.Text.Split(',').Select(x => x.Trim().ToUpper()).ToList() : new List<string>();

            // 3. Metadata Filter (All / Ori / Non-Ori)
            var oriFilter = OriFilterOption.All;
            if (radioOri.Checked) oriFilter = OriFilterOption.OriOnly;
            else if (radioNonOri.Checked) oriFilter = OriFilterOption.NonOriOnly;

            // 4. Buat parameter scan
            var param = new Parameters
            {
                SourcePath = txtScanPath.Text,
                //ImageExts = imageExts,
                //VideoExts = videoExts,
                //DocExts = docExts,
                //IncludeKeywords = incl,
                //ExcludeKeywords = excl,
                OriFilter = oriFilter
            };

            progressBarScan.Value = 0;
            dgvScan.Rows.Clear();
            btnScan.Enabled = false;
            btnCancelScan.Enabled = true;

            bgWorkerScan.RunWorkerAsync(param);
        }
        private void bgWorkerScan_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                currentState = Status.Process.Scanning;
                addLog(); // akan log: "Memindai file..."

                var param = (Parameters)e.Argument;
                var files = Directory.GetFiles(param.SourcePath, "*.*", SearchOption.AllDirectories);
                var result = new List<FileInfo>();

                int total = files.Length;
                totalScannedDatas = total; // Simpan total data yang akan di-scan
                for (int i = 0; i < total; i++)
                {
                    if (i % 100 == 0)
                    {
                        addLog($"Memproses file ke-{i}...");
                    }

                    if (bgWorkerScan.CancellationPending)
                    {
                        e.Cancel = true;
                        currentState = Status.Process.Stopping;
                        addLog(); // akan log: "Proses dihentikan oleh pengguna."
                        return;
                    }

                    var filePath = files[i];
                    var fileInfo = new FileInfo(filePath);
                    string ext = fileInfo.Extension.TrimStart('.').ToUpper();

                    if (!(imageExts.Contains(ext) || videoExts.Contains(ext) || docExts.Contains(ext))) continue;

                    string nameLower = fileInfo.Name.ToUpper();

                    if (includeKeys.Any() && !includeKeys.Any(k => nameLower.Contains(k))) continue;
                    if (excludeKeys.Any(k => nameLower.Contains(k))) continue;

                    // Metadata Check
                    var props = FileProperty.GetFileMetadata(filePath);
                    bool isOri = props.DateTaken != null || props.MediaCreated != null;

                    if (param.OriFilter == OriFilterOption.OriOnly && !isOri) continue;
                    if (param.OriFilter == OriFilterOption.NonOriOnly && isOri) continue;

                    string fileStatus = FileScanner.GetFileStatus(filePath, imageExts, videoExts, docExts);

                    //var resultItem = new FileScanResult
                    //{
                    //    FileName = Path.GetFileName(filePath),
                    //    FilePath = filePath,
                    //    Directory = Path.GetDirectoryName(filePath) ?? "",
                    //    SizeBytes = fileInfo.Length,
                    //    DateCreated = fileInfo.CreationTime,
                    //    DateModified = fileInfo.LastWriteTime,
                    //    DateTaken = props.DateTaken,
                    //    MediaCreated = props.MediaCreated,
                    //    FileStatus = fileStatus,
                    //    TotalFiles = total,
                    //    Index = i + 1,
                    //};

                    var resultItem = new FileScanResult();

                    resultItem.FileName = Path.GetFileName(filePath);
                    resultItem.FilePath = filePath;
                    resultItem.Directory = Path.GetDirectoryName(filePath) ?? "";
                    resultItem.SizeBytes = fileInfo.Length;
                    resultItem.DateCreated = fileInfo.CreationTime;
                    resultItem.DateModified = fileInfo.LastWriteTime;
                    resultItem.DateTaken = props.DateTaken;
                    resultItem.MediaCreated = props.MediaCreated;
                    resultItem.IsOri = isOri;
                    resultItem.FileStatus = fileStatus;
                    resultItem.TotalFiles = total;
                    resultItem.Index = i + 1;

                    bgWorkerScan.ReportProgress((int)((i + 1.0) / total * 100), resultItem);
                }

                e.Result = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in DoWork: " + ex.Message);
                e.Cancel = true;
                currentState = Status.Process.Error;
                addLog($"[ERROR] {ex.Message}");
                return;
            }

        }
        private void bgWorkerScan_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarScan.Value = e.ProgressPercentage;

            if (e.UserState is not FileScanResult result || result == null)
                return;

            dgvScan.Rows.Add(
                dgvScan.Rows.Count + 1,                                      // no
                result.Directory,                                             // path
                result.FileName,                                             // name
                Path.GetExtension(result.FileName).ToUpperInvariant(),       // type
                result.SizeBytes,                                            // size
                result.IsOri ? "ORI" : "NON-ORI",                            // originalStatus
                result.DateTaken?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",     // dateTaken
                result.MediaCreated?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",  // mediaCreated
                result.DateCreated.ToString("yyyy-MM-dd HH:mm:ss"),          // dateCreated
                result.FileStatus,                                           // fileStatus (nanti diisi proses selanjutnya)
                ""                                                           // copyStatus (nanti diisi proses copy)
            );
            toolStripLabelProgress.Text = $"Scanning: {result.Directory} | Progress: {result.Index} of {result.TotalFiles} files.";
        }
        private void bgWorkerScan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnScan.Enabled = true;
            btnCancelScan.Enabled = false;
            progressBarScan.Value = 100;
            int scannedCount = dgvScan.Rows.Count;
            scanEndTime = DateTime.Now; // Set waktu akhir scan

            if (e.UserState is not FileScanResult result || result == null)
                //return;

                if (e.Cancelled)
                {
                    MessageBox.Show("Scan dibatalkan oleh pengguna.", "Dibatalkan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    currentState = Status.Process.Stopping;
                    return;
                }

            if (e.Error != null)
            {
                MessageBox.Show("Kesalahan saat scan: " + e.Error.Message);
                currentState = Status.Process.Error;
            }
            else
            {
                TimeSpan duration = scanEndTime - scanStartTime;

                toolStripLabelProgress.Text = $"Scan completed: {scannedCount} files found";
                MessageBox.Show("Pemindaian selesai.\nTotal file ditampilkan: " + scannedCount, "Scan Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);

                addLog($"Finished scanning {totalScannedDatas} files.");
                addLog($"Matched {dgvScan.Rows.Count} files displayed.");
                addLog($"Scanning duration: {duration.TotalSeconds:F2} seconds.");
                currentState = Status.Process.Done;
            }
            addLog(); // akan log sesuai status
            addLog(" ----------------------------------- ");
            currentAction.Normalize(); // Reset currentAction ke None setelah selesai
            currentState.Normalize(); // Reset currentState ke None setelah selesai
        }
        private void btnCancelScan_Click(object sender, EventArgs e)
        {
            if (bgWorkerScan.IsBusy)
            {
                bgWorkerScan.CancelAsync();
                btnCancelScan.Enabled = false;
            }
        }
        #endregion SCAN FILES


        #region COPY FILES

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
            moveAndDelete = checkBoxMoveDeleteFile.Checked; // Ambil nilai dari checkbox
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
            else if (string.IsNullOrEmpty(comboBoxCopySubFolder.Text))
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
                    progressBarScan.Value = 0;
                    progressBarScan.Maximum = 100;
                    toolStripProgressBarPerFile.Value = 0;
                    toolStripProgressBarPerFile.Maximum = 100;
                    toolStripLabelProgress.Text = $"Memulai {currentAction.ToString()}...";

                    allExt = new List<string> { };

                    ResetCopiedStatus(); // Reset status "Copied" sebelum mulai copy ulang

                    Cursor.Current = Cursors.WaitCursor;

                    // Kirim dua nilai sebagai tuple
                    var args = Tuple.Create(txtCopyPath.Text, comboBoxCopySubFolder.Text);
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
            progressBarScan.Value = Math.Min(e.ProgressPercentage, 100);
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
                progressBarScan.Value = 100;
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
            comboBoxCopySubFolder.Invoke((MethodInvoker)(() =>
            {
                copySubFolderFormat = comboBoxCopySubFolder.Text;
            }));

            totalDataToCopy = dgvScan.InvokeRequired ? (int)dgvScan.Invoke(() => dgvScan.RowCount) : dgvScan.RowCount;
            if (totalDataToCopy == 0)
            {
                dgvScan.Invoke((MethodInvoker)(() =>
                {
                    toolStripLabelProgress.Text = $"Tidak ada file yang akan di-{currentAction.ToUpper()}.";
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
            string ext = Path.GetExtension(row.Cells[indexer["name"]].Value?.ToString() ?? "").ToUpper();
            string type = row.Cells[indexer["type"]].Value?.ToString().ToUpper(); // Type
            string status = row.Cells[indexer["fileStatus"]].Value?.ToString();
            string statusCopy = row.Cells[indexer["copyStatus"]].Value?.ToString();

            if (status != Status.Scan.Display && statusCopy == Status.Copy.Failed) return false;

            bool isImage = imageExts != null && imageExts.Contains(ext);
            bool isVideo = videoExts != null && videoExts.Contains(ext);
            bool isDocument = docExts != null && docExts.Contains(ext);

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
                    if (!File.Exists(destFile))
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
                        message = $"Proses {currentAction.ToUpper()} {(currentState == Status.Process.Initiating ? "dimulai" : "selesai")}.";
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
                    //lstBoxLog.Items.Insert(0, logMessage); // Tambah ke atas
                    lstBoxLog.Items.Add(logMessage); // Tambah ke bawah
                    rtBoxLog.AppendText(logMessage + Environment.NewLine); // Tambah ke bawah

                    if (lstBoxLog.Items.Count > 500)
                        lstBoxLog.Items.RemoveAt(lstBoxLog.Items.Count - 1);
                }));
            }
            else
            {
                //lstBoxLog.Items.Insert(0, logMessage); // Tambah ke atas
                lstBoxLog.Items.Add(logMessage); // Tambah ke bawah
                rtBoxLog.AppendText(logMessage + Environment.NewLine); // Tambah ke bawah

                if (lstBoxLog.Items.Count > 500)
                    lstBoxLog.Items.RemoveAt(lstBoxLog.Items.Count - 1);
            }
        }

        #endregion LOGGING

        private Image LoadImageSafe(string path)
        {
            byte[] imageBytes = File.ReadAllBytes(path);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms); // Image tetap valid setelah ms dibuang
            }
        }

        private void dgvScan_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (currentAction != Status.Action.None) return;
                // Hapus gambar lama
                picBox.Image?.Dispose();
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

                string ext = Path.GetExtension(filePath).ToUpper();
                bool isImage = imageExts.Contains(ext);

                if (isImage)
                {
                    picBox.Image = LoadImageSafe(filePath); // Boleh dipisah untuk duplikat
                    picBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    picBox.Image = null;
                }
            }
            catch (Exception ex)
            {
            }
        }



        #region PARAMETER COPY
        private void btnCopyBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserCopy.ShowDialog() == DialogResult.OK)
            {
                txtCopyPath.Text = folderBrowserCopy.SelectedPath;
                btnProcess.Enabled = true;
            }
        }
        private void txtCopyPath_TextChanged(object sender, EventArgs e)
        {
            activateBtnProcessData();
        }
        private void comboBoxCopySubFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            activateBtnProcessData();
        }
        private void activateBtnProcessData()
        {
            try
            {
                bool isValidPath = Directory.Exists(txtCopyPath.Text);
                bool isValidSubFolder = !string.IsNullOrWhiteSpace(comboBoxCopySubFolder.Text);

                btnProcess.Enabled = isValidPath && isValidSubFolder; // Aktifkan tombol jika path valid
                radioButtonProcessCopy.Enabled = isValidPath && isValidSubFolder; // Aktifkan tombol Copy jika path valid
                radioButtonProcessMove.Enabled = isValidPath && isValidSubFolder; // Aktifkan tombol Move jika path valid
                btnProcess.Enabled = isValidPath && isValidSubFolder; // Aktifkan tombol jika path valid

                checkBoxMoveDeleteFiles.Enabled = radioButtonProcessMove.Checked; // Aktifkan checkbox Move Delete Files jika tombol Move dipilih

                if (!isValidPath || !isValidSubFolder)
                {
                    lblCopyPathFinalPreview.Text = "⚠️ Path tidak valid atau struktur folder belum dipilih.";
                    return;
                }

                string mainPath = txtCopyPath.Text; // Misalnya textbox folder utama
                DateTime currentDateTime = DateTime.Now;     // Atau contoh tanggal dari metadata
                string format = comboBoxCopySubFolder.Text;

                string preview = BuildFinalPath(mainPath, currentDateTime, format);
                lblCopyPathFinalPreview.Text = $"{btnProcess.Text} to {preview}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat membangun path: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkBoxCopyImages_CheckedChanged(object sender, EventArgs e)
        {
            // Aktifkan atau nonaktifkan tombol radio berdasarkan checkbox
            rbtnImageAll.Enabled = chkBoxCopyImages.Checked;
            rbtnImageOri.Enabled = chkBoxCopyImages.Checked;
            rbtnImageNonOri.Enabled = chkBoxCopyImages.Checked;
        }
        private void chkBoxCopyVideos_CheckedChanged(object sender, EventArgs e)
        {
            // Aktifkan atau nonaktifkan tombol radio berdasarkan checkbox
            rbtnVideoAll.Enabled = chkBoxCopyVideos.Checked;
            rbtnVideoOri.Enabled = chkBoxCopyVideos.Checked;
            rbtnVideoNonOri.Enabled = chkBoxCopyVideos.Checked;
        }
        private void radioButtonProcessCopy_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxMoveDeleteFiles.Enabled = !radioButtonProcessCopy.Checked;
            btnProcess.Text = radioButtonProcessCopy.Checked ? "Copy" : "Move";
            activateBtnProcessData();
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {

        }

        #endregion PARAMETER COPY
    }
}