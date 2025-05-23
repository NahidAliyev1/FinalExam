using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostCloudMVC.Bl.Exceptions
{
    public class CloudException:Exception
    {
        public CloudException():base("Default mesajdir")
        {
            
        }
        public CloudException(string errormessage):base(errormessage) 
        {
            
        }
    }
}
