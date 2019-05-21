using System.Collections.Generic;

namespace dihiddie.BAL.DocxReader.Models
{
    public class Chapter
    {
        public Chapter() { Paragraphs = new List<Paragraph>(); }

        public string Title { get; set; }

        public List<Paragraph> Paragraphs { get; set; }

        public string Content { get; set; }
    }
}
