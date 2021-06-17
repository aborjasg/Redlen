using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Models
{
    /// <summary>
    /// Class: Restaurant
    /// </summary>
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public double Distance { get; set; }
        
        public string Schedule { get; set; }
        public int Active { get; set; }

        public bool Favorite { get; set; }
        public bool Open { get; set; }


        public Restaurant()
        {
            Id = 0;
            Name = "";
            Address = "";
            City = "";
            Country = "";
            PostalCode = "";
            Distance = 0;
            Schedule = "";
            Active = 0;            
        }

        public bool isOpen(string time)
        {
            if (!string.IsNullOrEmpty(Schedule) && !string.IsNullOrEmpty(time))
            {
                string[] hours = Schedule.Split('-');
                string[] hour1 = hours[0].Split(':');
                string[] hour2 = hours[1].Split(':');
                string[] hour0 = time.Split(':');

                DateTime time1 = new DateTime().AddHours(Convert.ToDouble(hour1[0])).AddMinutes(Convert.ToDouble(hour1[1]));
                DateTime time2 = new DateTime().AddHours(Convert.ToDouble(hour2[0])).AddMinutes(Convert.ToDouble(hour2[1]));
                DateTime current = new DateTime().AddHours(Convert.ToDouble(hour0[0])).AddMinutes(Convert.ToDouble(hour0[1]));
                if (current >= time1 && current <= time2)
                    return true;
            }
            return false;
        }
    }
}
