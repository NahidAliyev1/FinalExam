using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostCloudMVC.Bl.ViewModels
{
    public record class LoginVM
    {
        public string EmailAdress { get; set; }
        public string Password { get; set; }


    }
}
