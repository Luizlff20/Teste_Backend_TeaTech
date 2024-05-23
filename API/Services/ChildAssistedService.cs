using System;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Repositories;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.DTO.ChildAssisteds;

namespace Backend_TeaTech.Services
{
    public class ChildAssistedService : IChildAssistedService
    {
        private readonly IChildAssistedRepository _childAssistedRepository;
        private readonly IPreAnalysisRepository _preAnalysisRepository;
        private readonly IAssessmentRepository _assessmentRepository;
        public ChildAssistedService(IChildAssistedRepository childAssistedRepository, IPreAnalysisRepository preAnalysisRepository, IAssessmentRepository assessmentRepository)
        {
            _childAssistedRepository = childAssistedRepository;
            _preAnalysisRepository = preAnalysisRepository;
            _assessmentRepository = assessmentRepository;
        }
        public ChildAssisted CreateChild(ChildAssisted childAssisted)
        {
            var childAdd = _childAssistedRepository.Add(childAssisted);
            return childAdd;

        }

        public void DeleteChildById(Guid id)
        {
            var existingChild = _childAssistedRepository.GetById(id);
            if (existingChild != null)
            {
                _childAssistedRepository.DeleteById(id);
            }
            else
            {
                throw new ArgumentException("Child not found.");
            }
        }

        public ListChildAssistedDTO FilterByData(string data, int pageNumber, int pageSize, string orderBy, string orderDirection)
        {
            var childs = _childAssistedRepository.GetByData(data, pageNumber, pageSize, orderBy, orderDirection);

            List<FilterChildAssistedDTO> filterchildAssistedDTOs = new List<FilterChildAssistedDTO>();

            childs.ForEach(child => {
                PreAnalysis? preAnalysis = _preAnalysisRepository.GetByChildAssistedId(child.Id);
                filterchildAssistedDTOs.Add(new FilterChildAssistedDTO(child, preAnalysis, child.Responsible));
            });

            int totalChildAssisteds = _childAssistedRepository.CountAllChildAssisted();

            int totalPages = (int)Math.Ceiling((double)totalChildAssisteds / pageSize);

            ListChildAssistedDTO listChildAssistedDTO = new ListChildAssistedDTO(filterchildAssistedDTOs, totalPages, pageNumber);

            return listChildAssistedDTO;
        }

        public ChildAssistedDTO GetChildById(Guid id)
        {
            try
            {
                 var childAssisted = _childAssistedRepository.GetById(id);
                if (childAssisted == null)
                {
                    throw new ArgumentException($"Child with ID {id} not found.");
                }

                PreAnalysis? preAnalysis = _preAnalysisRepository.GetByChildAssistedId(childAssisted.Id);
                Assessment? assessment = _assessmentRepository.GetByChildAssistedId(childAssisted.Id);

                var childAssistedDTO = new ChildAssistedDTO(childAssisted, preAnalysis, childAssisted.Responsible, assessment);

                return childAssistedDTO;
            }
            catch (ArgumentException)
            {
                throw; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting child by ID", ex);
            }
        }
    }
}
