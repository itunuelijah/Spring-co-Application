namespace SpringCoApplication.Dtos
{
    public class SupaDto : AccountDto
    {
        public string Id { get; set; }
        public double Balance { get; set; }
        public CustomerDto CustomerDto { get; set; }
        public double InterestRate { get; set; }
        public string Type { get; internal set; }
    }
}
