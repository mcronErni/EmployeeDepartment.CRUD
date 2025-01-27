using AutoMapper;
using EmployeeDepartmentCRUD.Domain.DTOs.Department;
using EmployeeDepartmentCRUD.Domain.DTOs.EmployeeDTOs;
using EmployeeDepartmentCRUD.Domain.Models;

namespace EmployeeDepartmentCRUD.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateDepartmentDTO, Department>().ReverseMap();
            CreateMap<Department, ReadDepartmentDTO>()
                .ForMember(dest => dest.DepNameAbbr, opt => opt.MapFrom(src => $"{src.Abbr} - {src.DepartmentName}"));
            CreateMap<UpdateDepartmentDTO, Department>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ReadDepartmentDTO, Department>();

            //Employee
            CreateMap<CRUEmployeeDTO, Employee>().ReverseMap();
        }
    }
}
