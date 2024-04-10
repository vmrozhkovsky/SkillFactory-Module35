using AutheticationService.Controllers;
using AutoMapper;

namespace AutheticationService;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserViewModel>().ConstructUsing(user => new UserViewModel(user));
        CreateMap<UserViewModel, User>();
    }
}