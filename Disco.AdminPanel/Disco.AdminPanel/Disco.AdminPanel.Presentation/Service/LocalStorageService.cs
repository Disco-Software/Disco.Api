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
            return await _jsRuntime.InvokeAsync<T>("localStorage.getItem", key);
        }

        public async Task<string> GetStringAsync(string key)
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
        }

        public async Task RemoveItemAsync(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task SetItemAsync<T>(string key, T value)
        {
            var json = JsonSerializer.Serialize(value);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, json);
        }

        public async Task SetStringAsync(string key, string value)
        {
            await _jsRuntime.InvokeVoidAsync("set", key, value);
        }
    }
}
