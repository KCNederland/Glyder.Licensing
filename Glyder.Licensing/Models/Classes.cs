using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Glyder.Licensing.Models
{
    public class xmlResult
    {
        public XmlDocument xml { get; set; }
        public bool success { get; set; }
        public Exception exception { get; set; }
    }

    public class Result
    {
        public bool success { get; set; }
        public Exception exception { get; set; }
    }
    

    public class glyderLicense
    {
        public GlyderStateServiceLicense glyderStateServiceLicense { get; set; }
        public GlyderSMILicense glyderSMILicense { get; set; }
        public GlyderWorkflowLicense glyderWorkflowLicense { get; set; }
        public GlyderWorkspaceLicense glyderWorkspaceLicense { get; set; }
    }

    public class GlyderStateServiceLicense
    {
        public static int applicationID = 1;
        public bool active { get; set; }
        public DateTime expirationDate { get; set; }
    }

    public class GlyderSMILicense
    {
        public static int applicationID = 2;
        public bool active { get; set; }
        public DateTime expirationDate { get; set; }
    }

    public class GlyderWorkflowLicense
    {
        public static int applicationID = 3;
        public bool active { get; set; }
        public DateTime expirationDate { get; set; }
        public bool concurrent { get; set; }
        public int concurrentUsers { get; set; }
    }

    public class GlyderWorkspaceLicense
    {
        public static int applicationID = 4;
        public bool active { get; set; }
        public DateTime expirationDate { get; set; }
    }
}
