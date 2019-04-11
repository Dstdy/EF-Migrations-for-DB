using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace models.Data
{
    public class Room_rental
    {
        public DateTime InputDate { get; set; }
        public DateTime OutputDate { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
