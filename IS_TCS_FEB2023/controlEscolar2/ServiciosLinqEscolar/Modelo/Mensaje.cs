using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosLinqEscolar.Modelo
{
    public class Mensaje
    {
        public Usuario UsuarioEncontrado { get; set; }
        public String Respuesta { get; set; }
        public bool Error { get; set; }
        public Mensaje() { }
    }
}