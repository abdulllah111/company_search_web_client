using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanySearchMVC.Models;
using CompanySearchMVC.Models.Dto;
using CompanySearchMVC.Services.IServices;

namespace CompanySearchMVC.Services
{
    public class EventSerice : BaseService, IEventService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _categoryUrl;
        private string _basePath;

        public EventSerice(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _categoryUrl = configuration.GetValue<string>("ServiceUrls:CompanySearchWebAPI")!;
            _basePath = "/api/event";
        }

        public Task<T> CreateEventAsync<T>(CreateEventDto eventDto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Url = _categoryUrl + _basePath,
                Data = eventDto
            });
        }

        public Task<T> DeleteEventAsync<T>(Guid id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Url = _categoryUrl + _basePath + "/" + id,
            });
        }

        public Task<T> GetAllEventsAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = _categoryUrl + _basePath,
            });
        }

        public Task<T> GetEventByIdAsync<T>(Guid id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = _categoryUrl + _basePath + "/" + id,
            });
        }

        public Task<T> UpdateEventAsync<T>(UpdateEventDto eventDto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.PUT,
                Url = _categoryUrl + _basePath,
                Data = eventDto
            });
        }
        
        public Task<T> GetAllEventsByCategoryIdAsync<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllEventsByDateAsync<T>(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllEventsByDateRangeAndCategoryIdAsync<T>(DateTime startDate, DateTime endDate, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllEventsByDateRangeAndCompanyIdAsync<T>(DateTime startDate, DateTime endDate, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllEventsByDateRangeAndLocationIdAsync<T>(DateTime startDate, DateTime endDate, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllEventsByDateRangeAsync<T>(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllEventsByLocationIdAsync<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllEventsByUserIdAsync<T>(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}