namespace Disco.AdminPanel.Presentation.Interfaces
{
    public interface ILocalStorageService
    {
        Task<T> GetItemAsync<T>(string key);
        Task<string> GetStringAsync(string key);
        Task SetItemAsync<T>(string key, T value);
        Task SetStringAsync(string key, string value);
        Task RemoveItemAsync(string key);
    }
}
