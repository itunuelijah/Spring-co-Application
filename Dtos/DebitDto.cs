namespace SpringCoApplication.Dtos
{
    public class DebitDto
    {
        public string AccountId { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }

        public DebitDto(string accountId, double amount, string description)
        {
            AccountId = accountId;
            Amount = amount;
            Description = description;
        }

        public DebitDto()
        {
        }
    }
}
