using AutoMapper;
using OtusDomain.Entities;
using Otus.Application.ApplicationModels;

namespace Otus.Application.Mappers;

public static class CourseAppModelDTO
{
    public static MapperConfiguration ToEntityMap() => new(cfg =>
    {
        cfg.CreateMap<CourseApplicationModel, CourseEntity>()
            .ForMember(src => src.CourseName, opt => opt.MapFrom(target => target.CourseName))
            .ForMember(src => src.Students, opt => opt.MapFrom(target => target.Students))
            .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));

        cfg.CreateMap<StudentApplicationModel, StudentEntity>()
            .ForMember(src => src.Name, opt => opt.MapFrom(target => target.Name))
            .ForMember(src => src.Surname, opt => opt.MapFrom(target => target.Surname))
            .ForMember(src => src.Age, opt => opt.MapFrom(target => target.Age))
            .ForMember(src => src.Courses, opt => opt.MapFrom(target => target.Courses))
            .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));
    });
    public static MapperConfiguration ToAppModelMap() => new(cfg =>
    {
        cfg.CreateMap<CourseApplicationModel, CourseEntity>()
            .ForMember(src => src.CourseName, opt => opt.MapFrom(target => target.CourseName))
            .ForMember(src => src.Students, opt => opt.MapFrom(target => target.Students))
            .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));

        cfg.CreateMap<StudentEntity, StudentApplicationModel>()
            .ForMember(src => src.Name, opt => opt.MapFrom(target => target.Name))
            .ForMember(src => src.Surname, opt => opt.MapFrom(target => target.Surname))
            .ForMember(src => src.Age, opt => opt.MapFrom(target => target.Age))
            .ForMember(src => src.Courses, opt => opt.MapFrom(target => target.Courses))
            .ForMember(src => src.Id, opt => opt.MapFrom(target => target.Id));
    });
    public static CourseEntity ToEntity(this CourseApplicationModel source) => new Mapper(ToEntityMap()).Map<CourseApplicationModel, CourseEntity>(source);
    public static IEnumerable<CourseEntity> ToEntity(this IEnumerable<CourseApplicationModel> source) => new Mapper(ToEntityMap())
        .Map<IEnumerable<CourseApplicationModel>, IEnumerable<CourseEntity>>(source);

    public static CourseApplicationModel ToAppModel(this CourseEntity source) => new Mapper(ToAppModelMap()).Map<CourseEntity, CourseApplicationModel>(source);
    public static IEnumerable<CourseApplicationModel> ToAppModel(this IEnumerable<CourseEntity> source) => new Mapper(ToAppModelMap())
        .Map<IEnumerable<CourseEntity>, IEnumerable<CourseApplicationModel>>(source);
}
