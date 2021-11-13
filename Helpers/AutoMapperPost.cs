using AutoMapper;
using team_double_trouble_backend.Entities;
using team_double_trouble_backend.Models;

//Using AutoMapper to map between User in Entities and AuthenticateResponse, RegisterRequest, UpdateRequest in Models

namespace team_double_trouble_backend.Helpers
{
    public class AutoMapperPost : Profile
    {
        public AutoMapperPost()
        {
            // User -> AuthenticateResponse
            // CreateMap<User, AuthenticateResponse>();

            // RegisterRequest -> User
            CreateMap<MakePostRequest, Post>();

            // UpdateRequest -> User
            CreateMap<PostUpdateRequest, Post>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
        }
    }
}