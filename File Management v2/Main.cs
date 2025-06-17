using File_Management_v2.Helper;
using MetadataExtractor;
using Microsoft.VisualBasic;
using Microsoft.WindowsAPICodePack.Shell.Interop;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using Image = System.Drawing.Image;
using Status = File_Management_v2.Helper.Status;


namespace File_Management_v2
{
    public partial class Main : Form
    {
        private List<string> globImageExts = new List<string> { };
        private List<string> globVideoExts = new List<string> { };
        private List<string> globDocExts = new List<string> { };
        private List<string> globAllExts = new List<string> { };
        private List<string> globExcludeKeys = new List<string> { };
        private List<string> globIncludeKeys = new List<string> { };

        private string currentAction; // Variabel untuk menyimpan jenis proses yang sedang dilakukan (Scan, Copy, Move)
        private string currentState; // Variabel untuk menyimpan status proses saat ini

        private Dictionary<string, int> _prefixDict = new Dictionary<string, int>(); // Untuk menyimpan prefix yang sudah ditemukan beserta jumlahnya
        private DataGridColumnIndexer indexer; // Untuk menyimpan indeks kolom berdasarkan nama kolom
        private int totalScannedDatas = 0; // Total data yang akan di-scan, bisa digunakan untuk progress bar
        private DateTime processStartTime; // Waktu mulai scan
        private DateTime processEndTime; // Waktu selesai scan

        private string _lastPreviewFilePath = "";

        private bool isDeleteAfterMove = false; // Untuk menentukan apakah akan menghapus file setelah dipindahkan
        private bool copyImages = false; // Untuk menentukan apakah akan menyalin gambar
        private bool copyVideo = false;
        private bool copyDocument = false; // Untuk menentukan apakah akan menyalin dokumen
        private bool isProcessImages = false;
        private Parameters.OriFilterOption imagesOriFilter = Parameters.OriFilterOption.All; // Untuk menentukan filter original pada gambar
        private Parameters.OriFilterOption videoOriFilter = Parameters.OriFilterOption.All; // Untuk menentukan filter original pada video
        private string baseTargetPath = "";
        private string subfolderFormat = ""; // Format subfolder untuk penyalinan file

        private int totalDataToCopy = 0; // Total data yang akan di-copy, bisa digunakan untuk progress bar

        public Main()
        {
            InitializeComponent();
            currentState = currentAction = Helper.Status.Action.None; // Inisialisasi status awal
            totalScannedDatas = totalDataToCopy = 0; // Inisialisasi total data yang akan di-scan/copy
            _prefixDict.Clear();

            indexer = new DataGridColumnIndexer(dgvScan); // Inisialisasi indeks kolom berdasarkan DataGridView
        }

