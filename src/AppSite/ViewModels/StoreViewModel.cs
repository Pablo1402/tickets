using System.ComponentModel.DataAnnotations;

namespace AppSite.ViewModels
{
    public class StoreViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(400, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        [DataType(DataType.EmailAddress, ErrorMessage ="Informe um email válido")]
        public string Email { get; set; }

        [Display(Name= "Logo")]
        [Required(ErrorMessage = "Informe uma logo para a loja")]
        [StringLength(400, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Image { get; set; }

        [Display(Name = "Data de criação")]
        public DateTime? CreateDate { get; set; }


        [Display(Name = "Ativo?")]
        public bool Active { get; set; }

        [Display(Name = "Plano")]
        [Required(ErrorMessage ="Selecione um plano")]
        public Guid StorePlanId { get; set; }
        public StorePlanViewModel? StorePlan { get; set; }


    }

  
}
