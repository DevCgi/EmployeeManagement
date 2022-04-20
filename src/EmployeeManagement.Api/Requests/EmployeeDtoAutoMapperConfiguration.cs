using AutoMapper;
using EmployeeManagement.Api.Requests.AddEmployee;
using EmployeeManagement.Api.Requests.EditEmployee;
using EmployeeManagement.Api.Requests.GetEmployees;
using EmployeeManagement.Domain.Dtos;

namespace EmployeeManagement.Api.Requests
{
    public class EmployeeDtoAutoMapperConfiguration : Profile
    {
        public EmployeeDtoAutoMapperConfiguration() 
            : base(nameof(EmployeeDtoAutoMapperConfiguration))
        {
            CreateMap<AddEmployeeRequest, AddEmployeeDto>()
                .ForMember(x => x.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(x => x.Gender, opt => opt.MapFrom(src => src.Gender));

            CreateMap<EditEmployeeRequest, EditEmployeeDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => new Guid(src.Id)))
                .ForMember(x => x.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(x => x.Gender, opt => opt.MapFrom(src => src.Gender));

            CreateMap<GetEmployeeDto, EmployeeResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(x => x.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(x => x.RegistrationNumber, opt => opt.MapFrom(src => src.RegistrationNumber));
        }
    }
}
