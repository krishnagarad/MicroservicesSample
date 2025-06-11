using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVA.VendorService.Contracts.Vendors
{
    public class VendorDto
    {
        public Guid VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorCode { get; set; }
    }
}
