﻿using Disco.DAL.EF;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.DAL.Repositories
{
    public class StoryRepository : Base.BaseRepository<Story, int>
    {
        public StoryRepository(ApiDbContext ctx) : base(ctx) { }

        public async Task Add(Story item, Profile profile)
        {
            await ctx.Stories.AddAsync(item);
           
            profile.Stories.Add(item);

            await ctx.SaveChangesAsync();
        }

        public async Task<List<Story>> GetAll(int profileId)
        {
            var storyList = new List<Story>();

            var profile = await ctx.Profiles
                .Include(u => u.User)
                .Include(f => f.Friends)
                .ThenInclude(p => p.ProfileFriend)
                .ThenInclude(s => s.Stories)
                .ThenInclude(si => si.StoryImages)
                .Include(f => f.Friends)
                .ThenInclude(p => p.ProfileFriend)
                .ThenInclude(p => p.Stories)
                .ThenInclude(s => s.StoryVideos)
                .Include(f => f.Friends)
                .ThenInclude(p => p.UserProfile)
                .Include(f => f.Friends)
                .ThenInclude(p => p.ProfileFriend)
                .ThenInclude(s => s.Stories)
                .ThenInclude(s => s.StoryImages)
                .Include(f => f.Friends)
                .ThenInclude(f => f.ProfileFriend)
                .ThenInclude(f => f.Stories)
                .ThenInclude(f => f.StoryVideos)
                .Where(u => u.Id == profileId)
                .FirstOrDefaultAsync();
            
            storyList.AddRange(profile.Stories);

            foreach (var friend in profile.Friends)
                storyList.AddRange(friend.ProfileFriend.Stories);

           return storyList.OrderByDescending(d => d.DateOfCreation).ToList();
        }

        public override async Task Remove(int id)
        {
            var story = await ctx.Stories
                .Include(i => i.StoryImages)
                .Include(v => v.StoryVideos)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
            story.Profile.Stories.Remove(story);
            ctx.Stories.Remove(story);
        }

        public override Task<Story> Get(int id)
        {
            var story = ctx.Stories
                .Include(i => i.StoryImages)
                .Include(v => v.StoryVideos)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
            return story;
        }
    }
}