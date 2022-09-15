using System.ComponentModel.DataAnnotations;

namespace GDBank.Models
{
    public class CardApplicationModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Account Id is required")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Card type is required")]
        public string CardType { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        public string AccountType { get; set; }
    }
}
