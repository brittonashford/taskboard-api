using AutoMapper;
using System.Reflection.PortableExecutable;
using taskboard_api.DTOs.Issue;

namespace taskboard_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Issue, GetIssueDTO>();
            CreateMap<AddIssueDTO, Issue>();
        }
    }
}
