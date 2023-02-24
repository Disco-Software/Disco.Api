using AutoMapper;
using Disco.Business.Interfaces.Dtos.Roles;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Services.Mappers
{
    public class RoleMapProfile : Profile
    {
        public RoleMapProfile()
        {
            CreateMap<CreateRoleDto, Role>();
        }
    }
}
