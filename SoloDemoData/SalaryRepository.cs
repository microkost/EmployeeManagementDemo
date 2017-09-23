using SoloDemoDomain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloDemoData
{
    public class SalaryRepository : IRepository<SoloSalary>, IDisposable
    {
        private CompanyContext ctx;
        private bool disposed = false;
        public SalaryRepository()
        {
            ctx = new CompanyContext();
        }
        public void Delete(int id)
        {
            var sal = ctx.Salaries.Find(id);
            ctx.Salaries.Remove(sal);
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

        public ICollection<SoloSalary> GetAll()
        {
            return ctx.Salaries.ToList();
        }

        public SoloSalary GetByID(int id)
        {
            var sal = ctx.Salaries.First(d => d.IDsal == id);
            return sal;
        }

        public void Insert(SoloSalary obj)
        {
            ctx.Salaries.Add(obj);
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public SoloSalary SelectById(int id)
        {
            return ctx.Salaries.Find(id);
        }

        public SoloSalary SelectByIdEmp(int idemp) //NOT WORKING WELL!
        {
            // Query for the SoloSalary entry with IDemp 
            var sal = ctx.Salaries.Where(b => b.IDemp == idemp).FirstOrDefault();
            return sal;
        }

        public void Update(SoloSalary obj)
        {
            ctx.Set<SoloSalary>().AddOrUpdate(obj);
        }
    }
}
