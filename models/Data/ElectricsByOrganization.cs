using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace models.Data
{
    public class ElectricsByOrganization
    {
        public int ElectricId { get; set; }
        public Electric Electric { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
