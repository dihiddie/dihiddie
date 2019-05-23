using dihiddie.BAL.DocxReader.Models;
using dihiddie.BAL.DocxReader.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xceed.Words.NET;
using FileInfo = dihiddie.BAL.DocxReader.Models.FileInfo;

namespace dihiddie.BAL.DocxReader.Xceed.Repository
{
    public class DocxRepository : IDocxRepository
    {
        private const string CreateDateTimeKey = "dcterms:created";
        private const string ModifyDateTimeKey = "dcterms:modified";

        private readonly string folderPath;

        public DocxRepository(string folderPath) => this.folderPath = folderPath;

        public FileInfo[] GetAllFilesInformation()
        {
            var fileInfos = new List<FileInfo>();
            if (!Directory.Exists(folderPath)) return null;
            foreach (var fileName in Directory.GetFiles(folderPath).Where(s => s.EndsWith(".docx") || s.EndsWith(".doc")))
            {
                var size = Math.Round(new System.IO.FileInfo(fileName).Length / 1024f);
                try
                {
                    using (DocX document = DocX.Load(fileName))
                    {
                        fileInfos.Add(new FileInfo(Path.GetFileNameWithoutExtension(fileName),
                            document.CoreProperties[CreateDateTimeKey], document.CoreProperties[ModifyDateTimeKey])
                        { Size = size });
                    }
                }
                catch(Exception ex) { }
            }

            return fileInfos.OrderByDescending(x => x.CreateDateTime).ToArray();
        }

        public FileContent GetByChapter(string chapterTitle)
        {
            throw new NotImplementedException();
        }

        public FileContent GetByTitle(string title)
        {
            try
            {
                using (DocX document = DocX.Load(Path.Combine(folderPath, $"{title}.docx")))
                {
                    var fileContent = new FileContent();

                    foreach (var chapter in document.Sections)
                    {
                        var paragraphList = new List<Models.Paragraph>();
                        foreach (var paragrapth in chapter.SectionParagraphs)
                        {
                            paragraphList.Add(new Models.Paragraph { Content = paragrapth.Text });
                        }


                        fileContent.Chapters.Add(new Chapter
                        {
                            Title = string.Empty,
                            Paragraphs = chapter.SectionParagraphs.Select(x => new Models.Paragraph { Content = x.Text}).ToList()
                        });

                    }

                    return fileContent;
                }
            }
            catch
            {
                // ignored for now
                return null;
            }
        }
    }
}
