using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostCloudMVC.DAL.Models
{
    public class Cloud:BaseModel
    {
        public string ImgPath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
