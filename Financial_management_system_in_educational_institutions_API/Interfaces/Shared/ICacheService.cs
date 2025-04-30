namespace Financial_management_system_in_educational_institutions_API.Interfaces.Shared
{
    public interface ICacheService
    {
        void Set<T>(string key, T value, TimeSpan? expiration = null);
        T Get<T>(string key);
        void Update<T>(string key, T value, TimeSpan? expiration = null);
        void Remove(string key);

    }
}
