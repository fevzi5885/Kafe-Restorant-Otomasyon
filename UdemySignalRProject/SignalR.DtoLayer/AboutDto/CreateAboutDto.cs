﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.AboutDto
{
    public class CreateAboutDto
    {
        public string? ImgaeUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}