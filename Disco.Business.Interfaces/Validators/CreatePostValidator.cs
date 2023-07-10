using Disco.Business.Interfaces.Dtos.Posts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Validators
{
    public class CreatePostValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostValidator()
        {
            When(x => x.PostSongs.Count != 0, () =>
            {
                RuleFor(j => j.PostSongNames.Count)
                    .NotNull()
                    .Equal(j => j.PostSongs.Count)
                    .WithMessage("Song must contains name");
                RuleFor(j => j.PostSongImages.Count)
                    .NotNull()
                    .Equal(j => j.PostSongs.Count)
                    .WithMessage("Song must contains name");
                RuleFor(j => j.ExecutorNames.Count)
                    .NotNull()
                    .Equal(j => j.PostSongs.Count)
                    .WithMessage("Song must contains executor name");
            });
        }
    }
}
