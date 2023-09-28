using AutoMapper;
using Lecture_No4_HW.ViewModels;
using OtusDomain.Entities;

namespace OtusDataTransferObject
{
    public static class CourseDTO
    {
        public static MapperConfiguration ToEntityMap() => new(cfg =>
        {
            cfg.CreateMap<CourseViewModel, CourseEntity>()
                .ForMember(src => src.CourseName, opt => opt.MapFrom(target => target.CourseName))
                .ForMember(src => src.Students, opt => opt.MapFrom(target => target.Students))
                .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));

            cfg.CreateMap<StudentViewModel, StudentEntity>()
                .ForMember(src => src.Name, opt => opt.MapFrom(target => target.Name))
                .ForMember(src => src.Surname, opt => opt.MapFrom(target => target.Surname))
                .ForMember(src => src.Age, opt => opt.MapFrom(target => target.Age))
                .ForMember(src => src.Courses, opt => opt.MapFrom(target => target.Courses))
                .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));
        });
        public static MapperConfiguration ToViewModelMap() => new(cfg =>
        {
            cfg.CreateMap<CourseViewModel, CourseEntity>()
                .ForMember(src => src.CourseName, opt => opt.MapFrom(target => target.CourseName))
                .ForMember(src => src.Students, opt => opt.MapFrom(target => target.Students))
                .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));

            cfg.CreateMap<StudentEntity, StudentViewModel>()
                .ForMember(src => src.Name, opt => opt.MapFrom(target => target.Name))
                .ForMember(src => src.Surname, opt => opt.MapFrom(target => target.Surname))
                .ForMember(src => src.Age, opt => opt.MapFrom(target => target.Age))
                .ForMember(src => src.Courses, opt => opt.MapFrom(target => target.Courses))
                .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));
        });
        public static CourseEntity ToEntity(this CourseViewModel source) => new Mapper(ToEntityMap()).Map<CourseViewModel, CourseEntity>(source);
        public static IEnumerable<CourseEntity> ToEntity(this IEnumerable<CourseViewModel> source) => new Mapper(ToEntityMap())
            .Map<IEnumerable<CourseViewModel>, IEnumerable<CourseEntity>>(source);

        public static CourseViewModel ToViewModel(this CourseEntity source) => new Mapper(ToViewModelMap()).Map<CourseEntity, CourseViewModel>(source);
        public static IEnumerable<CourseViewModel> ToViewModel(this IEnumerable<CourseEntity> source) => new Mapper(ToViewModelMap())
            .Map<IEnumerable<CourseEntity>, IEnumerable<CourseViewModel>>(source);
    }
}
