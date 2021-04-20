using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AxxisSystem.Model.Modelo
{
    public class Departamento
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Direccion_Contacto> Direccion_Contacto { get; set;}

    }
}
