using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPersistence.Models;

namespace DataPersistence.Database
{
    /// <summary>
    /// Class: UserMaintenance
    /// </summary>
    public class UserMaintenance : DataMaintenance<SystemUser>
    {
        private const string path = "systemusers.json";

        public UserMaintenance() : base(path)
        {


        }

        public override SystemUser GetOne(int id)
        {
            return _list.Find(x => x.Id == id);
        }

        public override void Add(SystemUser item)
        {
            item.Id = _list.Select(x => x.Id).Max() + 1;
            _list.Add(item);
            Save();
        }

        public override void Update(SystemUser item)
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
