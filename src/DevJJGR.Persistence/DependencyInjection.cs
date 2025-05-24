using AutoMapper;
using Donouts.Application.Common.Interfaces;
using Donouts.Application.Mappings;
using Donouts.Infrastructure.Services;
using Donouts.Persistance.Repository.Activities;
using Donouts.Persistance.Repository.Appointment;
using Donouts.Persistance.Repository.Donouts;
using Donouts.Persistance.Repository.Messages;
using Donouts.Persistance.Repository.Security.Auth;
using Donouts.Persistence.Common;
using Donouts.Persistence.Repository.Security.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Donouts.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddScoped(provider => new MapperConfiguration(x =>
            {
                x.AddProfile(new UsersProfile());
                x.AddProfile(new RoleProfile());
                x.AddProfile(new TypeDonoutsProfile());
                x.AddProfile(new SalesDonoutsProfile());
                x.AddProfile(new ActivitiesProfile());
                x.AddProfile(new CalendarioActividadesProfile());
                x.AddProfile(new MessagesProfile());
            }).CreateMapper());

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ITypeDonoutsRepository, TypeDonoutsRepository>();
            services.AddScoped<ISalesDonoutsRepository, SalesDonoutsRepository>();
            services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
            services.AddScoped<ICalendarRepository, CalendarRepository>();
            services.AddScoped<IMessagesRepository, MessagesRepository>();
            return services;
        }
    }
}
