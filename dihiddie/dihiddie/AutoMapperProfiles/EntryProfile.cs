using AutoMapper;
using dihiddie.DAL.Post.Core.Models;
using dihiddie.ViewModels;
using System.Text;

namespace dihiddie.AutoMapperProfiles
{
    public class EntryProfile : Profile
    {
        public EntryProfile()
        {
            CreateMap<EntryViewModel, PostInformation>()
                .ForMember(x => x.PreviewText, o => o.MapFrom(y => y.Description))
                .ForMember(x => x.Id, o => o.MapFrom(y => y.PostInformationId))
                .ForMember(x => x.Tags, o => o.Ignore());

            CreateMap<PostInformation, EntryViewModel>()
                .ForMember(x => x.Description, o => o.MapFrom(y => y.PreviewText))
                // .ForMember(x => x.IsBlogPost, o => o.MapFrom(y => y.IsBlogPost))
                .ForMember(x => x.PostInformationId, o => o.MapFrom(y => y.Id));

            CreateMap<PostContentViewModel, PostContent>().ForMember(x => x.Content,
                o => o.MapFrom(y => Encoding.UTF8.GetBytes(y.Content)));

            CreateMap<PostContent, PostContentViewModel>().ForMember(x => x.Content,
                o => o.MapFrom(y => Encoding.UTF8.GetString(y.Content)));
        }
    }
}