using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloDemoDomain
{
    public class SoloDepartment
    {
        [Key]
        public int IDdpm { get; set; }
        public string Name { get; set; }
        public ICollection<SoloEmployer> Employees { get; set; }        
    }
}
