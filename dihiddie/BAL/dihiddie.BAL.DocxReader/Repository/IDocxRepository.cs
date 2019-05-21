using dihiddie.BAL.DocxReader.Models;

namespace dihiddie.BAL.DocxReader.Repository
{
    public interface IDocxRepository
    {
        FileInfo[] GetAllFilesInformation();

        FileContent GetByTitle(string title);

        FileContent GetByChapter(string chapterTitle);
    }
}
