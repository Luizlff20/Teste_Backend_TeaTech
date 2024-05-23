using Backend_TeaTech.DTO.Users;
using Backend_TeaTech.Enum;
using Backend_TeaTech.Models;
using System.Xml.Linq;

namespace Backend_TeaTech.DTO.Responsibles
{
    public class ResponsibleDTO
    {
        public Guid? Id { get; set; }
        public string? NameResponsibleOne { get; set; }
        public string? ResponsibleKinshipOne { get; set; }
        public string? ResponsibleCpfOne { get; set; }
        public string? NameResponsibleTwo { get; set; }
        public string? ResponsibleKinshipTwo { get; set; }
        public string? ResponsibleCpfTwo { get; set; }
        public string? ContactOne { get; set; }
        public string? ContactTwo { get; set; }

        public UserDTO? User { get; set; }

        public ResponsibleDTO()
        {
        }

        public ResponsibleDTO(Guid id, string nameResponsibleOne, string responsibleKinshipOne, string responsibleCpfOne, string nameResponsibleTwo, string responsibleKinshipTwo, string responsibleCpfTwo, string contactOne, string contactTwo,  UserDTO? user)
        {
            Id = id;
            NameResponsibleOne = nameResponsibleOne;
            ResponsibleKinshipOne = responsibleKinshipOne;
            ResponsibleCpfOne = responsibleCpfOne;
            NameResponsibleTwo = nameResponsibleTwo;
            ResponsibleKinshipTwo = responsibleKinshipTwo;
            ResponsibleCpfTwo = responsibleCpfTwo;
            ContactOne = contactOne;
            ContactTwo = contactTwo;
            User = user;
        }
        public ResponsibleDTO(Responsible responsible)
        {
            Id = responsible.Id;
            NameResponsibleOne = responsible.NameResponsibleOne;
            ResponsibleKinshipOne = responsible.ResponsibleKinshipOne;
            ResponsibleCpfOne = responsible.ResponsibleCpfOne;
            NameResponsibleTwo = responsible.NameResponsibleTwo;
            ResponsibleKinshipTwo = responsible.ResponsibleKinshipTwo;
            ResponsibleCpfTwo = responsible.ResponsibleCpfTwo;
            ContactOne = responsible.ContactOne;
            ContactTwo = responsible.ContactTwo;
            User = responsible.User != null ? new UserDTO(responsible.User) : null;
        }
    }
}
