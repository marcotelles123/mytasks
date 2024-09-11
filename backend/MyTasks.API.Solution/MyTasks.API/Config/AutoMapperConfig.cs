using AutoMapper;
using MyTasks.API.DTOs;
using MyTasks.Domain.VO;
using System.Threading.Tasks;

namespace MyTasks.API.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<MyTaskDTO, MyTaskVO>();
            CreateMap<MyTaskVO, MyTaskDTO>();
        }
    }
}