using Microsoft.Extensions.Configuration;
using System;

namespace Autotest.Utils
{
    public static class Startup
    {
        //{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}
        private static IConfiguration ConfigurePlatform() =>
            new ConfigurationBuilder()
            .AddJsonFile($@"Config\appsettings.Android.json")
            .Build();

        public static string ReadFromAppSettings(string value) => ConfigurePlatform().GetSection(value).Value;
    }
}
