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

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Models.Service, ServiceDTO>().ReverseMap();

            CreateMap<Project, ProjectDTO>().ReverseMap();

            CreateMap<Job, JobDTO>().ReverseMap();
        }
    }
}
