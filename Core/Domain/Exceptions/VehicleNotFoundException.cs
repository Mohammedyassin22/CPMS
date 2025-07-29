using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public  class VehicleNotFoundException(string message) : NotFoundException($":{message} Not Found ")
    {
    }
}
