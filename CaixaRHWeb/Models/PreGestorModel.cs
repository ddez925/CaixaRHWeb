using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaixaRHWeb.Models
{
    public class PreGestorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome.")]
        public string NomePergunta { get; set; }

        public string NomeResposta { get; set; }

        public string NomeResposta2 { get; set; }

        public string NomeResposta3 { get; set; }

        public string NomeResposta4 { get; set; }

        public bool Ativo { get; set; }
    }
}