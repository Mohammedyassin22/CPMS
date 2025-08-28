using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class MultiMessageParkingServicesException
    {
      public const string message1 = "Plate number required";
    public const string message2 ="The car is already parked.";
    public const string message3 = "The car was parked successfully";
    }
}
