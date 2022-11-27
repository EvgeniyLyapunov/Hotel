using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Hotels
    {
       public int Id { get; set; }
       public string CityId { get; set; }
       public string HotelName { get; set; }
       public List<Room> Rooms { get; set; }

    }
}
