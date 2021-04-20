using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxxisSystem.Model.Modelo
{
    public class Contacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContacto { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public decimal Peso { get; set; }

        public decimal Estatura { get; set; }
        public decimal IMC { get; set; }
        public string Telefono { get; set; }
        public string DireccionCorreoElectronico { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Direccion_Contacto> Direccion_Contacto { get; set; }
    }
}
