namespace B3Consultants.Models
{
    public class ConsultantQuery
    {
        public string SearchPhrase { get; set; } = "";
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; } = "";
        public SortDirections SortDirection { get; set; } = SortDirections.ASC;
    }
}
