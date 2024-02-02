using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace CompanySearchMVC.Services
{
    public class ApiService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiService(IHttpClientFactory httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetDataFromApi(string url)
        {
            var accessToken = await _httpContextAccessor.HttpContext!.GetTokenAsync("access_token");

            if (accessToken == null)
            {
                throw new ApplicationException("Access token is not available");
            }
            var client = _httpClient.CreateClient("CompanySearchWebAPI");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Ensure success status code

            return await response.Content.ReadAsStringAsync();
        }
    }
}