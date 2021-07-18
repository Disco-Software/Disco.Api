using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface ISubscriberService
    {
        Task<UserSubscriber> CreateSubscribe(UserSubscriber subscriber);
        Task DeleteSubscribe(int subscriberId);
        Task<List<UserSubscriber>> GetAllSubscribes(Expression<Func<UserSubscriber,bool>> subscribers);
    }
}
