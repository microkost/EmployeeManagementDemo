using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloDemoData
{
    public interface IRepository<T> where T : class
    {        
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        ICollection<T> GetAll();
        T GetByID(int id);
        T SelectById(int id);
        void Save();
        void Dispose();
    }
}
