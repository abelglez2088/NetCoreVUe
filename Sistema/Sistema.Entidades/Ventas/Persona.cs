using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Ventas
{
    class Persona
    {
        public int idpersona {get; set;}
        [Required]
        public string tipo_persona { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3,ErrorMessage = "La persona debe contener mas de 3 caracteres y un minimo de 100")]
        public string nombre { get; set; }
        public string tipo_documento { get; set;}
        public string num_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }

    }
}
