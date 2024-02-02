using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanySearchMVC.Models;
using CompanySearchMVC.Models.Dto;
using CompanySearchMVC.Services.IServices;

namespace CompanySearchMVC.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _categoryUrl;
        private string _basePath;

        public CategoryService(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _categoryUrl = configuration.GetValue<string>("ServiceUrls:CompanySearchWebAPI")!;
            _basePath = "/api/category";
        }

        public Task<T> GetAllCategoriesAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = _categoryUrl + _basePath,
            });
        }
        public Task<T> GetCategoryByIdAsync<T>(Guid id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = _categoryUrl + _basePath + "/" + id,
            });
        }
        public Task<T> CreateCategoryAsync<T>(CategoryDto categoryDto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Url = _categoryUrl + _basePath,
                Data = categoryDto
            });
        }

        public Task<T> DeleteCategoryAsync<T>(Guid id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Url = _categoryUrl + _basePath + "/" + id,
            });
        }
        public Task<T> GetCategoryByNameAsync<T>(string name)
        {
            throw new NotImplementedException();
        }
    }
}