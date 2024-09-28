namespace AgrotoolsMaps.Application.UseCases.Shared
{
    public class PageResponse
    {
        public int Page { get; set; }

        public int Size { get; set; }
        
        public int TotalResult { get; set; }
    }
}