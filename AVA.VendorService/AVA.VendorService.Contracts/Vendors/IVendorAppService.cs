using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVA.VendorService.Contracts.Vendors
{
    public interface IVendorAppService
    {
        Task<List<VendorDto>> GetVendors();
        Task<VendorDto> CreateVendor(VendorDto input);
        Task<VendorDto> UpdateVendor(VendorDto input);
        Task DeleteVendor(Guid vendorId);
    }
}
