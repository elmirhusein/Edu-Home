using AutoMapper;
using EduHome.Core.Entities;
using EduHome.UI.Areas.EduHomeAdmin.ViewModels.BlogViewModels;

namespace EduHome.UI.Mappers;

public class BlogProfile:Profile
{
    public BlogProfile()
    {
        CreateMap<BlogPostVM, Blog>().ReverseMap();
    }
}
