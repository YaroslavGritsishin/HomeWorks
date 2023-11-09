using Application.DataTransferObject.ViewModels;
using AutoMapper;
using Domain.Common.Entities;

namespace Application.DataTransferObject.Mappers.Profiles
{
    public class CustomerViewModelProfile: Profile
    {
        public CustomerViewModelProfile()
        {
            CreateMap<CustomerViewModel, CustomerEntity>()
                .ReverseMap();
        }
    }
}
