using System.ComponentModel.DataAnnotations;

namespace AppSite.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get;  set; }

        [Display(Name = "Tipo de usuário")]
        [Required(ErrorMessage = "Selecione um Tipo de usuário")]
        public Guid? UserTypeId { get;  set; }
        public UserTypeViewModel? UserType { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get;  set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Login { get;  set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Email { get;  set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Password { get;  set; }

        [Display(Name = "Criado em")] 
        public DateTime? CreateDate { get;  set; }

        [Display(Name = "Loja")]
        public Guid? StoreId { get;  set; }
        public StoreViewModel? Store { get; set; }

    }
}
