using Disco.AdminPanel.Presentation.Interfaces;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Disco.AdminPanel.Presentation.Service
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _jsRuntime;

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            return await _jsRuntime.InvokeAsync<T>("get", key);
        }

        public async Task<string> GetStringAsync(string key)
        {
            return await _jsRuntime.InvokeAsync<string>("get", key);
        }

        public async Task RemoveItemAsync(string key)
        {
            await _jsRuntime.InvokeVoidAsync("remove", key);
        }

        public async Task SetItemAsync<T>(string key, T value)
        {
            var json = JsonSerializer.Serialize(value);
            await _jsRuntime.InvokeVoidAsync("set", key, json);
        }

        public async Task SetStringAsync(string key, string value)
        {
            await _jsRuntime.InvokeVoidAsync("set", key, value);
        }
    }
}
