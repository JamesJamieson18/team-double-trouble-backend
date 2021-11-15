using AutoMapper;
using team_double_trouble_backend.Models;

namespace team_double_trouble_backend.Helpers
{
    //used to map MakePostRequest, PostUpdateRequest in Models to Post in Entities
    public class AutoMapperPost : Profile
    {
        public AutoMapperPost()
        {

            // MakePostRequest -> Post
            CreateMap<MakePostRequest, Post>();

            // PostUpdateRequest -> Post
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