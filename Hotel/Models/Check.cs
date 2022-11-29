using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Check
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string DateOfPayment { get; set; }
        public string City { get; set; }
        public string HotelName { get; set; }
        public string RoomType { get; set; }
        public int People { get; set; }
        public int Nights { get; set; }
        public int AmountPayment { get; set; }
    }
}
