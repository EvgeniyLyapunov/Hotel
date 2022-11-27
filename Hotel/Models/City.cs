using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public List<Hotels> HotelNames { get; set; }
    }
}
