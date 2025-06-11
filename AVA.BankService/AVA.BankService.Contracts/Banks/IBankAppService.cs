using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVA.BankService.Contracts.Banks
{
    public interface IBankAppService
    {
        /// <summary>
        /// Gets the bank details by its identifier.
        /// </summary>
        /// <param name="bankId">The identifier of the bank.</param>
        /// <returns>A task that represents the asynchronous operation, containing the bank details.</returns>
        Task<BankDto> GetBankDetailsAsync(Guid bankId);
        /// <summary>
        /// Gets a list of all banks.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing a list of banks.</returns>
        Task<List<BankDto>> GetAllBanksAsync();
    }
}
