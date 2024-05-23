using Backend_TeaTech.DTO.ProgramAssisteds;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Services
{
    public interface IProgramAssistedService
    {
        ProgramAssisted CreateProgram(ProgramAssisted program);
        ProgramAssisted UpdateProgram(Guid id, ProgramRequestDTO program, Guid employeeId);
    }
}
