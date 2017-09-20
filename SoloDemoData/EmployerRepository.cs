using SoloDemoDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloDemoData
{
    public class EmployerRepository : IRepository<SoloEmployer>, IDisposable
    {
        private CompanyContext ctx;
        private bool disposed = false;
        public EmployerRepository()
        {
            ctx = new CompanyContext();
        }        

        public void Delete(int id)
        {
            var emp = ctx.Employees.Find(id);
            ctx.Employees.Remove(emp);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
            }
            this.disposed = true;
        }

        public ICollection<SoloEmployer> GetAll()
        {
            //return ctx.Employees.ToList();
            return null;
        }

        public SoloEmployer GetByID(int id)
        {
            var emp = ctx.Employees.First(d => d.ID == id);
            return emp;
        }

        public void Insert(SoloEmployer obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public SoloEmployer SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SoloEmployer obj)
        {
            throw new NotImplementedException();
        }
    }
}
