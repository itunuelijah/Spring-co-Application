using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpringCoApplication.Models
{
    [Table("AccountOperation")]
    public class AccountOperation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime OperationDate { get; set; }
        public double Amount { get; set; }

        [EnumDataType(typeof(OperationType))]
        public OperationType Type { get; set; }

        [ForeignKey("Account")]
        public string AccountId { get; set; }

        public Account Account { get; set; }

        public string? Description { get; set; }

        public AccountOperation() { }

        public AccountOperation(long id, DateTime operationDate, double amount, OperationType type, Account account, string description)
        {
            Id = id;
            OperationDate = operationDate;
            Amount = amount;
            Type = type;
            Account = account;
            Description = description;
        }
    }
}
