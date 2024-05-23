using Backend_TeaTech.DTO.Assessments;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Repositories;

namespace Backend_TeaTech.Services
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public AssessmentService(IAssessmentRepository assessmentRepository, IEmployeeRepository employeeRepository)
        {
            _assessmentRepository = assessmentRepository;
            _employeeRepository = employeeRepository;
        }
        public Assessment CreateAssessment(Assessment assessment)
        {
            Assessment assessmentAdd = _assessmentRepository.Add(assessment);
            return assessmentAdd;
        }

        public Assessment UpdateAssessment(Guid id, AssessmentRequestDTO assessment, Guid employeeId)
        {
            Assessment assessmentUpdate = _assessmentRepository.GetById(id);

            if (assessmentUpdate == null)
            {
                throw new ArgumentException($"Assessment with ID {id} not found.");
            }

            if (assessment.ChildAssessment != assessmentUpdate.ChildAssessment && assessment.ChildAssessment != null)
            {
                assessmentUpdate.ChildAssessment = assessment.ChildAssessment;
            }

            Employee employee = _employeeRepository.GetByIdUser(employeeId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with ID {id} not found.");
            }
            else
            {
                assessmentUpdate.Employee = employee;

                assessmentUpdate.StatusCode = Enum.StatusCode.Completed;

                _assessmentRepository.Update(assessmentUpdate);

            }

            return assessmentUpdate;
        }
    }
}
