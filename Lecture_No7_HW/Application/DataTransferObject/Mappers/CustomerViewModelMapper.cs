using Application.DataTransferObject.Mappers.Profiles;
using Application.DataTransferObject.ViewModels;
using AutoMapper;
using Domain.Common.Entities;

namespace Application.DataTransferObject.Mappers
{
    public static class CustomerViewModelMapper
    {

        private static MapperConfiguration CustomerMap() => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CustomerViewModelProfile>();
        });
        
        public static CustomerEntity ToEntity(this CustomerViewModel viewModel) =>
            new Mapper(CustomerMap()).Map<CustomerEntity>(viewModel);

        public static IEnumerable<CustomerEntity> ToEntity(this IEnumerable<CustomerViewModel> viewModel) =>
            new Mapper(CustomerMap()).Map<IEnumerable<CustomerEntity>>(viewModel);

        public static CustomerViewModel ToViewModel(this CustomerEntity viewModel) =>
           new Mapper(CustomerMap()).Map<CustomerViewModel>(viewModel);

        public static IEnumerable<CustomerViewModel> ToViewModel(this IEnumerable<CustomerEntity> viewModel) =>
            new Mapper(CustomerMap()).Map<IEnumerable<CustomerViewModel>>(viewModel);
    }
}
