using AutoMapper;
using dihiddie.DAL.Post.EF.Context;
using Tag = dihiddie.DAL.Post.Core.Models.Tag;

namespace dihiddie.DAL.Post.EF.AutomapperProfiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Core.Models.PostInformation, PostInformation>()
                .ForMember(x => x.CreateDateTime, o => o.Ignore())
                .ForMember(x => x.UpdateDateTime, o => o.Ignore())
                .ForMember(x => x.PostId, o => o.MapFrom(y => y.PostContentId));

            CreateMap<Tag, Context.Tag>();
            CreateMap<Context.Tag, Tag>();

            CreateMap<PostInformation, Core.Models.PostInformation>()
                .ForMember(x => x.PostContentId, opt => opt.MapFrom(x => x.PostId));
            CreateMap<Core.Models.PostContent, PostContent>();
            CreateMap<PostContent, Core.Models.PostContent>();
        }
    }
}