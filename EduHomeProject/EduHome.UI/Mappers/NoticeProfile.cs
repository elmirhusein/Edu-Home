using AutoMapper;
using EduHome.Core.Entities;
using EduHome.UI.Areas.EduHomeAdmin.ViewModels.NoticeViewModels;
using EduHome.UI.Areas.EduHomeAdmin.ViewModels.SliderViewModels;

namespace EduHome.UI.Mappers;

public class NoticeProfile:Profile
{
    public NoticeProfile()
    {
        CreateMap<NoticePostVM, Notice>().ReverseMap();
    }
}
