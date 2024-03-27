using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.DeleteAccountPhoto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.DeleteAccountPhoto
{
    public class DeleteAccountPhotoRequest : IRequest<DeleteAccountPhotoResponseDto>
    {
        public DeleteAccountPhotoRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
