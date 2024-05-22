using Backend_TeaTech.DTO.ProgramAssisteds;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Repositories;

namespace Backend_TeaTech.Services
{
    public class ProgramAssistedService : IProgramAssistedService
    {
        private readonly IProgramAssistedRepository _programRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public ProgramAssistedService(IProgramAssistedRepository programRepository, IEmployeeRepository employeeRepository)
        {
            _programRepository = programRepository;
            _employeeRepository = employeeRepository;
        }
        public ProgramAssisted CreateProgram(ProgramAssisted program)
        {
            ProgramAssisted programAdd = _programRepository.Add(program);
            return programAdd;
        }

        public ProgramAssisted UpdateProgram(Guid id, ProgramRequestDTO program, Guid userId)
        {
            ProgramAssisted programUpdate = _programRepository.GetById(id);

            if (programUpdate == null)
            {
                throw new ArgumentException($"Program with ID {id} not found.");
            }

            if (program.ActivityDescription != programUpdate.ActivityDescription && program.ActivityDescription != null)
            {
                programUpdate.ActivityDescription = program.ActivityDescription;
            }
            if(program.StimuliUsed != programUpdate.StimuliUsed && program.StimuliUsed != null)
            {
                programUpdate.StimuliUsed = program.StimuliUsed;
            }
            if (program.ProgramType != programUpdate.ProgramType && program.ProgramType != null)
            {
                programUpdate.ProgramType = program.ProgramType;
            }
            if (program.ProtocolType != programUpdate.ProtocolType && program.ProtocolType != null)
            {
                programUpdate.ProtocolType = program.ProtocolType;
            }

            Employee employeeApplicador = _employeeRepository.GetByID(program.idApplicator);

            if (employeeApplicador == null || employeeApplicador.OccupationType != Enum.OccupationType.Applicator)
            {
                throw new ArgumentException($"EmployeeApplicator with ID {id} not found.");
            }
            else
            {
                programUpdate.Employee = employeeApplicador;
            }

            Employee employee = _employeeRepository.GetByIdUser(userId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with ID {id} not found.");
            }
            else
            {
                programUpdate.Employee = employee;

                programUpdate.StatusCode = Enum.StatusCode.Completed;

                _programRepository.Update(programUpdate);

            }

            return programUpdate;
        }
    }
    
}
