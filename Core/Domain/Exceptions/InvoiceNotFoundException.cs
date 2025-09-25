using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvoiceNotFoundException(int id) : NotFoundException($"Invoice with id {id} was not found.")
    {
    }
}
