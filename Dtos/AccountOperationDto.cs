namespace SpringCoApplication.Dtos
{
    public class AccountOperationDto
    {
        public long Id { get; set; }
        public DateTime OperationDate { get; set; }
        public double Amount { get; set; }
        public OperationType Type { get; set; }

        public AccountOperationDto(long id, DateTime operationDate, double amount, OperationType type)
        {
            Id = id;
            OperationDate = operationDate;
            Amount = amount;
            Type = type;
        }

        public AccountOperationDto()
        {
        }
    }
}
