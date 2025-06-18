using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVA.VendorService.Contracts.Vendors
{
    public interface IVendorAppService
    {
        Task<List<VendorDto>> Get();
        Task<VendorDto> Create(VendorDto input);
        Task<VendorDto> Update(VendorDto input);
        Task Delete(Guid vendorId);
    }
}
