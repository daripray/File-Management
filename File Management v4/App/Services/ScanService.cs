using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File_Management_v4.Core.Models;
using File_Management_v4.Core.Interfaces;

namespace File_Management_v4.App.Services
{
    public class ScanService
    {
        private readonly IFileScanner _scanner;
        private readonly IMetadataServices _metadata;
        private readonly DecisionService _decision;

        public ScanService(IFileScanner scanner, IMetadataServices metadata, DecisionService decision)
        {
            _scanner = scanner;
            _metadata = metadata;
            _decision = decision;
        }

        public IEnumerable<FileItem> Scan(ScanOptions scanOptions)
        {
            var files = _scanner.GetFiles(scanOptions.SourcePath);

            foreach (var path in files)
            {
                var item = _metadata.Extract(path);

                if (_decision.ShouldProcess(item, scanOptions))
                    yield return item;
            }
        }

        public IEnumerable<(FileItem item, int index)> ScanWithProgress(ScanOptions scanOptions)
        {
            var files = _scanner.GetFiles(scanOptions.SourcePath).ToList();
            int total = files.Count;
            for (int i = 0; i < total; i++)
            {
                var path = files[i];
                var item = _metadata.Extract(path);

                if (_decision.ShouldProcess(item, scanOptions))
                    yield return (item, i + 1);
            }
        }
    }
}
