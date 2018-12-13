using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlyderLicensing.Models
{
    public class xmlResult
    {
        public string xmlString { get; set; }
        public bool success { get; set; }
        public Exception exception { get; set; }
    }
}
