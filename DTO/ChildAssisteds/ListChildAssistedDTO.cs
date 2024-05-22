namespace Backend_TeaTech.DTO.ChildAssisteds
{
    public class ListChildAssistedDTO
    {
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        public List<FilterChildAssistedDTO> FilterChildAssisteds { get; set; } = new List<FilterChildAssistedDTO>();

        public ListChildAssistedDTO()
        {

        }
        public ListChildAssistedDTO(List<FilterChildAssistedDTO> filterChildAssisteds, int totalPages, int pageNumber)
        {
            FilterChildAssisteds = filterChildAssisteds;
            TotalPages = totalPages;    
            PageNumber = pageNumber;    
        }
    }
}
