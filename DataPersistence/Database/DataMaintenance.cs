using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Database
{
    /// <summary>
    /// Class: DataMaintenance
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataMaintenance<T> : IMaintenance<T>
    {
        const string _pathJsonFiles = "C:\\ABorjas\\eLearning\\Redlen\\DataPersistence\\Database\\";
        private readonly string _pathJsonFile;
        protected List<T> _list;

        public DataMaintenance(string path)
        {
            _pathJsonFile = path;
            var strData = File.ReadAllText(_pathJsonFiles + _pathJsonFile);
            _list = JsonConvert.DeserializeObject<List<T>>(strData);
        }

        public virtual void Add(T item)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return _list;
        }

        public virtual T GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            string contain = System.Text.Json.JsonSerializer.Serialize(_list);
            File.WriteAllText(_pathJsonFiles+_pathJsonFile, contain);
        }

        public virtual void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
