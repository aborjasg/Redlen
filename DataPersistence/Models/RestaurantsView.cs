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
        public RestaurantFilter Filter { get; set; } 
        public List<Restaurant> SearchResult { set; get; }
        public string UserMessage { get; set; }

        public RestaurantsView(RestaurantFilter filter)
        {
            Filter = filter;
            SearchResult = new List<Restaurant>();
            UserMessage = "";
        }
    }
}
