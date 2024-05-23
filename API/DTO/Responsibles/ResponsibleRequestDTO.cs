using Backend_TeaTech.Models;

namespace Backend_TeaTech.DTO.Responsibles
{
    public class ResponsibleRequestDTO
    {
        public string? NameResponsibleOne { get; set; }
        public string? ResponsibleKinshipOne { get; set; }
        public string? ResponsibleCpfOne { get; set; }
        public string? NameResponsibleTwo { get; set; }
        public string? ResponsibleKinshipTwo { get; set; }
        public string? ResponsibleCpfTwo { get; set; }
        public string? ContactOne { get; set; }
        public string? ContactTwo { get; set; }
        public ResponsibleRequestDTO()
        {
        }
        public ResponsibleRequestDTO(Responsible responsible)
        {
            NameResponsibleOne = responsible.NameResponsibleOne;
            ResponsibleKinshipOne = responsible.ResponsibleKinshipOne;
            ResponsibleCpfOne = responsible.ResponsibleCpfOne;
            NameResponsibleTwo = responsible.NameResponsibleTwo;
            ResponsibleKinshipTwo = responsible.ResponsibleKinshipTwo;
            ResponsibleCpfTwo = responsible.ResponsibleCpfTwo;
            ContactOne = responsible.ContactOne;
            ContactTwo = responsible.ContactTwo;
        }

    }
}
