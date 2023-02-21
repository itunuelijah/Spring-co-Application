namespace SpringCoApplication.Dtos
{
    public class CreditDto
    {
        public string AccountId { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }

        public CreditDto(string accountId, double amount, string description)
        {
            AccountId = accountId;
            Amount = amount;
            Description = description;
        }

        public CreditDto()
        {

        }
    }
}
