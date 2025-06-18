using AVA.VendorService.Contracts.Vendors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AVA.VendorService.Controllers
{
    [Route("api/vendors")]
    [ApiController]
    public class VendorController : Controller, IVendorAppService
    {
        public static List<VendorDto> Vendors = new List<VendorDto>();
        [HttpPost("create")]
        public Task<VendorDto> Create(VendorDto input)
        {
            input.VendorId = Guid.NewGuid();
            Vendors.Add(input);
            return Task.FromResult(input);
        }
        [HttpPost("delete")]
        public Task Delete(Guid vendorId)
        {
            if (Vendors.Any(x=>x.VendorId==vendorId))
            {
                Vendors.Remove(Vendors.FirstOrDefault(x => x.VendorId == vendorId));
            }
            return Task.CompletedTask;
        }
        [HttpGet]
        public Task<List<VendorDto>> Get()
        {
            return Task.FromResult(Vendors);
        }
        [HttpPut("update")]
        public Task<VendorDto> Update(VendorDto input)
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
