using AutoMapper;
using EduHome.Core.Entities;
using EduHome.UI.Areas.EduHomeAdmin.ViewModels.SliderViewModels;

namespace EduHome.UI.Mappers;

public class SliderProfile:Profile
{
    public SliderProfile()
    {
        CreateMap<SliderPostVM, Slider>().ReverseMap();
    }
}
