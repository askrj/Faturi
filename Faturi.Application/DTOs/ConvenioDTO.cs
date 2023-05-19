using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Application.DTOs
{
    public class ConvenioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o código ANS do plano")]
        [MinLength(3)]
        [MaxLength(8)]
        public string ANS { get; set; }

        [Required(ErrorMessage = "Digite nome do plano")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }
    }
}
