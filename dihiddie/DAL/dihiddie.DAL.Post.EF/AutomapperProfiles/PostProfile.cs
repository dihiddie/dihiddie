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

            CreateMap<Context.PostInformation, Core.Models.PostInformation>()
                // .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Post.Content))
                .ForMember(x => x.PostContentId, opt => opt.MapFrom(x => x.PostId));

            // CreateMap<PostContent, Core.Models.Post>().ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content));
            CreateMap<Core.Models.PostContent, PostContent>().ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content));


        }
    }
}