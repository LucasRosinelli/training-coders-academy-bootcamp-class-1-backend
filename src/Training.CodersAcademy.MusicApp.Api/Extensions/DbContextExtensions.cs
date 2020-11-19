using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Training.CodersAcademy.MusicApp.Api.Abstractions.Enums;

namespace Training.CodersAcademy.MusicApp.Api.Extensions
{
    /// <summary>
    /// Database context extensions.
    /// </summary>
    public static class DbContextExtensions
    {
        private const string ConfigurationDbProvider = "DbProvider";

        /// <summary>
        /// Configures the <see cref="DbContext"/> provider based on <see cref="IConfiguration"/> provided.
        /// </summary>
        /// <param name="options">The <see cref="DbContextOptionsBuilder"/>.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/>.</param>
        /// <returns>The <see cref="DbContextOptionsBuilder"/> with provider properly configured.</returns>
        /// <exception cref="NotSupportedException">Thrown when not supported provider was found.</exception>
        /// <exception cref="ArgumentException">Thrown when connection string setting was not found.</exception>
        public static DbContextOptionsBuilder UseProvider(this DbContextOptionsBuilder options, IConfiguration configuration)
        {
            var configurationDbProvider = configuration[ConfigurationDbProvider];
            var hasValidProvider = Enum.TryParse<SupportedDbProvider>(configurationDbProvider, true, out var dbProvider);
            if (!hasValidProvider)
            {
                throw new NotSupportedException($"{configurationDbProvider} is not supported as a database provider.");
            }

            var connectionStringName = $"BootcampConnection{dbProvider}";
            var connectionString = configuration.GetConnectionString(connectionStringName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"No connection string setting provided at {connectionStringName}.");
            }

            switch (dbProvider)
            {
                case SupportedDbProvider.SqlServer:
                    options.UseSqlServer(connectionString);
                    break;
                case SupportedDbProvider.Sqlite:
                    options.UseSqlite(connectionString);
                    break;
            }

            return options;
        }
    }
}
