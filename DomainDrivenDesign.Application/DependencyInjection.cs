using DomainDrivenDesign.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DomainDrivenDesign.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), typeof(Entity).Assembly);

			// şu satrıı typeof(Entity).Assembly); domain eventleri yakalaması için ekledik.
		});

		return services;
	}
}
