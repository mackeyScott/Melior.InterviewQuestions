namespace Melior.InterviewQuestion.Services.Configuration
{
    public interface IAppConfigService
    {
        string GetDataStoreType();
        bool DataStoreIsBackup();
    }
}
