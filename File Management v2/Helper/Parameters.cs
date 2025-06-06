namespace File_Management_v2.Helper
{
    internal class Parameters
    {
        internal class Scan
        {
            public string SourcePath { get; set; }
            public List<string> ImageExts { get; set; }
            public List<string> VideoExts { get; set; }
            public List<string> DocExts { get; set; }
            public List<string> Extensions { get; set; }
            public List<string> IncludeKeywords { get; set; }
            public List<string> ExcludeKeywords { get; set; }
            public OriFilterOption OriFilter { get; set; }
        }
        internal class Process
        {
            public string BaseTargetPath { get; set; }
            public string SubfolderFormat { get; set; }
            public Boolean DeleteAfterMove { get; set; }
            public Boolean ProcessImages { get; set; }
            public Boolean ProcessVideos { get; set; }
            public Boolean ProcessDocs { get; set; }
            public Boolean ProcessOtherFiles { get; set; }
            public Boolean ProcessOriFiles { get; set; }
            public Boolean ProcessNonOriFiles { get; set; }
            public Boolean ProcessOkFiles { get; set; }
            public List<string> ImageExts { get; set; }
            public List<string> VideoExts { get; set; }
            public List<string> DocExts { get; set; }
            public List<string> Extensions { get; set; }
            public List<string> IncludeKeywords { get; set; }
            public List<string> ExcludeKeywords { get; set; }
            public OriFilterOption OriImagesFilter { get; set; }
            public OriFilterOption OriVideosFilter { get; set; }
        }

        public enum OriFilterOption
        {
            All,
            Ori,
            NonOri
        }
    }
}