        #region PARAMETER SCAN
        private void txtScanPath_TextChanged(object sender, EventArgs e)
        {
            // Aktifkan atau nonaktifkan kontrol berdasarkan apakah path scan valid
            bool isValidPath = !string.IsNullOrWhiteSpace(txtScanPath.Text) && System.IO.Directory.Exists(txtScanPath.Text);
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
            using (var folderBrowserScan = new FolderBrowserDialog())
            {
                folderBrowserScan.Description = "Pilih Folder untuk Scan";
                folderBrowserScan.SelectedPath = txtScanPath.Text; // opsional
                if (folderBrowserScan.ShowDialog() == DialogResult.OK)
                {
                    txtScanPath.Text = folderBrowserScan.SelectedPath;
                    btnScan.Enabled = true;
                }
            }
        }
        private void chkImage_CheckedChanged(object sender, EventArgs e)
        {
            // Aktifkan atau nonaktifkan kontrol terkait gambar berdasarkan checkbox
            txtExtImage.Enabled = chkImage.Checked;
            checkBoxCopyImages.Enabled = chkImage.Checked;
            radioProcessImageAll.Enabled = chkImage.Checked;
            radioProcessImageOri.Enabled = chkImage.Checked;
            radioProcessImageNonOri.Enabled = chkImage.Checked;
        }
        private void chkVideo_CheckedChanged(object sender, EventArgs e)
        {
            // Aktifkan atau nonaktifkan kontrol terkait video berdasarkan checkbox
            txtExtVideo.Enabled = chkVideo.Checked;
            checkBoxCopyVideos.Enabled = chkVideo.Checked;
            radioProcessVideoAll.Enabled = chkVideo.Checked;
            radioProcessVideoOri.Enabled = chkVideo.Checked;
            radioProcessVideoNonOri.Enabled = chkVideo.Checked;
        }
        private void chkDocument_CheckedChanged(object sender, EventArgs e)
        {
            // Aktifkan atau nonaktifkan kontrol terkait dokumen berdasarkan checkbox
            txtExtDocument.Enabled = chkDocument.Checked;
            checkBoxCopyDocs.Enabled = chkDocument.Checked;
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
            processStartTime = DateTime.Now;
            currentAction = Helper.Status.Action.Scan;
            currentState = Helper.Status.Process.Running;
            addLog(" ----------------------------------- ");
            addLog(); // akan log: "Proses SCAN dimulai."

            btnCancelScan.Enabled = true;

            if (string.IsNullOrWhiteSpace(txtScanPath.Text) || !System.IO.Directory.Exists(txtScanPath.Text))
            {
                MessageBox.Show("Folder sumber wajib diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Kumpulkan ekstensi berdasarkan checkbox
            globImageExts = chkImage.Checked ? txtExtImage.Text.Split(',').Select(e => e.Trim().ToUpper()).ToList() : new List<string>();
            globVideoExts = chkVideo.Checked ? txtExtVideo.Text.Split(',').Select(e => e.Trim().ToUpper()).ToList() : new List<string>();
            globDocExts = chkDocument.Checked ? txtExtDocument.Text.Split(',').Select(e => e.Trim().ToUpper()).ToList() : new List<string>();
            globAllExts = new List<string>(globImageExts.Concat(globVideoExts).Concat(globDocExts).Distinct()); // Gabungkan semua ekstensi yang dipilih

            // 2. Keyword Include dan Exclude
            globIncludeKeys = chkKeyIncl.Checked ? txtKeyIncl.Text.Split(',').Select(x => x.Trim().ToUpper()).ToList() : new List<string>();
            globExcludeKeys = chkKeyExcl.Checked ? txtKeyExcl.Text.Split(',').Select(x => x.Trim().ToUpper()).ToList() : new List<string>();

            // 3. Metadata Filter (All / Ori / Non-Ori)
            var oriFilter = Parameters.OriFilterOption.All;
            if (radioOri.Checked) oriFilter = Parameters.OriFilterOption.Ori;
            else if (radioNonOri.Checked) oriFilter = Parameters.OriFilterOption.NonOri;

            // 4. Buat parameter scan
            var param = new Parameters.Scan();
            param.SourcePath = txtScanPath.Text;
            param.OriFilter = oriFilter;

            progressBarGlobal.Value = 0;
            dgvScan.Rows.Clear();
            btnScan.Enabled = false;
            btnCancelScan.Enabled = true;

            bgWorkerScan.RunWorkerAsync(param);
        }
        private void bgWorkerScan_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var param = (Parameters.Scan)e.Argument;
                var files = System.IO.Directory.GetFiles(param.SourcePath, "*.*", SearchOption.AllDirectories);
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
                        currentState = Helper.Status.Process.Canceled;
                        addLog(); // akan log: "Proses dihentikan oleh pengguna."
                        currentAction = Helper.Status.Action.None; // Reset currentAction ke None setelah dibatalkan
                        return;
                    }

                    var curr_FilePath = files[i];
                    var fileInfo = new FileInfo(curr_FilePath);
                    var metadata = new MetadataHelper(curr_FilePath);
                    string curr_Ext = metadata.FileExtension.TrimStart('.').ToUpper();

                    string curr_FileName = metadata.FileName.ToUpper();
                    string curr_MimeType = metadata.MimeType.ToUpperInvariant();
                    
                    // metadata file image
                   string curr_DateTaken = metadata.DateTaken?.ToString("yyyy-MM-dd HH:mm:ss");
                    string curr_Iso = metadata.Iso?.ToString() ?? "";

                    // metadata file video
                    string curr_MediaCreated = metadata.MediaCreated?.ToString("yyyy-MM-dd HH:mm:ss");
                    string curr_VideoDuration = metadata.DurationSeconds?.ToString(@"hh\:mm\:ss"); // Format durasi video

                    // Metadata Check
                    bool curr_IsOri = !string.IsNullOrEmpty(curr_DateTaken) || !string.IsNullOrEmpty(curr_MediaCreated);

                    if (!(globAllExts.Contains(curr_Ext))) continue;
                    //if (globIncludeKeys.Any() && !globIncludeKeys.Any(k => fileName.Contains(k))) continue;
                    if (chkKeyIncl.Checked && !globIncludeKeys.Any(k => curr_FileName.Contains(k))) continue; // Periksa apakah ada keyword yang harus di-include
                    if (chkKeyExcl.Checked && globExcludeKeys.Any(k => curr_FileName.Contains(k))) continue; // Periksa apakah ada keyword yang harus di-exclude

                    if (param.OriFilter == Parameters.OriFilterOption.Ori && !curr_IsOri) continue;
                    if (param.OriFilter == Parameters.OriFilterOption.NonOri && curr_IsOri) continue;

                    string curr_FileStatus = FileScanner.GetFileStatus(curr_FilePath, globImageExts, globVideoExts, globDocExts);

                    //metadata.FileName = fileInfo.FullName;
                    DateTime? dateTaken = null;
                    if (!string.IsNullOrWhiteSpace(curr_DateTaken) && DateTime.TryParse(curr_DateTaken, out var dtTaken))
                    {
                        dateTaken = dtTaken;
                    }

                    DateTime? mediaCreated = null;
                    if (!string.IsNullOrWhiteSpace(curr_MediaCreated) && DateTime.TryParse(curr_MediaCreated, out var dtMedia))
                    {
                        mediaCreated = dtMedia;
                    }

                    var resultItem = new FileScanResult
                    {
                        FileName = curr_FileName,
                        FilePath = curr_FilePath,
                        FileDir = Path.GetDirectoryName(curr_FilePath) ?? "",
                        FileRelDir = Path.GetRelativePath(param.SourcePath, Path.GetDirectoryName(curr_FilePath) ?? "") + Path.DirectorySeparatorChar,
                        FileExt = metadata.FileExtension,
                        FileType = metadata.MimeType, // Image, Video, Document, Other
                        SizeBytes = metadata.FileSizeBytes?? 0,
                        DateCreated = metadata.DateCreated,
                        DateModified = metadata.DateModified,
                        DateTaken = dateTaken,
                        MediaCreated = mediaCreated,
                        IsOri = curr_IsOri,
                        FileStatus = curr_FileStatus,
                        TotalFiles = total,
                        Index = i + 1
                    };
                    bgWorkerScan.ReportProgress((int)((i + 1.0) / total * 100), resultItem);
                }

