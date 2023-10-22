using AutoMapper;
using OtusDomain.Entities;
using OtusViewModels;

namespace OtusDataTransferObject
{
    public static class StudentDTO
    {
        public static MapperConfiguration ToEntityMap() => new(cfg =>
        {

            cfg.CreateMap<StudentViewModel, StudentEntity>()
                .ForMember(src => src.Name, opt => opt.MapFrom(target => target.Name))
                .ForMember(src => src.Surname, opt => opt.MapFrom(target => target.Surname))
                .ForMember(src => src.Age, opt => opt.MapFrom(target => target.Age))
                .ForMember(src => src.Courses, opt => opt.MapFrom(target => target.Courses))
                .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));

            cfg.CreateMap<CourseViewModel, CourseEntity>()
                .ForMember(src => src.CourseName, opt => opt.MapFrom(target => target.CourseName))
                .ForMember(src => src.Students, opt => opt.MapFrom(target => target.Students))
                .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));

        });
        public static MapperConfiguration ToViewModelMap() => new(cfg =>
        {

            cfg.CreateMap<StudentEntity, StudentViewModel>()
                .ForMember(src => src.Name, opt => opt.MapFrom(target => target.Name))
                .ForMember(src => src.Surname, opt => opt.MapFrom(target => target.Surname))
                .ForMember(src => src.Age, opt => opt.MapFrom(target => target.Age))
                .ForMember(src => src.Courses, opt => opt.MapFrom(target => target.Courses))
                .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));

            cfg.CreateMap<CourseViewModel, CourseEntity>()
                .ForMember(src => src.CourseName, opt => opt.MapFrom(target => target.CourseName))
                .ForMember(src => src.Students, opt => opt.MapFrom(target => target.Students))
                .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));
        });

        public static StudentEntity ToEntity(this StudentViewModel source) => new Mapper(ToEntityMap()).Map<StudentViewModel,StudentEntity>(source);
        public static IEnumerable<StudentEntity> ToEntity(this IEnumerable<StudentViewModel> source) => new Mapper(ToEntityMap())
            .Map<IEnumerable<StudentViewModel>, IEnumerable<StudentEntity>>(source);

        public static StudentViewModel ToViewModel(this StudentEntity source) => new Mapper(ToViewModelMap()).Map<StudentEntity, StudentViewModel>(source);
        public static IEnumerable<StudentViewModel> ToViewModel(this IEnumerable<StudentEntity> source) => new Mapper(ToViewModelMap())
            .Map<IEnumerable<StudentEntity>, IEnumerable<StudentViewModel>>(source);
    }
}
