﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace models.Data
{
    public class Lighting : BaseModel
    {
        public int ElectricId { get; set; }
        public Electric Electric { get; set; }
    }
}
