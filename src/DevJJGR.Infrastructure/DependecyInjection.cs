using System;
using Donouts.Application.Common.Interfaces;
using Donouts.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Donouts.Infrastructure
{
	public static partial class DependecyInjection
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddMemoryCache();
			services.AddTransient<IRabbitMQService, RabbitMQService>();
			return services;
		}
	}
}

