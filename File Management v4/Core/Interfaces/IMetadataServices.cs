using File_Management_v4.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management_v4.Core.Interfaces
{
    public interface IMetadataServices
    {
        FileItem Extract(string filePath);
    }
}
