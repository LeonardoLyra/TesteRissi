using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Teste_Rissi.Models
{
    public class Carro
    {
        public int? IdCarro { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo nome obrigatório")]
        [MinLength(3)]
        public string Nome { get; set; }

        [Display(Name = "Eixos")]
        [Required(ErrorMessage = "Campo eixos obrigatório")]
        public int Eixos { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo categoria obrigatório")]
        public virtual CategoriaEnum Cat { get; set; } = new CategoriaEnum();


        [Display(Name = "Tamanho do Porta Malas")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int TamanhoPortaMalas { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Campo preço obrigatório")]
        public decimal Preco { get; set; }

        [Display(Name = "Portas")]
        [Required(ErrorMessage = "Campo portas obrigatório")]
        public int Portas { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


    }

    public enum CategoriaEnum
        {
            [Description("Hatch")] Hatch,
            [Description("Sedan")] Sedan,
            [Description("SUV")] SUV,
            [Description("Utilitario")] Utilitario,
            [Description("Picape")] Picape
        }
}
