using System.ComponentModel.DataAnnotations;


namespace Teste_Rissi.Models
{
    public class ClienteViewModel
    {

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo e-mail obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo senha obrigatório")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres")]
        public string Senha { get; set; }


    }
}
