using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxxisSystem.Model.Modelo
{
    public class Direccion_Contacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDireccion_Contacto { get; set; }
        public string Direccion { get; set; }
        public int IdDepartamento { get; set; }
        public int IdContacto { get; set; }
        public bool Estado { get; set; }

        public virtual Departamento Departamento { get; set; }
        public virtual Contacto Contacto { get; set; }

    }
}
