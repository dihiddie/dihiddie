using dihiddie.BAL.DocxReader.Models;
using dihiddie.BAL.DocxReader.Repository;
using System;
using System.Collections.Generic;
using System.IO;
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
            foreach (var fileName in Directory.GetFiles(folderPath, "*.docx"))
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

            return fileInfos.ToArray();
        }

        public FileContent GetByChapter(string chapterTitle)
        {
            throw new NotImplementedException();
        }

        public FileContent GetByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
