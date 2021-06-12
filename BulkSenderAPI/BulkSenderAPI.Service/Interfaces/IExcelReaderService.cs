using BulkSenderAPI.Model.ServiceModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BulkSenderAPI.Service.Interfaces
{
    public interface IExcelReaderService
    {
        string CalculateCheckSum(IFormFile formFile);
        Task<ParsedPayrollSchedule> ParseFileAsync(IFormFile formFile);
    }
}