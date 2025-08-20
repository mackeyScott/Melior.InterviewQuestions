using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.UnitTesting
{
    public class AppConfigService : IDisposable
    {
        Services.Configuration.AppConfigService appConfigService;
        public AppConfigService() {
            this.appConfigService = new Services.Configuration.AppConfigService();
        }
        public void Dispose(){}

        [Fact]
        public void ItWillCheckIfBackup()
        {
            Assert.True(this.appConfigService.DataStoreIsBackup());
        }

        [Fact]
        public void ItWillReturnType()
        {
            Assert.Equal("Backup", this.appConfigService.GetDataStoreType());
        }
    }
}
