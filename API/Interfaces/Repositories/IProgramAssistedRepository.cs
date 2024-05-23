using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Repositories
{
    public interface IProgramAssistedRepository
    {
        ProgramAssisted Add(ProgramAssisted programAssisted);
        ProgramAssisted Update(ProgramAssisted programAssisted);
        void DeleteById(Guid id);
        ProgramAssisted GetById(Guid id);
        List<ProgramAssisted> GetAll();
        ProgramAssisted? GetByChildAssistedId(Guid id);

    }
}
