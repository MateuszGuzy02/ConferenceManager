﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ConferenceManager.Data;
using Volo.Abp.DependencyInjection;

namespace ConferenceManager.EntityFrameworkCore;

public class EntityFrameworkCoreConferenceManagerDbSchemaMigrator
    : IConferenceManagerDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreConferenceManagerDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the ConferenceManagerDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ConferenceManagerDbContext>()
            .Database
            .MigrateAsync();
    }
}
