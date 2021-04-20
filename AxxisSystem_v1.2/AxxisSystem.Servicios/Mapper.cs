using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxxisSystem.Servicios
{
    public static class Mapper<T> where T : class
    {

        public static void EditarEntidad(T source ,T outData)
        {
            var config = new MapperConfiguration(x => x.CreateMap<T, T>());

            IMapper mapper = config.CreateMapper();
            mapper.Map(source, outData);

        }
    }
}
