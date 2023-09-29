using AutoMapper;
using Otus.Application.ApplicationModels;
using OtusDomain.Entities;

namespace Otus.Application.Mappers
{
    public static class StudentAppModelDTO
    {
        public static MapperConfiguration ToEntityMap() => new(cfg =>
        {

            cfg.CreateMap<StudentApplicationModel, StudentEntity>()
                .ForMember(src => src.Name, opt => opt.MapFrom(target => target.Name))
                .ForMember(src => src.Surname, opt => opt.MapFrom(target => target.Surname))
                .ForMember(src => src.Age, opt => opt.MapFrom(target => target.Age))
                .ForMember(src => src.Courses, opt => opt.MapFrom(target => target.Courses))
                .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));

            cfg.CreateMap<CourseApplicationModel, CourseEntity>()
                .ForMember(src => src.CourseName, opt => opt.MapFrom(target => target.CourseName))
                .ForMember(src => src.Students, opt => opt.MapFrom(target => target.Students))
                .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));

        });
        public static MapperConfiguration ToViewModelMap() => new(cfg =>
        {

            cfg.CreateMap<StudentEntity, StudentApplicationModel>()
                .ForMember(src => src.Name, opt => opt.MapFrom(target => target.Name))
                .ForMember(src => src.Surname, opt => opt.MapFrom(target => target.Surname))
                .ForMember(src => src.Age, opt => opt.MapFrom(target => target.Age))
                .ForMember(src => src.Courses, opt => opt.MapFrom(target => target.Courses))
                .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));

            cfg.CreateMap<CourseApplicationModel, CourseEntity>()
                .ForMember(src => src.CourseName, opt => opt.MapFrom(target => target.CourseName))
                .ForMember(src => src.Students, opt => opt.MapFrom(target => target.Students))
                .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));
        });

        public static StudentEntity ToEntity(this StudentApplicationModel source) => new Mapper(ToEntityMap()).Map<StudentApplicationModel, StudentEntity>(source);
        public static IEnumerable<StudentEntity> ToEntity(this IEnumerable<StudentApplicationModel> source) => new Mapper(ToEntityMap())
            .Map<IEnumerable<StudentApplicationModel>, IEnumerable<StudentEntity>>(source);

        public static StudentApplicationModel ToAppModel(this StudentEntity source) => new Mapper(ToViewModelMap()).Map<StudentEntity, StudentApplicationModel>(source);
        public static IEnumerable<StudentApplicationModel> ToAppModel(this IEnumerable<StudentEntity> source) => new Mapper(ToViewModelMap())
            .Map<IEnumerable<StudentEntity>, IEnumerable<StudentApplicationModel>>(source);
    }
}
