using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ApiPlc
{
    public class RequestPlc
    {     
        public string? AddressPlc { get; set; }
        public string? Type { get; set; }
        public string? Value { get; set; }
    }
}
