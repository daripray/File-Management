
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File_Management_v4.Core.Models;

namespace File_Management_v4.App.Services
{
    public class DecisionService
    {
        public bool ShouldProcess(FileItem file, ScanOptions opt)
        {
            if (!opt.Extensions.Contains(file.Extension.ToUpper()))
                return false;

            if (opt.IncludeKeywords.Any() && !opt.IncludeKeywords.Any(k => file.Name.Contains(k, StringComparison.OrdinalIgnoreCase)))
                return false;

            if(opt.ExcludeKeywords.Any() && opt.ExcludeKeywords.Any(k => file.Name.Contains(k, StringComparison.OrdinalIgnoreCase)))
                return false;

            if(opt.OnlyOriginals && !file.IsOriginal)
                return false;

            return true;
        }        
    }
}
