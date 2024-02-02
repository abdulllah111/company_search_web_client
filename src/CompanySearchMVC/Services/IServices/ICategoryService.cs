using CompanySearchMVC.Models.Dto;

namespace CompanySearchMVC.Services.IServices
{
    public interface ICategoryService
    {
        Task<T> GetAllCategoriesAsync<T>();
        Task<T> GetCategoryByIdAsync<T>(Guid id);
        Task<T> CreateCategoryAsync<T>(CategoryDto categoryDto);
        Task<T> DeleteCategoryAsync<T>(Guid id);
        Task<T> GetCategoryByNameAsync<T>(string name);
    }
}