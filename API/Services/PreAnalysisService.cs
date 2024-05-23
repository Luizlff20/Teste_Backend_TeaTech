using Backend_TeaTech.DTO.ChildAssisteds;
using Backend_TeaTech.DTO.Employees;
using Backend_TeaTech.DTO.PreAnalysiss;
using Backend_TeaTech.DTO.Users;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Repositories;

namespace Backend_TeaTech.Services
{
    public class PreAnalysisService : IPreAnalysisService
    {
        private readonly IPreAnalysisRepository _preAnalysisRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAssessmentRepository _assessmentRepository;
        public PreAnalysisService(IPreAnalysisRepository preAnalysisRepository, IEmployeeRepository employeeRepository)
        {
            _preAnalysisRepository = preAnalysisRepository;
            _employeeRepository = employeeRepository;
        }

        public PreAnalysis CreatePreAnalysis(PreAnalysis preAnalysis)
        {
            PreAnalysis preAnalysisAdd = _preAnalysisRepository.Add(preAnalysis);
            return preAnalysisAdd;
        }

        public PreAnalysis UpdatePreAnalysis(Guid id, PreAnalysisRequestDTO preAnalysis, Guid employeeId)
        {
            
            PreAnalysis preAnalysisUpdate = _preAnalysisRepository.GetById(id);

            if (preAnalysisUpdate == null)
            {
                throw new ArgumentException($"Pre Analysis with ID {id} not found.");
            }

            if (preAnalysis.ProposedActivity != preAnalysisUpdate.ProposedActivity && preAnalysis.ProposedActivity != null)
            {
                preAnalysisUpdate.ProposedActivity = preAnalysis.ProposedActivity;
            }
            if (preAnalysis.FinalDuration != preAnalysisUpdate.FinalDuration && preAnalysis.FinalDuration != null)
            {
                preAnalysisUpdate.FinalDuration = preAnalysis.FinalDuration;
            }
            if (preAnalysis.IdentifiedSkills != preAnalysisUpdate.IdentifiedSkills && preAnalysis.IdentifiedSkills != null)
            {
                preAnalysisUpdate.IdentifiedSkills = preAnalysis.IdentifiedSkills;
            }
            if (preAnalysis.Protocol != preAnalysisUpdate.Protocol && preAnalysis.Protocol != null)
            {
                preAnalysisUpdate.Protocol = preAnalysis.Protocol;
            }

            Employee employee = _employeeRepository.GetByIdUser(employeeId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with ID {id} not found.");
            }
            else
            {
                preAnalysisUpdate.Employee = employee;

                preAnalysisUpdate.StatusCode = Enum.StatusCode.Completed;

                _preAnalysisRepository.Update(preAnalysisUpdate);

            }

            return preAnalysisUpdate;

        }

        public void DeletePreAnalysisById(Guid id)
        {
            var existingPreAnalysis = _preAnalysisRepository.GetById(id);
            if (existingPreAnalysis != null)
            {
                _preAnalysisRepository.DeleteById(id);
            }
            else
            {
                throw new ArgumentException("Pre Analysis not found.");
            }
        }

        public PreAnalysisDTO GetPreAnalysisById(Guid id)
        {
            try
            {
                var preAnalysis = _preAnalysisRepository.GetById(id);
                if (preAnalysis == null)
                {
                    throw new ArgumentException($"Pre Analysis with ID {id} not found.");
                }

                var childDTO = new ChildAssistedDTO
                {
                    Id = preAnalysis.ChildAssisted.Id,
                    Name = preAnalysis.ChildAssisted.Name,
                    Contact = preAnalysis.ChildAssisted.Responsible.ContactOne,
                    Email = preAnalysis.ChildAssisted.Responsible.User.Email,
                    PreAnalysisId = preAnalysis.ChildAssisted.Id,
                    PreAnalysisStatusCode = preAnalysis.StatusCode,
                };

                var userDTO = preAnalysis.Employee.User != null ? new UserDTO
                {
                    Id = preAnalysis.Employee.User.Id,
                    Email = preAnalysis.Employee.User.Email,
                    UserType = preAnalysis.Employee.User.UserType,
                } : null;

                var employeeDTO = new EmployeeDTO
                {
                    Id = preAnalysis.Employee.Id,
                    Name = preAnalysis.Employee.Name,
                    OccupationType = preAnalysis.Employee.OccupationType,
                    User = userDTO,
                };

                var preAnalysisDTO = new PreAnalysisDTO
                {
                    Id = preAnalysis.Id,
                    ProposedActivity = preAnalysis.ProposedActivity,
                    FinalDuration = preAnalysis.FinalDuration,
                    IdentifiedSkills = preAnalysis.IdentifiedSkills,
                    Protocol = preAnalysis.Protocol,
                    StatusCode = preAnalysis.StatusCode,
                    Employee = employeeDTO,
                    ChildAssisted = childDTO,

                };

                return preAnalysisDTO;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting pre-analysis by ID", ex);
            }
        }

        public List<PreAnalysisDTO> ListAllPreAnalysis()
        {
            throw new NotImplementedException();
        }

        //public List<PreAnalysisDTO> ListAllPreAnalysis()
        //{
        //    var preAnalysiss = _preAnalysisRepository.GetAll();

        //    List<PreAnalysisDTO> preAnalysisDTO = preAnalysiss.Select(preAnalysis => new PreAnalysisDTO
        //    {
        //        Id = preAnalysis.Id,
        //        ProposedActivity = preAnalysis.ProposedActivity,
        //        FinalDuration = preAnalysis.FinalDuration,
        //        IdentifiedSkills = preAnalysis.IdentifiedSkills,
        //        Protocol = preAnalysis.Protocol,
        //        StatusCode = preAnalysis.StatusCode,
        //        Employee = preAnalysis.Employee != null ? new EmployeeDTO(preAnalysis.Employee) : null,
        //        ChildAssisted = preAnalysis.ChildAssisted != null ? new ChildAssistedDTO(preAnalysis.ChildAssisted, preAnalysis, preAnalysis.ChildAssisted.Responsible) : null,

        //    }).ToList();

        //    return preAnalysisDTO;
        //}


    }
}
