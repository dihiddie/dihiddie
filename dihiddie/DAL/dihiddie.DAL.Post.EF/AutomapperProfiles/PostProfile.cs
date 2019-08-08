using AutoMapper;

namespace dihiddie.DAL.Post.EF.AutomapperProfiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Core.Models.Post, Context.Post>();
            CreateMap<Context.Post, Core.Models.Post>();
        }
    }
}
