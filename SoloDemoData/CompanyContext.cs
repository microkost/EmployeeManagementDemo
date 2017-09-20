using SoloDemoDomain;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace SoloDemoData
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base ("name=solodemo")
        {

        }

        public DbSet<SoloDepartment> Departments { get; set; }
        public DbSet<SoloEmployer> Employees { get; set; }        
    }
}
