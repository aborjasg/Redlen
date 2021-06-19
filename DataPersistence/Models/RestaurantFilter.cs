using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Models
{
    /// <summary>
    ///  Class: RestaurantFilter
    /// </summary>
    public class RestaurantFilter
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string Hour { get; set; }
        public double Distance { get; set; }
        public bool Favorite { get; set; }
        public bool Open { get; set; }

        public RestaurantFilter(string name, string location, string country, string hour, double distance, bool favorite, bool open)
        {
            Name = name;
            Location = location;
            Country = country;
            Hour = hour;
            Distance = distance;
            Favorite = favorite;
            Open = open;
        }

        private bool isHour(string hour)
        {
            bool result = false;

            for (int k = 0; k < 24; k++)
            {
                string temp = k.ToString("00").PadLeft(2, '0') + ":00";
                if (temp == hour)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool isValid()
        {
            bool result = false;

            if (Name.Length <= 10 && Location.Length <= 50 && Country.Length <= 20 && isHour(Hour) && Distance >= 0 && Distance <= 100)
                result = true;
            else if (Name.Length > 10)
                throw new Exception("Keyword is too long (Max. 20 characters)");
            else if (Location.Length > 50)
                throw new Exception("Location is too long (Max. 50 characters)");
            else if (Country.Length > 20)
                throw new Exception("Country is too long (Max. 20 characters)");
            else if (!isHour(Hour))
                throw new Exception("Hour format is invalid (hh:mm)");

            return result;
        }

        

    }
}
