using TwitterClone.Dal.Abstract;
using TwitterClone.Dal.Concrete.Context;
using TwitterClone.Dal.Concrete.Repositories;
using TwitterClone.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TwitterClone.Business.Abstract;
using TwitterClone.Business.Concrete;

namespace TwitterClone.Business.Containers.MicrosoftIoC
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TwitterContext>(ServiceLifetime.Singleton);

            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));


            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<ITweetService, TweetManager>();
            services.AddScoped<IFollowerService, FollowerManager>();
            services.AddScoped<ILikeService, LikeManager>();
            services.AddScoped<IReplyService, ReplyManager>();
            services.AddScoped<IRetweetService, RetweetManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<INotificationDal, EfNotificationRepository>();
            services.AddScoped<IMessageDal, EfMessageRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<ITweetDal, EfTweetRepository>();
            services.AddScoped<IFollowerDal, EfFollowerRepository>();
            services.AddScoped<ILikeDal, EfLikeRepository>();
            services.AddScoped<IReplyDal, EfReplyRepository>();
            services.AddScoped<IRetweetDal, EfRetweetRepository>();


        }

    }
}
