using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Profiles
{
    public class InvoiceProfile: AutoMapper.Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Domain.Models.Invoice, Shared.InvoiceDto>().ReverseMap();
        }
    }
}
