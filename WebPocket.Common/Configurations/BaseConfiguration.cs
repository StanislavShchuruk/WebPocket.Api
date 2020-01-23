using System;
using Microsoft.Extensions.Configuration;

namespace WebPocket.Common.Configurations
{
    public abstract class BaseConfiguration
    {
        protected IConfigurationRoot GetConfigurations()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) 
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        protected void RaiseValueNotFoundException(string configurationKey)
        {
            throw new Exception($"appsettings key ({configurationKey}) could not be found.");
        }
    }
}
