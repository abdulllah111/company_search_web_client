using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanySearchMVC.Models;
using CompanySearchMVC.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;

namespace CompanySearchMVC.Services
{
    public class BaseService : IBaseService
    {
        public IHttpClientFactory httpClientFactory;
        public IHttpContextAccessor httpContextAccessor;
        public ApiResponse responseModel { get; set; }

        public BaseService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) =>
        (this.httpClientFactory, this.httpContextAccessor, responseModel) = (httpClientFactory, httpContextAccessor, new());

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClientFactory.CreateClient("CompanySearchWevAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                var accessToken = await httpContextAccessor.HttpContext!.GetTokenAsync("access_token");
                if (accessToken == null)
                {
                    throw new ApplicationException("Access token is not available");
                }
                client.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                
                if(apiRequest.Data != null)
                {
                    message.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(apiRequest.Data),
                        System.Text.Encoding.UTF8, "application/json");
                }

                message.Method = apiRequest.ApiType switch
                {
                    ApiType.POST => HttpMethod.Post,
                    ApiType.PUT => HttpMethod.Put,
                    ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get,
                };

                HttpResponseMessage apiResponse = null;

                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var APIResponse = apiContent != null ? Newtonsoft.Json.JsonConvert.DeserializeObject<T>(apiContent) : default;
                return APIResponse!;
            }
            catch (Exception e){
                var dto = new ApiResponse{
                    ErrorMessages = new List<string>{Convert.ToString(e.Message)},
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T>(res);
                return APIResponse!; 
            }
        }
    }
}