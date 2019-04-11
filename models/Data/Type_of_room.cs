using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace models.Data
{
    public class Type_of_room : BaseModel
    {
        public string Name { get; set; }

        public IList<Room> rooms { get; set; }

        public Type_of_room()
        {
            rooms = new List<Room>();
        }
    }
}
