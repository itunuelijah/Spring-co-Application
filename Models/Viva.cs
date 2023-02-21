using System.ComponentModel.DataAnnotations.Schema;

namespace SpringCoApplication.Models
{
    public class Viva : Account
    {
        [Column("Type")]
        public string Discriminator => "Viva";

        public double InterestRate { get; set; }

        public Viva(string id,
                             DateTime createdAt,
                             Customer customer,
                             IList<AccountOperation> accountOperations)
        {
            Id = id;
            Balance = 0.0;
            CreatedAt = createdAt;
            Customer = customer;
            AccountOperations = accountOperations;
            InterestRate = 8.0;
        }

        public Viva()
        {
        }
    }
}
