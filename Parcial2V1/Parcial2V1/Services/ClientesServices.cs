using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parcial2V1.Models;

namespace Parcial2V1.Services
{
    public class ClientesServices
    {
        public Clientes ListaClientes()
        {
            return new Clientes()
            {
                Lista = "Lista de clientes",
                Nombre = "Julieta",
                Apellido = "Venegas",
                Sueldo = 200,
            };
        }
    }
}