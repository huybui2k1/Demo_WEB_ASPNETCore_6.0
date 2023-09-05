using System.ComponentModel.DataAnnotations;

namespace MyCodeFirstApprochDemo.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vui long nhap ten.")]
        
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui long nhap Email.")]
        [EmailAddress(ErrorMessage = "Email khong hop le.")]
        public string Email { get; set; }


    }
}
