using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountPhoto;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.ChangeAccountPhoto
{
    public class ChangeAccountPhotoRequest : IRequest<ChangeAccountPhotoResponseDto>
    {
        public ChangeAccountPhotoRequest(
            IFormFile photo,
            int userId)
        {
            Photo = photo;
            Userid = userId;
        }

        public IFormFile Photo { get; }
        public int Userid {  get; }
    }
}
