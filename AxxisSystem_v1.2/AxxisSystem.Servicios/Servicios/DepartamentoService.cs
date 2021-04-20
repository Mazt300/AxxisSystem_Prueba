using AxxisSystem.Model.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxxisSystem.Estructura;
using AxxisSystem.Model;
using System;
using AutoMapper;
using System.Data.Entity;

namespace AxxisSystem.Servicios
{
    public class DepartamentoService
    {

        public List<Departamento> TodosLosDepartamentosActivos()
        {
            using (var Contexto = new AxxisSystemDbContext())
            {
                List<Departamento> ListaDepartamento = new List<Departamento>();
                ListaDepartamento = Contexto.Departamentos.Where(x => x.Estado == true).ToList();

                return ListaDepartamento;
            }
        }
        public List<Departamento> TodosLosDepartamentos()
        {
            using (var Contexto = new AxxisSystemDbContext())
            {
                List<Departamento> ListaDepartamento = new List<Departamento>();
                ListaDepartamento = Contexto.Departamentos.ToList();

                return ListaDepartamento;
            }
        }

        public bool GuardarDepartamento(Departamento departamento)
        {
            using (var Contexto = new AxxisSystemDbContext())
            {
                Contexto.Set<Departamento>().Add(departamento);

                if (Contexto.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Departamento Obtener_DepartamentoxId(int? id)
        {
            if (id > 0)
            {
                using (var contexto = new AxxisSystemDbContext())
                {
                    var _departamento = contexto.Departamentos.Find(id);

                    return _departamento;
                }
            }
            return null;
        }

        public bool EditarDepartamento(Departamento departamento)
        {
            using (var contexto = new AxxisSystemDbContext())
            {
                var _Departamento = contexto.Departamentos.Where(x => x.IdDepartamento == departamento.IdDepartamento).FirstOrDefault();
                if (_Departamento == null)
                {
                    Console.Write("Sin registro");
                    return false;
                }

                departamento.Direccion_Contacto = contexto.Direccion_Contactos.ToList();
                Mapper<Departamento>.EditarEntidad(departamento, _Departamento);
                contexto.Entry(_Departamento).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    Console.Write("Error al editar departamento");
                    return false;
                }
            }
        }

        public bool EliminarDepartamento(int? id )
        {
            using (var contexto = new AxxisSystemDbContext())
            {
                var _departamento = contexto.Departamentos.Where(x => x.IdDepartamento == id).FirstOrDefault();
                if (_departamento == null)
                {
                    Console.Write("Sin registro");
                    return false;
                }

                _departamento.Estado = false;
                contexto.Entry(_departamento).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    Console.Write("Error al eliminar registro");
                    return false;
                }

            }
        }

    }
}
