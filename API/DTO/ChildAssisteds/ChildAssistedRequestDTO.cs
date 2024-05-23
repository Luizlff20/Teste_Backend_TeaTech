using System.Diagnostics.CodeAnalysis;

namespace Backend_TeaTech.DTO.ChildAssisteds
{
    public class ChildAssistedRequestDTO
    {
        [NotNull]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string FoodSelectivity { get; set; }
        public string Aversions { get; set; }
        public string Preferences { get; set; }
        public string MedicalRecord { get; set; }
        public string? Photo { get; set; }
        public string Email { get; set; }
        public string ResponsibleCpfOne { get; set; }
        public string NameResponsibleOne { get; set; }
        public string ResponsibleKinshipOne { get; set; }
        public string? NameResponsibleTwo { get; set; }
        public string? ResponsibleKinshipTwo { get; set; }
        public string? ResponsibleCpfTwo { get; set; }
        public string ContactOne { get; set; }
        public string? ContactTwo { get; set; }

        public ChildAssistedRequestDTO()
        {

        }

        public ChildAssistedRequestDTO(string name, DateTime birthDate, string foodSelectivity, string aversions, string preferences, string medicalRecord, string? photo, string email, string responsibleCpfOne, string nameResponsibleOne, string responsibleKinshipOne, string? nameResponsibleTwo, string? responsibleKinshipTwo, string? responsibleCpfTwo, string contactOne, string? contactTwo)
        {
            Name = name;
            BirthDate = birthDate;
            FoodSelectivity = foodSelectivity;
            Aversions = aversions;
            Preferences = preferences;
            MedicalRecord = medicalRecord;
            Photo = photo;
            Email = email;
            ResponsibleCpfOne = responsibleCpfOne;
            NameResponsibleOne = nameResponsibleOne;
            ResponsibleKinshipOne = responsibleKinshipOne;
            NameResponsibleTwo = nameResponsibleTwo;
            ResponsibleKinshipTwo = responsibleKinshipTwo;
            ResponsibleCpfTwo = responsibleCpfTwo;
            ContactOne = contactOne;
            ContactTwo = contactTwo;
        }
    }
}
