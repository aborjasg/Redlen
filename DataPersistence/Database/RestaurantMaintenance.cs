using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPersistence.Models;

namespace DataPersistence.Database
{
    /// <summary>
    /// Class: RestaurantMaintenance
    /// </summary>
    public class RestaurantMaintenance : DataMaintenance<Restaurant>
    {
        private const string path = "restaurants.json";

        public RestaurantMaintenance() : base (path)
        {           

        }

        public override Restaurant GetOne(int id)
        {            
            return _list.Find(x => x.Id == id);
        }

        public override void Add(Restaurant item)
        {
            item.Id = _list.Select(x => x.Id).Max() + 1;
            _list.Add(item);
            Save();
        }
        public override void Update(Restaurant item)
        {
            int index = _list.FindIndex(x => x.Id == item.Id);
            _list[index] = item;
            Save();
        }

        public override void Delete(int id)
        {
            var index = base._list.FindIndex(x => x.Id == id);
            if (index > -1)
            {
                _list.RemoveAt(index);
                Save();
            }            
        }
    }
}
