using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Simpler.Helper
{
    /// <summary>
    /// Kelas ini menyimpan dan mengakses indeks kolom DataGridView berdasarkan nama kolom.
    /// Jika kolom tidak ditemukan, akan mengembalikan indeks 0.
    /// 
    /// contoh penggunaan:
    /// private DataGridColumnIndexer index; // Untuk menyimpan indeks kolom berdasarkan nama kolom
    /// index = new DataGridColumnIndexer(dgvScan); // Inisialisasi indeks kolom berdasarkan DataGridView
    /// Console.WriteLine($"Index [\"no\"] = {indexer["no"]}"); // Mengakses indeks kolom "no"
    /// 
    /// </summary>
    internal class DataGridColumnIndexer
    {
        private Dictionary<string, int> columnIndices = new Dictionary<string, int>();

        // Konstruktor untuk inisialisasi indeks kolom dari DataGridView
        public DataGridColumnIndexer(DataGridView datagridView)
        {
            InitializeIndices(datagridView);
        }

        // Indexer untuk mengakses indeks kolom berdasarkan nama kolom
        public int this[string columnName] => columnIndices.ContainsKey(columnName) ? columnIndices[columnName] : 0;

        // Inisialisasi indeks kolom berdasarkan DataGridView
        private void InitializeIndices(DataGridView datagridView)
        {
            foreach (DataGridViewColumn column in datagridView.Columns)
            {
                columnIndices[column.Name] = column.Index;
            }
        }
    }
}
