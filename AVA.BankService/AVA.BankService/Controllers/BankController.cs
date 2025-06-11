using AVA.BankService.Contracts.Banks;
using Microsoft.AspNetCore.Mvc;

namespace AVA.BankService.Controllers
{
    public class BankController : Controller, IBankAppService
    {
        public static List<BankDto> Banks = new List<BankDto>();
        public BankController()
        {
            Banks.Add(new BankDto
            {
                Address = "123 Main St",
                CreatedAt = DateTime.UtcNow,
                Description = "Main branch of the bank",
                Email = "bank@bank.com",
                Id = Guid.NewGuid(),
                Name = "Main Bank",
                PhoneNumber = "123-456-7890",
                UpdatedAt = DateTime.UtcNow
            });
        }
        [HttpGet("api/banks")]
        public Task<List<BankDto>> GetAllBanksAsync()
        {
            return Task.FromResult(Banks);
        }
        [HttpGet("api/banks/{bankId}")]
        public async Task<BankDto> GetBankDetailsAsync(Guid bankId)
        {
            var bank = Banks.FirstOrDefault(b => b.Id == bankId);
            if (bank == null)
            {
                return null; // or throw an exception
            }
            return await Task.FromResult(bank);
        }
    }
}
