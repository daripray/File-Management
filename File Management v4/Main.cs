using File_Management_v4.App.Services;
using File_Management_v4.Core.Models;
using File_Management_v4.Helper;
using File_Management_v4.Infrastructure.Metadata;
using MetadataExtractor;
using Microsoft.VisualBasic;
using Microsoft.WindowsAPICodePack.Shell.Interop;
using System;
using System.ComponentModel;
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
using Status = File_Management_v4.Helper.Status;
using File_Management_v4.Infrastructure.FileSystem;


namespace File_Management_v4
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

        private Format formatHelper = new Format(); // Instance dari kelas Format untuk format ukuran file dan tanggal
        private int checkedCount = 0; // Untuk menghitung jumlah file yang diproses berdasarkan checkbox


        private readonly ScanService _scanService;
        private readonly ProcessService _processService;
        public Main()
        {
            InitializeComponent();

            var scanner = new FileScanner();
            var metadata = new MetadataService();
            var decision = new DecisionService();
            var filesystem = new FileSystemService();

            _scanService = new ScanService(scanner, metadata, decision);
            _processService = new ProcessService(filesystem);

            currentState = currentAction = Status.Action.None; // Inisialisasi status awal
            totalScannedDatas = totalDataToCopy = 0; // Inisialisasi total data yang akan di-scan/copy
            _prefixDict.Clear();

            indexer = new DataGridColumnIndexer(dgvScan); // Inisialisasi indeks kolom berdasarkan DataGridView
                                                          // ✅ Tambahkan event load
            this.Load += Main_Load;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            ReadLog();
        }

        #region PARAMETER SCAN
        private void SetScanControlsEnabled(bool enabled)
        {
            chkImage.Enabled = enabled;
            chkVideo.Enabled = enabled;
            chkDocument.Enabled = enabled;
            chkKeyIncl.Enabled = enabled;
            chkKeyExcl.Enabled = enabled;
            radioAll.Enabled = enabled;
            radioOri.Enabled = enabled;
            radioNonOri.Enabled = enabled;
            btnScan.Enabled = enabled;
        }
        private void txtScanPath_TextChanged(object sender, EventArgs e)
        {
            // Aktifkan atau nonaktifkan kontrol berdasarkan apakah path scan valid
            bool isValidPath = !string.IsNullOrWhiteSpace(txtScanPath.Text) && System.IO.Directory.Exists(txtScanPath.Text);
            
            SetScanControlsEnabled(isValidPath);
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

        #region GET PARAMETER SCAN
        private List<string> GetSelectedExtensions()
        {
            var list = new List<string>();

            if (chkImage.Checked)
                list.AddRange(txtExtImage.Text.Split(','));

            if (chkVideo.Checked)
                list.AddRange(txtExtVideo.Text.Split(','));

            if (chkDocument.Checked)
                list.AddRange(txtExtDocument.Text.Split(','));

            return list.Select(x => x.Trim().ToUpper()).ToList();
        }
        private List<string> GetIncludeKeys()
        {
            if (chkKeyIncl.Checked)
                return txtKeyIncl.Text.Split(',').Select(x => x.Trim().ToUpper()).ToList();
            return new List<string>();
        }
        private List<string> GetExcludeKeys()
        {
            if (chkKeyExcl.Checked)
                return txtKeyExcl.Text.Split(',').Select(x => x.Trim().ToUpper()).ToList();
            return new List<string>();
        }

        #endregion GET PARAMETER SCAN
        
        #region SCAN FILES
        private void btnScan_Click(object sender, EventArgs e)
        {

            checkedCount = 0; // Reset jumlah file yang diproses
            processStartTime = DateTime.Now;
            currentAction = Status.Action.Scan;
            currentState = Status.Process.Running;
            WriteLog(" ----------------------------------- ");
            WriteLog(); // akan log: "Proses SCAN dimulai."


            buttonProcess.Enabled = false;
            btnCancelScan.Enabled = true;

            if (string.IsNullOrWhiteSpace(txtScanPath.Text) || !System.IO.Directory.Exists(txtScanPath.Text))
            {
                MessageBox.Show("Folder sumber wajib diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var scanOption = new ScanOptions
            {
                SourcePath = txtScanPath.Text,
                Extensions = GetSelectedExtensions(),
                IncludeKeywords = GetIncludeKeys(),
                ExcludeKeywords = GetExcludeKeys(),
                OnlyOriginals = radioOri.Checked
            };
            dgvScan.Rows.Clear();
            progressBarGlobal.Value = 0;
            processStartTime = DateTime.Now;
            currentAction = Status.Action.Scan;
            currentState = Status.Process.Running;


            //// 4. Buat parameter scan
            //var param = new Parameters.Scan();
            //param.SourcePath = txtScanPath.Text;
            //param.OriFilter = oriFilter;

            progressBarGlobal.Value = 0;
            //dgvScan.Rows.Clear();
            btnScan.Enabled = false;
            btnCancelScan.Enabled = true;

            bgWorkerScan.RunWorkerAsync(scanOption);
            //bgWorkerScan.RunWorkerAsync(param);
        }
        private void bgWorkerScan_DoWork(object sender, DoWorkEventArgs e)
        {
            #region Scanner v3 (refactor dengan service)

            var options = (ScanOptions)e.Argument;
            try
            {
                var result = _scanService.ScanWithProgress(options).ToList();
                int total = result.Count;

                for (int i = 0; i < total; i++)
                {
                    if (i % 100 == 0)
                    {
                        WriteLog($"Memproses file ke-{i}...");
                    }

                    if (bgWorkerScan.CancellationPending)
                    {
                        e.Cancel = true;
                        currentState = Status.Process.Canceled;
                        WriteLog(); // akan log: "Proses dihentikan oleh pengguna."
                        currentAction = Status.Action.None; // Reset currentAction ke None setelah dibatalkan
                        return;
                    }

                    var (file, index) = result[i];
                    int progress = (int)((i + 1.0) / total * 100);

                    var resultItem = new
                    {
                        File = file,
                        Index = index,
                        Total = total,
                    };
                    bgWorkerScan.ReportProgress(progress, resultItem);
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;

                currentState = Status.Process.Failed;
                WriteLog($"[ERROR] {ex.Message}");
                return;
            }
            #endregion Scanner v3 (refactor dengan service)

        }

        private void bgWorkerScan_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarGlobal.Value = e.ProgressPercentage;

            dynamic data = e.UserState;
            var file = data.File as FileItem;
            int index = data.Index;
            int total = data.Total;

            bool isOri = !string.IsNullOrEmpty(file.DateTaken.ToString()) || !string.IsNullOrEmpty(file.MediaCreated.ToString());

            dgvScan.Rows.Add(
                    false,
                    dgvScan.Rows.Count + 1,                                      // no
                    file.DirName,                                             // dirName
                    file.Name,                                             // name
                    file.MimeType,       // type
                    file.Size,                                            // size
                    isOri ? "ORI" : "NON-ORI",
                    file.DateTaken?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",     // dateTaken
                    file.MediaCreated?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",  // mediaCreated
                    file.DateModified?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",          // dateModified
                    Status.Scan.Ok,                                           // fileStatus (nanti diisi proses selanjutnya)
                    ""                                                           // copyStatus (nanti diisi proses copy)
                );

            // Set ToolTipText untuk beberapa kolom (misal kolom 2: FileRelDir, 3: FileName, 7: DateTaken)
            DataGridViewRow addedRow = dgvScan.Rows[dgvScan.Rows.Count - 1];
            addedRow.Cells[indexer["dirPath"]].ToolTipText = file.Path;
            addedRow.Cells[indexer["name"]].ToolTipText = file.Name;
            addedRow.Cells[indexer["dateTaken"]].ToolTipText = "Tanggal diambil: " + (file.DateTaken?.ToString("f") ?? "Tidak tersedia");
            addedRow.Cells[indexer["mediaCreated"]].ToolTipText = "Media dibuat: " + (file.MediaCreated?.ToString("f") ?? "Tidak tersedia");
            addedRow.Cells[indexer["originalStatus"]].ToolTipText = $"Camera Make: {file.CameraMake}\nCamera Model:{file.CameraModel}";

            labelProgress.Text = $"Scanning: {file.Path} | Progress: {index} of {total} files.";
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
                    currentState = Status.Process.Canceled;
                    return;
                }
                else if (e.Error != null)
                {
                    MessageBox.Show($"Kesalahan saat {currentAction}: " + e.Error.Message);
                    currentState = Status.Process.Failed;
                }
                else
                {
                    TimeSpan duration = processEndTime - processStartTime;

                    labelProgress.Text = $"Scan completed: {scannedCount} files found";
                    MessageBox.Show("Pemindaian selesai.\nTotal file ditampilkan: " + scannedCount, "Scan Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    WriteLog($"Finished scanning {totalScannedDatas} files.");
                    WriteLog($"Matched {dgvScan.Rows.Count} files displayed.");
                    WriteLog($"Scanning duration: {duration.TotalSeconds:F2} seconds.");
                    currentState = Status.Process.Completed;
                }
            WriteLog(); // akan log sesuai status
            WriteLog(" ----------------------------------- ");
            currentAction = Status.Action.None; // Reset currentAction ke None setelah selesai
        }
        private void btnCancelScan_Click(object sender, EventArgs e)
        {
            if (bgWorkerScan.IsBusy)
            {
                bgWorkerScan.CancelAsync();
                btnCancelScan.Enabled = false;
                currentState = Status.Process.Stopping; // Set currentState ke Stopping

                WriteLog(); // akan log: "Proses dihentikan oleh pengguna."
                WriteLog(" ----------------------------------- ");
                currentAction = Status.Action.None; // Set currentAction ke Stop
            }
        }
        #endregion SCAN FILES


        #region COPY FILES

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkedCount == 0)
                {
                    MessageBox.Show($"Tidak ada data yang dipilih!", "Error", MessageBoxButtons.OK);
                }
                else if (!checkBoxCopyImages.Checked && !checkBoxCopyVideos.Checked && !checkBoxCopyDocs.Checked)
                {
                    MessageBox.Show($"Files Extensions belum dipilih!", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    processStartTime = DateTime.Now;
                    // Set currentAction dan currentState untuk proses Copy / Move
                    currentAction = radioButtonProcessCopy.Checked ? Status.Action.Copy : Status.Action.Move;
                    currentState = Status.Process.Running;
                    WriteLog(" ----------------------------------- ");
                    WriteLog(); // akan log: "Proses COPY dimulai."

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat memulai proses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentState = Status.Process.Failed;
                WriteLog($"[ERROR] {ex.Message}");
                return;
            }
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
                string stateLabel = isMove ? Status.Process.Moving : Status.Process.Copying;
                string stateResultLabel = isMove ? Status.Result.Moved : Status.Result.Copied;
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
                bool _currFileStatusOK = _currFileStatus.Equals(Status.Scan.Ok, StringComparison.OrdinalIgnoreCase);

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
                    _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Process.Skipped}";
                    continue;
                }

                // ⛔ Skip file bukan "OK"
                if (_currRow.Cells[indexer["fileStatus"]].Value.ToString() != Status.Scan.Ok)
                {
                    _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Result.Skipped}";
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
                        _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Result.Skipped}";
                        skipCount++;
                        //continue;
                    }
                    else
                        if (isFileDuplicateSize(_currSourceFilePath, _currDestFilePath))
                        {
                            _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Result.Exist} ";
                            if (param.DeleteAfterMove)
                            {
                                File.Delete(_currSourceFilePath); // Hapus file sumber jika deleteAfterMove diaktifkan
                                _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Result.Deleted} ";
                                if (File.Exists(_currSourceFilePath))
                                {
                                    _currRow.Cells[indexer["copyStatus"]].Value += Status.Process.Failed + " (Failed to delete source file)";
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
                            _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Result.Renamed} ";
                            if (param.DeleteAfterMove)
                            {
                                File.Delete(_currSourceFilePath); // Hapus file sumber jika deleteAfterMove diaktifkan
                                _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Result.Deleted} ";
                                if (File.Exists(_currSourceFilePath))
                                {
                                    _currRow.Cells[indexer["copyStatus"]].Value += Status.Process.Failed + " (Failed to delete source file)";
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
                            if (currentAction == Status.Action.Move)
                            {
                                File.Move(_currSourceFilePath, _currDestFilePath);
                                if (File.Exists(_currDestFilePath))
                                {
                                    _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Result.Moved} ";
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
                                    _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Process.Failed} (Failed to copy file) ";
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
                    _currRow.Cells[indexer["copyStatus"]].Value += $"{Status.Process.Error}: {ex.Message}";
                    failCount++;
                }

                if (i % 100 == 0) WriteLog($"{stateLabel} file ke-{i}...");

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
                currentState = Status.Process.Canceled;
                MessageBox.Show($"Process {currentAction} {currentState} by user.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (e.Error != null)
            {
                MessageBox.Show($"Kesalahan saat {currentAction}: " + e.Error.Message);
                currentState = Status.Process.Failed;
            }
            else
            {
                progressBarGlobal.Value = 100;
                progressBarPerFile.Value = 100;

                labelProgress.GetCurrentParent()?.Refresh();

                labelProgress.Text = $"{currentState}: {totalDataToCopy}/{totalDataToCopy} data completed.";
                currentState = Status.Process.Completed; // Set state ke Completed
            }

            TimeSpan duration = processEndTime - processStartTime;
            string stateLabel = currentAction == Status.Action.Move ? Status.Process.Moving : Status.Process.Copying;

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

            WriteLog($"Finished {currentState} {data.Total} files.");
            WriteLog($"{stateLabel} {data.Total} duration: {duration.TotalSeconds:F2} seconds.");
            WriteLog($"Success: {data.SuccessCount}");
            WriteLog($"Skip: {data.SkipCount}");
            WriteLog($"Fail: {data.FailCount}");

            currentState = Status.Process.Completed;
            WriteLog(); // akan log sesuai status
            WriteLog(" ----------------------------------- ");
            currentAction = Status.Action.None; // Reset currentAction ke None setelah selesai
            //currentState = FileStatus.Process.None; // Reset currentState ke None setelah selesai
        }
        private void btnCopyStop_Click(object sender, EventArgs e)
        {
            if (bgWorkerScan.IsBusy)
            {
                bgWorkerCopy.CancelAsync();
                btnCopyStop.Enabled = false;
                currentState = Status.Process.Canceled; // Set currentState ke Stopping

                WriteLog(); // akan log: "Proses dihentikan oleh pengguna."
                WriteLog(" ----------------------------------- ");
                currentAction = Status.Action.None; // Set currentAction ke Stop
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
            if (string.IsNullOrWhiteSpace(subPathFormat))
                return mainPath;

            // 🔥 Convert custom format ke .NET format
            string netFormat = formatHelper.ConvertToDotNetDateFormat(subPathFormat);

            // Format tanggal
            string formattedSubPath = date.ToString(netFormat.Trim('/'));

            // Split folder
            string[] subDirs = formattedSubPath.Split('/');

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
        private void WriteLog(string message = null)
        {
            // Tangkap nilai final message dulu (hindari perubahan di thread lain)
            if (string.IsNullOrWhiteSpace(message))
            {
                switch (currentState)
                {
                    case Status.Process.Running:
                    case Status.Process.Completed:
                        message = $"Proses {currentAction.ToUpper()} {(currentState == Status.Process.Running ? "dimulai" : "selesai")}.";
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

                    case Status.Process.Canceled:
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

        private void ReadLog()
        {
            try
            {
                string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");

                // Jika file log belum ada, buat file kosong
                if (!File.Exists(logFilePath))
                {
                    File.Create(logFilePath).Dispose();
                    return;
                }

                // Baca seluruh isi file log
                var lines = File.ReadAllLines(logFilePath);

                // Batas agar tidak terlalu banyak
                var limitedLines = lines.Reverse().Take(500).Reverse().ToList();

                // Tampilkan ke ListBox dan RichTextBox
                lstBoxLog.Items.Clear();
                rtBoxLog.Clear();

                foreach (var line in limitedLines)
                {
                    lstBoxLog.Items.Add(line);
                    rtBoxLog.AppendText(line + Environment.NewLine);
                }

                // Auto-scroll ke bawah
                rtBoxLog.SelectionStart = rtBoxLog.Text.Length;
                rtBoxLog.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membaca file log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (currentAction != Status.Action.None) return;
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


                    //rtBoxMetaFiles.AppendText($"\n-- Camera Info --\nMake: {make}\nModel: {model}\nDate Taken: {dateTaken}\nDate Taken Parsed: {dateTakenParsed}\n");
                    rtBoxMetaFiles.AppendText(
                        $"\n-- Camera Info --" +
                        $"\nCameraMake: {metadata.CameraMake}" +
                        $"\nModel: {metadata.CameraModel}" +
                        $"\nDate Taken: {metadata.DateTaken}" +
                        $"\nDate Taken Parsed: {metadata.DateTaken?.ToString("yyyy-MM-dd HH:mm:ss")}\n"
                        );
                }
                else if (isVideo)
                {
                    string created = TryGetMetaByContains(allMetadata, "QuickTimeMovieHeader.Created")
                                  ?? TryGetMetaByContains(allMetadata, "Mp4.Created");
                    string duration = TryGetMetaByContains(allMetadata, "QuickTimeMovieHeader.Duration")
                                  ?? TryGetMetaByContains(allMetadata, "Mp4.Created");

                    //rtBoxMetaFiles.AppendText($"\n-- Video Info --\nMedia Created: {created}\nDuration: {duration}\n");
                    rtBoxMetaFiles.AppendText(
                        $"\n-- Video Info --" +
                        $"\nMedia Created: {metadata.MediaCreated?.ToString("yyyy-MM-dd HH:mm:ss")}" +
                        $"\nDuration: {metadata.DurationSeconds}\n");
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
                    //buttonProcess.Enabled = true;
                    activateBtnProcessData();
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
                // Reset count sebelum menghitung ulang
                checkedCount = 0;

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
                        
                        // Update count sesuai dengan newCheckState
                        if (newCheckState) checkedCount++;
                        else checkedCount = 0;
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
                
                // Update checkedCount berdasarkan nilai baru
                if (cell.Value is bool newValue)
                {
                    checkedCount += newValue ? 1 : -1; // Tambah jika true, kurang jika false
                }
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            { // Tab Process
                activateBtnProcessData();
            }
        }
    }
}