using Melior.InterviewQuestion.Types;
using Microsoft.Extensions.Configuration;
using System;

namespace Melior.InterviewQuestion.Services.Configuration
{
    public class AppConfigService : IAppConfigService
    {
        private IConfiguration configBuilder { get; set; }
        private AppSettings config { get; set; }
        public AppConfigService()
        {
            this.configBuilder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appSettings.json", false, true)
                .Build();

            this.config = new AppSettings();
            this.configBuilder.Bind(config);
        }

        public string GetDataStoreType()
        {
            return this.config.DataStoreType;
        }

        public bool DataStoreIsBackup()
        {
            return this.config.DataStoreType.Equals("Backup");
        }

    }
}
