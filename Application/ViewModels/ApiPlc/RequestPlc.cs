using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ApiPlc
{
    public class RequestPlc
    {
        public required string Address{  get; set; }
        public object Value { get; set; } = "";
    }
}
