using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management.Interface
{
    internal interface IFileProperty
    {
        /// <summary>
        /// Mengambil properti file dari Windows Shell berdasarkan nama properti (misal: "Size", "Date taken", "Media created").
        /// </summary>
        /// <param name="filePath">Path lengkap ke file.</param>
        /// <param name="propertyName">Nama properti yang ingin diambil.</param>
        /// <returns>Nilai properti dalam bentuk string, atau null jika tidak ditemukan.</returns>
        string GetProperty(string filePath, string propertyName);
        long? GetFileSizeBytes(string filePath); // nilainya bisa null jika gagal
        string FormatSize(long bytes); // nilainya bisa null jika gagal
    }
}
