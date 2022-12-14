using AutoMapper;
using System.Reflection.PortableExecutable;
using taskboard_api.DTOs.Issue;
using taskboard_api.DTOs.User;
using taskboard_api.DTOs.UserRole;

namespace taskboard_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Issue, GetIssueDTO>();
            CreateMap<CreateIssueDTO, Issue>();
            CreateMap<UpdateIssueDTO, Issue>();
            CreateMap<User, GetUserDTO>();
            CreateMap<UserRole, GetUserRoleDTO>();
        }
    }
}