                e.Result = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in DoWork: " + ex.Message);
                e.Cancel = true;
                currentState = Helper.Status.Process.Failed;
                addLog($"[ERROR] {ex.Message}");
                return;
            }

        }
        private void bgWorkerScan_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarGlobal.Value = e.ProgressPercentage;

            if (e.UserState is not FileScanResult result || result == null)
                return;

            dgvScan.Rows.Add(
                false,
                dgvScan.Rows.Count + 1,                                      // no
                result.FileRelDir,                                             // path
                result.FileName,                                             // name
                result.FileType,       // type
                result.SizeBytes,                                            // size
                result.IsOri ? "ORI" : "NON-ORI",                            // originalStatus
                result.DateTaken?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",     // dateTaken
                result.MediaCreated?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",  // mediaCreated
                result.DateCreated?.ToString("yyyy-MM-dd HH:mm:ss")?? "",          // dateCreated
                result.FileStatus,                                           // fileStatus (nanti diisi proses selanjutnya)
                ""                                                           // copyStatus (nanti diisi proses copy)
            );

            // Set ToolTipText untuk beberapa kolom (misal kolom 2: FileRelDir, 3: FileName, 7: DateTaken)
            DataGridViewRow addedRow = dgvScan.Rows[dgvScan.Rows.Count - 1];
            var metadata = new MetadataHelper(result.FilePath);
            var indexer = new DataGridColumnIndexer(dgvScan);
            addedRow.Cells[indexer["dirPath"]].ToolTipText = result.FileDir;
            addedRow.Cells[indexer["name"]].ToolTipText = result.FilePath;
            addedRow.Cells[indexer["dateTaken"]].ToolTipText = "Tanggal diambil: " + (result.DateTaken?.ToString("f") ?? "Tidak tersedia");
            addedRow.Cells[indexer["mediaCreated"]].ToolTipText = "Media dibuat: " + (result.MediaCreated?.ToString("f") ?? "Tidak tersedia");
            addedRow.Cells[indexer["originalStatus"]].ToolTipText = $"Camera Make: {metadata.CameraMake}\nCamera Model:{metadata.CameraModel}";

            labelProgress.Text = $"Scanning: {result.FileDir} | Progress: {result.Index} of {result.TotalFiles} files.";
        }
        private void bgWorkerScan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnScan.Enabled = true;
            btnCancelScan.Enabled = false;
            progressBarGlobal.Value = 100;
            int scannedCount = dgvScan.Rows.Count;
            processEndTime = DateTime.Now; // Set waktu akhir scan

            if (e.UserState is not FileScanResult result || result == null)
                //return;


                if (e.Cancelled)
                {
                    MessageBox.Show($"Proses {currentAction} dibatalkan oleh pengguna.", "Dibatalkan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    currentState = Helper.Status.Process.Canceled;
                    return;
                }
                else if (e.Error != null)
                {
                    MessageBox.Show($"Kesalahan saat {currentAction}: " + e.Error.Message);
                    currentState = Helper.Status.Process.Failed;
                }
                else
                {
                    TimeSpan duration = processEndTime - processStartTime;

                    labelProgress.Text = $"Scan completed: {scannedCount} files found";
                    MessageBox.Show("Pemindaian selesai.\nTotal file ditampilkan: " + scannedCount, "Scan Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addLog($"Finished scanning {totalScannedDatas} files.");
                    addLog($"Matched {dgvScan.Rows.Count} files displayed.");
                    addLog($"Scanning duration: {duration.TotalSeconds:F2} seconds.");
                    currentState = Helper.Status.Process.Completed;
                }
            addLog(); // akan log sesuai status
            addLog(" ----------------------------------- ");
            currentAction = Helper.Status.Action.None; // Reset currentAction ke None setelah selesai
        }
        private void btnCancelScan_Click(object sender, EventArgs e)
        {
            if (bgWorkerScan.IsBusy)
            {
                bgWorkerScan.CancelAsync();
                btnCancelScan.Enabled = false;
                currentState = Helper.Status.Process.Stopping; // Set currentState ke Stopping

                addLog(); // akan log: "Proses dihentikan oleh pengguna."
                addLog(" ----------------------------------- ");
                currentAction = Helper.Status.Action.None; // Set currentAction ke Stop
            }
        }
        #endregion SCAN FILES


        #region COPY FILES

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            processStartTime = DateTime.Now;
            // Set currentAction dan currentState untuk proses Copy / Move
            currentAction = radioButtonProcessCopy.Checked ? Helper.Status.Action.Copy : Helper.Status.Action.Move;
            currentState = Helper.Status.Process.Running;
            addLog(" ----------------------------------- ");
            addLog(); // akan log: "Proses COPY dimulai."

            // Validasi form sebelum melanjutkan
            var param = new Parameters.Process();
            param.BaseTargetPath = txtCopyPath.Text.Trim();
            param.SubfolderFormat = comboBoxCopySubFolder.SelectedItem?.ToString() ?? "";
            //param.DeleteAfterMove = checkBoxMoveDeleteFile.Checked; // Ambil nilai dari checkbox
            param.DeleteAfterMove = checkBoxMoveDeleteFiles.Checked;
            param.ProcessImages = checkBoxCopyImages.Checked;
            param.ProcessVideos = checkBoxCopyVideos.Checked;
            param.ProcessDocs = checkBoxCopyDocs.Checked;


            var oriImageFilter = Parameters.OriFilterOption.All;
            if (radioProcessImageOri.Checked) oriImageFilter = Parameters.OriFilterOption.Ori;
            else if (radioProcessImageNonOri.Checked) oriImageFilter = Parameters.OriFilterOption.NonOri;
            param.OriImagesFilter = oriImageFilter;

            var oriVideoFilter = Parameters.OriFilterOption.All;
            if (radioProcessVideoOri.Checked) oriVideoFilter = Parameters.OriFilterOption.Ori;
            else if (radioProcessVideoNonOri.Checked) oriVideoFilter = Parameters.OriFilterOption.NonOri;
            param.OriVideosFilter = oriVideoFilter;

            bgWorkerCopy.RunWorkerAsync(param);
        }
        private void bgWorkerCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            var param = (Parameters.Process)e.Argument;

            int successCount = 0;
            int skipCount = 0;
            int failCount = 0;

            string baseTargetPath = param.BaseTargetPath;
            string subfolderFormat = param.SubfolderFormat;
            bool isMove = radioButtonProcessMove.Checked;
            bool deleteAfterMove = param.DeleteAfterMove;


            var indexer = new DataGridColumnIndexer(dgvScan);
            int total = dgvScan.Rows.Count;

            for (int i = 0; i < total; i++)
            {
                string stateLabel = isMove ? Helper.Status.Process.Moving : Helper.Status.Process.Copying;
                string stateResultLabel = isMove ? Helper.Status.Result.Moved : Helper.Status.Result.Copied;
                if (bgWorkerCopy.CancellationPending) break;

                var _currRow = dgvScan.Rows[i];

                bool _currChecked = _currRow.Cells[indexer["check"]].Value is bool value && value;

                string _currExt = Path.GetExtension(_currRow.Cells[indexer["name"]].Value.ToString()).TrimStart('.').ToUpper();

                // Ambil metadata
                string _currDirPath = _currRow.Cells[indexer["dirPath"]].Value.ToString();
                string _currFilename = _currRow.Cells[indexer["name"]].Value.ToString();
                string _currDateTaken = _currRow.Cells[indexer["dateTaken"]].Value?.ToString();
                string _currMediaCreated = _currRow.Cells[indexer["mediaCreated"]].Value?.ToString();
                string _currFileStatus = _currRow.Cells[indexer["fileStatus"]].Value.ToString();

                string _currOriStatus = _currRow.Cells[indexer["originalStatus"]].Value.ToString(); // jika masih digunakan

                // Cek original status berdasarkan metadata
                bool _currOriginalStatus = !string.IsNullOrEmpty(_currDateTaken) || !string.IsNullOrEmpty(_currMediaCreated);
                bool _currFileStatusOK = _currFileStatus.Equals(Helper.Status.Scan.Ok, StringComparison.OrdinalIgnoreCase);

                bool _currIsImage = globImageExts?.Contains(_currExt) == true;
                bool _currIsVideo = globVideoExts?.Contains(_currExt) == true;
                bool _currIsDoc = globDocExts?.Contains(_currExt) == true;

                // Fungsi bantu untuk filter ori
                bool MatchesOri(Parameters.OriFilterOption filter, bool oriFlag) =>
                    filter == Parameters.OriFilterOption.All ||
                    (filter == Parameters.OriFilterOption.Ori && oriFlag) ||
                    (filter == Parameters.OriFilterOption.NonOri && !oriFlag);

                // 🔎 Proses Filter
                bool _currShouldProcess = false;

                if (param.ProcessImages && _currIsImage)
                {
                    if (param.OriImagesFilter == Parameters.OriFilterOption.All)
                        _currShouldProcess = true; // Proses semua: Ori & Non-Ori
                    else
                        _currShouldProcess = MatchesOri(param.OriImagesFilter, _currOriginalStatus);
                }
                else if (param.ProcessVideos && globVideoExts.Contains(_currExt) == true)
                {
                    if (param.OriVideosFilter == Parameters.OriFilterOption.All)
                        _currShouldProcess = true; // Proses semua: Ori & Non-Ori
                    else
                        _currShouldProcess = MatchesOri(param.OriVideosFilter, _currOriginalStatus);
                }
                else if (param.ProcessDocs && globDocExts.Contains(_currExt) == true)
                {
                    _currShouldProcess = true; // Dokumen tidak punya filter ORI/Non-Ori
                }

                // 🔍 Filter include keyword
                if (_currShouldProcess && param.IncludeKeywords?.Count > 0 &&
                    !param.IncludeKeywords.Any(k => _currFilename.Contains(k.ToLower())))
                    _currShouldProcess = false;

                // 🔍 Filter exclude keyword
                if (_currShouldProcess && param.ExcludeKeywords?.Count > 0 &&
                    param.ExcludeKeywords.Any(k => _currFilename.Contains(k.ToLower())))
                    _currShouldProcess = false;

                // 🔍 Proses file OK saja
                if (_currShouldProcess && !_currFileStatusOK)
                    _currShouldProcess = false;

                // ❌ Jika tidak lolos filter
                if (!_currShouldProcess)
                {
                    _currRow.Cells[indexer["copyStatus"]].Value += $"{Helper.Status.Process.Skipped}";
                    continue;
                }

                // ⛔ Skip file bukan "OK"
                if (_currRow.Cells[indexer["fileStatus"]].Value.ToString() != Helper.Status.Scan.Ok)
                {
                    _currRow.Cells[indexer["copyStatus"]].Value += $"{Helper.Status.Result.Skipped}";
                    skipCount++;
                    continue;
                }

                DateTime myDate = GetTargetDate(_currRow);
                string destinationDir = BuildFinalPath(baseTargetPath, myDate, subfolderFormat);

                if (!System.IO.Directory.Exists(destinationDir)) System.IO.Directory.CreateDirectory(destinationDir);

                string _currSourceFilePath = Path.Combine(_currDirPath, _currFilename);

                string _currDestFilePath = Path.Combine(destinationDir, _currFilename);

                try
                {
                    if (!_currChecked)
                    {
                        _currRow.Cells[indexer["copyStatus"]].Value += $"{Helper.Status.Result.Skipped}";
                        skipCount++;
                        //continue;
                    }
                    else
                    if (isFileDuplicateSize(_currSourceFilePath, _currDestFilePath))
                    {
                        _currRow.Cells[indexer["copyStatus"]].Value += $"{Helper.Status.Result.Exist} ";
                        if (param.DeleteAfterMove)
                        {
                            File.Delete(_currSourceFilePath); // Hapus file sumber jika deleteAfterMove diaktifkan
                            _currRow.Cells[indexer["copyStatus"]].Value += $"{Helper.Status.Result.Deleted} ";
                            if (File.Exists(_currSourceFilePath))
                            {
                                _currRow.Cells[indexer["copyStatus"]].Value += Helper.Status.Process.Failed + " (Failed to delete source file)";
                                failCount++;
                                continue;
                            }
                            else
                            {
                                _currRow.Cells[indexer["copyStatus"]].Value += $"{stateResultLabel} ";
                                successCount++;
                            }
                        }
                        //continue;
                    }
                    else if (isFileDuplicateName(_currSourceFilePath, _currDestFilePath))
                    {
                        _currDestFilePath = GetUniqueFileName(destinationDir, Path.GetFileName(_currSourceFilePath));
                        _currRow.Cells[indexer["copyStatus"]].Value += $"{Helper.Status.Result.Renamed} ";
                        if (param.DeleteAfterMove)
                        {
                            File.Delete(_currSourceFilePath); // Hapus file sumber jika deleteAfterMove diaktifkan
                            _currRow.Cells[indexer["copyStatus"]].Value += $"{Helper.Status.Result.Deleted} ";
                            if (File.Exists(_currSourceFilePath))
                            {
                                _currRow.Cells[indexer["copyStatus"]].Value += Helper.Status.Process.Failed + " (Failed to delete source file)";
                                failCount++;
                                continue;
                            }
                            else
                            {
                                _currRow.Cells[indexer["copyStatus"]].Value += $"{stateResultLabel} ";
                                successCount++;
                            }
                        }
                    }
                    else
                    {
                        if (currentAction == Helper.Status.Action.Move)
                        {
                            File.Move(_currSourceFilePath, _currDestFilePath);
                            if (File.Exists(_currDestFilePath))
                            {
                                _currRow.Cells[indexer["copyStatus"]].Value += $"{Helper.Status.Result.Moved} ";
                                if (param.DeleteAfterMove)
                                {
                                    File.Delete(_currSourceFilePath); // Hapus file sumber jika deleteAfterMove diaktifkan
                                    if (File.Exists(_currSourceFilePath))
                                    {
                                        _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Result.Failed} (Failed to delete source file) ";
                                        failCount++;
                                        continue;
                                    }
                                    else
                                    {
                                        _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Result.Deleted} ";
                                        successCount++;
                                    }
                                }
                            }
                            _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Result.Success} ";
                        }
                        else
                        {
                            File.Copy(_currSourceFilePath, _currDestFilePath);
                            _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Result.Copied} ";
                            if (!File.Exists(_currDestFilePath))
                            {
                                _currRow.Cells[indexer["copyStatus"]].Value += $"{Helper.Status.Process.Failed} (Failed to copy file) ";
                                failCount++;
                                continue;
                            }
                            _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Result.Success} ";
                        }
                        successCount++;
                    }
                }
                catch (Exception ex)
                {
                    _currRow.Cells[indexer["copyStatus"]].Value += $"{Helper.Status.Process.Error}: {ex.Message}";
                    failCount++;
                }

                if (i % 100 == 0) addLog($"{stateLabel} file ke-{i}...");

                //addLog($"[{i + 1}/{total}] {_currRow.Cells[indexer["name"]].Value} => {_currRow.Cells[indexer["copyStatus"]].Value.ToString()}");

                // 🔄 Update UI progress
                int progress = (int)((i / (double)total) * 100);

                var resultItem = new
                {
                    Index = i + 1,
                    Total = total,
                    SuccessCount = successCount,
                    SkipCount = skipCount,
                    FailCount = failCount,
                    SourceFile = _currSourceFilePath,
                    DestFile = _currDestFilePath,
                };
                bgWorkerCopy.ReportProgress(progress, resultItem); // Laporan progress ke UI
                e.Result = resultItem; // Simpan hasil untuk digunakan di RunWorkerCompleted
            }
        }
        private void bgWorkerCopy_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarGlobal.Value = Math.Min(e.ProgressPercentage, 100);
            var data = e.UserState as dynamic;

            progressBarGlobal.Value = e.ProgressPercentage;

            labelProgress.Text = $"{currentState}: {data.SourceFile} to {data.DestFile} | Progress: {data.Index} of {data.Total} files.";
        }
        private void bgWorkerCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Pastikan untuk mengembalikan UI ke keadaan normal
            var result = e.Result;
            dynamic data = result;

            Cursor.Current = Cursors.Default;
            buttonProcess.Enabled = true;
            btnCopyStop.Enabled = false;
            progressBarGlobal.Value = 100;
            int scannedCount = dgvScan.Rows.Count;
            processEndTime = DateTime.Now; // Set waktu akhir scan

            progressBarPerFile.Visible = false;

            if (e.Cancelled)
            {
                currentState = Helper.Status.Process.Canceled;
                MessageBox.Show($"Process {currentAction} {currentState} by user.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (e.Error != null)
            {
                MessageBox.Show($"Kesalahan saat {currentAction}: " + e.Error.Message);
                currentState = Helper.Status.Process.Failed;
            }
            else
            {
                progressBarGlobal.Value = 100;
                progressBarPerFile.Value = 100;

                labelProgress.GetCurrentParent()?.Refresh();

                labelProgress.Text = $"{currentState}: {totalDataToCopy}/{totalDataToCopy} data completed.";
                currentState = Helper.Status.Process.Completed; // Set state ke Completed
            }

            TimeSpan duration = processEndTime - processStartTime;
            string stateLabel = currentAction == Status.Action.Move ? Helper.Status.Process.Moving : Helper.Status.Process.Copying;

            labelProgress.Text = $"{currentAction} completed." +
                $" Total: {data.Total}" +
                $", Success: {data.SuccessCount}" +
                $", Skip: {data.SkipCount}" +
                $", Fail: {data.FailCount}";

            // Tampilkan hasil akhir
            MessageBox.Show($"{currentAction} selesai:\nTotal: {data.Total}" +
                $"\nSuccess: {data.SuccessCount}" +
                $"\nSkip: {data.SkipCount}" +
                $"\nFail: {data.FailCount}",
                $"Hasil {currentAction}");

            addLog($"Finished {currentState} {data.Total} files.");
            addLog($"{stateLabel} {data.Total} duration: {duration.TotalSeconds:F2} seconds.");
            addLog($"Success: {data.SuccessCount}");
            addLog($"Skip: {data.SkipCount}");
            addLog($"Fail: {data.FailCount}");

            currentState = Helper.Status.Process.Completed;
            addLog(); // akan log sesuai status
            addLog(" ----------------------------------- ");
            currentAction = Helper.Status.Action.None; // Reset currentAction ke None setelah selesai
            //currentState = FileStatus.Process.None; // Reset currentState ke None setelah selesai
        }
        private void btnCopyStop_Click(object sender, EventArgs e)
        {
            if (bgWorkerScan.IsBusy)
            {
                bgWorkerCopy.CancelAsync();
                btnCopyStop.Enabled = false;
                currentState = Helper.Status.Process.Canceled; // Set currentState ke Stopping

                addLog(); // akan log: "Proses dihentikan oleh pengguna."
                addLog(" ----------------------------------- ");
                currentAction = Helper.Status.Action.None; // Set currentAction ke Stop
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
                newFileName = $"{fileNameWithoutExt}({counter}){ext}";
                counter++;
            }

            return Path.Combine(destFolder, newFileName);
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

        #endregion COPY FILES


        #region LOGGING
        private void addLog(string message = null)
        {
            // Tangkap nilai final message dulu (hindari perubahan di thread lain)
            if (string.IsNullOrWhiteSpace(message))
            {
                switch (currentState)
                {
                    case Helper.Status.Process.Running:
                    case Helper.Status.Process.Completed:
                        message = $"Proses {currentAction.ToUpper()} {(currentState == Helper.Status.Process.Running ? "dimulai" : "selesai")}.";
                        break;

                    case Helper.Status.Process.Scanning:
                        message = "Memindai file...";
                        break;

                    case Helper.Status.Process.Copying:
                        message = "Menyalin file...";
                        break;

                    case Helper.Status.Process.Moving:
                        message = "Memindahkan file...";
                        break;

                    case Helper.Status.Process.Canceled:
                        message = "Proses dihentikan oleh pengguna.";
                        break;

                    case Helper.Status.Process.Error:
                        message = "Terjadi kesalahan selama proses.";
                        break;

                    default:
                        message = $"Status proses saat ini: {currentState}";
                        break;
                }
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logMessage = $"[{timestamp}] {message}";

            // Simpan ke file log.txt
            try
            {
                string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Jika gagal simpan log ke file, tampilkan pesan error di UI log
                logMessage += $" (Gagal simpan log ke file: {ex.Message})";
            }

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

        #region PREVIEW IMAGE
        private Image LoadImageSafe(string path)
        {
            try
            {
                byte[] imageBytes = File.ReadAllBytes(path);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                // Log the error and return a placeholder image or null
                return null;
            }
        }
        private void dgvScan_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                rtBoxMetaFiles.Clear();
                if (currentAction != Helper.Status.Action.None) return;
                // Hapus gambar lama
                picBox.Image?.Dispose();
                if (dgvScan.CurrentCell == null || dgvScan.CurrentCell.RowIndex == dgvScan.NewRowIndex)
                    return;

                int rowIndex = dgvScan.CurrentCell.RowIndex;
                DataGridViewRow row = dgvScan.Rows[rowIndex];

                string filePath = Path.Combine(
                    row.Cells[indexer["dirPath"]].Value?.ToString() ?? "",
                    row.Cells[indexer["name"]].Value?.ToString() ?? ""
                );

                if (!File.Exists(filePath)) return;

                if (filePath == _lastPreviewFilePath) return;
                _lastPreviewFilePath = filePath;

                string ext = Path.GetExtension(filePath).TrimStart('.').ToUpper();
                bool isImage = globImageExts.Contains(ext);
                bool isVideo = globVideoExts.Contains(ext);

                if (isImage)
                {
                    picBox.Image = LoadImageSafe(filePath); // Boleh dipisah untuk duplikat
                    picBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else if (isVideo)
                {

                }
                else
                {
                    picBox.Image = null;
                }

                Debug.WriteLine("Start reading metadata...");
                var allMetadata = FileProperty.GetAllMetadata(filePath);
                var metadata = new MetadataHelper(filePath);
                if (isImage)
                {
                    string make = TryGetMetaByContains(allMetadata, "ExifIFD0.Make");
                    string model = TryGetMetaByContains(allMetadata, "ExifIFD0.Model");
                    //string dateTaken = TryGetMeta(allMetadata, "ExifSubIFD.DateTimeOriginal");
                    string dateTaken = TryGetMetaByContains(allMetadata, "Date/TimeOriginal");
                    //string dateTakenParsed = DateTime.Parse(dateTaken).ToString("yyyy-MM-dd HH:mm:ss");
                    string dateTakenParsed = dateTaken;
                    if (DateTime.TryParse(dateTakenParsed, out DateTime dt))
                    {
                        dateTakenParsed = dt.ToString("yyyy-MM-dd HH:mm:ss");
                    }


                    rtBoxMetaFiles.AppendText($"\n-- Camera Info --\nMake: {make}\nModel: {model}\nDate Taken: {dateTaken}\nDate Taken Parsed: {dateTakenParsed}\n");
                    rtBoxMetaFiles.AppendText($"\n-- Camera Info --\nCameraMake: {metadata.CameraMake}\nModel: {metadata.CameraModel}\nDate Taken: {metadata.DateTaken}\nDate Taken Parsed: {metadata.DateTaken?.ToString("yyyy-MM-dd HH:mm:ss")}\n");
                }
                else if (isVideo)
                {
                    string created = TryGetMetaByContains(allMetadata, "QuickTimeMovieHeader.Created")
                                  ?? TryGetMetaByContains(allMetadata, "Mp4.Created");
                    string duration = TryGetMetaByContains(allMetadata, "QuickTimeMovieHeader.Duration")
                                  ?? TryGetMetaByContains(allMetadata, "Mp4.Created");

                    rtBoxMetaFiles.AppendText($"\n-- Video Info --\nMedia Created: {created}\nDuration: {duration}\n");
                    rtBoxMetaFiles.AppendText($"\n-- Video Info --\nMedia Created: {metadata.MediaCreated?.ToString("yyyy-MM-dd HH:mm:ss")}\nDuration: {metadata.DurationSeconds}\n");
                }
                //string meta = $"";
                //foreach (var kv in allMetadata)
                //{
                //    string line = $"{kv.Key}: {kv.Value}";
                //    rtBoxMetaFiles.AppendText(line + Environment.NewLine); // Tambah ke bawah
                //        Debug.WriteLine(line);
                //}

                string meta = $"";
                foreach (var kv in allMetadata)
                {
                    string line = $"{kv.Key}: {kv.Value}";
                    rtBoxMetaFiles.AppendText(line + Environment.NewLine); // Tambah ke bawah
                    Debug.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private static string TryGetMeta(Dictionary<string, string> meta, string key)
        {
            return meta.ContainsKey(key) ? meta[key] : "";
        }
        private static string TryGetMetaByContains(Dictionary<string, string> meta, string keyword)
        {
            return meta.FirstOrDefault(kv => kv.Key.Contains(keyword, StringComparison.OrdinalIgnoreCase)).Value;
        }

        #endregion PREVIEW IMAGE


        #region PARAMETER COPY
        private void btnCopyBrowse_Click(object sender, EventArgs e)
        {
            using (var folderBrowserCopy = new FolderBrowserDialog())
            {
                folderBrowserCopy.Description = "Pilih Folder Tujuan Copy";
                folderBrowserCopy.SelectedPath = txtCopyPath.Text; // opsional
                if (folderBrowserCopy.ShowDialog() == DialogResult.OK)
                {
                    txtCopyPath.Text = folderBrowserCopy.SelectedPath;
                    buttonProcess.Enabled = true;
                }
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
                bool isValidPath = System.IO.Directory.Exists(txtCopyPath.Text);
                bool isValidSubFolder = !string.IsNullOrWhiteSpace(comboBoxCopySubFolder.Text);

                buttonProcess.Enabled = isValidPath && isValidSubFolder; // Aktifkan tombol jika path valid
                radioButtonProcessCopy.Enabled = isValidPath && isValidSubFolder; // Aktifkan tombol Copy jika path valid
                radioButtonProcessMove.Enabled = isValidPath && isValidSubFolder; // Aktifkan tombol Move jika path valid
                buttonProcess.Enabled = isValidPath && isValidSubFolder; // Aktifkan tombol jika path valid

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
                lblCopyPathFinalPreview.Text = $"{buttonProcess.Text} to {preview}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat membangun path: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkBoxCopyImages_CheckedChanged(object sender, EventArgs e)
        {
            // Aktifkan atau nonaktifkan tombol radio berdasarkan checkbox
            radioProcessImageAll.Enabled = checkBoxCopyImages.Checked;
            radioProcessImageOri.Enabled = checkBoxCopyImages.Checked;
            radioProcessImageNonOri.Enabled = checkBoxCopyImages.Checked;
        }
        private void checkBoxCopyVideos_CheckedChanged(object sender, EventArgs e)
        {
            // Aktifkan atau nonaktifkan tombol radio berdasarkan checkbox
            radioProcessVideoAll.Enabled = checkBoxCopyVideos.Checked;
            radioProcessVideoOri.Enabled = checkBoxCopyVideos.Checked;
            radioProcessVideoNonOri.Enabled = checkBoxCopyVideos.Checked;
        }
        private void radioButtonProcessCopy_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxMoveDeleteFiles.Enabled = !radioButtonProcessCopy.Checked;
            buttonProcess.Text = radioButtonProcessCopy.Checked ? "Copy" : "Move";
            activateBtnProcessData();
        }
        #endregion PARAMETER COPY

        private void dgvScan_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Pastikan kolom "check" yang diklik
            if (e.ColumnIndex == indexer["check"])
            {
                // Dapatkan status awal dari baris pertama (asumsi semua akan mengikuti)
                bool newCheckState = true;

                // Cek apakah semua sudah tercentang, jika iya, maka kita akan uncheck
                bool allChecked = dgvScan.Rows.Cast<DataGridViewRow>()
                    .All(row => row.Cells[indexer["check"]].Value is bool value && value);

                if (allChecked)
                {
                    newCheckState = false; // Jika semua sudah checked, maka toggle ke false
                }

                // Iterasi semua baris dan ubah nilai "check"
                foreach (DataGridViewRow row in dgvScan.Rows)
                {
                    if (row.Cells[indexer["check"]].Value != null)
                    {
                        row.Cells[indexer["check"]].Value = newCheckState; // Toggle berdasarkan kondisi awal
                    }
                }
            }
        }

        private void dgvScan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan klik terjadi di dalam batas indeks yang benar
            if (e.RowIndex >= 0 && e.RowIndex < dgvScan.Rows.Count && e.ColumnIndex == indexer["check"])
            {
                DataGridViewCell cell = dgvScan.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Toggle nilai antara true dan false
                if (cell.Value is bool currentValue)
                {
                    cell.Value = !currentValue; // Ubah nilai menjadi kebalikan dari sebelumnya
                }
                else
                {
                    cell.Value = true; // Jika awalnya kosong atau null, set ke true
                }
            }
        }
    }
}