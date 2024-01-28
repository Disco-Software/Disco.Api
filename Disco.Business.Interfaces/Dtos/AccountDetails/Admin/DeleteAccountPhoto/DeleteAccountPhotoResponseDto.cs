using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.DeleteAccountPhoto
{
    public class DeleteAccountPhotoResponseDto
    {
        public DeleteAccountPhotoResponseDto() { }
        public DeleteAccountPhotoResponseDto(AccountDto account)
        {
            Account = account;
        }

        public AccountDto Account { get; set; }
    }
}
