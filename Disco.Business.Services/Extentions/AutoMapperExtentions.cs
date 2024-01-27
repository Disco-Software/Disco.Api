using AutoMapper;
using Disco.Business.Services.Mapper;
using Disco.Business.Services.Mapper.Account.User;
using Disco.Business.Services.Mapper.AccountDetails.Admin;
using Disco.Business.Services.Mapper.AccountDetails.User;
using Disco.Business.Services.Mapper.AccountPassword.Admin;
using Disco.Business.Services.Mapper.Comment.User;
using Disco.Business.Services.Mapper.Follower;
using Disco.Business.Services.Mapper.Group;
using Disco.Business.Services.Mapper.Like.User;
using Disco.Business.Services.Mapper.Message;
using Disco.Business.Services.Mapper.Post.User;
using Disco.Business.Services.Mapper.PostImage;
using Disco.Business.Services.Mapper.PostSong;
using Disco.Business.Services.Mapper.PostVideo;
using Disco.Business.Services.Mapper.Role.Admin;
using Disco.Business.Services.Mapper.Story.User;
using Disco.Business.Services.Mapper.StoryImage;
using Disco.Business.Services.Mapper.StoryVideo;
using Disco.Business.Services.Mapper.Ticket.Admin;
using Disco.Business.Services.Mapper.Ticket.User;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Business.Services.Extentions
{
    public static class AutoMapperExtentions
    {
        public static void AddAutoMapper(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSingleton(conf => new MapperConfiguration(options =>
            {
                #region Admin
                options.AddProfile(new Mapper.Account.Admin.LogInMappingProfile());
                options.AddProfile(new Mapper.Account.Admin.RefreshTokenMappingProfile());
                options.AddProfile(new CreateAccountMappingProfile());
                options.AddProfile(new GetAccountsByPeriotMappingProfile());
                options.AddProfile(new GetAllAccountsMappingProfile());
                options.AddProfile(new ChangeSelectedUserPasswordMappingProfile());
                options.AddProfile(new ChangeAccountPhotoMappingProfile());
                options.AddProfile(new SearchAccountsMappingProfile());
                options.AddProfile(new ChangeAccountEmailMappingProfile());
                options.AddProfile(new ChangeAccountRoleMappingProfile());
                options.AddProfile(new GetAccountMappingProfile());
                options.AddProfile(new GetAllTicketsMappingProfile());
                #endregion

                #region User
                options.AddProfile(new AppleLogInMappingProfile());
                options.AddProfile(new RegisterMappingProfile());
                options.AddProfile(new Mapper.Account.User.LogInMappingProfile());
                options.AddProfile(new FacebookMappingProfile());
                options.AddProfile(new GoogleMappingProfile());
                options.AddProfile(new Mapper.Account.User.RefreshTokenMappingProfile());
                options.AddProfile(new ChangePhotoMappingProfile());
                options.AddProfile(new GetCurrentUserMappingProfile());
                options.AddProfile(new CreateCommentMappingProfile());
                options.AddProfile(new UpdateCommentMappingProfile());
                options.AddProfile(new CreateFollowerMappingProfile());
                options.AddProfile(new GetFollowerMappingProfile());
                options.AddProfile(new GetFollowersMappingProfile());
                options.AddProfile(new GetFollowingMappingProfile());
                options.AddProfile(new GetRecomendedMappingProfile());
                options.AddProfile(new CreateGroupMappingProfile());
                options.AddProfile(new GetAllGroupsMappingProfile());
                options.AddProfile(new GetAllGroupMessagesMappingProfile());
                options.AddProfile(new CreateLikeMappingProfile());
                options.AddProfile(new CreateMessageMappingProfile());
                options.AddProfile(new UpdateMessageMappingProfile());
                options.AddProfile(new CreatePostImageMappingProfile());
                options.AddProfile(new GetCurrentUserPostImagesMappingProfile());
                options.AddProfile(new GetPostImagesMappingProfile());
                options.AddProfile(new CreatePostSongMappingProfile());
                options.AddProfile(new GetCurrentUserPostSongsMappingProfile());
                options.AddProfile(new GetPostSongsMappingProfile());
                options.AddProfile(new CreatePostVideoMappingProfile());
                options.AddProfile(new GetCurrentUserPostVideosMappingProfile());
                options.AddProfile(new GetPostVideosMappingProfile());
                options.AddProfile(new CreatePostMappingProfile());
                options.AddProfile(new GetCurrentUserPostsMappingProfile());
                options.AddProfile(new GetPostsMappingProfile());
                options.AddProfile(new GetRolesMappingProfile());
                options.AddProfile(new CreateStoryImageMappingProfile());
                options.AddProfile(new GetStoryImagesMappingProfile());
                options.AddProfile(new GetCurrentStoryImageMappingProfile());
                options.AddProfile(new CreateStoryVideoMappingProfile());
                options.AddProfile(new GetAllStoryVideosMappingProfile());
                options.AddProfile(new GetCurrentStoryVideosMappingProfile());
                options.AddProfile(new CreateStoryMappingProfile());
                options.AddProfile(new GetAllStoriesMappingProfile());
                options.AddProfile(new GetStoryMappingProfile());
                options.AddProfile(new CreateTicketMappingProfile());
                #endregion

                options.AddProfile(new ErrorMappingProfile());
            }).CreateMapper());
        }
    }
}
