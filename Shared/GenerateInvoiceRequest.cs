using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class GenerateInvoiceRequest
    {
        public ParkingRecordDto Record { get; set; }
        public TariffsDto Tariff { get; set; }
    }

}
