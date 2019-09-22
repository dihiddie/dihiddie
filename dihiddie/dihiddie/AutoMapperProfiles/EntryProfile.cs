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
                .ForMember(x => x.Tags, o => o.Ignore())
                .ForMember(x => x.PostContent, o => o.Ignore());

            CreateMap<PostContentViewModel, PostContent>().ForMember(x => x.Content,
                o => o.MapFrom(y => Encoding.UTF8.GetBytes(y.Content)));
        }
    }
}