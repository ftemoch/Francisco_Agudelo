using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clase12.Models
{
    public class TipoCliente
    {
        public byte Id { get; set; }
        public String Nombre { get; set; }
        public short costoSubscripcion { get; set; }
        public byte duracionSbcEnMeses { get; set; }
        public byte porcDescuento { get; set; }




    }
}