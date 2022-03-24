﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vivarni.DDD.Core.Repositories;
using Vivarni.DDD.Infrastructure.Caching;
using Vivarni.DDD.Infrastructure.DomainEvents;

namespace Vivarni.DDD.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddVivarniInfrastructure(this IServiceCollection @this, Action<VivarniInfrastructureOptionsBuilder> optionsBuilder)
        {
            @this.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            @this.AddScoped(typeof(IDomainEventBrokerService), typeof(DomainEventBrokerService));
            @this.AddSingleton<ICachingProvider, CachingProviderStub>();

            var options = new VivarniInfrastructureOptionsBuilder();
            optionsBuilder.Invoke(options);
            @this.Add(new ServiceDescriptor(typeof(ICachingProvider), options.CachingProviderType, options.CachingProviderServiceLifetime));

            return @this;
        }
    }
}
