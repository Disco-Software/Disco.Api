using Disco.Business.Interfaces.Dtos.AccountDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.ChangePhoto
{
    public class ChangePhotoRequest : IRequest<Domain.Models.Models.User>
    {
        public ChangePhotoRequest(UpdateAccountDto dto)
        {
            Dto = dto;
        }
        
        public UpdateAccountDto Dto { get; }
    }
}
