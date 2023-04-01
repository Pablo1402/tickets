using System.ComponentModel.DataAnnotations;

namespace AppSite.ViewModels
{
    public class UserTypeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Tipo usuário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }
    }
}
