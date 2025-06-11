using AVA.VendorService.Contracts.Vendors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AVA.VendorService.Controllers
{
    public class VendorController : Controller, IVendorAppService
    {
        public static List<VendorDto> Vendors = new List<VendorDto>();
        [HttpPost("createVendor")]
        public Task<VendorDto> CreateVendor(VendorDto input)
        {
            input.VendorId = Guid.NewGuid();
            Vendors.Add(input);
            return Task.FromResult(input);
        }
        [HttpPost("deleteVendor")]

        public Task DeleteVendor(Guid vendorId)
        {
            if (Vendors.Any(x=>x.VendorId==vendorId))
            {
                Vendors.Remove(Vendors.FirstOrDefault(x => x.VendorId == vendorId));
            }
            return Task.CompletedTask;
        }
        [HttpGet("vendors")]
        public Task<List<VendorDto>> GetVendors()
        {
            return Task.FromResult(Vendors);
        }
        [HttpPut("updateVendor")]
        public Task<VendorDto> UpdateVendor(VendorDto input)
        {
           var v = Vendors.FirstOrDefault(x => x.VendorId == input.VendorId);
            if (v != null)
            {
                v.VendorName = input.VendorName;
                v.VendorCode = input.VendorCode;
            }
            return Task.FromResult(v);
        }        
    }
}
