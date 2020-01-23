using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebPocket.Common.Configurations
{
    public class DatabaseConfiguration : BaseConfiguration
    {
        private readonly string DbConnectionKey = "DatabaseConnectionString";
        
        public string GetDbConfigurationString()
        {
            return GetConfigurations().GetConnectionString(DbConnectionKey);
        }
    }
}
