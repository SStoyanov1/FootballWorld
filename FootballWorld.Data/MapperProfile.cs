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
            CreateMap<Article, DetailsArticleViewModel>()
                .ForMember(dest => dest.AuthorName,
                 opts => opts.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<DetailsArticleViewModel, Article>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                    .ForMember(dest => dest.Comments, opt => opt.Ignore())
                    .ForMember(dest => dest.Category, opt => opt.Ignore());


            CreateMap<CreateArticleViewModel, Article>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.ImageName,
                 opts => opts.MapFrom(src => src.Image.FileName))
                .ForMember(dest => dest.DateCreated,
                 opts => opts.MapFrom(src => DateTime.Now));

            CreateMap<ApplicationUser, UsersListViewModel>().ReverseMap();
            CreateMap<Article, IndexArticleViewModel>().ReverseMap();

            CreateMap<SubmitCommentViewModel, Comment>()
            .ForMember(dest => dest.Content,
                 opts => opts.MapFrom(src => src.Comment)).ReverseMap();
            CreateMap<Comment, CommentViewModel>()
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.Author.ProfileImage)).ReverseMap();

            CreateMap<Article, ListArticleViewModel>().ReverseMap();
        }
    }
}
