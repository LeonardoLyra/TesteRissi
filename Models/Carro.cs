using System;
using System.Collections;
using System.Collections.Generic;
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
        public CategoriaEnum _Categoria;

        public void SetCategoria(CategoriaEnum categoria)
        {
            _Categoria = categoria;
        }

        public CategoriaEnum GetCategoria()
        {
            return _Categoria;
        }


        [Display(Name = "TamanhoPortaMalas")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int TamanhoPortaMalas { get; set; }

        [Display(Name = "Preco")]
        [Required(ErrorMessage = "Campo preço obrigatório")]
        public decimal Preco { get; set; }

        [Display(Name = "Portas")]
        [Required(ErrorMessage = "Campo portas obrigatório")]
        public int Portas { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }

        public enum CategoriaEnum
        {
            [Description("Hatch")] Hatch = 0,
            [Description("Sedan")] Sedan = 1,
            [Description("SUV")] SUV = 2,
            [Description("Utilitario")] Utilitario = 3,
            [Description("Picape")] Picape = 4
        }

    }


}
