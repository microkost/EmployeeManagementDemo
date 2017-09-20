using SoloDemoDomain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloDemoData
{
    //inspired by https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    public class DepartmentRepository : IRepository<SoloDepartment>, IDisposable
    {
        private CompanyContext ctx;
        private bool disposed = false;
        public DepartmentRepository()
        {
            ctx = new CompanyContext();
        }

        public SoloDepartment SelectById(int id)
        {
            return ctx.Departments.Find(id);
        }

        public void Delete(int id)
        {
            var dpm = ctx.Departments.Find(id);
            ctx.Departments.Remove(dpm);
        }

        public ICollection<SoloDepartment> GetAll()
        {
            return ctx.Departments.ToList();

            /*
             * System.InvalidOperationException occurred  HResult=0x80131509
               The property 'DepartmentId' cannot be configured as a navigation property. The property must be a valid entity type and the 
               property should have a non-abstract getter and setter. For collection properties the type must implement ICollection<T> 
               where T is a valid entity type. Source=<Cannot evaluate the exception source>  

             */
        }

        public SoloDepartment GetByID(int id)
        {
            var dpm = ctx.Departments.First(d => d.IDdpm == id);
            return dpm;
        }

        public void Insert(SoloDepartment obj)
        {
            ctx.Departments.Add(obj);
        }

        public void Update(SoloDepartment obj)
        {
            //problem when updating row with primary key! //Attach method could potentially help somebody
            //ctx.Entry(obj).State = EntityState.Modified; //entity framework default procedure
            //ctx.SaveChanges();

            ctx.Set<SoloDepartment>().AddOrUpdate(obj);

            //alternatively
            //Delete(obj.IDdpm);
            //Insert(obj);
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            ctx.SaveChanges();
        }
    }
}
