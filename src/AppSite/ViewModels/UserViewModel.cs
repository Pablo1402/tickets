using System.ComponentModel.DataAnnotations;

namespace AppSite.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; private set; }

        [Display(Name = "Tipo de usuário")]
        [Required(ErrorMessage = "Selecione um Tipo de usuário")]
        public Guid? UserTypeId { get; private set; }
        public UserTypeViewModel? UserType { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Login { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Email { get; private set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Password { get; private set; }

        [Display(Name = "Criado em")] 
        public DateTime? CreateDate { get; private set; }

        [Display(Name = "Loja")]
        public Guid? StoreId { get; private set; }
        public StoreViewModel? Store { get; set; }

    }
}
