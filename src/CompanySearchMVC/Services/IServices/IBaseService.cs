using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanySearchMVC.Models;

namespace CompanySearchMVC.Services.IServices
{
    public interface IBaseService
    {
        ApiResponse responseModel {get; set;}
        Task<T> SendAsync<T>(ApiRequest apiRequest); 
    }
}