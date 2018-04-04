using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rissole.Mongo
{
    public static class MongoServiceExtension
    {
        public static IServiceCollection AddMongoContext<TContext>(
               this IServiceCollection serviceCollection,
               Action<MongoOptionsBuilder> optionsAction = null,
               ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
               ServiceLifetime optionsLifetime = ServiceLifetime.Scoped
               ) where TContext : MongoContext
        {
            var optionsBuilder = new MongoOptionsBuilder(optionsAction);

            var optionsService = new ServiceDescriptor(typeof(MongoOptions), x => optionsBuilder.Options, optionsLifetime);
            var contextService = new ServiceDescriptor(typeof(TContext), typeof(TContext), contextLifetime);

            serviceCollection.Add(optionsService);
            serviceCollection.Add(contextService);

            return serviceCollection;
        }
    }
}
