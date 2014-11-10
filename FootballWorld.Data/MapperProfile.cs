using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

using AutoMapper;

using FootballWorld.Model;
using FootballWorld.ViewModel;
using System.IO;

namespace FootballWorld.Data
{
    public class MapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Article, DetailsArticleViewModel>();
            CreateMap<DetailsArticleViewModel, Article>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

            CreateMap<CreateArticleViewModel, Article>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.ImageName,
                 opts => opts.MapFrom(src => src.Image.FileName))
                .ForMember(dest => dest.DateCreated,
                 opts => opts.MapFrom(src => DateTime.Now));

            CreateMap<ApplicationUser, UsersListViewModel>().ReverseMap();
        }
    }
}
