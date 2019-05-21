using dihiddie.BAL.DocxReader.Repository;

namespace dihiddie.BAL.DocxReader.UnitOfWork
{
    public interface IDocxUnitOfWork
    {
        IDocxRepository DocxRepository { get; }
    }
}
