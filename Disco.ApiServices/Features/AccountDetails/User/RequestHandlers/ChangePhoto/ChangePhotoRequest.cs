using Disco.Business.Interfaces.Dtos.AccountDetails;
using Disco.Business.Interfaces.Dtos.AccountDetails.User.ChangePhoto;
using MediatR;

namespace Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.ChangePhoto
{
    public class ChangePhotoRequest : IRequest<ChangePhotoResponseDto>
    {
        public ChangePhotoRequest(ChangePhotoRequestDto dto)
        {
            Dto = dto;
        }
        
        public ChangePhotoRequestDto Dto { get; }
    }
}
