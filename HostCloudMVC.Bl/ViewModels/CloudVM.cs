﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostCloudMVC.Bl.ViewModels;

public record CloudVM
{
    public IFormFile ImgFile { get; set; }

    
    public string Name { get; set; }
    public string Description { get; set; }
}
