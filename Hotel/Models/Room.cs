using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int BedNum { get; set; }
        public int Prise { get; set; }
        public bool IsFree { get; set; }
        public int HotelId { get; set; }

    }
}
