using Integrador.DTOs;
using Integrador.Models;
using AutoMapper;

namespace Integrador
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            // Mapeo de las clases a sus DTOs
            // Hace conversiones

            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

            CreateMap<Servicio, ServicioDTO>().ReverseMap();

            CreateMap<Proyecto, ProyectoDTO>().ReverseMap();

            CreateMap<Trabajo, TrabajoDTO>().ReverseMap();
        }
    }
}
