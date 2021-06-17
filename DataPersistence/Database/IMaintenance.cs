using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Database
{
    /// <summary>
    /// Interface: IMaintenance
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMaintenance<T>
    {
        public abstract T GetOne(int id);

        public void Add(T item);

        public abstract void Update(T item);

        public abstract void Delete(int id);

        public List<T> GetAll();

        public void Save();
    }
}
