using AxxisSystem.Model;
using AxxisSystem.Model.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxxisSystem.Servicios.Servicios
{
    public class ContactoService
    {
            
        public List<Contacto> TodosLosContactosActivos()
        {
            using (var contexto = new AxxisSystemDbContext())
            {
                List<Contacto> _ListaContacto = new List<Contacto>();

                _ListaContacto = contexto.Contactos.Where(x => x.Estado == true).ToList();
                return _ListaContacto;
            }
        }

        public bool GuardarContacto(Contacto contacto)
        {
            using (var contexto = new AxxisSystemDbContext())
            {
                contexto.Set<Contacto>().Add(contacto);

                if (contexto.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Contacto ObtenerContactoXId(int? id)
        {
            using (var contexto = new AxxisSystemDbContext())
            {
                var _Contacto = contexto.Contactos.Where(x => x.IdContacto == id).FirstOrDefault();

                return _Contacto;
            }
        }

        public bool EditarContacto(Contacto contacto)
        {
            using (var contexto = new AxxisSystemDbContext())
            {
                var _Contacto = contexto.Contactos.Where(x => x.IdContacto == contacto.IdContacto).FirstOrDefault();

                if (_Contacto == null)
                {
                    Console.Write("Sin registro");
                    return false;
                }

                _Contacto.Direccion_Contacto = contexto.Direccion_Contactos.ToList();
                Mapper<Contacto>.EditarEntidad(contacto, _Contacto);
                contexto.Entry(_Contacto).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    Console.Write("Error al editar contacto");
                    return false;
                }
            }
        }

        public bool EliminarContacto (int? id)
        {
            using (var contexto = new AxxisSystemDbContext())
            {
                var _Contacto = contexto.Contactos.Where(x => x.IdContacto == id).FirstOrDefault();
                if (_Contacto == null)
                {
                    Console.Write("Sin registro");
                    return false;
                }

                _Contacto.Estado = false;
                contexto.Entry(_Contacto).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    Console.Write("Erro al eliminar el contacto");
                    return false;
                }
            }
        }
    }
}
