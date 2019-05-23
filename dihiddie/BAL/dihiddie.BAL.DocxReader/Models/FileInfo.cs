using System;

namespace dihiddie.BAL.DocxReader.Models
{
    public class FileInfo
    {
        public FileInfo(string title, string createDateTime, string updateDateTime)
        {
            Title = title;
            CreateDateTime = DateTime.Parse(createDateTime);
            UpdateDateTime = DateTime.Parse(updateDateTime);
        }

        public string Title { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }

        public bool HadContents { get; set; }

        public double Size { get; set; }

        public string Preview { get; set; }
    }
}
