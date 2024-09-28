namespace AgrotoolsMaps.Domain.Model
{
    public class TokenInfoModel
    {
        public int ApplicationId { get; set; }
        public int CompanyId { get; set; }
        public int CompanyHolderId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyHolderName { get; set; }
        public string ConnectionString { get; set; }
        public string ConnectionStringHolder { get; set; }
        public string DatabaseName { get; set; }
    }
}