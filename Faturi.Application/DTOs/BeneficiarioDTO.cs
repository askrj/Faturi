using Faturi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Application.DTOs
{
    public class BeneficiarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do beneficiário")]
        [MinLength(3)]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o número da carteira do beneficiário")]
        [MinLength(3)]
        [MaxLength(15)]
        public string Carteira { get; set; }

        [Required(ErrorMessage = "Digite CPF do beneficiário ")]
        [MinLength(11)]
        [MaxLength(15)]
        public string CPF { get; set; }

        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime Nascimento { get; set; }

        public string Foto { get;   set; }

        public Convenio Convenio { get; set; }

        [DisplayName("Convenio")]
        public int ConvenioId { get; set; }
    }
}
