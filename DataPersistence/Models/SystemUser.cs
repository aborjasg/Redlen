using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Models
{
    /// <summary>
    /// Class: SystemUser
    /// </summary>
    public class SystemUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<int> Restaurant_Favorites { get; set; }
        public List<int> Restaurant_BlackList { get; set; }

        public SystemUser()
        {
            Id = 0;
            UserName = "";
            FullName = "";
            City = "";
            Country = "";
            Restaurant_Favorites = new List<int>();
            Restaurant_BlackList = new List<int>();
        }

        public void FavoriteAdd(int id)
        {
            AddValueToList(Restaurant_Favorites, id);
        }

        public void FavoriteRemove(int id)
        {
            RemoveValueToList(Restaurant_Favorites, id);
        }

        public void BlacklistAdd(int id)
        {
            AddValueToList(Restaurant_BlackList, id);
        }

        public void BlacklistRemove(int id)
        {
            RemoveValueToList(Restaurant_BlackList, id);
        }

        private void  AddValueToList(List<int> list, int id)
        {
            if (!list.Contains(id))
            {
                list.Add(id);
            }
        }
        private void RemoveValueToList(List<int> list, int id)
        {
            if (list.Contains(id))
            {
                list.Remove(id);
            }
        }
    }
}
