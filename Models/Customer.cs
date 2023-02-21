using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpringCoApplication.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email field is required")]
        [EmailAddress]
        public string Email { get; set; }

        [InverseProperty("Customer")]
        public virtual List<Account>? Accounts { get; set; }

        //  or
        //  public ICollection<Account> Accounts { get; set; }

        public Customer()
        {
        }

        public Customer(long id, string name, string email, List<Account>? accounts)
        {
            Id = id;
            Name = name;
            Email = email;
            Accounts = accounts;
        }

    }
}
