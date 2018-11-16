using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clase12.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        [Required]
        [StringLength(255)]

        public String Nombre { get; set; }
        public String Apellido { get; set; }

        public float Salario { get; set; }

        public bool estaactivo { get; set; }

        public bool estaInscritoRevista { get; set; }
        public TipoCliente tipoCliente { get; set; }

        public byte IdTipoCliente { get; set; }


    }
}       