using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Repositories;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.DTO.Responsibles;
using Backend_TeaTech.DTO.Users;

namespace Backend_TeaTech.Services
{
    public class ResponsibleService : IResponsibleService
    {
        private readonly IResponsibleRepository _responsibleRepository;
        public ResponsibleService(IResponsibleRepository responsibleRepository) {
            _responsibleRepository = responsibleRepository;
        }

        public Responsible CreateResponsible(Responsible responsible)
        {
            var responsibleAdd = _responsibleRepository.Add(responsible);

            return responsibleAdd;
        }

        public void DeleteResponsibleById(Guid id)
        {
            var existingResponsible = _responsibleRepository.GetById(id);
            if (existingResponsible != null)
            {
                _responsibleRepository.DeleteById(id);
            }
            else
            {
                throw new ArgumentException("Responsible not found.");
            }
        }

        public List<ResponsibleDTO> ListAllResponsible()
        {
            var responsibles = _responsibleRepository.GetAll();

            List<ResponsibleDTO> responsibleDTO = responsibles.Select(responsible => new ResponsibleDTO(responsible)).ToList();

            return responsibleDTO;
        }

        public ResponsibleDTO GetResponsibleById(Guid id)
        {
            try
            {
                var responsible = _responsibleRepository.GetById(id);
                if (responsible == null)
                {
                    throw new ArgumentException($"Responsible with ID {id} not found.");
                }

                UserDTO userDTO = null;
                if (responsible.User != null)
                {
                    userDTO = new UserDTO
                    {
                        Id = responsible.User.Id,
                        Email = responsible.User.Email,
                        UserType = responsible.User.UserType,
                    };
                }

                var responsibleDTO = new ResponsibleDTO
                {
                    Id = responsible.Id,
                    NameResponsibleOne = responsible.NameResponsibleOne,
                    ResponsibleCpfOne = responsible.ResponsibleCpfOne,
                    ResponsibleKinshipOne = responsible.ResponsibleKinshipOne,
                    ContactOne = responsible.ContactOne,
                    NameResponsibleTwo = responsible.NameResponsibleTwo,
                    ResponsibleCpfTwo = responsible.ResponsibleCpfTwo,
                    ResponsibleKinshipTwo = responsible.ResponsibleKinshipTwo,
                    ContactTwo = responsible.ContactTwo,
                    User = userDTO,
                };

                return responsibleDTO;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting responsible by ID", ex);
            }
        }


    }
}
