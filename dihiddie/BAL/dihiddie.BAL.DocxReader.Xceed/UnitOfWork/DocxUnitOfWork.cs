using dihiddie.BAL.DocxReader.Repository;
using dihiddie.BAL.DocxReader.UnitOfWork;
using dihiddie.BAL.DocxReader.Xceed.Repository;

namespace dihiddie.BAL.DocxReader.Xceed.UnitOfWork
{
    public class DocxUnitOfWork : IDocxUnitOfWork
    {
        private readonly string folderPath;

        public DocxUnitOfWork() => this.folderPath = @"C:\Users\User\Desktop\текст";

        public IDocxRepository DocxRepository => new DocxRepository(folderPath);
    }
}
