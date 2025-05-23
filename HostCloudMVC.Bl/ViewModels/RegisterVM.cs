using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostCloudMVC.Bl.ViewModels;

public record RegisterVM
{
    public string UserName { get; set; }
    public string EmailAdress { get; set; }
    public string Password { get; set; }

}
