using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanySearchMVC.Models.Dto;

namespace CompanySearchMVC.Services.IServices
{
    public interface IEventService
    {
        Task<T> GetAllEventsAsync<T>();
        Task<T> GetEventByIdAsync<T>(Guid id);
        Task<T> CreateEventAsync<T>(CreateEventDto eventDto);
        Task<T> UpdateEventAsync<T>(UpdateEventDto eventDto);
        Task<T> DeleteEventAsync<T>(Guid id);
        Task<T> GetAllEventsByUserIdAsync<T>(Guid id);
        Task<T> GetAllEventsByCategoryIdAsync<T>(Guid id);
        Task<T> GetAllEventsByLocationIdAsync<T>(Guid id);
        Task<T> GetAllEventsByDateAsync<T>(DateTime date);
        Task<T> GetAllEventsByDateRangeAsync<T>(DateTime startDate, DateTime endDate);
        Task<T> GetAllEventsByDateRangeAndCategoryIdAsync<T>(DateTime startDate, DateTime endDate, Guid id);
        Task<T> GetAllEventsByDateRangeAndLocationIdAsync<T>(DateTime startDate, DateTime endDate, Guid id);
        Task<T> GetAllEventsByDateRangeAndCompanyIdAsync<T>(DateTime startDate, DateTime endDate, Guid id);
    }
}