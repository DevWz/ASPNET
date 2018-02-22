using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Core.Models
{
    public class Dado
    {
        [Key]
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        public string Fone { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
