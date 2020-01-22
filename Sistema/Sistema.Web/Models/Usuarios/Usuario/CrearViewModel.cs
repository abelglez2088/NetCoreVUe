﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Usuarios.Usuario
{
    public class CrearViewModel
    {
        [Required]
        public int idrol { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener un maximo de 100 caracteres y un minimo de 3")]
        public string nombre { get; set; }
        public string tipo_documento { get; set; }
        public string num_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
