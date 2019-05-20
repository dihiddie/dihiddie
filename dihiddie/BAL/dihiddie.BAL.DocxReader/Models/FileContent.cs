using System.Collections.Generic;

namespace dihiddie.BAL.DocxReader.Models
{
    public class FileContent
    {
        public FileContent() { Chapters = new List<Chapter>(); }

        public List<Chapter> Chapters { get; set; }

        public FileStructInfo StructInfo { get; set; }
    }
}
