namespace File_Management_v2.Helper
{
    internal class Parameters
    {
        public string SourcePath { get; set; }
        public List<string> ImageExts { get; set; }
        public List<string> VideoExts { get; set; }
        public List<string> DocExts { get; set; }
        public List<string> Extensions { get; set; }
        public List<string> IncludeKeywords { get; set; }
        public List<string> ExcludeKeywords { get; set; }
        public OriFilterOption OriFilter { get; set; }
        public string FileTypeFilter { get; set; } // All, Ori, NonOri
    }
    public enum OriFilterOption
    {
        All,
        OriOnly,
        NonOriOnly
    }
}