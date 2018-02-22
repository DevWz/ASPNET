using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Core.Models
{
    public class Endereco
    {
        [Key]
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        public string Logradouro { get; set; }
        public string N { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
