using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace models.Data
{
    public class Organization : BaseModel
    {
        public string Name { get; set; }

        public string Post { get; set; }

        public List<Room_rental> Room_rentals { get; set; }

        public List<ElectricsByOrganization> ElectricsByOrganization { get; set; }

        public Organization()
        {
            Room_rentals = new List<Room_rental>();
            ElectricsByOrganization = new List<ElectricsByOrganization>();
        }
    }
}
