using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Models
{
    /// <summary>
    /// Class: RestaurantsView
    /// </summary>
    public class RestaurantsView
    {
        public SystemUser User { get; set; }
        public RestaurantFilter Filter { get; set; } 
        public List<Restaurant> SearchResult { set; get; }
        public string UserMessage { get; set; }
        public List<string> Hours { get; set; }
        public List<string> Locations { get; set; }
        public List<string> Countries { get; set; }

        
        private void setParameters()
        {
            List<string> list = new List<string>();
            for (int k = 1; k < 24; k++)
            {
                list.Add(k.ToString().PadLeft(2, '0') + ":00");
            }
            Hours = list;

            Locations = new List<string>() { "Victoria, BC", "Vancouver, BC" };
            Countries = new List<string>() { "Canada"};

        }

        public RestaurantsView(int id, RestaurantFilter filter)
        {
            var db = new DataPersistence.Database.UserMaintenance();
            User = db.GetOne(id);
            Filter = filter;
            SearchResult = new List<Restaurant>();
            UserMessage = "";
            setParameters();
        }
    }
}
