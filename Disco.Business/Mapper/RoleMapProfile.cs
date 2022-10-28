using AutoMapper;
using Disco.Business.Dtos.Roles;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Mapper
{
    public class RoleMapProfile : Profile
    {
        public RoleMapProfile()
        {
            CreateMap<CreateRoleDto, Role>();
        }
    }
}
